using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MreaShared.Objects;
using MreaShared.BLL;
using System.Configuration;

namespace Andon_V3
{
    public partial class Configuration : Form
    {
        public int IdAV { get; set; }
        public string _employeeName { get; set; }
        public string _lastLogin { get; set; }
        public Configuration()
        {
            InitializeComponent();
        }

        private void Configuration_Load(object sender, EventArgs e)
        {
            ApplyModernTheme();
            loadData();
        }

        private void ApplyModernTheme()
        {
            this.BackColor = Color.FromArgb(248, 250, 252);
            this.Font = new Font("Segoe UI", 9.5f, FontStyle.Regular);

            if (menuStrip1 != null)
            {
                menuStrip1.BackColor = Color.FromArgb(15, 23, 42);
                menuStrip1.ForeColor = Color.White;
                menuStrip1.Font = new Font("Segoe UI", 9.5f, FontStyle.Regular);
                foreach (ToolStripMenuItem item in menuStrip1.Items)
                {
                    item.ForeColor = Color.White;
                }
            }

            if (statusStrip1 != null)
            {
                statusStrip1.BackColor = Color.FromArgb(241, 245, 249);
                statusStrip1.Font = new Font("Segoe UI", 9f, FontStyle.Regular);
                toolStripUserName.ForeColor = Color.FromArgb(30, 41, 59);
                toolStripLastLogin.ForeColor = Color.FromArgb(100, 116, 139);
            }

            if (groupBox1 != null)
            {
                groupBox1.ForeColor = Color.FromArgb(15, 23, 42);
                groupBox1.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
            }

            if (button1 != null)
            {
                button1.FlatStyle = FlatStyle.Flat;
                button1.BackColor = Color.FromArgb(37, 99, 235);
                button1.ForeColor = Color.White;
                button1.FlatAppearance.BorderSize = 0;
                button1.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
                button1.Cursor = Cursors.Hand;
            }

            if (btnNew != null)
            {
                btnNew.FlatStyle = FlatStyle.Flat;
                btnNew.BackColor = Color.FromArgb(16, 185, 129);
                btnNew.ForeColor = Color.White;
                btnNew.FlatAppearance.BorderSize = 0;
                btnNew.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
                btnNew.Cursor = Cursors.Hand;
            }

            if (grdMessages != null)
            {
                grdMessages.BorderStyle = BorderStyle.None;
                grdMessages.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
                grdMessages.GridColor = Color.FromArgb(226, 232, 240);
                grdMessages.EnableHeadersVisualStyles = false;

                grdMessages.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 41, 59);
                grdMessages.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                grdMessages.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
                grdMessages.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                grdMessages.ColumnHeadersHeight = 36;

                grdMessages.DefaultCellStyle.BackColor = Color.White;
                grdMessages.DefaultCellStyle.ForeColor = Color.FromArgb(30, 41, 59);
                grdMessages.DefaultCellStyle.Font = new Font("Segoe UI", 9f, FontStyle.Regular);
                grdMessages.DefaultCellStyle.SelectionBackColor = Color.FromArgb(219, 234, 254);
                grdMessages.DefaultCellStyle.SelectionForeColor = Color.FromArgb(30, 58, 138);
                grdMessages.DefaultCellStyle.Padding = new Padding(4, 2, 4, 2);

                grdMessages.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
                grdMessages.AlternatingRowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(219, 234, 254);
                grdMessages.AlternatingRowsDefaultCellStyle.SelectionForeColor = Color.FromArgb(30, 58, 138);

                grdMessages.RowTemplate.Height = 30;
                grdMessages.BackgroundColor = Color.White;
            }
        }

