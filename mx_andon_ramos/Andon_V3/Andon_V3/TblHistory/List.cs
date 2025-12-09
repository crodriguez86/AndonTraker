using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MreaShared;
using MreaShared.BLL;
using MreaShared.Objects;

namespace Andon_V3.TblHistory
{
    public partial class List : Form
    {
        public List()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                AndonHistoryBLL objBLL = new AndonHistoryBLL();
                grdData.AutoGenerateColumns = false;
                var list = objBLL.GetAllFromDates(dtpFrom.Value.Date, dtpTo.Value.Date.AddDays(1).AddSeconds(-1));
                var listAndonCount = objBLL.GetCountAndonFromDates(dtpFrom.Value.Date, dtpTo.Value.Date.AddDays(1).AddSeconds(-1));
                if (list != null)
                {
                    grdData.DataSource = list;
                }
                else
                {
                    ShowWarning("Something went wrong. Please see log for more details. Error: " + objBLL._error);
                }
                //Generar paneles con la informacion de los Andon 
                if (listAndonCount != null)
                {
                    buildQueue(listAndonCount);
                }
                else
                {
                    ShowWarning("Something went wrong. Please see log for more details. Error: " + objBLL._error);
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

        private void List_Load(object sender, EventArgs e)
        {
            this.Text = "History report";
        }

        private void btnToExcel_Click(object sender, EventArgs e)
        {
            if (grdData.RowCount > 1)
            {
                btnToExcel.Text = "Please wait...";
                ExportToExcel();
                btnToExcel.Text = "Export to EXCEL";
            }
            else
            {
                ShowWarning("Grid es empty.");
            }
        }
        private void ExportToExcel()
        {
            // Creating a Excel object. 
            Microsoft.Office.Interop.Excel._Application excel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = excel.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;

            try
            {

                worksheet = workbook.ActiveSheet;
                string name = "Rep_from_" + dtpFrom.Value.ToString("MM-dd-yy") + "_to_" + dtpTo.Value.ToString("MM-dd-yy");
                worksheet.Name = name;

                int cellRowIndex = 1;
                int cellColumnIndex = 1;

                //Loop through each row and read value from each column. 
                for (int i = 0; i < grdData.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < grdData.Columns.Count; j++)
                    {
                        // Excel index starts from 1,1. As first Row would have the Column headers, adding a condition check. 
                        if (cellRowIndex == 1)
                        {
                            worksheet.Cells[cellRowIndex, cellColumnIndex] = grdData.Columns[j]?.HeaderText;
                        }
                        else
                        {
                            worksheet.Cells[cellRowIndex, cellColumnIndex] = grdData.Rows[i].Cells[j].Value == null ? string.Empty : grdData.Rows[i].Cells[j].Value.ToString();
                        }
                        cellColumnIndex++;
                    }
                    cellColumnIndex = 1;
                    cellRowIndex++;
                }

                //Getting the location and file name of the excel to save from user. 
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                saveDialog.FileName = name;
                saveDialog.FilterIndex = 1;

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    workbook.SaveAs(saveDialog.FileName);
                    MessageBox.Show("Export Successful");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                excel.Quit();
                workbook = null;
                excel = null;
            }

        }
        private void buildQueue(List<AndonHistory> listAndon)
        {
            if (listAndon != null)
            {
                if (listAndon.Any())
                {
                    pnlTopAndonHist.Controls.Clear();
                    int i = 0;
                    foreach (var item in listAndon)
                    {
                        Panel pnl = buildQueuePanel(item, i);
                        pnlTopAndonHist.Controls.Add(pnl);
                        i++;
                    }
                }
            }
        }
        private Panel buildQueuePanel(AndonHistory objAndon, int pos)
        {
            int width = 200;
            int height = pnlTopAndonHist.Height-15;
            int heightThird = pnlTopAndonHist.Height/5;
            int horizontal = pnlTopAndonHist.Width / 5 * pos + 5;
            Panel panel = new Panel();
            panel.BackColor = Color.LightGray;
            panel.Size = new Size(width, height);
            panel.Location = new Point(horizontal, 0);
            panel.BorderStyle = BorderStyle.FixedSingle;

            //Tipo
            Label label1 = new Label();
            label1.Text = objAndon.type;
            label1.ForeColor = Color.Black;
            label1.AutoSize = false;
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.Width = width;
            label1.Height = heightThird-10;
            label1.Font = new Font(this.Font.FontFamily, 9, FontStyle.Regular);
            label1.Location = new Point(0, 0);
            panel.Controls.Add(label1);
            //Contador
            Label label2 = new Label();
            label2.Text = "Total Andon calls: "+objAndon.count.ToString() + " times.";
            label2.ForeColor = Color.Black;
            label2.AutoSize = false;
            label2.TextAlign = ContentAlignment.MiddleLeft;
            label2.Width = width;
            label2.Height = heightThird;
            label2.Font = new Font(this.Font.FontFamily, 9, FontStyle.Regular);
            label2.Location = new Point(0, (heightThird) * 1 - 15);
            panel.Controls.Add(label2);
            //Response average
            Label label3 = new Label();
            label3.Text = "Average response of Andon calls: \n" + objAndon.responseAverageSec + " sec.";
            label3.ForeColor = Color.Black;
            label3.AutoSize = false;
            label3.TextAlign = ContentAlignment.MiddleLeft;
            label3.Width = width;
            label3.Height = heightThird;
            label3.Font = new Font(this.Font.FontFamily, 9, FontStyle.Regular);
            label3.Location = new Point(0, (heightThird) * 2 - 20);
            panel.Controls.Add(label3);
            //Line with more support
            Label label4 = new Label();
            label4.Text = "Line with more Andon calls: \n" + objAndon.topLineSupport;
            label4.ForeColor = Color.Black;
            label4.AutoSize = false;
            label4.TextAlign = ContentAlignment.MiddleLeft;
            label4.Width = width;
            label4.Height = heightThird;
            label4.Font = new Font(this.Font.FontFamily, 9, FontStyle.Regular);
            label4.Location = new Point(0, (heightThird) * 3 - 20);
            panel.Controls.Add(label4);
            //Highest response time
            Label label5 = new Label();
            label5.Text = "Andon with more response time: \n" + objAndon.topResponseSec;
            label5.ForeColor = Color.Black;
            label5.AutoSize = false;
            label5.TextAlign = ContentAlignment.MiddleLeft;
            label5.Width = width;
            label5.Height = heightThird+10;
            label5.Font = new Font(this.Font.FontFamily, 9, FontStyle.Regular);
            label5.Location = new Point(0, (heightThird) * 4 - 20);
            panel.Controls.Add(label5);
            return panel;
        }
    }
}
