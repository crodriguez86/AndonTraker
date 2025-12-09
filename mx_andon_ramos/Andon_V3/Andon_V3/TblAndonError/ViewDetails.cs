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

namespace Andon_V3.TblAndonError
{
    public partial class ViewDetails : Form
    {
        public int _idError { get; set; }
        public ViewDetails()
        {
            InitializeComponent();
        }

        private void ViewDetails_Load(object sender, EventArgs e)
        {
            if (_idError > 0)
            {
                AndonErrorLogBLL errorLogBLL = new AndonErrorLogBLL();
                AndonBLL andonBLL = new AndonBLL();
                var error = errorLogBLL.GetById(_idError);
                if (error == null)
                    MreaMessage.ShowWarning("Error can't be loaded. Something went wrong. Error: " + errorLogBLL._error);
                var listApp = andonBLL.getAndonApp(new AndonApp { idApp = error.idApp });
                if(listApp == null)
                    MreaMessage.ShowWarning("App can't be loaded. Something went wrong.");
                if (listApp.Count <= 0)
                    MreaMessage.ShowWarning("App can't be loaded. Something went wrong.");
                var app = listApp.First();
                lblId.Text = error.idError.ToString();
                lblErrorDate.Text = error.errorDate.ToString();
                lblHostname.Text = error.deviceName;
                lblIpAddress.Text = error.ipAddress;
                lblApp.Text = app.name;
                lblMessage.Text = error.message;
                txtStackTrace.Text = error.stackTrace;

            }
            else
            {
                MreaMessage.ShowWarning("Error ID is not valid.");
            }
        }
    }
}
