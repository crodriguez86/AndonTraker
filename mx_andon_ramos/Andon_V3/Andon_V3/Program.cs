using MreaShared.BLL;
using MreaShared.Objects;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Andon_V3
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            DBConnectionBLL objConn = new DBConnectionBLL();
            if (objConn.CheckConnection())
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                AndonBLL andonBLL = new AndonBLL();
                AndonConfig andon = andonBLL.getAndonConfigByHostname(Dns.GetHostName());
                if (andon != null)
                {
                    if (andon.startAlways)
                    {
                        showApp(andon.startApp);
                    }
                    else
                    {
                        Application.Run(new StartUpConfig());
                    }
                }
                else
                {
                    Application.Run(new StartUpConfig());
                }
            }
            else
            {
                Application.Run(new StartUpConfig());
            }
        }
        static void showApp(int startApp)
        {
            switch ((EApps)startApp)
            {
                case EApps.PRODUCCION:
                    Application.Run(new Production());
                    break;
                case EApps.VISORGEN:
                    Application.Run(new Monitor());
                    break;
                case EApps.TEST:
                    Application.Run(new TestAndon());
                    break;
                case EApps.MATERIALES:
                    Application.Run(new Materials());
                    break;
                case EApps.ADMON:
                    Application.Run(new Login());
                    break;
                case EApps.SUPERMARKET:
                    Application.Run(new SuperMarket());
                    break;
                case EApps.PANELGROUP:
                    Application.Run(new PanelGroup());
                    break;
            }
        }
    }
}
