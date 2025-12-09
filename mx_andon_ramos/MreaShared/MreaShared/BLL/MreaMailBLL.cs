using MreaShared.BLL;
using MreaShared.Objects;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace MreaShared.BLL
{
    public class MreaMailBLL
    {
        public string _error { get; set; }

        private void SendMail(MailMessage Message)
        {
            try
            {
                SmtpClient client = new SmtpClient();
                client.Host = Convert.ToString(ConfigurationManager.AppSettings["smtpHost"]); // Leer del config
                client.Port = 25;
                client.UseDefaultCredentials = false;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential(Convert.ToString(ConfigurationManager.AppSettings["mailfrom"]), Convert.ToString(ConfigurationManager.AppSettings["mailpass"]));
                client.Send(Message);
            }
            catch (SqlException sqlex)
            {
                HandleException.MreaSqlException(sqlex);
                _error = sqlex.Message;
            }
            catch (Exception ex)
            {
                HandleException.MreaException(ex);
                _error = ex.Message;
            }
        }
        private bool BuildAndonMail(Andon objAndon, List<Correos> listTo)
        {
            try
            {
                MailMessage mail = new MailMessage();
                string from = Convert.ToString(ConfigurationManager.AppSettings["mailfrom"]);
                from = from ?? "Slpassy.andonalerts@martinrea.com";
                MailAddress fromAddress = new MailAddress(from, "Andon Alert!");
                mail.From = fromAddress;
                foreach (var item in listTo)
                {
                    mail.To.Add(item.correo);
                }
                mail.Subject = "Andon Linea: " + objAndon.nameLine + " Tipo: " + objAndon.nameType + " Mensaje: " + objAndon.message;
                mail.Body = buildHTML(objAndon);
                mail.IsBodyHtml = true;
                SendMail(mail);
                return true;
            }
            catch (Exception ex)
            {
                AndonBLL andonBLL = new AndonBLL();
                andonBLL.insertAndonError(ex);
                return false;
            }
        }
        private string buildHTML(Andon objAndon)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<!DOCTYPE html>");
            sb.Append("<html lang='en'>");
            sb.Append("<head><meta charset='UTF-8'></head>");
            sb.Append(buildStyle(objAndon.nameText));
            sb.Append("<body><div style='text-align: center' class='border'><h1 class='title'>Notificacion Andon</h1>");
            sb.AppendFormat("<div class='date'><strong>Fecha:</strong> {0} </div><br>", DateTime.Now.ToShortDateString());
            sb.AppendFormat("<div class='date'><strong>Hora:</strong> {0} </div><br>", DateTime.Now.ToShortTimeString());
            sb.AppendFormat("<table bgcolor='{0}' style='background:{0}; text-align: center' class='square'><tr><td> <br><br><div class='separator'></div>", objAndon.nameBackground);
            sb.AppendFormat("<div class='text-white'>{0}</div><br>", objAndon.nameLine);
            sb.AppendFormat("<div class='text-white'>{0}</div><br>", objAndon.nameType);
            sb.AppendFormat("<div class='text-white'>{0}</div><br><br></td></tr></table></div></body>", objAndon.message);
            sb.Append("</html>");
            return sb.ToString();
        }
        private string buildStyle(string fontColor)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<style>");
            sb.Append(".square { width: 500px;height: 250px; margin: 0 auto; }");
            sb.Append(".text-white{ color: " + fontColor + ";font-family: Arial, Helvetica, sans-serif;font-weight: 800; font-size: 30px;}");
            sb.Append(".separator{padding-top: 20px;}");
            sb.Append(".title{font-family: Arial, Helvetica, sans-serif;font-weight: 700;}");
            sb.Append(".date{font-family: Arial, Helvetica, sans-serif; font-size: 24px;}");
            //sb.Append(".border{border: solid 10px rgb(3, 50, 121);padding: 5px;}");
            sb.Append("</style>");

            return sb.ToString();
        }
        public void Send(Andon objAndon)
        {
            bool showLog = Convert.ToBoolean(ConfigurationManager.AppSettings["showlog"]);
            int timeLevel2 = Convert.ToInt32(ConfigurationManager.AppSettings["timelevel2"]);
            int timeLevel3 = Convert.ToInt32(ConfigurationManager.AppSettings["timelevel3"]);
            CorreoBLL correoBLL = new CorreoBLL();
            List<Correos> list = null;
            List<Correos> list2 = null;
            list = correoBLL.getMailsByLevel(1, objAndon.idType);
            //list = new List<Correos>();
            //Correos cor = new Correos();
            //cor.correo = "juan.guerrero@martinrea.com";
            //list.Add(cor);

            //TODO: Realizar manejo de niveles dinamico!
            if (objAndon.idType == (int)ETypes.PDL)
            {//Si el andon detectado el por paro de linea de buscan correos por niveles.
                //Busco ultimo andon
                AndonHistoryBLL andonHistoryBLL = new AndonHistoryBLL();
                AndonHistory andon = andonHistoryBLL.GetLastAndonByLine(objAndon.idLine);
                if (andon != null)
                {
                    objAndon.nameType = andon.type;
                }
                if (objAndon.tagValue == timeLevel2)
                {
                    list2 = correoBLL.getMailsByLevel(2, andon.idType);
                }
                else if (objAndon.tagValue == timeLevel3)
                {
                    list2 = correoBLL.getMailsByLevel(3, 0);
                }
                if (list2 != null)
                {
                    if (list2.Any())
                    {
                        if (showLog)
                            Console.WriteLine("***Enviando correo de paro de linea...");
                        if (BuildAndonMail(objAndon, list2))
                        {
                            if (showLog)
                                Console.WriteLine("***Correo enviado correctamente.");
                        }
                        else
                        {
                            if (showLog)
                                Console.WriteLine("***Error al enviar correo. Revisar LOG en base de datos para mas detalles.");
                        }
                    }
                }
            }


            if (list != null)
            {
                if (list.Any())
                {
                    if (showLog)
                        Console.WriteLine("***Enviando correo...");
                    if (BuildAndonMail(objAndon, list))
                    {
                        if (showLog)
                            Console.WriteLine("***Correo enviado correctamente.");
                    }
                    else
                    {
                        if (showLog)
                            Console.WriteLine("***Error al enviar correo. Revisar LOG en base de datos para mas detalles.");
                    }
                }
            }
        }
        public void SendByLevel(Andon objAndon, int level)
        {
            bool showLog = Convert.ToBoolean(ConfigurationManager.AppSettings["showlog"]);
            CorreoBLL correoBLL = new CorreoBLL();
            List<Correos> list2 = null;
            //Si es nivel 3 se manda un correo a todos los del nivel 3 sin importar el departamento
            objAndon.idType = level == 3 ? 0 : objAndon.idType;
            list2 = correoBLL.getMailsByLevel(level, objAndon.idType);
            //list2 = new List<Correos>();
            //Correos cor = new Correos();
            //cor.correo = "juan.guerrero@martinrea.com";
            //list2.Add(cor);
            if (list2 != null)
            {
                if (list2.Any())
                {
                    objAndon.message = objAndon.message + "<br/> Mas de " + objAndon.timeElapsed + " sin atender llamado.";
                    if (showLog)
                        Console.WriteLine("***Enviando correo por exceso de tiempo. Nivel:" + level + " Tiempo transcurrido: " + objAndon.timeElapsed);
                    if (BuildAndonMail(objAndon, list2))
                    {
                        if (showLog)
                            Console.WriteLine("***Correo por exceso de tiempo. Enviado correctamente.");
                    }
                    else
                    {
                        if (showLog)
                            Console.WriteLine("***Error al enviar correo por exceso de tiempo. Revisar LOG en base de datos para mas detalles.");
                    }
                }
            }
        }
        public bool CheckStatusAndon(string emails)
        {
            bool valid = true;
            AndonBLL andonBLL = new AndonBLL();
            AndonConfig andonConfig = new AndonConfig();
            var list = andonBLL.getAndonConfig(andonConfig);
            if (list != null)
            {
                if (list.Any())
                {
                    var HTML = buildHTMLStatusAndon(list);
                    try
                    {
                        if (string.IsNullOrEmpty(emails))
                            throw new Exception("La lista de correos esta vacia");
                        var listEmails = emails.Split(';');
                        if (listEmails == null)
                            throw new Exception("La lista de correo esta vacia.");
                        if (listEmails.Count() == 0)
                            throw new Exception("La lista de correo esta vacia.");
                        MailMessage mail = new MailMessage();
                        string from = Convert.ToString(ConfigurationManager.AppSettings["mailfrom"]);
                        from = from ?? "Slpassy.andonalerts@martinrea.com";
                        MailAddress fromAddress = new MailAddress(from, "Andon Status!");
                        mail.From = fromAddress;
                        for (int i = 0; i < listEmails.Count(); i++)
                        {
                            mail.To.Add(listEmails[i]);
                        }

                        mail.Subject = "Estatus";
                        mail.Body = HTML;
                        mail.IsBodyHtml = true;
                        SendMail(mail);
                        return true;
                    }
                    catch (Exception ex)
                    {
                        andonBLL.insertAndonError(ex);
                        return false;
                    }

                }
            }
            return valid;
        }
        public string buildHTMLStatusAndon(List<AndonConfig> list)
        {
            MreaLineBLL mreaLineBLL = new MreaLineBLL();
            MreaLine mreaLine = new MreaLine();
            StringBuilder sb = new StringBuilder();
            sb.Append("<!DOCTYPE html>");
            sb.Append("<html lang='en'>");
            sb.Append("<head><meta charset='UTF-8'></head>");
            sb.Append("<style> .style-request{ font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; table-layout: fixed; } table tr{ background-color: rgb(220, 220, 220);} .bg-color{ background-color: rgb(250, 252, 252); border: 1px solid black;}</style>");
            sb.Append("<body><table align='center' class='style - request'><tr><td colspan='4'><h1><center>Estatus Andon</center></h1></td></tr><tr><td><b>HostName</b></td><td><b>Linea</b></td><td><b>Ultima conexion</b></td><td><b>Estatus</b></td></tr>");

            foreach (var item in list)
            {
                mreaLine.idLine = item.idLine ?? 0;
                var line = mreaLineBLL.getMreaLine(mreaLine);
                sb.Append("<tr>");
                sb.AppendFormat("<td>{0}</td>", item.hostname);
                sb.AppendFormat("<td>{0}</td>", line.First().name);
                sb.AppendFormat("<td>{0}</td>", item.lastUpdate?.ToString());
                if (item.lastUpdate != null)
                {
                    if (item.lastUpdate.Value.AddMinutes(20) > DateTime.Now)
                    {
                        sb.AppendFormat("<td style='background-color: rgb(43, 255, 0)'>RUNNING</td>");
                    }
                    else
                    {
                        sb.AppendFormat("<td style='background-color: red'>NOT RUNNING</td>");
                    }

                }
                else
                {
                    sb.AppendFormat("<td>NOT SET</td>");
                }

                sb.Append("</tr>");
            }

            sb.Append("</table></body></html>");
            return sb.ToString();
        }
        public bool SendErrorEmail(string emails, Exception ex)
        {
            bool valid = true;
            var HTML = ex.ToString();
            AndonBLL andonBLL = new AndonBLL();
            try
            {
                if (string.IsNullOrEmpty(emails))
                    throw new Exception("La lista de correos esta vacia");
                var listEmails = emails.Split(';');
                if (listEmails == null)
                    throw new Exception("La lista de correo esta vacia.");
                if (listEmails.Count() == 0)
                    throw new Exception("La lista de correo esta vacia.");
                MailMessage mail = new MailMessage();
                string from = Convert.ToString(ConfigurationManager.AppSettings["mailfrom"]);
                from = from ?? "Slpassy.andonalerts@martinrea.com";
                MailAddress fromAddress = new MailAddress(from, "Andon Error!");
                mail.From = fromAddress;
                for (int i = 0; i < listEmails.Count(); i++)
                {
                    mail.To.Add(listEmails[i]);
                }
                string hostname = Dns.GetHostName() ?? "Vacio";
                mail.Subject = hostname + " Error: " + ex.Message;
                mail.Body = HTML;
                mail.IsBodyHtml = true;
                SendMail(mail);
                valid = true;
            }
            catch (Exception ex2)
            {
                andonBLL.insertAndonError(ex2);
                valid = false;
            }
            return valid;
        }
    }
}