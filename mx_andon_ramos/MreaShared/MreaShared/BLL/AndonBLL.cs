using System;
using System.Linq;
using MreaShared.DAL;
using MreaShared.Objects;
using System.IO;
using System.Collections.Generic;
using System.Net;
using System.Net.NetworkInformation;
using System.Configuration;
using System.Net.Sockets;
using System.Data.SqlClient;

namespace MreaShared.BLL
{
    public class AndonBLL
    {
        public Andon selectScreen(int idScreen)
        {
            try
            {
                Andon objAndon = new Andon();
                AndonDAL andonDAL = new AndonDAL();
                objAndon = andonDAL.selectScreen(idScreen);
                return objAndon;
            }
            catch (SqlException sqlex)
            {
                HandleException.MreaSqlException(sqlex);
                return null;
            }
            catch (Exception ex)
            {
                insertAndonError(ex);
                return null;
            }
        }
        public List<Andon> selectAllScreens()
        {
            try
            {
                List<Andon> list = new List<Andon>();
                AndonDAL andonDAL = new AndonDAL();
                list = andonDAL.selectAllScreens();
                return list;
            }
            catch (SqlException sqlex)
            {
                HandleException.MreaSqlException(sqlex);
                return null;
            }
            catch (Exception ex)
            {
                insertAndonError(ex);
                return null;
            }
        }
        public List<Andon> selectAllTypesAndonTracker()
        {
            try
            {
                List<Andon> list = new List<Andon>();
                AndonDAL andonDAL = new AndonDAL();
                list = andonDAL.selectAllTypesAndonTracker();
                return list;
            }
            catch (SqlException sqlex)
            {
                HandleException.MreaSqlException(sqlex);
                return null;
            }
            catch (Exception ex)
            {
                insertAndonError(ex);
                return null;
            }
        }
        public void testAndon(int idMsg)
        {
            try
            {
                int tagValue = 0;
                Andon obj = getMessage(idMsg);
                AndonPanelButtonBLL buttonBLL = new AndonPanelButtonBLL();
                //Se agrega soporte para activar valores binarios como supermercado.
                if (buttonBLL.MsgIsBinary(idMsg))
                {
                    tagValue = GetDecimalFromPosition(obj.tagValue);
                }
                else
                {
                    tagValue = obj.tagValue;
                }
                setAndonValue(obj.idAndonValue, tagValue);
            }
            catch (Exception ex)
            {
                insertAndonError(ex);
            }
        }
        public List<Andon> getLines()
        {
            try
            {
                List<Andon> list = new List<Andon>();
                AndonDAL andonDAL = new AndonDAL();
                list = andonDAL.getLines();
                return list;
            }
            catch (Exception ex)
            {
                insertAndonError(ex);
                return null;
            }
        }
        public List<Andon> getMessages(int idLine, int idType)
        {
            try
            {
                List<Andon> list = new List<Andon>();
                AndonDAL andonDAL = new AndonDAL();
                list = andonDAL.getMessages(idLine, idType);
                return list;
            }
            catch (Exception ex)
            {
                insertAndonError(ex);
                return null;
            }
        }
        public List<AndonPlc> getAndonPlc(AndonPlc obj)
        {
            try
            {
                List<AndonPlc> list = new List<AndonPlc>();
                AndonDAL andonDAL = new AndonDAL();
                list = andonDAL.getAndonPlc(obj);
                return list;
            }
            catch (Exception ex)
            {
                insertAndonError(ex);
                return null;
            }
        }
        public List<AndonValues> getAndonValues(AndonValues obj)
        {
            try
            {
                List<AndonValues> list = new List<AndonValues>();
                AndonDAL andonDAL = new AndonDAL();
                list = andonDAL.getAndonValues(obj);
                return list;
            }
            catch (Exception ex)
            {
                insertAndonError(ex);
                return null;
            }
        }
        public List<AndonType> getAndonTypes(AndonType obj)
        {
            try
            {
                List<AndonType> list = new List<AndonType>();
                AndonDAL andonDAL = new AndonDAL();
                list = andonDAL.getAndonTypes(obj);
                return list;
            }
            catch (Exception ex)
            {
                insertAndonError(ex);
                return null;
            }
        }
        public List<AndonFontsize> getAndonFonts(AndonFontsize obj)
        {
            try
            {
                List<AndonFontsize> list = new List<AndonFontsize>();
                AndonDAL andonDAL = new AndonDAL();
                list = andonDAL.getAndonFonts(obj);
                return list;
            }
            catch (Exception ex)
            {
                insertAndonError(ex);
                return null;
            }
        }
        public List<Andon> getAllMessages()
        {
            try
            {
                List<Andon> list = new List<Andon>();
                AndonDAL andonDAL = new AndonDAL();
                list = andonDAL.getAllMessages();
                return list;
            }
            catch (SqlException sqlex)
            {
                HandleException.MreaSqlException(sqlex);
                return null;
            }
            catch (Exception ex)
            {
                insertAndonError(ex);
                return null;
            }
        }
        public List<AndonValues> getSuperMarketValues(int zone)
        {
            try
            {
                List<AndonValues> list = new List<AndonValues>();
                AndonDAL andonDAL = new AndonDAL();
                list = andonDAL.getSuperMarketValues(zone);
                return list;
            }
            catch (SqlException sqlex)
            {
                HandleException.MreaSqlException(sqlex);
                return null;
            }
            catch (Exception ex)
            {
                insertAndonError(ex);
                return null;
            }
        }
        public Andon getMessageSuperMarket(int idAv, int position)
        {
            try
            {
                Andon objAndon = new Andon();
                AndonDAL andonDAL = new AndonDAL();
                objAndon = andonDAL.getMessageSuperMarket(idAv, position);
                return objAndon;
            }
            catch (SqlException sqlex)
            {
                HandleException.MreaSqlException(sqlex);
                return null;
            }
            catch (Exception ex)
            {
                insertAndonError(ex);
                return null;
            }
        }
        public List<Andon> getMsgsSuperMarket(int zone)
        {
            try
            {
                List<AndonValues> listAndonValues = getSuperMarketValues(zone);
                List<Andon> listAndonMsg = new List<Andon>();
                if (listAndonValues != null)
                {
                    foreach (var item in listAndonValues)
                    {
                        List<int> listPos = getBinaryPositionByDecimal(item.andonValue ?? 0);
                        if (listPos != null)
                        {
                            foreach (var item2 in listPos)
                            {
                                Andon objAndon = getMessageSuperMarket(item.idAv, item2);
                                if (objAndon != null)
                                {
                                    listAndonMsg.Add(objAndon);
                                }
                            }
                        }
                    }
                }
                return listAndonMsg;
            }
            catch (SqlException sqlex)
            {
                HandleException.MreaSqlException(sqlex);
                return null;
            }
            catch (Exception ex)
            {
                insertAndonError(ex);
                return null;
            }
        }
        public List<Andon> getTagNamesByLineAndType(int idLine, int idType)
        {
            try
            {
                List<Andon> list = new List<Andon>();
                AndonDAL andonDAL = new AndonDAL();
                list = andonDAL.getTagNamesByLineAndType(idLine, idType);
                return list;
            }
            catch (Exception ex)
            {
                insertAndonError(ex);
                return null;
            }
        }
        public Andon getMessage(int idMsg)
        {
            try
            {
                Andon objAndon = new Andon();
                AndonDAL andonDAL = new AndonDAL();
                objAndon = andonDAL.getMessage(idMsg);
                return objAndon;
            }
            catch (Exception ex)
            {
                insertAndonError(ex);
                return null;
            }
        }
        public void setAndonValue(int idAv, int tagValue)
        {
            try
            {
                AndonDAL andonDAL = new AndonDAL();
                andonDAL.testAndon(idAv, tagValue);
            }
            catch (Exception ex)
            {
                insertAndonError(ex);
            }
        }
        public int insertAndonHist(AndonHistory andon)
        {
            try
            {
                int id = 0;
                AndonDAL andonDAL = new AndonDAL();
                id = andonDAL.insertAndonHist(andon);
                return id;
            }
            catch (SqlException sqlex)
            {
                HandleException.MreaSqlException(sqlex);
                return 0;
            }
            catch (Exception ex)
            {
                insertAndonError(ex);
                return 0;
            }
        }
        public int insertAndon(Andon andon)
        {
            try
            {
                int id = 0;
                AndonDAL andonDAL = new AndonDAL();
                id = andonDAL.insertAndon(andon);
                return id;
            }
            catch (Exception ex)
            {
                insertAndonError(ex);
                return 0;
            }
        }
        public bool updateAndon(Andon andon)
        {
            try
            {
                if (andon.idMessage == 0)
                    throw new Exception("No se puede actualizar mensaje sin ID");

                bool valid;
                AndonDAL andonDAL = new AndonDAL();
                valid = andonDAL.updateAndon(andon);
                return valid;
            }
            catch (Exception ex)
            {
                insertAndonError(ex);
                return false;
            }
        }

