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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNoNomina.Text))
                    throw new Exception("No Employee is required.");
                if (string.IsNullOrWhiteSpace(txtPassword.Text))
                    throw new Exception("Password is required.");
                UserBLL authEmpBLL = new UserBLL();
                if(authEmpBLL.ValidUserByEmployeeAndPassword(txtNoNomina.Text.Trim(), txtPassword.Text.Trim()))
                {
                    var user = authEmpBLL.GetByNoEmployee(txtNoNomina.Text.Trim());
                    Configuration configuration = new Configuration();
                    var screen = Screen.FromPoint(Cursor.Position);
                    configuration.StartPosition = FormStartPosition.Manual;
                    configuration.Left = screen.Bounds.Left + screen.Bounds.Width / 2 - configuration.Width / 2;
                    configuration.Top = screen.Bounds.Top + screen.Bounds.Height / 2 - configuration.Height / 2;
                    configuration._employeeName = user.AuthName;
                    configuration._lastLogin = user.AuthLastLogin == null ? "First Login" : user.AuthLastLogin.Value.ToString();
                    user.AuthLastLogin = DateTime.Now;
                    authEmpBLL.UpdateLastLoginDate(user);
                    configuration.Show();
                    this.Close();
                }
                else
                {
                    ShowWarning("User or password are not correct. Please try again.");
                }
            }
            catch (Exception ex)
            {
                ShowWarning(ex.Message);
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

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                button1_Click(null, null);
            }
        }
    }
}
