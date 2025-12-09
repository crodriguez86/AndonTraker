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

namespace Andon_V3.TblPanelGroup
{
    public partial class List : Form
    {
        public List()
        {
            InitializeComponent();
        }

        private void List_Load(object sender, EventArgs e)
        {

            loadData();
            
        }
        private void loadData()
        {
            AndonPanelGroupBLL objBLL = new AndonPanelGroupBLL();
            grdData.AutoGenerateColumns = false;
            List<AndonPanelGroup> list = objBLL.GetAll();
            if (list != null)
            {
                grdData.DataSource = list;
            }
            else
            {
                ShowWarning("Can't load panel groups from database. " + objBLL._error);
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

        private void grdLines_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (grdData[e.ColumnIndex, e.RowIndex].GetType() == typeof(DataGridViewLinkCell))

                {
                    string val = grdData[0, e.RowIndex].Value.ToString();
                    if (grdData[e.ColumnIndex, e.RowIndex].Value.ToString() == "Update")
                    {
                        Add add = new Add();
                        add.FormClosed += new FormClosedEventHandler(Form_Closed);
                        add.id = Convert.ToInt32(val);
                        var screen = Screen.FromPoint(Cursor.Position);
                        add.StartPosition = FormStartPosition.Manual;
                        add.Left = screen.Bounds.Left + screen.Bounds.Width / 2 - add.Width / 2;
                        add.Top = screen.Bounds.Top + screen.Bounds.Height / 2 - add.Height / 2;
                        add.ShowDialog();
                    }
                    else if (grdData[e.ColumnIndex, e.RowIndex].Value.ToString() == "Delete")
                    {
                        DialogResult dr = MessageBox.Show("Are you sure want to delete?", "Confirm delete", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);

                        if (dr == DialogResult.Yes)
                        {
                            int id = Convert.ToInt32(val);
                            //Eliminar registro
                            AndonPanelGroupBLL objBLL = new AndonPanelGroupBLL();
                            bool res = objBLL.Delete(id);
                            if (res)
                            {
                                ShowOK("Deleted successfully!");
                            }
                            else
                            {
                                ShowWarning("Something went wrong. " + objBLL._error);
                            }
                        }
                        loadData();
                    }
                    else if (grdData[e.ColumnIndex, e.RowIndex].Value.ToString() == "View")
                    {
                        int id = Convert.ToInt32(val);
                        TblPanelView.List listViews = new TblPanelView.List();
                        listViews._id = id;
                        var screen = Screen.FromPoint(Cursor.Position);
                        listViews.StartPosition = FormStartPosition.Manual;
                        listViews.Left = screen.Bounds.Left + screen.Bounds.Width / 2 - listViews.Width / 2;
                        listViews.Top = screen.Bounds.Top + screen.Bounds.Height / 2 - listViews.Height / 2;
                        listViews.ShowDialog();
                    }
                }
            }
        }
        private void grdLines_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (int i = 0; i < grdData.Rows.Count; i++)
            {
                grdData[8, i].Value = "Update";
                grdData[9, i].Value = "Delete";
                grdData[10, i].Value = "View";
            }
        }
        void Form_Closed(object sender, FormClosedEventArgs e)
        {
            loadData();
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            AndonPanelGroupBLL objBLL = new AndonPanelGroupBLL();
            grdData.AutoGenerateColumns = false;
            List<AndonPanelGroup> list = objBLL.GetAll();
            if (list != null)
            {
                list = list.Where(p => p.GroupName.Contains(textBox1.Text)).ToList();
                grdData.DataSource = list;
            }
            else
            {
                ShowWarning("Can't load panel groups from database. " + objBLL._error);
            }
        }
    }
}
