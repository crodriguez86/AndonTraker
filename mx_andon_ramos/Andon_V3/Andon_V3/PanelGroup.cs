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
using System.Net;

namespace Andon_V3
{
    public partial class PanelGroup : Form
    {
        public int _idGroup { get; set; }
        public PanelGroup()
        {
            InitializeComponent();
        }

        private void PanelGroup_Load(object sender, EventArgs e)
        {
            try
            {
                AndonBLL andonBLL = new AndonBLL();
                var config = andonBLL.getAndonConfigByHostname(Dns.GetHostName());
                if (config != null)
                {
                    #region Table config   
                    var rowCount = 2;
                    var columnCount = 3;

                    tablePanelGroup.ColumnCount = columnCount;
                    tablePanelGroup.RowCount = rowCount;

                    tablePanelGroup.ColumnStyles.Clear();
                    tablePanelGroup.RowStyles.Clear();

                    for (int i = 0; i < columnCount; i++)
                    {
                        tablePanelGroup.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100 / columnCount));
                    }
                    for (int i = 0; i < rowCount; i++)
                    {
                        tablePanelGroup.RowStyles.Add(new RowStyle(SizeType.Percent, 100 / rowCount));
                    }
                    #endregion
                    _idGroup = config.idPanelGroup ?? 0;
                    if (_idGroup != 0)
                    {
                        MreaLineBLL lineBLL = new MreaLineBLL();
                        AndonPanelGroupBLL groupBLL = new AndonPanelGroupBLL();
                        var objGroup = groupBLL.GetById(_idGroup);
                        lblDescGroup.Text = objGroup.GroupName;
                        var line = lineBLL.getMreaLine(new MreaLine { idLine = objGroup.IdLine.Value }).First();
                        lblLineName.Text = line.name;
                        AndonPanelViewBLL viewBLL = new AndonPanelViewBLL();
                        var list = viewBLL.GetAllByIdGroup(_idGroup);
                        foreach (var item in list)
                        {
                            Button b = Create_Button(item.PanelName, item.IdPanel);
                            tablePanelGroup.Controls.Add(b);
                        }
                    }
                    else
                    {
                        ShowWarning("Group ID is not valid");
                    }
                }
            }
            catch (Exception ex)
            {
                ShowWarning(ex.Message);
            }
        }
        Button Create_Button(string textButton, int idPanel)
        {
            var b = new Button
            {
                Text = textButton,
                Name = string.Format("btnGroup_{0}", idPanel.ToString()),
                BackColor = Color.DarkBlue,
                Font = new Font(this.Font.FontFamily, 20, FontStyle.Bold),
                ForeColor = Color.White
        };
            b.Click += Event_Click;
            b.Dock = DockStyle.Fill;
            return b;
        } 
        void Event_Click(object sender, EventArgs e)
        {
            if (sender is Button b)
            {
                string btnName = b.Name;
                string idString = btnName.Split('_')[1];
                int.TryParse(idString, out int idPanel);
                if (idPanel != 0)
                {
                    AndonPanelViewBLL viewBLL = new AndonPanelViewBLL();
                    var objPanel = viewBLL.GetById(idPanel);
                    if (objPanel != null)
                    {
                        var panelView = new PanelView();
                        panelView._idPanel = idPanel;
                        panelView._rowCount = objPanel.PanelRows ?? 0;
                        panelView._columnCount = objPanel.PanelColumns ?? 0;
                        panelView.Owner = this;
                        var screen = Screen.FromPoint(Cursor.Position);
                        panelView.StartPosition = FormStartPosition.Manual;
                        panelView.Left = screen.Bounds.Left + screen.Bounds.Width / 2 - panelView.Width / 2;
                        panelView.Top = screen.Bounds.Top + screen.Bounds.Height / 2 - panelView.Height / 2;
                        panelView.Show();
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
