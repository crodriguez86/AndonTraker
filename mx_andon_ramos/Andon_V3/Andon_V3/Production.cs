using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MreaShared.BLL;
using MreaShared.Objects;
using System.Configuration;
using System.Net;
using System.Diagnostics;

namespace Andon_V3
{
    public partial class Production : Form
    {
        public int iActual = -1;
        public int iActualR = -1;
        public int idLine;
        public bool error;
        public int i = 0;
        public int random = 0;
        public Andon randomObj = null;
        public int idMsg;
        public int x = 0;//Contador para actualizar conexion de andon
        static Random rnd = new Random();
        public Production()
        {
            InitializeComponent();
            AndonNotify.BalloonTipText = "Andon is now running.";
            AndonNotify.BalloonTipTitle = "Andon";
            AndonNotify.BalloonTipIcon = ToolTipIcon.Info;
            AndonNotify.ShowBalloonTip(3000);
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                setScreen();
                clearValues();
                this.Show();
            }
            catch (Exception ex)
            {
                error = true;
                SendErrorEmail(ex);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                DBConnectionBLL objConn = new DBConnectionBLL();
                if (objConn.CheckConnection())
                {
                    if (!error)
                    {
                        AndonBLL andonBLL = new AndonBLL();
                        AndonHistoryBLL historyBLL = new AndonHistoryBLL();
                        Andon objAndon = null;
                        if (idLine == 0)
                        {
                            var andons = andonBLL.selectAllScreens();
                            if (andons != null)
                            {
                                if (andons.Count > 0)
                                {
                                    int r = rnd.Next(andons.Count);
                                    objAndon = andons[r];
                                }
                            }
                        }
                        else
                        {
                            objAndon = andonBLL.selectScreen(idLine);
                        }
                        if (x == 300)//Cada 5 minutos se actualiza conexion de andon
                        {
                            x = 0;
                            var objConfig = new AndonConfig();
                            objConfig.hostname = Dns.GetHostName();
                            objConfig.lastUpdate = DateTime.Now;
                            andonBLL.updateAndonConfigLastConnection(objConfig);
                        }
                        else
                        {
                            x++;
                        }
                        if (objAndon != null)
                        {
                            //Tiempo transcurrido desde que presionan el boton de algun Andon.
                            if (Convert.ToBoolean(ConfigurationManager.AppSettings["showTimePROD"]))
                            {
                                int fontsize = Convert.ToInt32(ConfigurationManager.AppSettings["timeFontsizePROD"]);
                                pnlTimeElapsed.Controls.Clear();
                                pnlTimeElapsed.Controls.Add(loadTime(fontsize, objAndon.nameText, objAndon.timeElapsed ?? "NO DATA"));
                            }
                            if (iActual != objAndon.idLine || iActualR != objAndon.tagValue)
                            {
                                this.BackColor = Color.FromName(objAndon.nameBackground);
                                pnlAndon.Controls.Clear();
                                pnlAndon.Controls.Add(buildPanel(objAndon));
                                this.Show();
                                this.TopMost = true;
                                iActual = objAndon.idLine;
                                iActualR = objAndon.tagValue;
                            }
                            else
                            {
                                if (Convert.ToBoolean(ConfigurationManager.AppSettings["forceBlinkScreen"]))
                                {
                                    int timelimit;
                                    timelimit = Convert.ToInt32(ConfigurationManager.AppSettings["timeForBlink"]);
                                    if (i == timelimit)
                                    {
                                        this.Visible = false;
                                        i = 0;
                                    }
                                    else
                                    {
                                        this.Visible = true;
                                        i++;
                                    }
                                }
                            }
                        }
                        else
                            clearValues();
                    }
                }
                else
                {
                    this.BackColor = Color.Black;
                    var objAndon = new Andon();
                    objAndon.nameType = "Error!";
                    objAndon.nameText = "White";
                    objAndon.nameBackground = "Black";
                    objAndon.fontProd = 120;
                    objAndon.nameLine = "";
                    objAndon.message = "Unable to connect to database.";
                    objAndon.font = 90;
                    pnlAndon.Controls.Clear();
                    pnlTimeElapsed.Controls.Clear();
                    pnlAndon.Controls.Add(buildPanel(objAndon));
                    this.Show();
                    this.TopMost = true;
                }
            }
            catch (Exception ex)
            {
                SendErrorEmail(ex);
                Timer1.Stop();
                MessageBox.Show(ex.Message, "Error de aplicacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Timer1.Start();
            }
        }
        protected void setScreen()
        {
            Screen screen;
            AndonBLL andonBLL = new AndonBLL();
            var andon = andonBLL.getAndonConfigByHostname(Dns.GetHostName());
            if (andon == null)
                throw new Exception("No hay informacion para configuracion");
           
            Timer1.Interval = Convert.ToInt32(ConfigurationManager.AppSettings["timer"]);
            idLine = andon.idLine ?? 0;
            if (idLine == 0)
                throw new Exception("Debe especificar un numero de pantalla valido");
            if (andon.startScreen == null)
                throw new Exception("No hay valor para iniciar pantalla");
            int screenRun = andon.startScreen.Value;
            this.Visible = false;
            if(screenRun > Screen.AllScreens.Count()-1)
                throw new Exception("El identificador de pantalla esta fuera del rango de pantallas del sistema. \nIdentificador: " + screenRun);
            screen = Screen.AllScreens.ElementAt(screenRun);
            this.StartPosition = FormStartPosition.Manual;
            this.Location = screen.Bounds.Location;
            this.BackColor = Color.White;
            this.WindowState = FormWindowState.Maximized;

            //Mostrar todos los Andon
            //Si en la opcion config esta el texto ShowAll, se mostraran todos los andon de produccion en una sola pantalla
            if (andon.config == "ShowAll")
            {
                idLine = 0;
            }

            //Nuevo para verificar si esta corriendo Andon
            x = 0;
            var objConfig = new AndonConfig();
            objConfig.hostname = Dns.GetHostName();
            objConfig.lastUpdate = DateTime.Now;
            andonBLL.updateAndonConfigLastConnection(objConfig);
        }
        protected void clearValues()
        {
            this.Hide();
            iActual = -1;
            iActualR = -1;
            i = 0;
        }

