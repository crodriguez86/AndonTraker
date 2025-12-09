using MreaShared.BLL;
using MreaShared.Objects;
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

namespace Andon_V3.TblPanelButton
{
    public partial class List : Form
    {
        public List()
        {
            InitializeComponent();
        }

        public int _id { get; set; }
        private void List_Load(object sender, EventArgs e)
        {

            loadData();
            
        }
        private void loadData()
        {
            AndonPanelButtonBLL objBLL = new AndonPanelButtonBLL();
            grdData.AutoGenerateColumns = false;
            List<AndonPanelButton> list = objBLL.GetAllByIdPanel(_id);
            if (list != null)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    list[i].Msg = list[i].Msg + "-" + list[i].NameType;
                    if (list[i].ButtonTowerConfig != null)
                    {
                        if (list[i].ButtonTowerConfig == 1)
                        {
                            list[i].ButtonTowerConfigName = "Default IP";
                        }else if (list[i].ButtonTowerConfig == 2)
                        {
                            list[i].ButtonTowerConfigName = "Own IP";
                        }else if (list[i].ButtonTowerConfig == 3)
                        {
                            list[i].ButtonTowerConfigName = "Both IP";
                        }
                    }
                }
                grdData.DataSource = list;
            }
            else
            {
                MreaMessage.ShowWarning("Can't load panel buttons from database. " + objBLL._error);
            }

        }

        private void grdLines_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (grdData[e.ColumnIndex, e.RowIndex].GetType() == typeof(DataGridViewLinkCell))

                {
                    string val = grdData[0, e.RowIndex].Value.ToString();
                    if (grdData[e.ColumnIndex, e.RowIndex].Value.ToString() == "Update")
                    {
                        Add add = new Add();
                        add.FormClosed += new FormClosedEventHandler(Form_Closed);
                        add.id = Convert.ToInt32(val);
                        add.idPanel = _id;
                        var screen = Screen.FromPoint(Cursor.Position);
                        add.StartPosition = FormStartPosition.Manual;
                        add.Left = screen.Bounds.Left + screen.Bounds.Width / 2 - add.Width / 2;
                        add.Top = screen.Bounds.Top + screen.Bounds.Height / 2 - add.Height / 2;
                        add.ShowDialog();
                    }
                    else if (grdData[e.ColumnIndex, e.RowIndex].Value.ToString() == "Delete")
                    {
                        DialogResult dr = MessageBox.Show("Are you sure want to delete?", "Confirm delete", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);

                        if (dr == DialogResult.Yes)
                        {
                            int id = Convert.ToInt32(val);
                            //Eliminar registro
                            AndonPanelButtonBLL objBLL = new AndonPanelButtonBLL();
                            bool res = objBLL.Delete(id);
                            if (res)
                            {
                                MreaMessage.ShowOK("Deleted successfully!");
                            }
                            else
                            {
                                MreaMessage.ShowWarning("Something went wrong. " + objBLL._error);
                            }
                        }
                        loadData();
                    }
                    else if (grdData[e.ColumnIndex, e.RowIndex].Value.ToString() == "Test")
                    {
                        try
                        {
                            int id = Convert.ToInt32(val);
                            AndonPanelButtonBLL objBLL = new AndonPanelButtonBLL();
                            AndonPanelViewBLL objViewBLL = new AndonPanelViewBLL();
                            AndonPanelGroupBLL objGroupBLL = new AndonPanelGroupBLL();
                            var obj = objBLL.GetById(id);
                            var objView = objViewBLL.GetById(obj.IdPanel ?? 0);
                            var objGroup = objGroupBLL.GetById(objView.IdGroup ?? 0);
                            if (objGroup.GroupTowerActive == true)
                            {
                                string defaultIp = objBLL.GetGlobalIpTower(obj.IdPanel ?? 0);
                                string command = string.Empty;
                                string command2 = string.Empty;
                                if (obj.ButtonTowerConfig == 1)
                                {
                                    if (string.IsNullOrWhiteSpace(defaultIp))
                                        throw new Exception("Default IP is empty.");
                                    if (string.IsNullOrWhiteSpace(obj.ButtonTowerCommand))
                                        throw new Exception("The command is empty.");
                                    command = defaultIp + obj.ButtonTowerCommand;
                                    SendRequestToTower(command);
                                }
                                else if (obj.ButtonTowerConfig == 2)
                                {
                                    if (string.IsNullOrWhiteSpace(obj.ButtonTowerIp))
                                        throw new Exception("The IP is empty.");
                                    if (string.IsNullOrWhiteSpace(obj.ButtonTowerCommand))
                                        throw new Exception("The command is empty.");
                                    command = obj.ButtonTowerIp + obj.ButtonTowerCommand;
                                    SendRequestToTower(command);
                                }
                                else if (obj.ButtonTowerConfig == 3)
                                {
                                    if (string.IsNullOrWhiteSpace(defaultIp))
                                        throw new Exception("Default IP is empty.");
                                    if (string.IsNullOrWhiteSpace(obj.ButtonTowerIp))
                                        throw new Exception("The IP is empty.");
                                    if (string.IsNullOrWhiteSpace(obj.ButtonTowerCommand))
                                        throw new Exception("The command is empty.");
                                    if (string.IsNullOrWhiteSpace(obj.ButtonTowerCommand2))
                                        throw new Exception("The second command is empty.");
                                    command = obj.ButtonTowerIp + obj.ButtonTowerCommand;
                                    command2 = defaultIp + obj.ButtonTowerCommand2;
                                    SendRequestToTower(command);
                                    SendRequestToTower(command2);
                                }
                                else
                                {
                                    MreaMessage.ShowWarning("There is no configuration for this button.");
                                }

                            }
                            else
                            {
                                MreaMessage.ShowWarning("Tower is not active");
                            }
                            
                        }
                        catch (Exception ex)
                        {

                            MreaMessage.ShowWarning(ex.Message);
                        }
                    }
                }
            }
        }
        private void grdLines_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (int i = 0; i < grdData.Rows.Count; i++)
            {
                grdData[12, i].Value = "Update";
                grdData[13, i].Value = "Delete";
                grdData[14, i].Value = "Test";
            }
        }
        void Form_Closed(object sender, FormClosedEventArgs e)
        {
            loadData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Add add = new Add();
            add.FormClosed += new FormClosedEventHandler(Form_Closed);
            add.idPanel = _id;
            var screen = Screen.FromPoint(Cursor.Position);
            add.StartPosition = FormStartPosition.Manual;
            add.Left = screen.Bounds.Left + screen.Bounds.Width / 2 - add.Width / 2;
            add.Top = screen.Bounds.Top + screen.Bounds.Height / 2 - add.Height / 2;
            add.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            AndonPanelButtonBLL objBLL = new AndonPanelButtonBLL();
            grdData.AutoGenerateColumns = false;
            List<AndonPanelButton> list = objBLL.GetAllByIdPanel(_id);
            if (list != null)
            {
                list = list.Where(p => p.ButtonName.Contains(textBox1.Text)).ToList();
                grdData.DataSource = list;
            }
            else
            {
                MreaMessage.ShowWarning("Can't load panel buttons from database. " + objBLL._error);
            }
        }
        private void SendRequestToTower(string command)
        {
            try
            {
                Uri url = new Uri(command);
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                request.Method = "GET";
                request.ContentType = "text/html";
                request.Timeout = 10000;
                string results = string.Empty;
                HttpWebResponse response;
                using (response = request.GetResponse() as HttpWebResponse)
                {
                    StreamReader reader = new StreamReader(response.GetResponseStream());
                    results = reader.ReadToEnd();
                }
                MreaMessage.ShowOK(command + "\n\n" + results);
            }
            catch (Exception ex)
            {
                MreaMessage.ShowWarning(command + "\n\n" + ex.Message);
            }
        }
    }
}
