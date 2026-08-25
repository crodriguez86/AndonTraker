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
                LayoutCharts();
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

        private void Monitor_Resize(object sender, EventArgs e)
        {
            LayoutCharts();
            if (label1 != null && panel2 != null)
            {
                label1.Location = new Point((panel2.ClientSize.Width - label1.Width) / 2, (panel2.ClientSize.Height - label1.Height) / 2);
            }
        }

        private void LayoutCharts()
        {
            if (chart1 != null && chart2 != null && panel1 != null)
            {
                int topMargin = 120;
                int sideMargin = 30;
                int bottomMargin = pnlQueue.Height + 20;
                int availableWidth = this.ClientSize.Width - (sideMargin * 3);
                int availableHeight = this.ClientSize.Height - topMargin - bottomMargin;

                int chartWidth = availableWidth / 2;
                chart1.Location = new Point(sideMargin, topMargin);
                chart1.Size = new Size(chartWidth, Math.Max(300, availableHeight));

                chart2.Location = new Point(sideMargin * 2 + chartWidth, topMargin);
                chart2.Size = new Size(chartWidth, Math.Max(300, availableHeight));
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                lblDate.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                if (!error)
                {
                    panel1.Controls.Clear();
                    panel1.Visible = false;
                    AndonBLL andonBLL = new AndonBLL();
                    List<Andon> list = andonBLL.selectAllScreens();
                    if (list != null && list.Any())
                    {
                        int i = 0;
                        resetCount = 0;
                        panel1.Visible = true;
                        int totalCards = list.Count;
                        foreach (var objAndon in list)
                        {
                            i++;
                            panel1.Controls.Add(buildPanel(objAndon, i, totalCards));
                            bool repeat = CheckRepeatLineMsg(objAndon);
                            if (!repeat)
                            {
                                var newEntry = new KeyValuePair<int, int>(objAndon.idLine, objAndon.idMessage);
                                arrayLinesTags.Add(newEntry);
                                listAndon.Insert(0, objAndon);
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
            chart1.Series.Clear();
            AndonHistoryBLL andonBLL = new AndonHistoryBLL();
            var list = andonBLL.getAndonTodayCount();
            if (list != null && list.Any())
            {
                foreach (var item in list)
                {
                    var series = chart1.Series.Add(item.type);
                    series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
                    series.Points.AddY(item.count);
                    series.ChartArea = "ChartArea1";
                    series.IsValueShownAsLabel = true;
                    series.Font = new Font("Segoe UI", 13, FontStyle.Bold);
                    series.Legend = "Legend1";
                    series["PointWidth"] = "0.6";
                    series.Color = ResolveColor(item.colorMonitor, Color.FromArgb(59, 130, 246));
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
            if (list != null && list.Any())
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

        private Color ResolveColor(string colorName, Color fallback)
        {
            if (string.IsNullOrEmpty(colorName)) return fallback;
            try
            {
                Color c = Color.FromName(colorName);
                if (c.A != 0 && (c.R != 0 || c.G != 0 || c.B != 0 || colorName.Equals("Black", StringComparison.OrdinalIgnoreCase)))
                    return c;
                if (colorName.StartsWith("#"))
                    return ColorTranslator.FromHtml(colorName);
            }
            catch { }
            return fallback;
        }

        private Color GetAutoContrast(Color bg)
        {
            double luminance = (0.299 * bg.R + 0.587 * bg.G + 0.114 * bg.B);
            return luminance > 140 ? Color.FromArgb(15, 23, 42) : Color.White;
        }

        private Panel buildPanel(Andon objAndon, int pos, int totalCards)
        {
            int total = Math.Max(1, totalCards);
            int availableWidth = panel1.ClientSize.Width;
            int availableHeight = panel1.ClientSize.Height;

            int cardWidth, cardHeight, horizontal, vertical;
            if (total == 1)
            {
                cardWidth = Math.Min(1400, availableWidth - 80);
                cardHeight = Math.Max(400, availableHeight - 60);
                horizontal = (availableWidth - cardWidth) / 2;
                vertical = (availableHeight - cardHeight) / 2;
            }
            else
            {
                int spacing = 30;
                cardWidth = Math.Max(400, (availableWidth - (spacing * (total + 1))) / total);
                cardHeight = Math.Max(400, availableHeight - 60);
                horizontal = spacing + (pos - 1) * (cardWidth + spacing);
                vertical = 30;
            }

            Panel panel = new Panel();
            Color bgColor = ResolveColor(objAndon.nameBackground, Color.FromArgb(220, 38, 38));
            Color txtColor = !string.IsNullOrEmpty(objAndon.nameText) ? ResolveColor(objAndon.nameText, GetAutoContrast(bgColor)) : GetAutoContrast(bgColor);

            panel.BackColor = bgColor;
            panel.Size = new Size(cardWidth, cardHeight);
            panel.Location = new Point(horizontal, vertical);

            // 1. Tag Superior: Tipo de Soporte
            int headerH = Math.Max(50, (int)(cardHeight * 0.15));
            Label lblType = new Label();
            lblType.Text = "&#9679;  " + (objAndon.nameType ?? "").ToUpper();
            lblType.ForeColor = txtColor;
            lblType.BackColor = Color.FromArgb(45, 0, 0, 0);
            lblType.TextAlign = ContentAlignment.MiddleCenter;
            lblType.Dock = DockStyle.Top;
            lblType.Height = headerH;
            int fontTypeSize = Math.Max(18, Math.Min(34, (int)(cardHeight * 0.045)));
            lblType.Font = new Font("Segoe UI", fontTypeSize, FontStyle.Bold);
            panel.Controls.Add(lblType);

            // 2. Temporizador Inferior (Badge Digital)
            int timerH = Math.Max(70, (int)(cardHeight * 0.22));
            Panel pnlTimer = new Panel();
            pnlTimer.Dock = DockStyle.Bottom;
            pnlTimer.Height = timerH;
            pnlTimer.BackColor = Color.FromArgb(60, 0, 0, 0);

            Label lblTime = new Label();
            lblTime.Text = (objAndon.timeElapsed != null) ? " " + objAndon.timeElapsed : "ACTIVO";
            lblTime.ForeColor = txtColor;
            lblTime.BackColor = Color.Transparent;
            lblTime.Dock = DockStyle.Fill;
            lblTime.TextAlign = ContentAlignment.MiddleCenter;
            int fontTimerSize = Math.Max(26, Math.Min(60, (int)(cardHeight * 0.08)));
            lblTime.Font = new Font("Segoe UI", fontTimerSize, FontStyle.Bold);
            pnlTimer.Controls.Add(lblTime);
            panel.Controls.Add(pnlTimer);

            // 3. Área Central (Línea y Estación)
            int remainingH = cardHeight - headerH - timerH;
            
            // Estación / Mensaje (Mitad inferior del centro)
            Label lblMsg = new Label();
            lblMsg.Text = objAndon.message ?? "";
            lblMsg.ForeColor = txtColor;
            lblMsg.BackColor = Color.Transparent;
            lblMsg.TextAlign = ContentAlignment.MiddleCenter;
            lblMsg.Location = new Point(0, headerH + (remainingH / 2));
            lblMsg.Size = new Size(cardWidth, remainingH / 2);
            int fontMsgSize = Math.Max(18, Math.Min(40, (int)(cardHeight * 0.055)));
            lblMsg.Font = new Font("Segoe UI", fontMsgSize, FontStyle.Bold);
            panel.Controls.Add(lblMsg);

            // Nombre de Línea (Mitad superior del centro)
            Label lblLine = new Label();
            lblLine.Text = objAndon.nameLine ?? "";
            lblLine.ForeColor = txtColor;
            lblLine.BackColor = Color.Transparent;
            lblLine.TextAlign = ContentAlignment.MiddleCenter;
            lblLine.Location = new Point(0, headerH);
            lblLine.Size = new Size(cardWidth, remainingH / 2);
            int fontLineSize = Math.Max(28, Math.Min(75, (int)(cardHeight * 0.10)));
            lblLine.Font = new Font("Segoe UI", fontLineSize, FontStyle.Bold);
            panel.Controls.Add(lblLine);

            return panel;
        }

        private void buildQueue()
        {
            if (listAndon != null && listAndon.Any())
            {
                pnlQueue.Controls.Clear();
                int totalInQueue = Math.Min(listAndon.Count, 5);
                int i = 0;
                foreach (var item in listAndon.Take(5))
                {
                    Panel pnl = buildQueuePanel(item, i, totalInQueue);
                    pnlQueue.Controls.Add(pnl);
                    i++;
                }
            }
        }

        private Panel buildQueuePanel(Andon objAndon, int pos, int totalInQueue)
        {
            int total = Math.Max(1, Math.Min(totalInQueue, 5));
            int spacing = 16;
            int qWidth = (pnlQueue.ClientSize.Width - (spacing * (total + 1))) / total;
            int qHeight = Math.Max(100, pnlQueue.ClientSize.Height - 32);
            int horizontal = spacing + pos * (qWidth + spacing);

            Panel panel = new Panel();
            Color bgColor = ResolveColor(objAndon.nameBackground, Color.FromArgb(30, 41, 59));
            Color txtColor = !string.IsNullOrEmpty(objAndon.nameText) ? ResolveColor(objAndon.nameText, GetAutoContrast(bgColor)) : GetAutoContrast(bgColor);

            panel.BackColor = bgColor;
            panel.Size = new Size(qWidth, qHeight);
            panel.Location = new Point(horizontal, 16);

            // Tipo
            Label lblType = new Label();
            lblType.Text = (objAndon.nameType ?? "").ToUpper();
            lblType.ForeColor = txtColor;
            lblType.BackColor = Color.FromArgb(40, 0, 0, 0);
            lblType.Dock = DockStyle.Top;
            lblType.Height = (int)(qHeight * 0.28);
            lblType.TextAlign = ContentAlignment.MiddleCenter;
            lblType.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            panel.Controls.Add(lblType);

            // Estación
            Label lblMsg = new Label();
            lblMsg.Text = objAndon.message ?? "";
            lblMsg.ForeColor = txtColor;
            lblMsg.BackColor = Color.Transparent;
            lblMsg.Dock = DockStyle.Bottom;
            lblMsg.Height = (int)(qHeight * 0.34);
            lblMsg.TextAlign = ContentAlignment.MiddleCenter;
            lblMsg.Font = new Font("Segoe UI", 12, FontStyle.Regular);
            panel.Controls.Add(lblMsg);

            // Línea
            Label lblLine = new Label();
            lblLine.Text = objAndon.nameLine ?? "";
            lblLine.ForeColor = txtColor;
            lblLine.BackColor = Color.Transparent;
            lblLine.Dock = DockStyle.Fill;
            lblLine.TextAlign = ContentAlignment.MiddleCenter;
            lblLine.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            panel.Controls.Add(lblLine);

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
