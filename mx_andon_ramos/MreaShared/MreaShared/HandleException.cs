using MreaShared.BLL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MreaShared
{
    public static class HandleException
    {
        public static void SaveErrorTxt(Exception ex)
        {
            string currentDir = Environment.CurrentDirectory;
            string logFilePath = currentDir + "\\";
            Console.WriteLine("===" + logFilePath);

            logFilePath = logFilePath + "LogData" + "-" + DateTime.Today.ToString("yyyyMMdd") + "." + "txt";
            using (StreamWriter writer = new StreamWriter(logFilePath, true))
            {
                writer.WriteLine("Message :" + ex.Message + "\n" + "Full message :" + ex.ToString() + "\n" + Environment.NewLine + "StackTrace :" + ex.StackTrace +
                   "" + Environment.NewLine + "Date :" + DateTime.Now.ToString());
                writer.WriteLine(Environment.NewLine + "-----------------------------------------------------------------------------" + Environment.NewLine);
            }
        }
        public static void MreaSqlException(SqlException sqex)
        {
            AndonBLL andonBLL = new AndonBLL();
            if (sqex != null)
            {
                switch (sqex.Number)
                {
                    case -1:
                    case 2:
                    case 53:
                        SaveErrorTxt(sqex);
                        break;
                    default:
                        andonBLL.insertAndonError(sqex);
                        break;
                }
            }
        }
        public static void MreaException(Exception ex)
        {
            AndonBLL andonBLL = new AndonBLL();
            andonBLL.insertAndonError(ex);
        }
    }
}
