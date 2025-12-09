using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using MreaShared.BLL;
using MreaShared.Objects;

namespace Andon_V3.TblPanelGroup
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
                AndonPanelGroupBLL objBLL = new AndonPanelGroupBLL();

                if (string.IsNullOrEmpty(txtName.Text))
                    throw new Exception("Name required.");

                AndonPanelGroup obj = new AndonPanelGroup();
                obj.GroupName = txtName.Text;
                obj.GroupDesc = txtDesc.Text;
                int.TryParse(cmbLine.SelectedValue.ToString(), out int idLine);
                if (idLine == 0)
                    throw new Exception("Please select a line from combo box.");
                obj.IdGroup = id;
                obj.IdLine = idLine;
                obj.GroupTowerActive = chkTowerActive.Checked;
                if (obj.GroupTowerActive.Value)
                {
                    obj.GroupTowerIp = txtTowerIp.Text;
                    obj.GroupTowerTestCommand = txtTowerTestCmd.Text;
                    obj.GroupTowerClearCommand = txtClearCmd.Text;
                }
                else
                {
                    obj.GroupTowerIp = null;
                    obj.GroupTowerTestCommand = null;
                    obj.GroupTowerClearCommand = null;
                }
                if (update)
                {
                    bool valid = objBLL.Update(obj);
                    if (valid)
                        ShowOK("Panel Group updated successfully ID: (" + id + ")");
                    else
                        ShowWarning("Panel Group not updated. Something went wrong. " + objBLL._error);
                    this.Close();
                }
                else
                {

                    int id = objBLL.Insert(obj);
                    if (id > 0)
                        ShowOK("Panel Group created successfully ID: (" + id + ")");
                    else
                        ShowWarning("Panel Group not created. Something went wrong. " + objBLL._error);
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
            SetTowerVisible(true);
            lblAction.Text = "INSERT";
            AndonBLL andonBLL = new AndonBLL();
            List<Andon> list = andonBLL.getLines();
            if (list == null)
                ShowWarning("Can't load lines from database. Please see log for more details.");
            cmbLine.DataSource = list;
            cmbLine.DisplayMember = "nameLine";
            cmbLine.ValueMember = "idLine";
            if (id > 0)
            {
                AndonPanelGroupBLL objBLL = new AndonPanelGroupBLL();
                var obj = objBLL.GetById(id);
                if (obj != null)
                {
                    txtName.Text = obj.GroupName;
                    txtDesc.Text = obj.GroupDesc;
                    cmbLine.SelectedValue = obj.IdLine;
                    chkTowerActive.Checked = obj.GroupTowerActive ?? false;
                    if (chkTowerActive.Checked)
                    {
                        SetTowerVisible(true);
                        txtTowerIp.Text = obj.GroupTowerIp;
                        txtTowerTestCmd.Text = obj.GroupTowerTestCommand;
                        txtClearCmd.Text = obj.GroupTowerClearCommand;
                    }
                    else
                    {
                        SetTowerVisible(false);
                    }
                    update = true;
                    lblAction.Text = "UPDATE";
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTowerActive.Checked)
            {
                SetTowerVisible(true);
            }
            else
            {
                SetTowerVisible(false);
            }
        }
        private void SetTowerVisible(bool visible)
        {
            lblTowerIp.Visible = visible;
            lblTowerCmd.Visible = visible;
            txtTowerIp.Visible = visible;
            txtTowerTestCmd.Visible = visible;
            btnTowerTest.Visible = visible;
            txtTowerResult.Visible = visible;
            lblClearCmd.Visible = visible;
            txtClearCmd.Visible = visible;
            btnTowerClear.Visible = visible;
        }

        private void btnTowerTest_Click(object sender, EventArgs e)
        {
            try
            {
                string command = txtTowerIp.Text + txtTowerTestCmd.Text;
                Uri url = new Uri(command);
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                request.Method = "GET";
                request.ContentType = "text/html";
                request.Timeout = 10000;
                string results = string.Empty;
                HttpWebResponse response;
                results += "Url: " + command + "\n\n";
                using (response = request.GetResponse() as HttpWebResponse)
                {
                    StreamReader reader = new StreamReader(response.GetResponseStream());
                    results += "Response: " + reader.ReadToEnd() + "\n";
                }
                txtTowerResult.Text = results;
            }
            catch (Exception ex)
            {

                ShowWarning(ex.Message);
            }
        }

        private void btnTowerClear_Click(object sender, EventArgs e)
        {
            try
            {
                string command = txtTowerIp.Text + txtClearCmd.Text;
                Uri url = new Uri(command);
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                request.Method = "GET";
                request.ContentType = "text/html";
                request.Timeout = 10000;
                string results = string.Empty;
                HttpWebResponse response;
                results += "Url: " + command + "\n\n";
                using (response = request.GetResponse() as HttpWebResponse)
                {
                    StreamReader reader = new StreamReader(response.GetResponseStream());
                    results += "Response: " + reader.ReadToEnd() + "\n";
                }
                txtTowerResult.Text = results;
            }
            catch (Exception ex)
            {

                ShowWarning(ex.Message);
            }
        }
    }
}
