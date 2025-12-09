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

namespace Andon_V3
{
    public partial class NewMessage : Form
    {
        public int idMessage;
        public int idLine;
        public int idType;
        public int idAndonValue;
        public bool update = false;
        public NewMessage()
        {
            InitializeComponent();
        }

        private void NewMessage_Load(object sender, EventArgs e)
        {
            AndonBLL andonBLL = new AndonBLL();
            List<Andon> list = andonBLL.getLines();
            List<AndonType> list2 = andonBLL.getAndonTypes(new AndonType());
            List<AndonPlc> list3 = andonBLL.getAndonPlc(new AndonPlc());
            List<AndonFontsize> list4 = andonBLL.getAndonFonts(new AndonFontsize());
            List<AndonFontsize> list5 = andonBLL.getAndonFonts(new AndonFontsize());
            List<AndonFontsize> list6 = andonBLL.getAndonFonts(new AndonFontsize());

            if (list == null)
                ShowWarning("Can't load lines from database. Please see log for more details.");

            if (list2 == null)
                ShowWarning("Can't load types from database. Please see log for more details.");

            if (list3 == null)
                ShowWarning("Can't load PLC's from database. Please see log for more details.");

            if (list4 == null)
                ShowWarning("Can't load fonsizes from database. Please see log for more details.");

            cmbType.DataSource = list2;
            cmbType.DisplayMember = "name";
            cmbType.ValueMember = "idType";

            cmbLine.DataSource = list;
            cmbLine.DisplayMember = "nameLine";
            cmbLine.ValueMember = "idLine";

            cmbPlc.DataSource = list3;
            cmbPlc.DisplayMember = "name";
            cmbPlc.ValueMember = "idPlc";

            cmbFont1.DataSource = list4;
            cmbFont1.DisplayMember = "font";
            cmbFont1.ValueMember = "idFont";

            cmbFont2.DataSource = list5;
            cmbFont2.DisplayMember = "font";
            cmbFont2.ValueMember = "idFont";

            cmbFont3.DataSource = list6;
            cmbFont3.DisplayMember = "font";
            cmbFont3.ValueMember = "idFont";

            if(idMessage != 0)
            {
                loadMessage(idMessage);
            }
            else
            {
                if(idType != 0)
                    cmbType.SelectedValue = idType;
                if (idLine != 0)
                    cmbLine.SelectedValue = idLine;
                if (idAndonValue != 0)
                {
                    AndonPlcBLL andonPlcBLL = new AndonPlcBLL();
                    AndonValueBLL andonValueBLL = new AndonValueBLL();
                    var listAV = andonValueBLL.getAndonValues(new AndonValues { idAv = idAndonValue });
                    if (listAV != null)
                    {
                        var objAV = listAV.First();
                        if (objAV != null)
                        {
                            cmbPlc.SelectedValue = objAV.idPlc;
                            cmbPlc_SelectedIndexChanged_1(null, null);
                        }
                    }
                }
            }
        }

        private void loadMessage(int idMessage)
        {
            AndonBLL andonBLL = new AndonBLL();
            var objMessage = andonBLL.getMessage(idMessage);
            if (objMessage != null)
            {
                var andon = objMessage;
                if (andon != null)
                {
                    cmbLine.SelectedValue = andon.idLine;
                    //cmbLine.Enabled = false;
                    cmbType.SelectedValue = andon.idType;
                    //cmbType.Enabled = false;
                    cmbPlc.SelectedValue = andon.idPlc;
                    cmbPlc_SelectedIndexChanged_1(null,null);
                    cmbTag.SelectedValue = andon.idAndonValue;
                    cmbFont1.SelectedValue = andon.idfont1;
                    cmbFont2.SelectedValue = andon.idfont2;
                    cmbFont3.SelectedValue = andon.idfont3;

                    txtValue.Text = andon.tagValue.ToString();
                    txtMsg.Text = andon.message;
                    if (update == false)
                    {
                        btnSave.Text = "Save Copy";
                    }
                    else
                    {
                        btnSave.Text = "Update";
                    }
                }
            }
            else
            {
                ShowWarning("Can't load message from database. Please see log for more details.");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbPlc_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (int.TryParse(cmbPlc.SelectedValue.ToString(), out int idPlc))
            {
                AndonBLL andonBLL = new AndonBLL();
                AndonValues objAndon = new AndonValues();
                objAndon.idPlc = idPlc;
                var list = andonBLL.getAndonValues(objAndon);
                if (list == null)
                    ShowWarning("Can't load tags from database. Please see log for more details.");
                cmbTag.DataSource = list;
                cmbTag.DisplayMember = "tagName";
                cmbTag.ValueMember = "idAv";
                if (idAndonValue != 0)
                {
                    cmbTag.SelectedValue = idAndonValue;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int.TryParse(Convert.ToString(cmbLine.SelectedValue),  out int idLine);
            int.TryParse(Convert.ToString(cmbType.SelectedValue),  out int idType);
            int.TryParse(Convert.ToString(cmbPlc.SelectedValue),   out int idPlc);
            int.TryParse(Convert.ToString(cmbTag.SelectedValue),   out int idTag);
            int.TryParse(Convert.ToString(cmbFont1.SelectedValue), out int idFont1);
            int.TryParse(Convert.ToString(cmbFont2.SelectedValue), out int idFont2);
            int.TryParse(Convert.ToString(cmbFont3.SelectedValue), out int idFont3);

            if(idTag != 0)
            {
                int tagValue = 0;

                if (int.TryParse(txtValue.Text, out tagValue))
                {
                    AndonBLL andonBLL = new AndonBLL();
                    Andon objAndon = new Andon();
                    objAndon.idAndonValue = idTag;
                    objAndon.idLine = idLine;
                    objAndon.tagValue = tagValue;
                    objAndon.message = txtMsg.Text;
                    objAndon.idType = idType;
                    objAndon.font = idFont1;
                    objAndon.font2 = idFont2;
                    objAndon.font3 = idFont3;
                    if (update)
                    {
                        objAndon.idMessage = idMessage;
                        bool valid = andonBLL.updateAndon(objAndon);
                        if (valid)
                        {
                            ShowOK("Message updated successfully! ID: (" + idMessage + ")");
                            this.Close();
                        }
                        else
                        {
                            ShowWarning("Message not updated. Something went wrong. Please see log for more details.");
                        }
                    }
                    else
                    {
                        int id = andonBLL.insertAndon(objAndon);
                        if (id != 0)
                        {
                            ShowOK("Message created successfully ID: (" + id + ")");
                            this.Close();
                        }
                        else
                        {
                            ShowWarning("Message not created. Something went wrong. Please see log for more details.");
                        }
                    }
                }
                else
                {
                    ShowWarning("Tag value must be a number.");
                }
            }
            else
            {
                ShowWarning("Please select a tag.");
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
    }
}
