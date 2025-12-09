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
using System.Net;

namespace Andon_V3
{
    public partial class StartUpConfig : Form
    {
        public StartUpConfig()
        {
            InitializeComponent();
        }
        bool update;
        int idConf = 0;

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void StartUpConfig_Load(object sender, EventArgs e)
        {
            try
            {
                DBConnectionBLL objConn = new DBConnectionBLL();
                if (objConn.CheckConnection())
                {
                    setVisibleSM(false);
                    AndonBLL andonBLL = new AndonBLL();
                    AndonPanelGroupBLL groupBLL = new AndonPanelGroupBLL();
                    List<Andon> list = new List<Andon>();
                    list.Add(new Andon { idLine = 0, nameLine = "ALL" });
                    list.AddRange(andonBLL.getLines());
                    List<AndonApp> list2 = andonBLL.getAndonApp(new AndonApp());
                    List<AndonPanelGroup> list3 = groupBLL.GetAll();

                    ZoneBLL zoneBLL = new ZoneBLL();
                    List<Zone> listZones = new List<Zone>();
                    listZones = zoneBLL.getZone(new Zone());
                    if (listZones == null)
                        ShowWarning("Can't load zones from database. Please see log for more details.");

                    listBoxZones.DataSource = listZones;
                    listBoxZones.DisplayMember = "name";
                    listBoxZones.ValueMember = "idZone";

                    cmbLine.DataSource = list;
                    cmbLine.DisplayMember = "nameLine";
                    cmbLine.ValueMember = "idLine";

                    cmbApp.DataSource = list2;
                    cmbApp.DisplayMember = "name";
                    cmbApp.ValueMember = "idApp";

                    cmbPanelGroup.DataSource = list3;
                    cmbPanelGroup.DisplayMember = "GroupName";
                    cmbPanelGroup.ValueMember = "IdGroup";

                    lblHostname.Text = Dns.GetHostName();

                    cmbScreen.DataSource = getListScreens();
                    cmbScreen.DisplayMember = "screenName";
                    cmbScreen.ValueMember = "idScreen";

                    AndonConfig andon = andonBLL.getAndonConfigByHostname(Dns.GetHostName());
                    if (andon != null)
                    {
                        cmbApp.SelectedValue = andon.startApp;
                        cmbLine.SelectedValue = andon.idLine;
                        cmbScreen.SelectedValue = andon.startScreen;
                        txtDivitions.Text = andon.smDivs.ToString();
                        cmbPanelGroup.SelectedValue = andon.idPanelGroup;
                        update = true;
                        idConf = andon.idConfig;
                        if (andon.startApp == (int)EApps.PRODUCCION)
                        {
                            setVisibleProd(true);
                        }
                        else
                        {
                            setVisibleProd(false);
                        }
                        if (andon.startApp == (int)EApps.PANELGROUP)
                        {
                            setVisiblePanelGroup(true);
                        }
                        else
                        {
                            setVisiblePanelGroup(false);
                        }
                    }
                }
                else
                {
                    ShowWarning("There is no connection to database. Please check connection string in config file.");
                }
            }
            catch (Exception ex)
            {
                ShowWarning(ex.Message);
            }
        }

        private void showApp(int startApp)
        {
            switch ((EApps)startApp)
            {
                case EApps.PRODUCCION:
                    new Production().Show();
                    break;
                case EApps.VISORGEN:
                    new Monitor().Show();
                    break;
                case EApps.TEST:
                    new TestAndon().Show();
                    break;
                case EApps.MATERIALES:
                    new Materials().Show();
                    break;
                case EApps.ADMON:
                    new Login().Show();
                    break;
                case EApps.SUPERMARKET:
                    new SuperMarket().Show();
                    break;
                case EApps.PANELGROUP:
                    var pg = new PanelGroup();
                    pg.Show();
                    break;
            }
            this.WindowState = FormWindowState.Minimized;
        }