        public void insertAndonError(Exception ex)
        {
            try
            {
                var andon = getAndonConfigByHostname(Dns.GetHostName());
                int? idApp = andon?.startApp;
                idApp = ConfigurationManager.AppSettings["appAndonTracker"] == null ? idApp : int.Parse(ConfigurationManager.AppSettings["appAndonTracker"]);
                AndonErrorLog log = new AndonErrorLog();
                log.message = TruncateLongString(ex.Message, 199);
                log.stackTrace = ex.StackTrace;
                log.ipAddress = GetIPAddress();
                log.deviceName = TruncateLongString(Dns.GetHostName(), 99);
                log.idApp = idApp ?? -1;
                AndonDAL andonDAL = new AndonDAL();
                andonDAL.inserAndonError(log);
            }
            catch (Exception exc)
            {
                SaveErrorTxt(exc);
            }
        }
        public string TruncateLongString(string str, int maxLength)
        {
            if (string.IsNullOrEmpty(str))
                return str;
            return str.Substring(0, Math.Min(str.Length, maxLength));
        }
        public void SaveErrorTxt(Exception ex)
        {
            string currentDir = Environment.CurrentDirectory;
            string logFilePath = currentDir + "\\";
            Console.WriteLine("===" + logFilePath);

            logFilePath = logFilePath + "AndonLog" + "-" + DateTime.Today.ToString("yyyyMMdd") + "." + "txt";
            using (StreamWriter writer = new StreamWriter(logFilePath, true))
            {
                writer.WriteLine("Message :" + ex.Message + "\n" + "Full message :" + ex.ToString() + "\n" + Environment.NewLine + "StackTrace :" + ex.StackTrace +
                   "" + Environment.NewLine + "Date :" + DateTime.Now.ToString());
                writer.WriteLine(Environment.NewLine + "-----------------------------------------------------------------------------" + Environment.NewLine);
            }
        }
        public string GetIPAddress()
        {
            string localIP;
            using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
            {
                socket.Connect("8.8.8.8", 65530);
                IPEndPoint endPoint = socket.LocalEndPoint as IPEndPoint;
                localIP = endPoint.Address.ToString();
            }
            return localIP;
        }
        public List<int> getBinaryPositionByDecimal(int value)
        {
            List<int> positions = new List<int>();
            int pos;
            string binaryText = Convert.ToString(value, 2);
            if(binaryText != null)
            {
                pos = binaryText.Length;
                for (int i = 0; i < binaryText.Length; i++)
                {
                    if (binaryText.ElementAt(i) == '1')
                    {
                        positions.Add(pos);
                    }
                    pos--;
                }
            }
            return positions;
        }
        public List<AndonApp> getAndonApp(AndonApp obj)
        {
            try
            {
                List<AndonApp> list = new List<AndonApp>();
                AndonDAL andonDAL = new AndonDAL();
                list = andonDAL.getAndonApp(obj);
                return list;
            }
            catch (Exception ex)
            {
                insertAndonError(ex);
                return null;
            }
        }
        public int insertAndonConfig(AndonConfig andon)
        {
            try
            {
                int id = 0;
                AndonDAL andonDAL = new AndonDAL();
                id = andonDAL.insertAndonConfig(andon);
                return id;
            }
            catch (Exception ex)
            {
                insertAndonError(ex);
                return 0;
            }
        }
        public bool updateAndonConfig(AndonConfig andon)
        {
            try
            {
                if (andon.idConfig == 0)
                    throw new Exception("No se puede actualizar configuracion sin ID");

                bool valid;
                AndonDAL andonDAL = new AndonDAL();
                valid = andonDAL.updateAndonConfig(andon);
                return valid;
            }
            catch (SqlException sqlex)
            {
                HandleException.MreaSqlException(sqlex);
                return false;
            }
            catch (Exception ex)
            {
                insertAndonError(ex);
                return false;
            }
        }
        public AndonConfig getAndonConfigByHostname(string hostname)
        {
            try
            {
                AndonConfig objAndon = new AndonConfig();
                AndonDAL andonDAL = new AndonDAL();
                objAndon = andonDAL.getAndonConfigByHostname(hostname);
                return objAndon;
            }
            catch (SqlException sqlex)
            {
                HandleException.MreaSqlException(sqlex);
                return null;
            }
            catch (Exception ex)
            {
                insertAndonError(ex);
                return null;
            }
        }
        public List<AndonValues> getWarningValues()
        {
            try
            {
                List<AndonValues> list = new List<AndonValues>();
                AndonDAL andonDAL = new AndonDAL();
                list = andonDAL.getSuperMarketValues(999);
                return list;
            }
            catch (SqlException sqlex)
            {
                HandleException.MreaSqlException(sqlex);
                return null;
            }
            catch (Exception ex)
            {
                insertAndonError(ex);
                return null;
            }
        }
        public List<Andon> getWarningMsgs()
        {
            try
            {
                List<AndonValues> listAndonValues = getWarningValues();
                List<Andon> listAndonMsg = new List<Andon>();
                if (listAndonValues != null)
                {
                    foreach (var item in listAndonValues)
                    {
                        List<int> listPos = getBinaryPositionByDecimal(item.andonValue ?? 0);
                        if (listPos != null)
                        {
                            foreach (var item2 in listPos)
                            {
                                Andon objAndon = getMessageSuperMarket(item.idAv, item2);
                                if (objAndon != null)
                                {
                                    listAndonMsg.Add(objAndon);
                                }
                            }
                        }
                    }
                }
                return listAndonMsg;
            }
            catch (SqlException sqlex)
            {
                HandleException.MreaSqlException(sqlex);
                return null;
            }
            catch (Exception ex)
            {
                insertAndonError(ex);
                return null;
            }
        }
        public bool updateAndonConfigLastConnection(AndonConfig andon)
        {
            try
            {
                if (string.IsNullOrEmpty(andon.hostname))
                    throw new Exception("Especifica hostname para actualizar conexion.");

                bool valid;
                AndonDAL andonDAL = new AndonDAL();
                valid = andonDAL.updateAndonConfigLastConnection(andon);
                return valid;
            }
            catch (SqlException sqlex)
            {
                HandleException.MreaSqlException(sqlex);
                return false;
            }
            catch (Exception ex)
            {
                insertAndonError(ex);
                return false;
            }
        }
        public List<AndonConfig> getAndonConfig(AndonConfig obj)
        {
            try
            {
                List<AndonConfig> list = new List<AndonConfig>();
                AndonDAL andonDAL = new AndonDAL();
                list = andonDAL.getAndonConfig(obj);
                return list;
            }
            catch (Exception ex)
            {
                insertAndonError(ex);
                return null;
            }
        }
        public bool deleteAndonConfig(int id)
        {
            try
            {
                AndonDAL andonDAL = new AndonDAL();
                bool valid = andonDAL.deleteAndonConfig(id);
                return valid;
            }
            catch (Exception ex)
            {
                insertAndonError(ex);
                return false;
            }
        }

