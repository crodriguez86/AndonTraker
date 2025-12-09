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

namespace Andon_V3.TagValues
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
                AndonValueBLL objBLL = new AndonValueBLL();
                int.TryParse(Convert.ToString(cmbPlc.SelectedValue), out int idPlc);

                if (idPlc == 0)
                    throw new Exception("Please select a PLC from list.");

                if (string.IsNullOrEmpty(txtTagName.Text))
                    throw new Exception("Tagname is required!");
                AndonValues obj = new AndonValues();
                obj.idPlc = Convert.ToInt32(cmbPlc.SelectedValue);
                obj.tagName = txtTagName.Text;
                obj.andonDate = dateTP.Value.Date;
                obj.andonValue = Convert.ToInt32(numValue.Value);
                obj.idAv = id;
                var objAV = objBLL.GetAndonValueByTagname(txtTagName.Text.Trim());
               
                if (update)
                {
                    if (objAV != null)
                    {
                        if (objAV.idAv != id) // Solo validar si el Tag name repetido es de otro PLC
                            throw new Exception("Tag name must be unique. This is already in use by the " + objAV.plcName + " PLC");
                    }
                    bool valid = objBLL.updateAndonValues(obj);
                    if (valid)
                        ShowOK("Andon value updated successfully!");
                    else
                        ShowWarning("Something went wrong. Please see log for more details.");
                    this.Close();
                }
                else
                {
                    if (objAV != null)
                        throw new Exception("Tag name must be unique. This is already in use by the " + objAV.plcName + " PLC");
                    int id = objBLL.insertAndonValues(obj);
                    if (id > 0)
                        ShowOK("Andon value inserted successfully!");
                    else
                        ShowWarning("Something went wrong. Please see log for more details.");
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
            AndonPlcBLL objBLL = new AndonPlcBLL();
            lblAction.Text = "INSERT";
            List<AndonPlc> list3 = objBLL.getAndonPlc(new AndonPlc());
            if (list3 == null)
                ShowWarning("Can't load PLC's from database.");
            cmbPlc.DataSource = list3;
            cmbPlc.DisplayMember = "name";
            cmbPlc.ValueMember = "idPlc";

            if (id > 0)
            {
                AndonValueBLL objABLL = new AndonValueBLL();
                AndonValues objParam = new AndonValues();
                objParam.idAv = id;
                List<AndonValues> listObj = objABLL.getAndonValues(objParam);
                if (listObj != null)
                {
                    if (listObj.Any())
                    {
                        cmbPlc.SelectedValue = listObj.First().idPlc;
                        txtTagName.Text = listObj.First().tagName;
                        numValue.Value = Convert.ToInt32(listObj.First().andonValue);
                        dateTP.Value = listObj.First().andonDate == null ? DateTime.Now : listObj.First().andonDate.Value;
                        update = true;
                        lblAction.Text = "UPDATE";
                    }
                }
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
    }
}