        private void loadData()
        {
            toolStripLastLogin.Text = "Last login date: " + _lastLogin;
            toolStripUserName.Text = "User: " + _employeeName;
            AndonBLL andonBLL = new AndonBLL();
            grdMessages.AutoGenerateColumns = false;
            List<Andon> list = andonBLL.getLines();
            List<AndonType> list2 = andonBLL.getAndonTypes(new AndonType());

            if (list == null)
            {
                ShowWarning("No se pudo cargar lista de lineas en base de datos");
            }
            else
            {
                if (list2 == null)
                {
                    ShowWarning("No se pudo cargar lista de tipo en base de datos");
                }
                else
                {
                    list2.Insert(0, new AndonType { idType = 0, name = "ALL" });
                    list.Insert(0, new Andon { idLine = 0, nameLine = "ALL" });

                    cmbType.DataSource = list2;
                    cmbType.DisplayMember = "name";
                    cmbType.ValueMember = "idType";
                    cmbLine.DataSource = list;
                    cmbLine.DisplayMember = "nameLine";
                    cmbLine.ValueMember = "idLine";
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (cmbLine.SelectedValue != null)
            {
                if (cmbType.SelectedValue != null)
                {
                    AndonBLL andonBLL = new AndonBLL();
                    var list = andonBLL.getAllMessages();
                    if(list != null)
                    {
                        int line = Convert.ToInt32(cmbLine.SelectedValue.ToString());
                        int type = Convert.ToInt32(cmbType.SelectedValue.ToString());
                        string sIdAv = cmbTag.SelectedValue?.ToString();
                        int idAv = 0;
                        int.TryParse(sIdAv, out idAv);
                        if (line != 0 && type != 0 && idAv != 0)
                        {
                            list = list.FindAll(l => l.idLine == line && l.idType == type && l.idAndonValue == idAv);
                        }else if (line != 0 && type != 0)
                        {
                            list = list.FindAll(l => l.idLine == line && l.idType == type);
                        }
                        else if (line != 0 && idAv != 0)
                        {
                            list = list.FindAll(l => l.idLine == line && l.idAndonValue == idAv);
                            list = list.OrderByDescending(m => m.tagValue).ToList();
                        }
                        else if (line != 0)
                        {
                            list = list.FindAll(l => l.idLine == line);
                        }
                        else if (type != 0)
                        {
                            list = list.FindAll(l => l.idType == type);
                        }
                        lblCountMsg.Text = list.Count().ToString();
                        grdMessages.DataSource = list;
                    }
                    else
                    {
                        ShowWarning("No se pudo cargar mensajes de base datos");
                    }
                }
                else
                {
                    ShowWarning("Por favor selecciona un tipo");
                }
            }
            else
            {
                ShowWarning("Por favor selecciona una linea");
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            NewMessage newMessage = new NewMessage();
            newMessage.FormClosed += new FormClosedEventHandler(Form_Closed);
            newMessage.idLine = cmbLine.SelectedValue != null ? Convert.ToInt32(cmbLine.SelectedValue) : 0;
            newMessage.idType = cmbType.SelectedValue != null ? Convert.ToInt32(cmbType.SelectedValue) : 0;
            newMessage.idAndonValue = cmbTag.SelectedValue != null ? Convert.ToInt32(cmbTag.SelectedValue) : 0;
            var screen = Screen.FromPoint(Cursor.Position);
            newMessage.StartPosition = FormStartPosition.Manual;
            newMessage.Left = screen.Bounds.Left + screen.Bounds.Width / 2 - newMessage.Width / 2;
            newMessage.Top = screen.Bounds.Top + screen.Bounds.Height / 2 - newMessage.Height / 2;
            newMessage.ShowDialog();
        }

        private void grdMessages_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.grdMessages.Rows[e.RowIndex];
                int idMsg = Convert.ToInt32(row.Cells[0].Value);
                NewMessage newMessage = new NewMessage();
                newMessage.FormClosed += new FormClosedEventHandler(Form_Closed);
                newMessage.idMessage = idMsg;
                newMessage.update = true;
                newMessage.Show();
            }
        }

        void Form_Closed(object sender, FormClosedEventArgs e)
        {
            button1_Click(null, null);
        }
        private void ShowWarning(string msg)
        {
            MessageBox.Show(msg, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        private void ShowOK(string msg)
        {
            MessageBox.Show(msg, "Done!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string line = cmbLine.SelectedValue?.ToString();
            string type = cmbType.SelectedValue?.ToString();
            cmbTag.Enabled = false;
            if (int.TryParse(line, out int idLine) && int.TryParse(type, out int idType))
            {
                List<Andon> list = new List<Andon>();
                AndonBLL andonBLL = new AndonBLL();
                list = andonBLL.getTagNamesByLineAndType(idLine, idType);

                if (list != null)
                {
                    list.Insert(0, new Andon { idAndonValue = 0, tagName = "ALL" });
                    cmbTag.DataSource = list;
                    cmbTag.DisplayMember = "tagName";
                    cmbTag.ValueMember = "idAndonValue";
                    cmbTag.Enabled = true;
                }
            }
        }

        private void addLineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Lines.List list = new Lines.List();
            var screen = Screen.FromPoint(Cursor.Position);
            list.StartPosition = FormStartPosition.Manual;
            list.Left = screen.Bounds.Left + screen.Bounds.Width / 2 - list.Width / 2;
            list.Top = screen.Bounds.Top + screen.Bounds.Height / 2 - list.Height / 2;
            list.Show();
        }

        private void pLCsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PLCs.List list = new PLCs.List();
            var screen = Screen.FromPoint(Cursor.Position);
            list.StartPosition = FormStartPosition.Manual;
            list.Left = screen.Bounds.Left + screen.Bounds.Width / 2 - list.Width / 2;
            list.Top = screen.Bounds.Top + screen.Bounds.Height / 2 - list.Height / 2;
            list.Show();
        }

        private void tagValuesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TagValues.List list = new TagValues.List();
            var screen = Screen.FromPoint(Cursor.Position);
            list.StartPosition = FormStartPosition.Manual;
            list.Left = screen.Bounds.Left + screen.Bounds.Width / 2 - list.Width / 2;
            list.Top = screen.Bounds.Top + screen.Bounds.Height / 2 - list.Height / 2;
            list.Show();
        }

        private void typesOfSupportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Types.List list = new Types.List();
            var screen = Screen.FromPoint(Cursor.Position);
            list.StartPosition = FormStartPosition.Manual;
            list.Left = screen.Bounds.Left + screen.Bounds.Width / 2 - list.Width / 2;
            list.Top = screen.Bounds.Top + screen.Bounds.Height / 2 - list.Height / 2;
            list.Show();
        }