        public List<Andon> getAllMsgsByBinaryPosition()
        {
            try
            {
                List<AndonValues> listAndonValues = getSuperMarketValues(1010);//EXTRAER LOS ANDON VALUES QUE SON BINARIOS
                List<Andon> listAndonMsg = new List<Andon>();
                if (listAndonValues != null)
                {
                    foreach (var item in listAndonValues)
                    {
                        List<int> listPos = getBinaryPositionByDecimal(item.andonValue ?? 0);
                        if (listPos != null)
                        {
                            foreach (var item2 in listPos)
                            {
                                Andon objAndon = getMessageSuperMarket(item.idAv, item2);
                                if (objAndon != null)
                                {
                                    listAndonMsg.Add(objAndon);
                                }
                            }
                        }
                    }
                }
                return listAndonMsg;
            }
            catch (SqlException sqlex)
            {
                HandleException.MreaSqlException(sqlex);
                return null;
            }
            catch (Exception ex)
            {
                insertAndonError(ex);
                return null;
            }
        }
        public bool deleteAndonMessage(int id)
        {
            try
            {
                AndonDAL andonDAL = new AndonDAL();
                bool valid = andonDAL.deleteAndonMessage(id);
                return valid;
            }
            catch (Exception ex)
            {
                insertAndonError(ex);
                return false;
            }
        }
        public List<AndonValues> GetSuperMarketValuesByZones(List<int> idZones)
        {
            try
            {
                List<AndonValues> list = new List<AndonValues>();
                AndonDAL andonDAL = new AndonDAL();
                list = andonDAL.GetSuperMarketValuesByZones(idZones);
                return list;
            }
            catch (SqlException sqlex)
            {
                HandleException.MreaSqlException(sqlex);
                return null;
            }
            catch (Exception ex)
            {
                insertAndonError(ex);
                return null;
            }
        }
        public List<Andon> GetSuperMarketAndonByZones(List<int> idZones)
        {
            try
            {
                List<AndonValues> listAndonValues = GetSuperMarketValuesByZones(idZones);
                List<Andon> listAndonMsg = new List<Andon>();
                if (listAndonValues != null)
                {
                    foreach (var item in listAndonValues)
                    {
                        List<int> listPos = getBinaryPositionByDecimal(item.andonValue ?? 0);
                        if (listPos != null)
                        {
                            foreach (var item2 in listPos)
                            {
                                Andon objAndon = getMessageSuperMarket(item.idAv, item2);
                                if (objAndon != null)
                                {
                                    listAndonMsg.Add(objAndon);
                                }
                            }
                        }
                    }
                }
                return listAndonMsg;
            }
            catch (SqlException sqlex)
            {
                HandleException.MreaSqlException(sqlex);
                return null;
            }
            catch (Exception ex)
            {
                insertAndonError(ex);
                return null;
            }
        }
        private int GetDecimalFromPosition(int position)
        {
            int decimalAndon = 1;

            for (int i = 1; i <= position; i++)
            {
                if (i == 1)
                {
                    decimalAndon = (decimalAndon * 1);
                }
                else
                {
                    decimalAndon = (decimalAndon * 2);
                }
            }

            return decimalAndon;
        }
    }
}