        private List<ScreenDevice> getListScreens()
        {
            List<ScreenDevice> list = new List<ScreenDevice>();
            int i = 0;
            foreach (var item in Screen.AllScreens)
            {
                ScreenDevice obj = new ScreenDevice();
                obj.idScreen = i;
                obj.screenName = item.DeviceName.ToString();
                list.Add(obj);
                i++;
            }
            return list;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbApp_SelectedIndexChanged(object sender, EventArgs e)
        {
            string app = cmbApp.SelectedValue?.ToString();
            if (int.TryParse(app, out int idApp))
            {
                if(idApp == (int)EApps.SUPERMARKET)
                {
                    setVisibleSM(true);
                }
                else
                {
                    setVisibleSM(false);
                }
                if (idApp == (int)EApps.PRODUCCION)
                {
                    setVisibleProd(true);
                }
                else
                {
                    setVisibleProd(false);
                }
                if (idApp == (int)EApps.PANELGROUP)
                {
                    setVisiblePanelGroup(true);
                }
                else
                {
                    setVisiblePanelGroup(false);
                }
            }
        }

        private void setVisibleSM(bool visible)
        {
            groupBox1.Visible = visible;
            lblZM.Visible = visible;
            lblDivs.Visible = visible;
            txtDivitions.Visible = visible;
            txtDivitions.Text = "6";
        }
        private void setVisibleProd(bool visible)
        {
            cmbLine.Visible = visible;
            cmbScreen.Visible = visible;
        }
        private void setVisiblePanelGroup(bool visible)
        {
            cmbPanelGroup.Visible = visible;
            cmbPanelGroup.Visible = visible;
        }
        private void ShowWarning(string msg)
        {
            MessageBox.Show(msg, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        private void ShowOK(string msg)
        {
            MessageBox.Show(msg, "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                AndonBLL andonBLL = new AndonBLL();
                AndonConfig andonConfig = new AndonConfig();
                andonConfig.hostname = lblHostname.Text;
                int.TryParse(Convert.ToString(cmbApp.SelectedValue), out int idApp);
                if (idApp == 0)
                    throw new Exception("Please select an App from the list");
                andonConfig.startApp = idApp;
                andonConfig.idLine = Convert.ToInt32(cmbLine.SelectedValue);
                andonConfig.startAlways = chkAlways.Checked;
                andonConfig.startScreen = Convert.ToInt32(cmbScreen.SelectedValue);
                andonConfig.idPanelGroup = Convert.ToInt32(cmbPanelGroup.SelectedValue);
                andonConfig.config = string.Empty;
                string strConfig = andonConfig.startApp.ToString();
                string strTabletMode = chkTabletMode.Checked.ToString();
                if (andonConfig.startApp == (int)EApps.SUPERMARKET)
                {
                    andonConfig.smDivs = Convert.ToInt32(txtDivitions.Text);
                    //Get list zones
                    List<int> listIdZone = new List<int>();
                    List<string> listNameZone = new List<string>();
                    foreach (object item in listBoxZones.SelectedItems)
                    {
                        Zone objZone = (Zone)item;
                        int.TryParse(Convert.ToString(objZone.idZone), out int idZone);
                        if (idZone != 0)
                        {
                            listIdZone.Add(idZone);
                            listNameZone.Add(objZone.name);
                        }
                    }
                    if (listIdZone.Count <= 0)
                        throw new Exception("Please select at least one zone.");
                    string strZones = string.Join(",", listIdZone);
                    string strNameZones = string.Join(",", listNameZone);
                    strConfig += "_" + strZones + "_" + strTabletMode + "_" + strNameZones;
                }
                else if (andonConfig.startApp == (int)EApps.PRODUCCION)
                {
                    if (andonConfig.idLine == 0)
                    {
                        strConfig = "ShowAll";
                    }
                    else
                    {
                        strConfig = string.Empty;
                    }
                }
                if (andonConfig.idLine == 0)
                {
                    var lines = andonBLL.getLines();
                    if (lines == null)
                        throw new Exception("There is not lines in database");
                    if (lines.Count == 0)
                        throw new Exception("There is not lines in database");
                    andonConfig.idLine = lines.First().idLine;
                }
                andonConfig.config = strConfig;
                if (update)
                {
                    andonConfig.idConfig = idConf;
                    if (andonBLL.updateAndonConfig(andonConfig))
                    {
                        //ShowOK("Se actualizo configuracion correctamente");
                        if (chkAlways.Checked)
                            Application.Restart();
                        showApp(andonConfig.startApp);
                    }
                    else
                    {
                        ShowWarning("Something went wrong. Please see log for more details.");
                    }
                }
                else
                {
                    int id = andonBLL.insertAndonConfig(andonConfig);
                    if (id > 0)
                    {
                        ShowOK("Configuration created successfully!");
                        if (chkAlways.Checked)
                            Application.Restart();
                        showApp(andonConfig.startApp);
                        idConf = id;
                        update = true;
                    }
                    else
                    {
                        ShowWarning("Configuration not created. Something went wrong. Please see log for more details.");
                    }
                }
                
            }
            catch (Exception ex)
            {
                ShowWarning(ex.Message);
            }
        }
        private void StartUpConfig_Shown(object sender, EventArgs e)
        {
            try
            {
                AndonBLL andonBLL = new AndonBLL();
                AndonConfig andon = andonBLL.getAndonConfigByHostname(Dns.GetHostName());
                if (andon != null)
                {
                    update = true;
                    idConf = andon.idConfig;
                    showApp(andon.startApp);
                }
            }
            catch (Exception ex)
            {
                ShowWarning(ex.Message);
            }
        }
    }
}
