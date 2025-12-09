using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Andon_V3.TblAndonError
{
    public partial class ListLogFiles : Form
    {
        public ListLogFiles()
        {
            InitializeComponent();
        }

        private void ListLogFiles_Load(object sender, EventArgs e)
        {
            LoadFiles();
        }

        private void grdData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string currentDir = Environment.CurrentDirectory;
            string logFilePath = currentDir + "\\";
            if (e.RowIndex >= 0)
            {
                if (grdData[e.ColumnIndex, e.RowIndex].GetType() == typeof(DataGridViewLinkCell))

                {
                    string val = grdData[0, e.RowIndex].Value.ToString();
                    logFilePath = logFilePath + val;
                    if (grdData[e.ColumnIndex, e.RowIndex].Value.ToString() == "View")
                    {
                        ViewLogFileDetails view = new ViewLogFileDetails();
                        view._filename = val;
                        view._content = File.ReadAllText(logFilePath);
                        var screen = Screen.FromPoint(Cursor.Position);
                        view.StartPosition = FormStartPosition.Manual;
                        view.Left = screen.Bounds.Left + screen.Bounds.Width / 2 - view.Width / 2;
                        view.Top = screen.Bounds.Top + screen.Bounds.Height / 2 - view.Height / 2;
                        view.ShowDialog();
                    }
                    else if (grdData[e.ColumnIndex, e.RowIndex].Value.ToString() == "Delete")
                    {
                        DialogResult dr = MessageBox.Show("Are you sure want to delete?", "Confirm delete", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);

                        if (dr == DialogResult.Yes)
                        {
                            File.Delete(logFilePath);
                            MreaMessage.ShowOK("Deleted successfully!");
                            LoadFiles();
                        }
                    }
                }
            }
        }
        private void LoadFiles()
        {
            grdData.Rows.Clear();
            string currentDir = Environment.CurrentDirectory;
            string logFilePath = currentDir + "\\";
            DirectoryInfo d = new DirectoryInfo(logFilePath);
            FileInfo[] Files = d.GetFiles("*.txt");
            foreach (FileInfo file in Files)
            {
                if (file.Name.Contains("Log"))
                {
                    var index = grdData.Rows.Add();
                    var size = (file.Length / 1024).ToString();
                    grdData.Rows[index].Cells["fileName"].Value = file.Name;
                    grdData.Rows[index].Cells["size"].Value = size + " kb";
                    grdData.Rows[index].Cells["Details"].Value = "View";
                    grdData.Rows[index].Cells["Delete"].Value = "Delete";
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadFiles();
        }
    }
}
