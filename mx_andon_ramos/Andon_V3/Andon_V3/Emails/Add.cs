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

namespace Andon_V3.Emails
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
                CorreoBLL objBLL = new CorreoBLL();

                if (string.IsNullOrEmpty(txtData.Text))
                    throw new Exception("Correo requerido.");

                Correos obj = new Correos();
                obj.correo = txtData.Text;
                obj.id = id;
                if (update)
                {
                    bool valid = objBLL.updateCorreos(obj);
                    if (valid)
                        ShowOK("Se actualizo correctamente registro");
                    else
                        ShowWarning("Se origino un problema al actualizar registro");
                    this.Close();
                }
                else
                {
                    //Se comenta codigo para evitar correos duplicados para poder crear dos correos con el mismo nombre y asignarlos a diferente nivel
                    //Ejemplo:
                    //juan.guerrero@martinrea.com ID 10 --> Se agrega a nivel 1 y se asigna a Calidad --+
                    //                                                                                  +--->Hay conflicto con esto. Porque se enviaria correo de Mtto nivel 1 ya que se asigno anteriormente a nivel 1 para calidad
                    //juan.guerrero@martinrea.com ID 10 --> Se agrega a nivel 2 y se asigna a Mtto    --+

                    //Solucion:
                    //Crear otro correo con el mismo nombre juan.guerrero@martinrea.com ID 11 y asignarlo a nivel 2 y ya no hay conflicto con el nivel 1 de calidad

                    //List<Correos> searchDuplicated = objBLL.searchCorreos(obj);
                    //if (searchDuplicated == null)
                    //    throw new Exception("Ocurrio un error al buscar registro");
                    //if (searchDuplicated.Any())
                    //    throw new Exception("Este correo ya existe. Por favor verifica.");

                    int id = objBLL.insertCorreos(obj);
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
                CorreoBLL objBLL = new CorreoBLL();
                Correos objParam = new Correos();
                objParam.id = id;
                List<Correos> listObj = objBLL.getCorreos(objParam);
                if (listObj != null)
                {
                    if (listObj.Any())
                    {
                        txtData.Text = listObj.First().correo;
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
