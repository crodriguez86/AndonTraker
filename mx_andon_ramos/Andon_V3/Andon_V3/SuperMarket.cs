using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MreaShared.BLL;
using MreaShared.Objects;
using System.Configuration;
using System.Net;

namespace Andon_V3
{
    public partial class SuperMarket : Form
    {
        private int smDivs;
        private List<int> listIdZones = new List<int>();
        private bool tabletMode;
        public SuperMarket()
        {
            InitializeComponent();
        }

        private void SuperMarket_Load(object sender, EventArgs e)
        {
            try
            {
                AndonBLL andonBLL = new AndonBLL();
                var andon = andonBLL.getAndonConfigByHostname(Dns.GetHostName());
                if (andon != null)
                {
                    if (andon.smDivs == null)
                        throw new Exception("Configuration has not value for parts per screen");
                    if (andon.smDivs.Value == 0)
                        throw new Exception("Configuration has not value for parts per screen");
                    smDivs = andon.smDivs.Value;
                    if (andon.config != null)
                    {
                        string[] configValues = andon.config.Split('_');
                        if (configValues != null)
                        {
                            string strIdApp = configValues[0];
                            if (Convert.ToInt32(EApps.SUPERMARKET) != Convert.ToInt32(strIdApp))
                                throw new Exception("This configuration is not for supermarket.");
                            string strConfig = configValues[1];
                            string[] strIdZones = strConfig.Split(',');
                            if (strIdZones != null)
                            {
                                this.Text = "Supermarket Zones : " + configValues[3];
                                for (int i = 0; i < strIdZones.Count(); i++)
                                {
                                    listIdZones.Add(Convert.ToInt32(strIdZones[i]));
                                }
                            }
                            string strTabletMode = configValues[2];
                            if (strTabletMode != null)
                            {
                                tabletMode = Convert.ToBoolean(strTabletMode);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ShowWarning(ex.Message);
            }
        }
        private void ShowWarning(string msg)
        {
            MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        private void ShowOK(string msg)
        {
            MessageBox.Show(msg, "Done!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private Panel buildPanel(string noPart, string fontColor, string backColor, int fontSize, int pos)
        {
            //panel1.Controls.Clear();
            int width = panel1.Width;
            int height = panel1.Height/smDivs;
            Panel panel = new Panel();
            panel.BackColor = Color.FromName(backColor);
            panel.Size = new Size(width, height);
            panel.Location = new Point(0, height*pos);
           
            //NUMERO DE PARTE
            if (noPart != null)
            {
                Label label3 = new Label();
                label3.Text = noPart;
                label3.ForeColor = Color.FromName(fontColor);
                label3.AutoSize = false;
                label3.TextAlign = ContentAlignment.MiddleCenter;
                label3.Width = width;
                label3.Height = height-10;
                label3.Font = new Font(this.Font.FontFamily, fontSize, FontStyle.Bold);
                panel.Controls.Add(label3);
            }

            return panel;
        }
        private Panel buildPanelMsg(string noPart, string fontColor, string backColor, int fontSize, int pos)
        {
            //panel1.Controls.Clear();
            int width = panel1.Width;
            int height = panel1.Height / 4;
            Panel panel = new Panel();
            panel.BackColor = Color.FromName(backColor);
            panel.Size = new Size(width, height);
            panel.Location = new Point(0, height * pos-100);

            //NUMERO DE PARTE
            if (noPart != null)
            {
                Label label3 = new Label();
                label3.Text = noPart;
                label3.ForeColor = Color.FromName(fontColor);
                label3.AutoSize = false;
                label3.TextAlign = ContentAlignment.MiddleCenter;
                label3.Width = width;
                label3.Height = height - 10;
                label3.Font = new Font(this.Font.FontFamily, fontSize, FontStyle.Bold);
                panel.Controls.Add(label3);
            }

            return panel;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            AndonBLL andonBLL = new AndonBLL();
            List<Andon> listAndonMsg = andonBLL.GetSuperMarketAndonByZones(listIdZones);
            Andon msgInformation = andonBLL.selectScreen(23);
            panel1.Controls.Clear();
            if (listAndonMsg != null)
            {
                int pos = 0;
                //Build panels
                foreach (var item in listAndonMsg)
                {
                    if (tabletMode)
                    {
                        item.font = item.font3 ?? item.font;
                    }
                    panel1.Controls.Add(buildPanel(item.message, "white","Blue", item.font, pos));
                    pos++;
                }
                if (listAndonMsg.Count() == 0)
                {
                    //Msg para supermercado peticion de Roberto Garcia >:/
                    if (msgInformation != null)
                    {
                        panel1.Controls.Add(buildPanelMsg(msgInformation.message, msgInformation.nameText, msgInformation.nameBackground, msgInformation.font, 2));
                    }
                    else
                    {
                        if (Convert.ToBoolean(ConfigurationManager.AppSettings["showTimeSMK"]))
                        {
                            int fontsize = Convert.ToInt32(ConfigurationManager.AppSettings["timeFontsizeSMK"]);
                            int tableModeFontsize = Convert.ToInt32(ConfigurationManager.AppSettings["timeFontsizeTMSMK"]);
                            if (tabletMode)
                            {
                                fontsize = tableModeFontsize;
                            }
                            panel1.Controls.Add(loadTime(fontsize));
                        }
                    }
                    
                }
            }
            else
            {
                ShowWarning("Ocurrio un problema al obtener numeros de parte de base de datos");
            }
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }
        private Panel loadTime(int fontsize)
        {
            
            int width = panel1.Width;
            int height = panel1.Height/3;
            Panel panel = new Panel();
            //panel.BackColor = Color.Gray;
            panel.Size = new Size(width, height);
            panel.Location = new Point(0, height);
            panel.BackColor = Color.FromArgb(100, 255, 255, 255);

            Label lblTime = new Label();
            //Initialize label time
            FontFamily family = new FontFamily("Consolas");
            lblTime.Text = DateTime.Now.ToString("hh:mm:ss");
            lblTime.Font = new Font(family, fontsize, FontStyle.Bold);
            lblTime.ForeColor = Color.Black;
            lblTime.TextAlign = ContentAlignment.MiddleCenter;
            lblTime.Visible = true;
            lblTime.Width = width;
            lblTime.Height = height;
            lblTime.AutoSize = false;
            panel.Controls.Add(lblTime);

            return panel;
        }
    }
}
