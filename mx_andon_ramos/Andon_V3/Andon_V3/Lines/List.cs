using MreaShared.BLL;
using MreaShared.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Andon_V3.Lines
{
    public partial class List : Form
    {
        public List()
        {
            InitializeComponent();
        }

        private void List_Load(object sender, EventArgs e)
        {

            loadLines();
            
        }
        private void loadLines()
        {
            MreaLineBLL lineBLL = new MreaLineBLL();
            grdLines.AutoGenerateColumns = false;
            List<MreaLine> list = lineBLL.getMreaLine(new MreaLine());
            if (list != null)
            {
                grdLines.DataSource = list;
            }
            else
            {
                ShowWarning("Dan't load lines from database. Please see log for more details.");
            }

        }
        private void ShowWarning(string msg)
        {
            MessageBox.Show(msg, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        private void ShowOK(string msg)
        {
            MessageBox.Show(msg, "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void grdLines_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (grdLines[e.ColumnIndex, e.RowIndex].GetType() == typeof(DataGridViewLinkCell))

                {
                    string val = grdLines[0, e.RowIndex].Value.ToString();
                    if (grdLines[e.ColumnIndex, e.RowIndex].Value.ToString() == "Update")
                    {
                        Add add = new Add();
                        add.FormClosed += new FormClosedEventHandler(Form_Closed);
                        add.id = Convert.ToInt32(val);
                        add.Show();
                    }
                    else if (grdLines[e.ColumnIndex, e.RowIndex].Value.ToString() == "Delete")
                    {
                        DialogResult dr = MessageBox.Show("Are you sure want to delete?", "Confirm delete", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);

                        if (dr == DialogResult.Yes)
                        {
                            MreaLineBLL lineBLL = new MreaLineBLL();
                            if (lineBLL.deleteMreaLine(Convert.ToInt32(val)))
                                ShowOK("Deleted successfully!");
                            else
                                ShowWarning("Line not deleted. Something went wrong. Please see log for more details.");
                        }

                        loadLines();
                    }
                }
            }
        }
        private void grdLines_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (int i = 0; i < grdLines.Rows.Count; i++)
            {
                grdLines[4, i].Value = "Update";
                grdLines[5, i].Value = "Delete";
            }
        }
        void Form_Closed(object sender, FormClosedEventArgs e)
        {
            loadLines();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Add add = new Add();
            add.FormClosed += new FormClosedEventHandler(Form_Closed);
            var screen = Screen.FromPoint(Cursor.Position);
            add.StartPosition = FormStartPosition.Manual;
            add.Left = screen.Bounds.Left + screen.Bounds.Width / 2 - add.Width / 2;
            add.Top = screen.Bounds.Top + screen.Bounds.Height / 2 - add.Height / 2;
            add.ShowDialog();
        }
    }
}
