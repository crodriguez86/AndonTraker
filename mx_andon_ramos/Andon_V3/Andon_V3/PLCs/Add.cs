using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MreaShared.BLL;
using MreaShared.Objects;

namespace Andon_V3.PLCs
{
    public partial class Add : Form
    {
        public int id = -1;
        public bool update = false;
        public Add()
        {
            InitializeComponent();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            AndonPlcBLL objBLL = new AndonPlcBLL();
            if (txtName.Text != string.Empty)
            {
                AndonPlc obj = new AndonPlc();
                obj.name = txtName.Text;
                obj.ip = txtIp.Text;
                obj.idPlc = id;
                if (update)
                {
                    bool valid = objBLL.updateAndonPlc(obj);
                    if (valid)
                        ShowOK("Se actualizo correctamente PLC");
                    else
                        ShowWarning("Se origino un problema al actualizar PLC");
                    this.Close();
                }
                else
                {
                    int id = objBLL.insertAndonPlc(obj);
                    if (id > 0)
                        ShowOK("Se inserto PLC correctamente");
                    else
                        ShowWarning("Se origino un problema al insertar PLC");
                    this.Close();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Add_Load(object sender, EventArgs e)
        {
            lblAction.Text = "INSERT";
            if (id > 0)
            {
                AndonPlcBLL objBLL = new AndonPlcBLL();
                AndonPlc objParam = new AndonPlc();
                objParam.idPlc = id;
                List<AndonPlc> listObj = objBLL.getAndonPlc(objParam);
                if (listObj != null)
                {
                    if (listObj.Any())
                    {
                        txtName.Text = listObj.First().name;
                        txtIp.Text = listObj.First().ip;
                        update = true;
                        lblAction.Text = "UPDATE";
                    }
                }
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
    }
}
