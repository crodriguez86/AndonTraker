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

namespace Andon_V3.BackColor
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
            try
            {
                ColorBgBLL objBLL = new ColorBgBLL();

                if (string.IsNullOrEmpty(txtData.Text))
                    throw new Exception("Color de fondo requerido.");

                ColorBg obj = new ColorBg();
                obj.name = txtData.Text;
                obj.idBg = id;
                if (update)
                {
                    bool valid = objBLL.updateColorBg(obj);
                    if (valid)
                        ShowOK("Se actualizo correctamente registro");
                    else
                        ShowWarning("Se origino un problema al actualizar registro");
                    this.Close();
                }
                else
                {
                    List<ColorBg> searchDuplicated = objBLL.searchColorBg(obj);
                    if (searchDuplicated == null)
                        throw new Exception("Ocurrio un error al buscar registro");
                    if (searchDuplicated.Any())
                        throw new Exception("Este color de fondo ya existe. Por favor verifica.");

                    int id = objBLL.insertColorBg(obj);
                    if (id > 0)
                        ShowOK("Se inserto el registro correctamente");
                    else
                        ShowWarning("Se origino un problema al insertar registro");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                ShowWarning(ex.Message);
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
                ColorBgBLL objBLL = new ColorBgBLL();
                ColorBg objParam = new ColorBg();
                objParam.idBg = id;
                List<ColorBg> listObj = objBLL.getColorBg(objParam);
                if (listObj != null)
                {
                    if (listObj.Any())
                    {
                        txtData.Text = listObj.First().name;
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
