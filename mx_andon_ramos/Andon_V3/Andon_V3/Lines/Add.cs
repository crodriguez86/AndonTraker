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

namespace Andon_V3.Lines
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
            MreaLineBLL objBLL = new MreaLineBLL();
            int.TryParse(Convert.ToString(cmbZones.SelectedValue), out int idZone);
            if (txtName.Text != string.Empty)
            {
                if (idZone > 0)
                {
                    MreaLine obj = new MreaLine();
                    obj.name = txtName.Text;
                    obj.desc = txtDesc.Text;
                    obj.idZone = idZone;
                    obj.idLine = id;
                    if (update)
                    {
                        bool valid = objBLL.updateMreaLine(obj);
                        if (valid)
                            ShowOK("Line updated successfully!");
                        else
                            ShowWarning("Line not updated. Something went wrong. Please see log for more details.");
                        this.Close();
                    }
                    else
                    {
                        int id = objBLL.insertMreaLine(obj);
                        if (id > 0)
                            ShowOK("Line created successfully!");
                        else
                            ShowWarning("Line not created. Something went wrong. Please see log for more details.");
                        this.Close();
                    }
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
            ZoneBLL zoneBLL = new ZoneBLL();
            List<Zone> listZones = new List<Zone>();
            listZones = zoneBLL.getZone(new Zone());
            if (listZones == null)
                ShowWarning("Can't load zones from database. Please see log for more details.");

            cmbZones.DataSource = listZones;
            cmbZones.DisplayMember = "name";
            cmbZones.ValueMember = "idZone";

            if (id > 0)
            {
                MreaLineBLL objBLL = new MreaLineBLL();
                MreaLine objParam = new MreaLine();
                objParam.idLine = id;
                List<MreaLine> listObj = objBLL.getMreaLine(objParam);
                if (listObj != null)
                {
                    if (listObj.Any())
                    {
                        txtName.Text = listObj.First().name;
                        txtDesc.Text = listObj.First().desc;
                        cmbZones.SelectedValue = listObj.First().idZone;
                        update = true;
                        lblAction.Text = "UPDATE";
                    }
                }
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
