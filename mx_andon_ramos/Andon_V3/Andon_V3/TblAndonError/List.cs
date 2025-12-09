using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MreaShared;
using MreaShared.BLL;
using MreaShared.Objects;

namespace Andon_V3.TblAndonError
{
    public partial class List : Form
    {
        public List()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                AndonErrorLogBLL logBLL = new AndonErrorLogBLL();
                grdData.AutoGenerateColumns = false;
                var listLog = logBLL.GetAllFromDates(dtpFrom.Value.Date, dtpTo.Value.Date.AddDays(1).AddSeconds(-1));
                if (listLog != null)
                {
                    grdData.DataSource = listLog;
                }
            }
            catch (Exception ex)
            {
                MreaMessage.ShowWarning(ex.Message);
            }
        }
        private void grdData_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (int i = 0; i < grdData.Rows.Count; i++)
            {
                grdData[7, i].Value = "View";
            }
        }

        private void List_Load(object sender, EventArgs e)
        {
            this.Text = "Log report";
        }

        private void grdData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (grdData[e.ColumnIndex, e.RowIndex].GetType() == typeof(DataGridViewLinkCell))

                {
                    string val = grdData[0, e.RowIndex].Value.ToString();
                    if (grdData[e.ColumnIndex, e.RowIndex].Value.ToString() == "View")
                    {
                        ViewDetails view = new ViewDetails();
                        view._idError = Convert.ToInt32(val);
                        var screen = Screen.FromPoint(Cursor.Position);
                        view.StartPosition = FormStartPosition.Manual;
                        view.Left = screen.Bounds.Left + screen.Bounds.Width / 2 - view.Width / 2;
                        view.Top = screen.Bounds.Top + screen.Bounds.Height / 2 - view.Height / 2;
                        view.ShowDialog();
                    }
                }
            }
        }
    }
    
}
