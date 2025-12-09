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
    public partial class ManageLevel : Form
    {
        public ManageLevel()
        {
            InitializeComponent();
        }

        private void Manage_Load(object sender, EventArgs e)
        {
            grdData3.AutoGenerateColumns = false;
            grdData2.AutoGenerateColumns = false;
            rdLevel1.Checked = true;
            loadData();
        }
        private void loadData()
        {
            CorreoBLL objBLL = new CorreoBLL();
            AndonBLL andonBLL = new AndonBLL();
            List<Correos> list = objBLL.getCorreos(new Correos());

            if (list != null)
            {
                grdData3.DataSource = list;
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
        private void grdData2_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (int i = 0; i < grdData2.Rows.Count; i++)
            {
                grdData2[3, i].Value = "Delete";
            }
        }
        private void grdData3_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (int i = 0; i < grdData3.Rows.Count; i++)
            {
                grdData3[3, i].Value = "Add";
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

                        EmailByLevelBLL objBLL = new EmailByLevelBLL();
                        EmailByLevel obj = new EmailByLevel();
                        obj.idEmail = Convert.ToInt32(val);
                        obj.idLevel = findLevel();

                        if(!objBLL.findEmailByLevel(obj.idLevel, obj.idEmail))
                        {
                            int id = objBLL.insertEmailByLevel(obj);
                            if (id > 0)
                            {
                                ShowOK("Se agrego correo correctamente.");
                                loadData2(obj.idLevel);
                                //Se cargan otra vez los correos para que se refleje que nivel tiene
                                loadData();
                            }
                            else
                            {
                                ShowWarning("No se pudo insertar correo.");
                            }
                        }
                        else
                        {
                            ShowWarning("Este correo ya esta en el nivel selecionado.");
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
                        EmailByLevelBLL objBLL = new EmailByLevelBLL();
                        if (objBLL.deleteEmailByLevel(Convert.ToInt32(val)))
                            ShowOK("Se elimino correctamente");
                        else
                            ShowWarning("Se origino un problema al eliminar el registro");

                        loadData2(findLevel());
                        //Se cargan otra vez los correos para que se refleje que nivel tiene
                        loadData();
                    }
                }
            }
        }
        private void loadData2(int val)
        {
            List<EmailByLevel> list = new List<EmailByLevel>();
            EmailByLevelBLL objBLL = new EmailByLevelBLL();
            list = objBLL.searchEmailByLevel(val, 1);
            if (list == null)
            {
                ShowWarning("No se pudieron cargar datos de base de datos");
            }
            else
            {
                grdData2.DataSource = list;
            }
        }

        private void rdLevel1_CheckedChanged(object sender, EventArgs e)
        {
            loadData2(findLevel());
        }

        private void rdLevel2_CheckedChanged(object sender, EventArgs e)
        {
            loadData2(findLevel());
        }

        private void rdLevel3_CheckedChanged(object sender, EventArgs e)
        {
            loadData2(findLevel());
        }
        private int findLevel()
        {
            if (rdLevel1.Checked)
            {
                return 1;
            }else if (rdLevel2.Checked)
            {
                return 2;
            }else if (rdLevel3.Checked)
            {
                return 3;
            }
            return 0;
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