        private void emailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Emails.List list = new Emails.List();
            var screen = Screen.FromPoint(Cursor.Position);
            list.StartPosition = FormStartPosition.Manual;
            list.Left = screen.Bounds.Left + screen.Bounds.Width / 2 - list.Width / 2;
            list.Top = screen.Bounds.Top + screen.Bounds.Height / 2 - list.Height / 2;
            list.Show();
        }

        private void fontsizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Fonsize.List list = new Fonsize.List();
            var screen = Screen.FromPoint(Cursor.Position);
            list.StartPosition = FormStartPosition.Manual;
            list.Left = screen.Bounds.Left + screen.Bounds.Width / 2 - list.Width / 2;
            list.Top = screen.Bounds.Top + screen.Bounds.Height / 2 - list.Height / 2;
            list.Show();
        }

        private void fontColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontColor.List list = new FontColor.List();
            var screen = Screen.FromPoint(Cursor.Position);
            list.StartPosition = FormStartPosition.Manual;
            list.Left = screen.Bounds.Left + screen.Bounds.Width / 2 - list.Width / 2;
            list.Top = screen.Bounds.Top + screen.Bounds.Height / 2 - list.Height / 2;
            list.Show();
        }

        private void backgroundColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BackColor.List list = new BackColor.List();
            var screen = Screen.FromPoint(Cursor.Position);
            list.StartPosition = FormStartPosition.Manual;
            list.Left = screen.Bounds.Left + screen.Bounds.Width / 2 - list.Width / 2;
            list.Top = screen.Bounds.Top + screen.Bounds.Height / 2 - list.Height / 2;
            list.Show();
        }

        private void zonesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Zones.List list = new Zones.List();
            var screen = Screen.FromPoint(Cursor.Position);
            list.StartPosition = FormStartPosition.Manual;
            list.Left = screen.Bounds.Left + screen.Bounds.Width / 2 - list.Width / 2;
            list.Top = screen.Bounds.Top + screen.Bounds.Height / 2 - list.Height / 2;
            list.Show();
        }

        private void manageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Notifications.Manage manage = new Notifications.Manage();
            var screen = Screen.FromPoint(Cursor.Position);
            manage.StartPosition = FormStartPosition.Manual;
            manage.Left = screen.Bounds.Left + screen.Bounds.Width / 2 - manage.Width / 2;
            manage.Top = screen.Bounds.Top + screen.Bounds.Height / 2 - manage.Height / 2;
            manage.Show();
        }

        private void emailByLevelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Notifications.ManageLevel manage = new Notifications.ManageLevel();
            var screen = Screen.FromPoint(Cursor.Position);
            manage.StartPosition = FormStartPosition.Manual;
            manage.Left = screen.Bounds.Left + screen.Bounds.Width / 2 - manage.Width / 2;
            manage.Top = screen.Bounds.Top + screen.Bounds.Height / 2 - manage.Height / 2;
            manage.Show();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            loadData();
        }
        private void grdMessages_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (int i = 0; i < grdMessages.Rows.Count; i++)
            {
                grdMessages[10, i].Value = "Update";
                grdMessages[11, i].Value = "Delete";
                grdMessages[12, i].Value = "Copy";
            }
        }

        private void grdMessages_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (grdMessages[e.ColumnIndex, e.RowIndex].GetType() == typeof(DataGridViewLinkCell))

                {
                    string val = grdMessages[0, e.RowIndex].Value.ToString();
                    if (grdMessages[e.ColumnIndex, e.RowIndex].Value.ToString() == "Update")
                    {
                        NewMessage newMessage = new NewMessage();
                        newMessage.FormClosed += new FormClosedEventHandler(Form_Closed);
                        newMessage.idMessage = Convert.ToInt32(val);
                        newMessage.update = true;
                        newMessage.Show();
                    }
                    else if (grdMessages[e.ColumnIndex, e.RowIndex].Value.ToString() == "Delete")
                    {
                        DialogResult dr = MessageBox.Show("Are you sure want to delete?", "Confirm delete", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);

                        if (dr == DialogResult.Yes)
                        {
                            int idMessage = Convert.ToInt32(val);
                            //Eliminar mensaje
                            AndonBLL andonBLL = new AndonBLL();
                            bool res = andonBLL.deleteAndonMessage(idMessage);
                            if (res)
                            {
                                ShowOK("Deleted successfully!");
                                button1_Click(null, null);
                                
                            }
                            else
                            {
                                ShowWarning("Something went wrong. Please see log for more details");
                            }
                        }
                    }
                    else
                    {
                        if (grdMessages[e.ColumnIndex, e.RowIndex].Value.ToString() == "Copy")
                        {
                            NewMessage newMessage = new NewMessage();
                            newMessage.FormClosed += new FormClosedEventHandler(Form_Closed);
                            newMessage.idMessage = Convert.ToInt32(val);
                            newMessage.update = false;
                            newMessage.Show();
                        }
                    }
                }
            }
        }

        private void reloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void cmbLine_SelectedIndexChanged(object sender, EventArgs e)
        {
            string line = cmbLine.SelectedValue?.ToString();
            cmbTag.Enabled = false;
            if (int.TryParse(line, out int idLine))
            {
                List<Andon> list = new List<Andon>();
                AndonBLL andonBLL = new AndonBLL();
                list = andonBLL.getTagNamesByLineAndType(idLine, 0);

                if (list != null)
                {
                    list.Insert(0, new Andon { idAndonValue = 0, tagName = "ALL" });
                    cmbTag.DataSource = list;
                    cmbTag.DisplayMember = "tagName";
                    cmbTag.ValueMember = "idAndonValue";
                    cmbTag.Enabled = true;
                }
            }
        }
        private void grdMessages_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Ignore if a column or row header is clicked
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                if (e.Button == MouseButtons.Right)
                {
                    string strIdAV = grdMessages[13, e.RowIndex].Value.ToString();
                    IdAV = Convert.ToInt32(strIdAV);
                    DataGridViewCell clickedCell = (sender as DataGridView).Rows[e.RowIndex].Cells[e.ColumnIndex];

                    // Here you can do whatever you want with the cell
                    this.grdMessages.CurrentCell = clickedCell;  // Select the clicked cell, for instance

                    // Get mouse position relative to the vehicles grid
                    var relativeMousePosition = grdMessages.PointToClient(Cursor.Position);

                    // Show the context menu
                    this.contextMenuStrip1.Show(grdMessages, relativeMousePosition);
                }
            }
        }

        private void realtimeTAGMonitorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (IdAV > 0)
            {
                TagMonitor.Monitor monitor = new TagMonitor.Monitor();
                monitor.id = IdAV;
                var screen = Screen.FromPoint(Cursor.Position);
                monitor.StartPosition = FormStartPosition.Manual;
                monitor.Left = screen.Bounds.Left + screen.Bounds.Width / 2 - monitor.Width / 2;
                monitor.Top = screen.Bounds.Top + screen.Bounds.Height / 2 - monitor.Height / 2;
                monitor.Show();
            }
        }

        private void andonConfigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AndonConfig2.List list = new AndonConfig2.List();
            var screen = Screen.FromPoint(Cursor.Position);
            list.StartPosition = FormStartPosition.Manual;
            list.Left = screen.Bounds.Left + screen.Bounds.Width / 2 - list.Width / 2;
            list.Top = screen.Bounds.Top + screen.Bounds.Height / 2 - list.Height / 2;
            list.Show();
        }

        private void sendNowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string emails = Convert.ToString(ConfigurationManager.AppSettings["emailsStatusReport"]);
            MreaMailBLL mreaMailBLL = new MreaMailBLL();
            if (mreaMailBLL.CheckStatusAndon(emails))
            {
                ShowOK("Se envio correo correctamente");
            }
            else
            {
                ShowWarning("Se origino un error al enviar correo");
            }
        }

        private void previewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AndonConfig2.StatusWebView window = new AndonConfig2.StatusWebView();
            var screen = Screen.FromPoint(Cursor.Position);
            window.StartPosition = FormStartPosition.Manual;
            window.Left = screen.Bounds.Left + screen.Bounds.Width / 2 - window.Width / 2;
            window.Top = screen.Bounds.Top + screen.Bounds.Height / 2 - window.Height / 2;
            window.Show();
        }

        private void panelsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TblPanelGroup.List window = new TblPanelGroup.List();
            var screen = Screen.FromPoint(Cursor.Position);
            window.StartPosition = FormStartPosition.Manual;
            window.Left = screen.Bounds.Left + screen.Bounds.Width / 2 - window.Width / 2;
            window.Top = screen.Bounds.Top + screen.Bounds.Height / 2 - window.Height / 2;
            window.Show();
        }

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void deleteAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //View logs from text files
            TblAndonError.ListLogFiles window = new TblAndonError.ListLogFiles();
            var screen = Screen.FromPoint(Cursor.Position);
            window.StartPosition = FormStartPosition.Manual;
            window.Left = screen.Bounds.Left + screen.Bounds.Width / 2 - window.Width / 2;
            window.Top = screen.Bounds.Top + screen.Bounds.Height / 2 - window.Height / 2;
            window.ShowDialog();
        }

        private void viewToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TblHistory.List window = new TblHistory.List();
            var screen = Screen.FromPoint(Cursor.Position);
            window.StartPosition = FormStartPosition.Manual;
            window.Left = screen.Bounds.Left + screen.Bounds.Width / 2 - window.Width / 2;
            window.Top = screen.Bounds.Top + screen.Bounds.Height / 2 - window.Height / 2;
            window.ShowDialog();
        }

        private void viewToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            TblAndonError.List window = new TblAndonError.List();
            var screen = Screen.FromPoint(Cursor.Position);
            window.StartPosition = FormStartPosition.Manual;
            window.Left = screen.Bounds.Left + screen.Bounds.Width / 2 - window.Width / 2;
            window.Top = screen.Bounds.Top + screen.Bounds.Height / 2 - window.Height / 2;
            window.ShowDialog();
        }

        private void deleteAllToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure want to delete all?", "Confirm delete", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);

            if (dr == DialogResult.Yes)
            {
                //Eliminar mensaje
                AndonErrorLogBLL logBLL = new AndonErrorLogBLL();
                bool res = logBLL.DeleteAll();
                if (res)
                {
                    ShowOK("Deleted successfully!");
                }
                else
                {
                    ShowWarning("Something went wrong. Please see log for more details");
                }
            }
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TblUser.List window = new TblUser.List();
            var screen = Screen.FromPoint(Cursor.Position);
            window.StartPosition = FormStartPosition.Manual;
            window.Left = screen.Bounds.Left + screen.Bounds.Width / 2 - window.Width / 2;
            window.Top = screen.Bounds.Top + screen.Bounds.Height / 2 - window.Height / 2;
            window.ShowDialog();
        }
    }
}
