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
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Andon_V3
{
    public partial class Layout : Form
    {
        public List<int> msgTagRKRRH = new List<int>();
        public List<int> msgTagRKRLH = new List<int>();
        public List<int> msgTagUPRAILLH = new List<int>();
        public List<int> msgTagUPRAILRH = new List<int>();
        public List<int> msgTagBAR4LWR = new List<int>();
        public List<int> msgTagBAR4UPR = new List<int>();
        public List<int> msgTagWHRH = new List<int>();
        public List<int> msgTagSKIES = new List<int>();
        public List<int> msgTagBIGH = new List<int>();
        public List<int> msgTagBAR5 = new List<int>();
        public List<int> msgTagBAR2 = new List<int>();
        public List<int> msgTagWHLH = new List<int>();
        public List<int> msgTagBOXLH = new List<int>();
        public List<int> msgTagBAR3 = new List<int>();
        public List<int> msgTagBOXRH = new List<int>();
        public List<int> msgTagPANEL5 = new List<int>();
        public List<int> msgTagRRLH = new List<int>();
        public List<int> msgTagRRRH = new List<int>();
        public List<int> msgTagMIG = new List<int>();
        public int resetCount = 0;
        public bool error;

        public Layout()
        {
            InitializeComponent();
        }

        private void Layout_Load(object sender, EventArgs e)
        {
            try
            {
                setScreen();
                clearValues();
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
                lblDate.Text = DateTime.Now.ToShortDateString();
                lblTime.Text = DateTime.Now.ToShortTimeString();
                if (!error)
                {
                    clearValues();
                    AndonBLL andonBLL = new AndonBLL();
                    List<Andon> list = andonBLL.selectAllScreens();
                    if (list != null)
                    {
                        if (list.Any())
                        {
                            int i = 0;
                            resetCount = 0;
                            lblAndonActive.Text = list.Count().ToString();
                            foreach (var objAndon in list)
                            {
                                i++;
                                drawPanel(i, objAndon);
                                bool write = false;
                                switch ((EIdLine)objAndon.idLine)
                                {
                                    case EIdLine.SKIES:
                                        pnlSkies.BackColor = Color.FromName(objAndon.nameBackground);
                                        if (msgTagSKIES.Contains(objAndon.tagValue))
                                        {
                                            write = false;
                                        }
                                        else
                                        {
                                            write = true;
                                            msgTagSKIES.Add(objAndon.tagValue);
                                        }
                                        break;
                                    case EIdLine.BAR2:
                                        pnlBar2.BackColor = Color.FromName(objAndon.nameBackground);
                                        if (msgTagBAR2.Contains(objAndon.tagValue))
                                        {
                                            write = false;
                                        }
                                        else
                                        {
                                            write = true;
                                            msgTagBAR2.Add(objAndon.tagValue);
                                        }
                                        break;
                                    case EIdLine.BAR3:
                                        pnlBar3.BackColor = Color.FromName(objAndon.nameBackground);
                                        if (msgTagBAR3.Contains(objAndon.tagValue))
                                        {
                                            write = false;
                                        }
                                        else
                                        {
                                            write = true;
                                            msgTagBAR3.Add(objAndon.tagValue);
                                        }
                                        break;
                                    case EIdLine.BAR4UPR:
                                        pnlBar4.BackColor = Color.FromName(objAndon.nameBackground);
                                        if (msgTagBAR4UPR.Contains(objAndon.tagValue))
                                        {
                                            write = false;
                                        }
                                        else
                                        {
                                            write = true;
                                            msgTagBAR4UPR.Add(objAndon.tagValue);
                                        }
                                        break;
                                    case EIdLine.BAR4LWR:
                                        pnlBar4LWR.BackColor = Color.FromName(objAndon.nameBackground);
                                        if (msgTagBAR4LWR.Contains(objAndon.tagValue))
                                        {
                                            write = false;
                                        }
                                        else
                                        {
                                            write = true;
                                            msgTagBAR4LWR.Add(objAndon.tagValue);
                                        }
                                        break;
                                    case EIdLine.RKRRH:
                                        pnlRkrRH.BackColor = Color.FromName(objAndon.nameBackground);
                                        if (msgTagRKRRH.Contains(objAndon.tagValue))
                                        {
                                            write = false;
                                        }
                                        else
                                        {
                                            write = true;
                                            msgTagRKRRH.Add(objAndon.tagValue);
                                        }
                                        break;
                                    case EIdLine.RKRLH:
                                        pnlRkrLH.BackColor = Color.FromName(objAndon.nameBackground);
                                        if (msgTagRKRLH.Contains(objAndon.tagValue))
                                        {
                                            write = false;
                                        }
                                        else
                                        {
                                            write = true;
                                            msgTagRKRLH.Add(objAndon.tagValue);
                                        }
                                        break;
                                    case EIdLine.PANEL5:
                                        pnlSill5.BackColor = Color.FromName(objAndon.nameBackground);
                                        if (msgTagPANEL5.Contains(objAndon.tagValue))
                                        {
                                            write = false;
                                        }
                                        else
                                        {
                                            write = true;
                                            msgTagPANEL5.Add(objAndon.tagValue);
                                        }
                                        break;
                                    case EIdLine.BAR5:
                                        pnlBar5.BackColor = Color.FromName(objAndon.nameBackground);
                                        if (msgTagBAR5.Contains(objAndon.tagValue))
                                        {
                                            write = false;
                                        }
                                        else
                                        {
                                            write = true;
                                            msgTagBAR5.Add(objAndon.tagValue);
                                        }
                                        break;
                                    case EIdLine.UPRRAILLH:
                                        pnlUpperLH.BackColor = Color.FromName(objAndon.nameBackground);
                                        if (msgTagUPRAILLH.Contains(objAndon.tagValue))
                                        {
                                            write = false;
                                        }
                                        else
                                        {
                                            write = true;
                                            msgTagUPRAILLH.Add(objAndon.tagValue);
                                        }
                                        break;
                                    case EIdLine.UPRRAILRH:
                                        pnlUpperRH.BackColor = Color.FromName(objAndon.nameBackground);
                                        if (msgTagUPRAILRH.Contains(objAndon.tagValue))
                                        {
                                            write = false;
                                        }
                                        else
                                        {
                                            write = true;
                                            msgTagUPRAILRH.Add(objAndon.tagValue);
                                        }
                                        break;
                                    case EIdLine.WHLH:
                                        pnlWheelLH.BackColor = Color.FromName(objAndon.nameBackground);
                                        if (msgTagWHLH.Contains(objAndon.tagValue))
                                        {
                                            write = false;
                                        }
                                        else
                                        {
                                            write = true;
                                            msgTagWHLH.Add(objAndon.tagValue);
                                        }
                                        break;
                                    case EIdLine.WHRH:
                                        pnlWheelRH.BackColor = Color.FromName(objAndon.nameBackground);
                                        if (msgTagWHRH.Contains(objAndon.tagValue))
                                        {
                                            write = false;
                                        }
                                        else
                                        {
                                            write = true;
                                            msgTagWHRH.Add(objAndon.tagValue);
                                        }
                                        break;
                                    case EIdLine.RRLH:
                                        pnlRailLH.BackColor = Color.FromName(objAndon.nameBackground);
                                        if (msgTagRRLH.Contains(objAndon.tagValue))
                                        {
                                            write = false;
                                        }
                                        else
                                        {
                                            write = true;
                                            msgTagRRLH.Add(objAndon.tagValue);
                                        }
                                        break;
                                    case EIdLine.RRRH:
                                        pnlRailRH.BackColor = Color.FromName(objAndon.nameBackground);
                                        if (msgTagRRRH.Contains(objAndon.tagValue))
                                        {
                                            write = false;
                                        }
                                        else
                                        {
                                            write = true;
                                            msgTagRRRH.Add(objAndon.tagValue);
                                        }
                                        break;
                                    case EIdLine.BIGH:
                                        pnlBigH.BackColor = Color.FromName(objAndon.nameBackground);
                                        if (msgTagBIGH.Contains(objAndon.tagValue))
                                        {
                                            write = false;
                                        }
                                        else
                                        {
                                            write = true;
                                            msgTagBIGH.Add(objAndon.tagValue);
                                        }
                                        break;
                                    case EIdLine.BOXLH:
                                        pnlBoxLH.BackColor = Color.FromName(objAndon.nameBackground);
                                        if (msgTagBOXLH.Contains(objAndon.tagValue))
                                        {
                                            write = false;
                                        }
                                        else
                                        {
                                            write = true;
                                            msgTagBOXLH.Add(objAndon.tagValue);
                                        }
                                        break;
                                    case EIdLine.BOXRH:
                                        pnlBoxRH.BackColor = Color.FromName(objAndon.nameBackground);
                                        if (msgTagBOXRH.Contains(objAndon.tagValue))
                                        {
                                            write = false;
                                        }
                                        else
                                        {
                                            write = true;
                                            msgTagBOXRH.Add(objAndon.tagValue);
                                        }
                                        break;
                                    case EIdLine.CELDASMIG:
                                        pnlMig10.BackColor = Color.FromName(objAndon.nameBackground);
                                        pnlMig20.BackColor = Color.FromName(objAndon.nameBackground);
                                        pnlMig30.BackColor = Color.FromName(objAndon.nameBackground);
                                        pnlMig40.BackColor = Color.FromName(objAndon.nameBackground);
                                        if (msgTagMIG.Contains(objAndon.tagValue))
                                        {
                                            write = false;
                                        }
                                        else
                                        {
                                            write = true;
                                            msgTagMIG.Add(objAndon.tagValue);
                                        }
                                        break;
                                    default:
                                        break;
                                }
                                if (write)
                                {
                                    string line = EnumBLL.GetEnumDescription((EIdLine)objAndon.idLine);
                                    //string[] row = new string[] { DateTime.Now.ToString(), line, objAndon.tDescription, objAndon.msgMessage };
                                    //grdHistory.Rows.Insert(0, row);
                                    if (chkNotification.Checked)
                                    {
                                        showNotification(objAndon.nameType, line + "\n" + objAndon.message);
                                    }
                                    drawChart();
                                    drawChart2();
                                }
                            }
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
                        resetMsgTag();
                    }
                }
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
            //if (Screen.AllScreens.Count() == 1)
            // throw new Exception("Este sistema cuenta con solo una pantalla");
            if (screenRun > Screen.AllScreens.Count() - 1)
                throw new Exception("El identificador de pantalla esta fuera del rango de pantallas del sistema. \nIdentificador: " + screenRun);
            screen = Screen.AllScreens.ElementAt(screenRun);
            this.StartPosition = FormStartPosition.Manual;
            this.Location = screen.Bounds.Location;
            //this.BackColor = Color.White;
        }

        protected void clearValues()
        {
            pnlBigH.BackColor    = Color.Gray;
            pnlRkrLH.BackColor   = Color.Gray;
            pnlRkrRH.BackColor   = Color.Gray;
            pnlBar5.BackColor    = Color.Gray;
            pnlUpperLH.BackColor = Color.Gray;
            pnlUpperRH.BackColor = Color.Gray;
            pnlBoxLH.BackColor   = Color.Gray;
            pnlBoxRH.BackColor   = Color.Gray;
            pnlBar2.BackColor    = Color.Gray;
            pnlBar3.BackColor    = Color.Gray;
            pnlBar4.BackColor    = Color.Gray;
            pnlBar4LWR.BackColor = Color.Gray;
            pnlSkies.BackColor   = Color.Gray;
            pnlRailLH.BackColor  = Color.Gray;
            pnlRailRH.BackColor  = Color.Gray;
            pnlWheelLH.BackColor = Color.Gray;
            pnlWheelRH.BackColor = Color.Gray;
            pnlSill5.BackColor   = Color.Gray;
            pnlMig10.BackColor   = Color.Gray;
            pnlMig20.BackColor   = Color.Gray;
            pnlMig30.BackColor   = Color.Gray;
            pnlMig40.BackColor   = Color.Gray;
            pnlPed1.BackColor    = Color.Gray;
            pnlPed2.BackColor    = Color.Gray;
            pnlPed3.BackColor    = Color.Gray;
            lblAndonActive.Text = "0";
            pnlPre1.BackColor = this.BackColor;
            pnlPre2.BackColor = this.BackColor;
            //pnlPre3.BackColor = this.BackColor;
            //pnlPre4.BackColor = this.BackColor;
            lblPre10.Text = "N/A";
            lblPre11.Text = "N/A";
            lblPre12.Text = "N/A";
            lblPre20.Text = "N/A";
            lblPre21.Text = "N/A";
            lblPre22.Text = "N/A";
            //lblPre30.Text = "N/A";
            //lblPre31.Text = "N/A";
            //lblPre32.Text = "N/A";
            //lblPre40.Text = "N/A";
            //lblPre41.Text = "N/A";
            //lblPre42.Text = "N/A";
            pnlPre1.Visible = false;
            pnlPre2.Visible = false;

        }

        private void showNotification(string title, string msj)
        {
            ntfIcon.Icon = SystemIcons.Application;//or any icon you like
            ntfIcon.Visible = true;
            ntfIcon.ShowBalloonTip(1000, title, msj, ToolTipIcon.Info);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        //private void ExportToExcel()
        //{
        //    // Creating a Excel object. 
        //    Microsoft.Office.Interop.Excel._Application excel = new Microsoft.Office.Interop.Excel.Application();
        //    Microsoft.Office.Interop.Excel._Workbook workbook = excel.Workbooks.Add(Type.Missing);
        //    Microsoft.Office.Interop.Excel._Worksheet worksheet = null;

        //    try
        //    {

        //        worksheet = workbook.ActiveSheet;

        //        worksheet.Name = "ExportedFromDatGrid";

        //        int cellRowIndex = 1;
        //        int cellColumnIndex = 1;

        //        //Loop through each row and read value from each column. 
        //        for (int i = 0; i < grdHistory.Rows.Count - 1; i++)
        //        {
        //            for (int j = 0; j < grdHistory.Columns.Count; j++)
        //            {
        //                // Excel index starts from 1,1. As first Row would have the Column headers, adding a condition check. 
        //                if (cellRowIndex == 1)
        //                {
        //                    worksheet.Cells[cellRowIndex, cellColumnIndex] = grdHistory.Columns[j].HeaderText;
        //                }
        //                else
        //                {
        //                    worksheet.Cells[cellRowIndex, cellColumnIndex] = grdHistory.Rows[i].Cells[j].Value.ToString();
        //                }
        //                cellColumnIndex++;
        //            }
        //            cellColumnIndex = 1;
        //            cellRowIndex++;
        //        }

        //        //Getting the location and file name of the excel to save from user. 
        //        SaveFileDialog saveDialog = new SaveFileDialog();
        //        saveDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
        //        saveDialog.FilterIndex = 1;

        //        if (saveDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        //        {
        //            workbook.SaveAs(saveDialog.FileName);
        //            MessageBox.Show("Export Successful");
        //        }
        //    }
        //    catch (System.Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //    finally
        //    {
        //        excel.Quit();
        //        workbook = null;
        //        excel = null;
        //    }

        //}

        private void button1_Click(object sender, EventArgs e)
        {
            //ExportToExcel();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void resetMsgTag()
        {
            msgTagRKRRH.Clear();
            msgTagRKRLH.Clear();
            msgTagUPRAILLH.Clear();
            msgTagUPRAILRH.Clear();
            msgTagBAR4LWR.Clear();
            msgTagBAR4UPR.Clear();
            msgTagWHRH.Clear();
            msgTagSKIES.Clear();
            msgTagBIGH.Clear();
            msgTagBAR5.Clear();
            msgTagBAR2.Clear();
            msgTagWHLH.Clear();
            msgTagBOXLH.Clear();
            msgTagBAR3.Clear();
            msgTagBOXRH.Clear();
            msgTagPANEL5.Clear();
            msgTagRRLH.Clear();
            msgTagRRRH.Clear();
            msgTagMIG.Clear();
        }
        private void drawPanel(int i, Andon objAndon)
        {
            //pintar paneles.....

            string line = EnumBLL.GetEnumDescription((EIdLine)objAndon.idLine);
            if (i == 1)
            {
                pnlPre1.BackColor = Color.FromName(objAndon.nameBackground);
                lblPre11.ForeColor = Color.FromName(objAndon.nameText);
                lblPre12.ForeColor = Color.FromName(objAndon.nameText);
                lblPre11.Text = objAndon.nameType;
                lblPre12.Text = objAndon.message;
                lblPre10.ForeColor = Color.FromName(objAndon.nameText);
                lblPre12.Font = new Font(lblPre12.Font.FontFamily, objAndon.font2 ?? 25);
                lblPre10.Text = line;
                pnlPre1.Visible = true;
            }
            else if (i == 2)
            {
                pnlPre2.BackColor = Color.FromName(objAndon.nameBackground);
                lblPre21.ForeColor = Color.FromName(objAndon.nameText);
                lblPre22.ForeColor = Color.FromName(objAndon.nameText);
                lblPre21.Text = objAndon.nameType;
                lblPre22.Text = objAndon.message;
                lblPre20.ForeColor = Color.FromName(objAndon.nameText);
                lblPre22.Font = new Font(lblPre22.Font.FontFamily, objAndon.font2 ?? 25);
                lblPre20.Text = line;
                pnlPre2.Visible = true;
            }
            else if (i == 3)
            {
                //pnlPre3.BackColor = Color.FromName(objAndon.nameBackground);
                //lblPre31.ForeColor = Color.FromName(objAndon.nameText);
                //lblPre32.ForeColor = Color.FromName(objAndon.nameText);
                //lblPre31.Text = objAndon.tDescription;
                //lblPre32.Text = objAndon.msgMessage;
                //lblPre30.ForeColor = Color.FromName(objAndon.nameText);
                //lblPre30.Text = line;
            }
            else if (i == 4)
            {
                //pnlPre4.BackColor = Color.FromName(objAndon.nameBackground);
                //lblPre41.ForeColor = Color.FromName(objAndon.nameText);
                //lblPre42.ForeColor = Color.FromName(objAndon.nameText);
                //lblPre41.Text = objAndon.tDescription;
                //lblPre42.Text = objAndon.msgMessage;
                //lblPre40.ForeColor = Color.FromName(objAndon.nameText);
                //lblPre40.Text = line;
            }

            //...................
        }

        private void drawChart()
        {
            foreach (var series in chart1.Series)
            {
                series.Points.Clear();
            }
            AndonHistoryBLL andonBLL = new AndonHistoryBLL();
            var list = andonBLL.getAndonTodayCount();
            if(list != null)
            {
                if (list.Any())
                {
                    foreach (var item in list)
                    {
                        chart1.Series[item.type].Points.AddXY("Val", item.count);
                    }
                }
            }
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
                        if (i == 6)
                            break;
                    }
                }
            }
        }
    }
}
