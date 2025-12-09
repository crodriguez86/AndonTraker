using MreaShared.BLL;
using MreaShared.Objects;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading;

namespace AndonTracker
{
    class Program
    {
        public static List<KeyValuePair<int, int>> arrayLinesTags = new List<KeyValuePair<int, int>>();
        public static List<KeyValuePair<int, int>> arrayParts = new List<KeyValuePair<int, int>>();
        public static List<int> arrayMsgNotIn = new List<int>();
        public static List<int> arrayEmailSentLv2 = new List<int>();
        public static List<int> arrayEmailSentLv3 = new List<int>();
        public static int resetCount = 0;
        public static int _limitResetCount = 0;
        public static bool _showLog;

        static System.Threading.Mutex singleton = new Mutex(true, "AndonTracker");

        static void Main(string[] args)
        {
            if (!singleton.WaitOne(TimeSpan.Zero, true))
            {
                //there is already another instance running!
                Console.WriteLine("Ya existe otra instacia corriendo!");
                Console.WriteLine("Presiona cualquier tecla para salir...");
                Console.ReadLine();
                return;

            }
            // Create a Timer object that knows to call our TimerCallback
            // method once every 1000 milliseconds.
            Console.WriteLine("Andon tracking corriendo: " + DateTime.Now);
            Console.WriteLine("Favor de no cerrar esta aplicacion ya que ");
            Console.WriteLine("se encarga de monitorear la actividad del andon en las lineas ");
            Console.WriteLine("e insertarla en base de datos para tener un historico. ");
            Console.WriteLine("Ademas de enviar correos.");
            Console.WriteLine(" ");
            _showLog = Convert.ToBoolean(ConfigurationManager.AppSettings["showlog"]);


            var autoEvent = new AutoResetEvent(false);

            if (_showLog)
                Console.WriteLine("Log activado...");
            Timer t = new Timer(TimerCallback, autoEvent, 0, 1000);
            // Wait for the user to hit <Enter>
            Console.ReadLine();
        }
        private static void TimerCallback(Object o)
        {
            AutoResetEvent obj = (AutoResetEvent)o;
            startAndonTracker();
            obj.Set();
        }
        private static void startAndonTracker()
        {
            bool _showLog = Convert.ToBoolean(ConfigurationManager.AppSettings["showlog"]);
            bool showCounter = Convert.ToBoolean(ConfigurationManager.AppSettings["showCounter"]);
            _limitResetCount = Convert.ToInt32(ConfigurationManager.AppSettings["limitResetCount"]);
            try
            {
                DBConnectionBLL objConn = new DBConnectionBLL();
                if (objConn.CheckConnection())
                {
                    CheckAndonStatus();
                    AndonBLL andonBLL = new AndonBLL();
                    List<Andon> list = andonBLL.selectAllTypesAndonTracker();
                    List<Andon> listBinary = andonBLL.getAllMsgsByBinaryPosition();
                    AndonHistoryBLL andonHistoryBLL = new AndonHistoryBLL();
                    if (list != null)
                    {
                        if (list.Any())
                        {
                            resetCount = 0;
                            foreach (var objAndon in list)
                            {
                                bool repeat = false;
                                repeat = CheckRepeatIdMsg(objAndon.idMessage);
                                if (!repeat)
                                {
                                    var newEntry = new KeyValuePair<int, int>(objAndon.idMessage, 0);
                                    arrayLinesTags.Add(newEntry);
                                    //si es el valor 9999 que no se inserte, este valor indica que se presiono boton de reset para finalizar tiempo de reparacion.
                                    if (objAndon.tagValue == 9999)
                                    {
                                        //Solo si esta activo el pin para ese mensaje
                                        AndonPinsBLL pinsBLL = new AndonPinsBLL();
                                        if (pinsBLL.CheckPinActiveByIdMsg(objAndon.idMessage))
                                        {
                                            AndonHistoryBLL historyBLL = new AndonHistoryBLL();
                                            //Buscar el ultimo andon por linea y tag
                                            var hist = historyBLL.GetLastHistoryByLineAndTag(objAndon.idLine, objAndon.idAndonValue);
                                            if (hist != null)
                                            {
                                                if (hist.date != null && hist.endDate != null)
                                                {
                                                    //Actualizar fecha de reparacion si ya tiene fecha de inicio y fecha de respuesta
                                                    if (historyBLL.UpdateEndRepairDate(hist.id))
                                                    {
                                                        if (_showLog)
                                                            Console.WriteLine("Se actualizo fecha de reparacion. ID MSG: " + objAndon.idMessage + " : " + DateTime.Now.ToString());
                                                    }
                                                    else
                                                    {
                                                        if (_showLog)
                                                            Console.WriteLine("NO se actualizo fecha de reparacion. ID MSG: " + objAndon.idMessage + " : " + DateTime.Now.ToString() + " Motivo: " + historyBLL._error);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        andonHistoryBLL.insertAndonHist(objAndon);
                                        //Send Mail
                                        MreaMailBLL mailBLL = new MreaMailBLL();
                                        mailBLL.Send(objAndon);
                                        if (_showLog)
                                            Console.WriteLine(objAndon.idMessage + " : " + objAndon.nameType + " : " + objAndon.nameLine + " : " + objAndon.message + " : " + DateTime.Now.ToString());
                                    }
                                }
                                if (arrayLinesTags.Exists(a => a.Key == objAndon.idMessage))
                                {
                                    arrayLinesTags.Remove(arrayLinesTags.First(x => x.Key.Equals(objAndon.idMessage)));
                                }
                                arrayLinesTags.Add(new KeyValuePair<int, int>(objAndon.idMessage, 0));
                                EmailByLevel(objAndon);
                            }
                            UpdateEndDatesHistory(3);
                        }
                        else
                        {
                            resetCount++;
                            UpdateEndDatesHistory(3);
                            //aumentar el contador
                        }
                    }
                    else
                    {
                        resetCount++;
                        UpdateEndDatesHistory(3);
                        //aumentar el contador
                    }

                    //=========================================SUPERMERCADO Y WARNINGS (MODO BINARIO)====================================================
                    if (listBinary != null)
                    {
                        if (listBinary.Any())
                        {
                            foreach (var objAndon in listBinary)
                            {
                                bool repeat = false;
                                repeat = CheckRepeatParts(objAndon.idMessage);
                                if (!repeat)
                                {
                                    var newEntry = new KeyValuePair<int, int>(objAndon.idMessage, 0);
                                    arrayParts.Add(newEntry);
                                    var objHist = andonHistoryBLL.GetLastHistoryByIdMsg(objAndon.idMessage);
                                    if (objHist != null)
                                    {
                                        if (objHist.endDate != null)
                                        {
                                            //Si tiene valor, si se inserta nuevo registro en BD
                                            andonHistoryBLL.insertAndonHist(objAndon);
                                            //Send Mail
                                            MreaMailBLL mailBLL = new MreaMailBLL();
                                            mailBLL.Send(objAndon);
                                            if (_showLog)
                                                Console.WriteLine(objAndon.idMessage + " : " + objAndon.nameType + " : " + objAndon.nameLine + " : " + objAndon.message + " : " + DateTime.Now.ToString());
                                        }
                                    }
                                    else
                                    {
                                        andonHistoryBLL.insertAndonHist(objAndon);
                                        //Send Mail
                                        MreaMailBLL mailBLL = new MreaMailBLL();
                                        mailBLL.Send(objAndon);
                                        if (_showLog)
                                            Console.WriteLine(objAndon.idMessage + " : " + objAndon.nameType + " : " + objAndon.nameLine + " : " + objAndon.message + " : " + DateTime.Now.ToString());
                                    }
                                }
                                EmailByLevel(objAndon);
                            }
                            //Revisar cuando ya no se detecte un numero de parte
                            int DataBaseCount = listBinary.Count();
                            int InternalCount = arrayParts.Count();
                            if (DataBaseCount != InternalCount)
                            {
                                //Buscar cual ya no coincide
                                foreach (var In in arrayParts)
                                {
                                    bool found = false;
                                    foreach (var Db in listBinary)
                                    {
                                        if (Db.idMessage == In.Key)
                                            found = true;
                                    }
                                    if (!found)
                                    {
                                        arrayMsgNotIn.Add(In.Key);
                                    }
                                }
                            }
                            //Actualizar fecha de entrega de partes que ya no se han detectado
                            UpdateEndDatesHistory(1);
                        }
                        else
                        {
                            //Actualizar fecha de entrega de partes porque no se detecto ningun dato en BD
                            UpdateEndDatesHistory(2);
                        }
                    }
                    else
                    {
                        //Actualizar fecha de entrega de partes porque no se detecto ningun dato en BD
                        UpdateEndDatesHistory(2);
                    }
                }
                else
                {
                    throw new Exception("No hay conexion a base de datos");
                }
                arrayMsgNotIn.Clear();
                if (showCounter)
                {
                    Console.WriteLine("-------------------------------------------------------");
                    foreach (var item in arrayLinesTags)
                    {
                        Console.WriteLine("Key >>" + item.Key + "<< Value >>" + item.Value + "<<");
                    }
                    Console.WriteLine("---------+++++++++++++++++++++++++++++++++++++++++++---");
                    foreach (var item in arrayParts)
                    {
                        Console.WriteLine("Key >>" + item.Key + "<< Value >>" + item.Value + "<<");
                    }
                }
            }
            catch (Exception ex)
            {
                if (_showLog)
                {
                    Console.WriteLine("-->Error: " + ex.ToString() + " Datetime: " + DateTime.Now);
                }
            }
        }

        private static bool CheckRepeatIdMsg(int idMsg)
        {
            bool repeat = false;
            if (idMsg == 0)
                return repeat;
            if (arrayLinesTags == null)
                return repeat;

            var findIdMsg = arrayLinesTags.Find(x => x.Key == idMsg);

            if (findIdMsg.Key != 0)
                return true;

            return repeat;
        }
        private static bool CheckRepeatParts(int idMsg)
        {
            bool repeat = false;
            if (idMsg == 0)
                return repeat;
            if (arrayParts == null)
                return repeat;

            var findPart = arrayParts.Find(x => x.Key == idMsg);
            if (findPart.Key != 0)
                return true;

            return repeat;
        }
        private static void CheckAndonStatus()
        {
            string emails = Convert.ToString(ConfigurationManager.AppSettings["emailsStatusReport"]);
            int hour = DateTime.Now.Hour;
            int minute = DateTime.Now.Minute;
            int second = DateTime.Now.Second;
            bool send = false;
            if (hour == 07 && minute == 00 && second == 00)
            {
                int days = Convert.ToInt32(ConfigurationManager.AppSettings["daysToUpdateAndon"] == null ? "0" : ConfigurationManager.AppSettings["daysToUpdateAndon"]);
                AndonHistoryBLL objBLL = new AndonHistoryBLL();
                //Se actualizan todos los andon_history atrasados a partir de los dias atras que vengan en la variable
                if (days < 0)
                    objBLL.UpdateAllOldAndonEnddates(days);
                send = true;
            }
            else if (hour == 15 && minute == 00 && second == 00)
            {
                send = true;
            }
            else if (hour == 22 && minute == 30 && second == 00)
            {
                send = true;
            }
            if (send)
            {
                MreaMailBLL mreaMailBLL = new MreaMailBLL();
                mreaMailBLL.CheckStatusAndon(emails);
            }
        }
        private static void UpdateEndDatesHistory(int i)
        {
            if (i == 3 && arrayLinesTags.Count() > 0)
            {
                AndonHistoryBLL andonHistoryBLL = new AndonHistoryBLL();
                List<int> listDelete = new List<int>();
                var listUpdate = new List<KeyValuePair<int, int>>();
                foreach (var item in arrayLinesTags)
                {
                    if (item.Value > _limitResetCount)
                    {
                        //Se agrega a la lista de por eliminar para despues ser eliminados
                        listDelete.Add(item.Key);
                    }
                    else
                    {
                        //Se incrementa contador
                        var newEntry = new KeyValuePair<int, int>(item.Key, item.Value + 1);
                        listUpdate.Add(newEntry);
                    }
                }
                //Se elimina lista de ID's de la lista
                foreach (var item in listDelete)
                {
                    arrayLinesTags.Remove(arrayLinesTags.First(x => x.Key.Equals(item)));
                    if (_showLog)
                        Console.WriteLine("OPT 3 Se elimina ID >> " + item + " : " + DateTime.Now.ToString());
                    //Se actualiza todo lo que haya quedado en el array de los id
                    var objHist = andonHistoryBLL.GetLastHistoryByIdMsg(item);
                    if (objHist != null)
                    {
                        //Solo se actualiza la fecha de respuesta si la fecha de reparacion no tiene valor
                        if (objHist.endRepairDate == null)
                        {
                            andonHistoryBLL.UpdateEndDate(new AndonHistory { id = objHist.id, endDate = DateTime.Now });
                        }
                    }

                    if (arrayEmailSentLv2.Contains(item))
                    {
                        arrayEmailSentLv2.Remove(item);
                    }
                    if (arrayEmailSentLv3.Contains(item))
                    {
                        arrayEmailSentLv3.Remove(item);
                    }
                }

                //Se actualizan contadores de la lista
                foreach (var item in listUpdate)
                {
                    arrayLinesTags.Remove(arrayLinesTags.First(x => x.Key.Equals(item.Key)));
                    arrayLinesTags.Add(item);
                    //Console.WriteLine("Se incrementa contador ID >>" + item.Key + " Contador >>" + item.Value);
                }
                //Console.WriteLine("--------------------------------------------------");
            }
            else if (i == 1)
            {

                //Se actualiza solo los que no fueron detectados
                foreach (var item in arrayMsgNotIn)
                {
                    AndonHistoryBLL andonHistoryBLL = new AndonHistoryBLL();
                    var objHist = andonHistoryBLL.GetLastHistoryByIdMsg(item);
                    if (objHist != null)
                    {
                        if (objHist.idType == 9 || objHist.idType == 11)//TODO: La condicion debe ser if is binary no por tipo
                        {
                            andonHistoryBLL.UpdateEndDate(new AndonHistory { id = objHist.id, endDate = DateTime.Now });
                            arrayParts.Remove(arrayParts.First(x => x.Key.Equals(item)));
                            if (_showLog)
                                Console.WriteLine("OPT 1 Se elimina Binary ID >> " + item + " : " + DateTime.Now.ToString());
                        }
                    }
                }
            }
            else if (i == 2)
            {
                List<int> listD = new List<int>();
                //Se actualiza todo lo que haya quedado en el array de los id
                foreach (var item in arrayParts)
                {
                    AndonHistoryBLL andonHistoryBLL = new AndonHistoryBLL();
                    var objHist = andonHistoryBLL.GetLastHistoryByIdMsg(item.Key);
                    if (objHist != null)
                    {
                        if (objHist.idType == 9 || objHist.idType == 11)//TODO: La condicion debe ser if is binary no por tipo
                        {
                            andonHistoryBLL.UpdateEndDate(new AndonHistory { id = objHist.id, endDate = DateTime.Now });
                            listD.Add(item.Key);
                        }
                    }
                }
                foreach (var item in listD)
                {
                    arrayParts.Remove(arrayParts.First(x => x.Key.Equals(item)));
                    if (_showLog)
                        Console.WriteLine("OPT 2 Se elimina Binary ID >> " + item + " : " + DateTime.Now.ToString());
                }
            }
        }
        private static TimeSpan GetTimeSpanFromTimeString(string str_time)
        {
            TimeSpan time;
            if (!TimeSpan.TryParse(str_time, out time))
            {
                time = new TimeSpan(0, 0, 0);
            }
            return time;
        }
        private static void EmailByLevel(Andon objAndon)
        {
            if (objAndon.timeElapsed != null)
            {
                var timeElapsed = GetTimeSpanFromTimeString(objAndon.timeElapsed);
                var timeLv2 = GetTimeSpanFromTimeString(objAndon.timeLimitLv2);
                var timeLv3 = GetTimeSpanFromTimeString(objAndon.timeLimitLv3);

                if (objAndon.timeLimitLv2 != null && objAndon.timeLimitLv3 != null)
                {//Cuando todos tienen valor
                    if (timeElapsed > timeLv2 && timeElapsed < timeLv3)
                    {
                        //Envia correo de nivel 2
                        if (!arrayEmailSentLv2.Contains(objAndon.idMessage))
                        {
                            //Se agrega en la lista de que ya se envio correo
                            arrayEmailSentLv2.Add(objAndon.idMessage);
                            MreaMailBLL mailBLL = new MreaMailBLL();
                            mailBLL.SendByLevel(objAndon, 2);
                            //Console.WriteLine("Correo nivel 2: array count: " + arrayEmailSentLv2.Count() + " andon count: " + list.Count());
                        }
                    }
                    else if (timeElapsed > timeLv3)
                    {
                        //Envia correo de nivel 3
                        if (!arrayEmailSentLv3.Contains(objAndon.idMessage))
                        {
                            //Se agrega en la lista de que ya se envio correo
                            arrayEmailSentLv3.Add(objAndon.idMessage);
                            MreaMailBLL mailBLL = new MreaMailBLL();
                            mailBLL.SendByLevel(objAndon, 3);
                            //Console.WriteLine("Correo nivel 3: array count: " + arrayEmailSentLv3.Count() + " andon count: " + list.Count());
                        }
                    }
                }
                else if (objAndon.timeLimitLv2 != null && objAndon.timeLimitLv3 == null)
                {//Cuando solo level 2 tiene valor
                    if (timeElapsed > timeLv2)
                    {
                        //Envia correo de nivel 2
                        if (!arrayEmailSentLv2.Contains(objAndon.idMessage))
                        {
                            //Se agrega en la lista de que ya se envio correo
                            arrayEmailSentLv2.Add(objAndon.idMessage);
                            MreaMailBLL mailBLL = new MreaMailBLL();
                            mailBLL.SendByLevel(objAndon, 2);
                            //Console.WriteLine("Correo nivel 2: array count: " + arrayEmailSentLv2.Count() + " andon count: " + list.Count());
                        }
                    }
                }
                else if (objAndon.timeLimitLv3 != null && objAndon.timeLimitLv2 == null)
                {//Cuando solo level 3 tiene valor
                    if (timeElapsed > timeLv3)
                    {
                        //Envia correo de nivel 3
                        if (!arrayEmailSentLv3.Contains(objAndon.idMessage))
                        {
                            //Se agrega en la lista de que ya se envio correo
                            arrayEmailSentLv3.Add(objAndon.idMessage);
                            MreaMailBLL mailBLL = new MreaMailBLL();
                            mailBLL.SendByLevel(objAndon, 3);
                            //Console.WriteLine("Correo nivel 3: array count: " + arrayEmailSentLv3.Count() + " andon count: " + list.Count());
                        }
                    }
                }
            }
        }
    }
}