        private Panel loadTime(int fontsize, string fontColor, string timeElapsed)
        {

            int width = pnlTimeElapsed.Width;
            int height = pnlTimeElapsed.Height;
            Panel panel = new Panel();
            //panel.BackColor = Color.Gray;
            panel.Size = new Size(width, height);
            panel.Location = new Point(0, 0);
            panel.BackColor = Color.FromArgb(0, 255, 255, 255);

            Label lblTime = new Label();
            //Initialize label time
            lblTime.Text = timeElapsed;
            lblTime.Font = new Font(this.Font.FontFamily, fontsize, FontStyle.Bold);
            lblTime.ForeColor = Color.FromName(fontColor);
            lblTime.TextAlign = ContentAlignment.MiddleCenter;
            lblTime.Visible = true;
            lblTime.Width = width;
            lblTime.Height = height;
            lblTime.AutoSize = false;
            panel.Controls.Add(lblTime);

            return panel;
        }

        public void SendErrorEmail(Exception ex)
        {
            string emails = Convert.ToString(ConfigurationManager.AppSettings["emailsStatusReport"]);
            MreaMailBLL mreaMailBLL = new MreaMailBLL();
            mreaMailBLL.SendErrorEmail(emails, ex);
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

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private Panel buildPanel(Andon objAndon)
        {
            int width = pnlAndon.Width;
            int height = pnlAndon.Height;
            int thirdHeight = pnlAndon.Height /3;
            Panel panel = new Panel();
            panel.BackColor = Color.FromName(objAndon.nameBackground);
            panel.Size = new Size(width, height);
            panel.Location = new Point(0, height / 10);

            //Tipo
            Label label1 = new Label();
            label1.Text = objAndon.nameType;
            label1.ForeColor = Color.FromName(objAndon.nameText);
            label1.AutoSize = false;
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.Width = width;
            label1.Height = thirdHeight;
            label1.Font = new Font(this.Font.FontFamily, objAndon.fontProd, FontStyle.Bold);
            label1.Location = new Point(0, 15);
            panel.Controls.Add(label1);
            //Linea
            Label label2 = new Label();
            label2.Text = objAndon.nameLine;
            label2.ForeColor = Color.FromName(objAndon.nameText);
            label2.AutoSize = false;
            label2.TextAlign = ContentAlignment.MiddleCenter;
            label2.Width = width;
            label2.Height = thirdHeight;
            label2.Font = new Font(this.Font.FontFamily, objAndon.fontProd, FontStyle.Bold);
            label2.Location = new Point(0, (thirdHeight-15) * 1);
            panel.Controls.Add(label2);
            //Estacion
            Label label3 = new Label();
            label3.Text = objAndon.message;
            label3.ForeColor = Color.FromName(objAndon.nameText);
            label3.AutoSize = false;
            label3.TextAlign = ContentAlignment.MiddleCenter;
            label3.Width = width;
            label3.Height = thirdHeight;
            label3.Font = new Font(this.Font.FontFamily, objAndon.font, FontStyle.Bold);
            label3.Location = new Point(0, (thirdHeight-15) * 2);
            panel.Controls.Add(label3);

            return panel;
        }
    }
}
