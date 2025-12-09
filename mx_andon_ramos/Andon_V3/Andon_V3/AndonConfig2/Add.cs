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

namespace Andon_V3.AndonConfig2
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
                AndonBLL andonBLL = new AndonBLL();
                AndonConfig andonConfig = new AndonConfig();
                andonConfig.hostname = txtHostname.Text;
                andonConfig.startApp = Convert.ToInt32(cmbApp.SelectedValue);
                andonConfig.idLine = Convert.ToInt32(cmbLine.SelectedValue);
                andonConfig.startAlways = chkAlways.Checked;
                andonConfig.startScreen = Convert.ToInt32(nmbIndex.Value);
                andonConfig.smZone = Convert.ToInt32(nmbZone.Value);
                andonConfig.smDivs = Convert.ToInt32(nmbDivs.Value);
                andonConfig.lastUpdate = dateLastUpdtae.Value;
                if (update)
                {
                    andonConfig.idConfig = id;
                    if (andonBLL.updateAndonConfig(andonConfig))
                    {
                        ShowOK("Se actualizo configuracion correctamente");
                        this.Close();
                    }
                    else
                    {
                        ShowWarning("No se actualizo configuracion a base de datos");
                    }
                }
                else
                {
                    int id = andonBLL.insertAndonConfig(andonConfig);
                    if (id > 0)
                    {
                        ShowOK("Se agrego configuracion correctamente!");
                        this.Close();
                    }
                    else
                    {
                        ShowWarning("No se agrego configuracion a base de datos");
                    }
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
            AndonBLL andonBLL = new AndonBLL();
            List<Andon> list = andonBLL.getLines();
            List<AndonApp> list2 = andonBLL.getAndonApp(new AndonApp());

            cmbLine.DataSource = list;
            cmbLine.DisplayMember = "nameLine";
            cmbLine.ValueMember = "idLine";

            cmbApp.DataSource = list2;
            cmbApp.DisplayMember = "name";
            cmbApp.ValueMember = "idApp";

            if (id > 0)
            {
                AndonConfig objParam = new AndonConfig();
                objParam.idConfig = id;
                List<AndonConfig> listObj = andonBLL.getAndonConfig(objParam);
                if (listObj != null)
                {
                    if (listObj.Any())
                    {
                        var andonC = listObj.First();
                        cmbApp.SelectedValue = andonC.startApp;
                        cmbLine.SelectedValue = andonC.idLine;
                        nmbIndex.Value = andonC.startScreen ?? 0;
                        nmbZone.Value = andonC.smZone ?? 0;
                        nmbDivs.Value = andonC.smDivs ?? 0;
                        txtHostname.Text = andonC.hostname;
                        dateLastUpdtae.Value = andonC.lastUpdate ?? DateTime.Now;
                        chkAlways.Checked = andonC.startAlways;
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
