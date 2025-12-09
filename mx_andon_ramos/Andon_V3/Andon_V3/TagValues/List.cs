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

namespace Andon_V3.TagValues
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
            AndonValueBLL lineBLL = new AndonValueBLL();
            grdData.AutoGenerateColumns = false;
            List<AndonValues> list = lineBLL.getAndonValues(new AndonValues());
            if (list != null)
            {
                grdData.DataSource = list;
            }
            else
            {
                ShowWarning("No se pudo cargar Andon Values de base datos");
            }

        }
        private void ShowWarning(string msg)
        {
            MessageBox.Show(msg, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        private void ShowOK(string msg)
        {
            MessageBox.Show(msg, "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        add.Show();
                    }
                    else if (grdData[e.ColumnIndex, e.RowIndex].Value.ToString() == "Delete")
                    {
                        AndonValueBLL lineBLL = new AndonValueBLL();
                        if (lineBLL.deleteAndonValues(Convert.ToInt32(val)))
                            ShowOK("Se elimino correctamente");
                        else
                            ShowWarning("Se origino un problema al eliminar el registro");

                        loadData();
                    }
                }
            }
        }
        private void grdLines_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (int i = 0; i < grdData.Rows.Count; i++)
            {
                grdData[5, i].Value = "Update";
                grdData[6, i].Value = "Delete";
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

        private void button2_Click(object sender, EventArgs e)
        {
            loadData();
        }
    }
}
