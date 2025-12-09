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

namespace Andon_V3.Notifications
{
    public partial class Manage : Form
    {
        public Manage()
        {
            InitializeComponent();
        }

        private void Manage_Load(object sender, EventArgs e)
        {
            loadData();
        }
        private void loadData()
        {
            CorreoBLL objBLL = new CorreoBLL();
            AndonBLL andonBLL = new AndonBLL();
            grdData3.AutoGenerateColumns = false;
            grdData2.AutoGenerateColumns = false;
            grdData1.AutoGenerateColumns = false;
            List<AndonType> list2 = andonBLL.getAndonTypes(new AndonType());
            List<Correos> list = objBLL.getCorreos(new Correos());
            if (list2 == null)
                ShowWarning("No se obtuvieron tipos en base de datos");

            if (list != null && list2 != null)
            {
                grdData3.DataSource = list;
                grdData1.DataSource = list2;
            }
            else
            {
                ShowWarning("No se pudieron cargar correos de base datos");
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

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }
        private void grdData1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (int i = 0; i < grdData1.Rows.Count; i++)
            {
                grdData1[2, i].Value = "Search";
            }
        }
        private void grdData2_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (int i = 0; i < grdData2.Rows.Count; i++)
            {
                grdData2[4, i].Value = "Delete";
            }
        }
        private void grdData3_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (int i = 0; i < grdData3.Rows.Count; i++)
            {
                grdData3[3, i].Value = "Add";
            }
        }

        private void grdData1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (grdData1[e.ColumnIndex, e.RowIndex].GetType() == typeof(DataGridViewLinkCell))

                {
                    string val = grdData1[0, e.RowIndex].Value.ToString();
                    if (grdData1[e.ColumnIndex, e.RowIndex].Value.ToString() == "Search")
                    {
                        loadData2(Convert.ToInt32(val));
                    }
                }
            }
        }

        private void grdData3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (grdData3[e.ColumnIndex, e.RowIndex].GetType() == typeof(DataGridViewLinkCell))

                {
                    string val = grdData3[0, e.RowIndex].Value.ToString();
                    if (grdData3[e.ColumnIndex, e.RowIndex].Value.ToString() == "Add")
                    {
                        int index = grdData1.CurrentCell.RowIndex;
                        string type = grdData1[0, index].Value.ToString();

                        EmailByTypeBLL objBLL = new EmailByTypeBLL();
                        EmailByType obj = new EmailByType();
                        obj.idEmail = Convert.ToInt32(val);
                        obj.idType = Convert.ToInt32(type);

                        if(!objBLL.findEmailByType(obj.idType, obj.idEmail))
                        {
                            int id = objBLL.insertEmailByType(obj);
                            if (id > 0)
                            {
                                ShowOK("Se agrego correo correctamente.");
                                loadData2(obj.idType);
                            }
                            else
                            {
                                ShowWarning("No se pudo insertar correo.");
                            }
                        }
                        else
                        {
                            ShowWarning("Este correo ya pertenece a este tipo de soporte.");
                        }
                    }
                }
            }
        }

        private void grdData2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (grdData2[e.ColumnIndex, e.RowIndex].GetType() == typeof(DataGridViewLinkCell))

                {
                    string val = grdData2[0, e.RowIndex].Value.ToString();
                    if (grdData2[e.ColumnIndex, e.RowIndex].Value.ToString() == "Delete")
                    {
                        EmailByTypeBLL objBLL = new EmailByTypeBLL();
                        if (objBLL.deleteEmailByType(Convert.ToInt32(val)))
                            ShowOK("Se elimino correctamente");
                        else
                            ShowWarning("Se origino un problema al eliminar el registro");

                        int index = grdData1.CurrentCell.RowIndex;
                        string type = grdData1[0, index].Value.ToString();
                        loadData2(Convert.ToInt32(type));
                    }
                }
            }
        }
        private void loadData2(int val)
        {
            List<EmailByType> list = new List<EmailByType>();
            EmailByTypeBLL objBLL = new EmailByTypeBLL();
            list = objBLL.searchEmailByType(val, 1);
            if (list == null)
            {
                ShowWarning("No se pudieron cargar datos de base de datos");
            }
            else
            {
                grdData2.DataSource = list;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            CorreoBLL objBLL = new CorreoBLL();
            List<Correos> list = objBLL.getCorreos(new Correos { correo = textBox1.Text });
            if (list != null)
            {
                grdData3.DataSource = list;
            }
            else
            {
                ShowWarning("No se pudieron cargar correos de base datos");
            }
        }
    }
}
