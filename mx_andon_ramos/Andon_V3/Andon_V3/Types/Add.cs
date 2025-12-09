using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MreaShared.BLL;
using MreaShared.Objects;

namespace Andon_V3.Types
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
                AndonTypeBLL objBLL = new AndonTypeBLL();
                int.TryParse(Convert.ToString(cmbBgColor.SelectedValue), out int idBg);
                int.TryParse(Convert.ToString(cmbFont1.SelectedValue), out int idText);
                int.TryParse(Convert.ToString(cmbFontsizeProd.SelectedValue), out int idFontProd);
                int.TryParse(Convert.ToString(cmbFontsizeMonitor.SelectedValue), out int idFontMon);
                int.TryParse(Convert.ToString(cmbBgMonitor.SelectedValue), out int idBgMonitor);

                if (idBg == 0)
                    throw new Exception("Selecciona algun color de fuente");
                if (idText == 0)
                    throw new Exception("Selecciona algun color de fondo");

                if (string.IsNullOrEmpty(txtName.Text))
                    throw new Exception("Agrega el nombre del tipo de soporte");

                if (!validateTimeString(txtLimitTimeLv2.Text.Trim()))
                    throw new Exception("The time limit for level 2 does not have the correct format. [HH:MM:SS]");
                if (txtLimitTimeLv2.Text == "00:00:00" && !chkLvl2.Checked)
                {
                    throw new Exception("Time limit must be greater than zero.");
                }
                if (!validateTimeString(txtLimitTimeLv3.Text.Trim()))
                    throw new Exception("The time limit for level 3 does not have the correct format. [HH:MM:SS]");
                if (txtLimitTimeLv3.Text == "00:00:00" && !chkLvl3.Checked)
                {
                    throw new Exception("Time limit must be greater than zero.");
                }

                AndonType obj = new AndonType();
                obj.idBg = idBg;
                obj.idText = idText;
                obj.name = txtName.Text;
                obj.idFontProduction = idFontProd;
                obj.idFontMonitor = idFontMon;
                obj.showProduction = chkProd.Checked;
                obj.showMonitor = chkMon.Checked;
                obj.showSpare1 = chkSp1.Checked;
                obj.showSpare2 = chkSp2.Checked;
                obj.idBgMonitor = idBgMonitor;
                obj.timeLimitLv2 = chkLvl2.Checked ? null : txtLimitTimeLv2.Text;
                obj.timeLimitLv3 = chkLvl3.Checked ? null : txtLimitTimeLv3.Text;
                obj.idType = id;
                if (update)
                {
                    bool valid = objBLL.updateAndonType(obj);
                    if (valid)
                        ShowOK("Se actualizo correctamente tipo de soporte");
                    else
                        ShowWarning("Se origino un problema al actualizar tipo de soporte");
                    this.Close();
                }
                else
                {
                    int id = objBLL.insertAndonType(obj);
                    if (id > 0)
                        ShowOK("Se inserto tipo de soporte correctamente");
                    else
                        ShowWarning("Se origino un problema al insertar tipo de soporte");
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
            ColorBgBLL bgBLL = new ColorBgBLL();
            ColorTextBLL textBLL = new ColorTextBLL();
            FontsizeBLL fontBLL = new FontsizeBLL();
            List<ColorBg> list = bgBLL.getColorBg(new ColorBg());
            List<ColorText> list2 = textBLL.getColorText(new ColorText());
            List<AndonFontsize> list3 = fontBLL.getAndonFontsize(new AndonFontsize());
            List<ColorBg> list4 = bgBLL.getColorBg(new ColorBg());
            List<AndonFontsize> list5 = fontBLL.getAndonFontsize(new AndonFontsize());

            if (list == null)
                ShowWarning("No se obtuvieron colores de fuente en base de datos");
            cmbBgColor.DataSource = list;
            cmbBgColor.DisplayMember = "name";
            cmbBgColor.ValueMember = "idBg";

            if (list2 == null)
                ShowWarning("No se obtuvieron colores de fondo en base de datos");
            cmbFont1.DataSource = list2;
            cmbFont1.DisplayMember = "name";
            cmbFont1.ValueMember = "idText";

            if (list3 == null)
                ShowWarning("No se obtuvieron fuentes produccion en base de datos");
            cmbFontsizeProd.DataSource = list3;
            cmbFontsizeProd.DisplayMember = "font";
            cmbFontsizeProd.ValueMember = "idFont";

            if (list5 == null)
                ShowWarning("No se obtuvieron fuentes monitor en base de datos");
            cmbFontsizeMonitor.DataSource = list5;
            cmbFontsizeMonitor.DisplayMember = "font";
            cmbFontsizeMonitor.ValueMember = "idFont";

            if (list4 == null)
                ShowWarning("No se obtuvieron colores para Andon Monitor en base de datos");
            cmbBgMonitor.DataSource = list4;
            cmbBgMonitor.DisplayMember = "name";
            cmbBgMonitor.ValueMember = "idBg";

            lblAction.Text = "INSERT";
            if (id > 0)
            {
                AndonTypeBLL objBLL = new AndonTypeBLL();
                AndonType objParam = new AndonType();
                objParam.idType = id;
                List<AndonType> listObj = objBLL.getAndonType(objParam);
                if (listObj != null)
                {
                    if (listObj.Any())
                    {
                        cmbBgColor.SelectedValue = listObj.First().idBg;
                        cmbFont1.SelectedValue = listObj.First().idText;
                        cmbFontsizeProd.SelectedValue = listObj.First().idFontProduction;
                        cmbFontsizeMonitor.SelectedValue = listObj.First().idFontMonitor;
                        cmbBgMonitor.SelectedValue = listObj.First().idBgMonitor;
                        txtName.Text = listObj.First().name;
                        chkProd.Checked = listObj.First().showProduction;
                        chkMon.Checked = listObj.First().showMonitor;
                        chkSp1.Checked = listObj.First().showSpare1;
                        chkSp2.Checked = listObj.First().showSpare2;
                        txtLimitTimeLv2.Text = listObj.First().timeLimitLv2 ?? "00:00:00";
                        txtLimitTimeLv3.Text = listObj.First().timeLimitLv3 ?? "00:00:00";
                        chkLvl2.Checked = listObj.First().timeLimitLv2 == null ? true : false;
                        chkLvl3.Checked = listObj.First().timeLimitLv3 == null ? true : false;
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
        private bool validateTimeString(string time)
        {
            DateTime ignored;
            return DateTime.TryParseExact(time, "HH:mm:ss",
                                          CultureInfo.InvariantCulture,
                                          DateTimeStyles.None,
                                          out ignored);
        }

        private void chkLvl2_CheckedChanged(object sender, EventArgs e)
        {
            if (chkLvl2.Checked)
            {
                txtLimitTimeLv2.Text = "00:00:00";
                txtLimitTimeLv2.ReadOnly = true;
            }
            else
            {
                txtLimitTimeLv2.ReadOnly = false;
            }
        }

        private void chkLvl3_CheckedChanged(object sender, EventArgs e)
        {
            if (chkLvl3.Checked)
            {
                txtLimitTimeLv3.Text = "00:00:00";
                txtLimitTimeLv3.ReadOnly = true;
            }
            else
            {
                txtLimitTimeLv3.ReadOnly = false;
            }
        }
    }
}
