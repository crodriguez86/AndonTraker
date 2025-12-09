using MreaShared.BLL;
using MreaShared.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Andon_V3
{
    public partial class Monitor : Form
    {
        public List<KeyValuePair<int, int>> arrayLinesTags = new List<KeyValuePair<int, int>>();
        public List<Andon> listAndon = new List<Andon>();
        public bool error;
        public int resetCount = 0;
        public Monitor()
        {
            InitializeComponent();
        }

        private void Monitor_Load(object sender, EventArgs e)
        {
            try
            {
                setScreen();
                drawChart();
                drawChart2();
                this.Show();
            }
            catch (Exception ex)
            {
                error = true;
                MessageBox.Show(ex.Message, "Error de aplicacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                lblDate.Text = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
                if (!error)
                {
                    panel1.Controls.Clear();
                    panel1.Visible = false;
                    AndonBLL andonBLL = new AndonBLL();
                    List<Andon> list = andonBLL.selectAllScreens();
                    if (list != null)
                    {
                        if (list.Any())
                        {
                            int i = 0;
                            resetCount = 0;
                            panel1.Visible = true;
                            foreach (var objAndon in list)
                            {
                                i++;
                                panel1.Controls.Add(buildPanel(objAndon, i));
                                bool repeat = false;
                                repeat = CheckRepeatLineMsg(objAndon);
                                if (!repeat)
                                {
                                    var newEntry = new KeyValuePair<int, int>(objAndon.idLine, objAndon.idMessage);
                                    arrayLinesTags.Add(newEntry);
                                    listAndon.Insert(0,objAndon);
                                    if (listAndon.Count() > 5)
                                    {
                                        listAndon.RemoveAt(listAndon.Count - 1);
                                    }
                                }
                            }
                            buildQueue();
                        }
                        else
                        {
                            resetCount++;
                        }
                    }
                    else
                    {
                        resetCount++;
                    }
                    if (resetCount == 30)
                    {
                        arrayLinesTags = new List<KeyValuePair<int, int>>();
                    }
                }
                drawChart();
                drawChart2();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error de aplicacion", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        protected void setScreen()
        {
            Screen screen;
            AndonBLL andonBLL = new AndonBLL();
            var andon = andonBLL.getAndonConfigByHostname(System.Net.Dns.GetHostName());
            if (andon == null)
                throw new Exception("No hay informacion para configuracion");
            timer1.Interval = Convert.ToInt32(ConfigurationManager.AppSettings["timer"]);
            if (andon.startScreen == null)
                throw new Exception("No hay valor para iniciar pantalla");
            int screenRun = andon.startScreen.Value;
            if (screenRun > Screen.AllScreens.Count() - 1)
                throw new Exception("El identificador de pantalla esta fuera del rango de pantallas del sistema. \nIdentificador: " + screenRun);
            screen = Screen.AllScreens.ElementAt(screenRun);
            this.StartPosition = FormStartPosition.Manual;
            this.Location = screen.Bounds.Location;
        }

        private void drawChart()
        {
            //foreach (var series in chart1.Series)
            //{
            //    series.Points.Clear();
            //}
            chart1.Series.Clear();
            AndonHistoryBLL andonBLL = new AndonHistoryBLL();
            var list = andonBLL.getAndonTodayCount();
            if (list != null)
            {
                if (list.Any())
                {
                    foreach (var item in list)
                    {
                        //chart1.Series[item.type].Points.AddXY("Val", item.count);
                        chart1.Series.Add(item.type);
                        chart1.Series[item.type].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
                        chart1.Series[item.type].Points.AddY(item.count);
                        chart1.Series[item.type].ChartArea = "ChartArea1";
                        chart1.Series[item.type].IsValueShownAsLabel = true;
                        chart1.Series[item.type].Font = new Font(this.Font.FontFamily, 12, FontStyle.Bold);
                        chart1.Series[item.type].Legend = "Legend1";
                        chart1.Series[item.type]["PointWidth"] = "2";
                        chart1.Series[item.type].Color = Color.FromName(item.colorMonitor);
                    }
                }
            }
            chart1.ResetAutoValues();
        }
        private void drawChart2()
        {
            foreach (var series in chart2.Series)
            {
                series.Points.Clear();
            }
            AndonHistoryBLL andonBLL = new AndonHistoryBLL();
            var list = andonBLL.getAndonTodayCountByLine();
            if (list != null)
            {
                if (list.Any())
                {
                    int i = 0;
                    foreach (var item in list)
                    {
                        chart2.Series["LINEAS"].Points.AddXY(item.line, item.count);
                        i++;
                        if (i == 8)
                            break;
                    }
                }
            }
        }
        private Panel buildPanel(Andon objAndon, int pos)
        {
            int width = 900;
            int height = 600;
            int horizontal = pos == 1 ? 30 : width + 50;
            Panel panel = new Panel();
            panel.BackColor = Color.FromName(objAndon.nameBackground);
            panel.Size = new Size(width, height);
            panel.Location = new Point(horizontal, height / 10);

            //Tipo
            Label label1 = new Label();
            label1.Text = objAndon.nameType;
            label1.ForeColor = Color.FromName(objAndon.nameText);
            label1.AutoSize = false;
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.Width = width;
            label1.Height = height / 4;
            label1.Font = new Font(this.Font.FontFamily, objAndon.fontMon, FontStyle.Bold);
            label1.Location = new Point(0,15);
            panel.Controls.Add(label1);
            //Linea
            Label label2 = new Label();
            label2.Text = objAndon.nameLine;
            label2.ForeColor = Color.FromName(objAndon.nameText);
            label2.AutoSize = false;
            label2.TextAlign = ContentAlignment.MiddleCenter;
            label2.Width = width;
            label2.Height = height / 4;
            label2.Font = new Font(this.Font.FontFamily, 70, FontStyle.Bold);
            label2.Location = new Point(0, (height / 4) * 1);
            panel.Controls.Add(label2);
            //Estacion
            Label label3 = new Label();
            label3.Text = objAndon.message;
            label3.ForeColor = Color.FromName(objAndon.nameText);
            label3.AutoSize = false;
            label3.TextAlign = ContentAlignment.MiddleCenter;
            label3.Width = width;
            label3.Height = height / 4;
            label3.Font = new Font(this.Font.FontFamily, objAndon.font2.Value, FontStyle.Bold);
            label3.Location = new Point(0, (height / 4) * 2);
            panel.Controls.Add(label3);

            //Tiempo trancurrido
            //AndonHistoryBLL historyBLL = new AndonHistoryBLL();
            //var timeElapsed = historyBLL.GetTimeElapsedByIdMsg(objAndon.idMessage);
            Label lblTime = new Label();
            lblTime.Text = objAndon.timeElapsed ?? "NO DATA";
            lblTime.Font = new Font(this.Font.FontFamily, 70, FontStyle.Bold);
            lblTime.ForeColor = Color.FromName(objAndon.nameText);
            lblTime.TextAlign = ContentAlignment.MiddleCenter;
            lblTime.Visible = true;
            lblTime.Width = width;
            lblTime.Height = height / 4;
            lblTime.AutoSize = false;
            lblTime.Location = new Point(0, (height / 4) * 3);
            panel.Controls.Add(lblTime);

            return panel;
        }
        private void buildQueue()
        {
            if (listAndon != null)
            {
                if (listAndon.Any())
                {
                    pnlQueue.Controls.Clear();
                    int i = 0;
                    foreach (var item in listAndon)
                    {
                        Panel pnl = buildQueuePanel(item, i);
                        pnlQueue.Controls.Add(pnl);
                        i++;
                    }
                }
            }
        }
        private Panel buildQueuePanel(Andon objAndon, int pos)
        {
            int width = 300;
            int height = 150;
            int horizontal = pnlQueue.Width / 5 * pos + 10;
            Panel panel = new Panel();
            panel.BackColor = Color.FromName(objAndon.nameBackground);
            panel.Size = new Size(width, height);
            panel.Location = new Point(horizontal, 10);

            //Tipo
            Label label1 = new Label();
            label1.Text = objAndon.nameType;
            label1.ForeColor = Color.FromName(objAndon.nameText);
            label1.AutoSize = false;
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.Width = width;
            label1.Height = height / 3;
            label1.Font = new Font(this.Font.FontFamily, 17, FontStyle.Bold);
            label1.Location = new Point(0, 15);
            panel.Controls.Add(label1);
            //Linea
            Label label2 = new Label();
            label2.Text = objAndon.nameLine;
            label2.ForeColor = Color.FromName(objAndon.nameText);
            label2.AutoSize = false;
            label2.TextAlign = ContentAlignment.MiddleCenter;
            label2.Width = width;
            label2.Height = height / 3;
            label2.Font = new Font(this.Font.FontFamily, 17, FontStyle.Bold);
            label2.Location = new Point(0, (height / 3) * 1);
            panel.Controls.Add(label2);
            //Estacion
            Label label3 = new Label();
            label3.Text = objAndon.message;
            label3.ForeColor = Color.FromName(objAndon.nameText);
            label3.AutoSize = false;
            label3.TextAlign = ContentAlignment.MiddleCenter;
            label3.Width = width;
            label3.Height = height / 3;
            label3.Font = new Font(this.Font.FontFamily, objAndon.font3.Value, FontStyle.Bold);
            label3.Location = new Point(0, (height / 3) * 2);
            panel.Controls.Add(label3);
            return panel;
        }
        private bool CheckRepeatLineMsg(Andon andon)
        {
            bool repeat = false;
            if (andon == null)
                return repeat;
            if (arrayLinesTags == null)
                return repeat;

            var findLine = arrayLinesTags.FindAll(x => x.Key == andon.idLine);
            if (findLine == null)
                return repeat;
            var findMsg = findLine.Find(x => x.Value == andon.idMessage);
            if (findMsg.Value != 0)
                return true;

            return repeat;
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
    }
}
