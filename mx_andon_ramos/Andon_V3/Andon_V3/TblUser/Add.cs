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

namespace Andon_V3.TblUser
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
                UserBLL objBLL = new UserBLL();

                if (string.IsNullOrEmpty(txtNoEmployee.Text))
                    throw new Exception("No Employee is required.");
                if (string.IsNullOrEmpty(txtName.Text))
                    throw new Exception("Name is required.");
                if (string.IsNullOrEmpty(txtPassword.Text))
                    throw new Exception("Password is required.");
                if (string.IsNullOrEmpty(txtConfirm.Text))
                    throw new Exception("Password Confirm is required.");

                Users obj = new Users();
                obj.NoEmployee = txtNoEmployee.Text.Trim();
                obj.AuthName = txtName.Text;
                if (txtPassword.Text.Trim() != txtConfirm.Text.Trim())
                    throw new Exception("Password and Confirm must match.");
                obj.AuthPass = txtPassword.Text.Trim();
                obj.IdAuth = id;
                if (update)
                {
                    //Validar que el antiguo numero de empleado y contraseña sean validos
                    bool found = objBLL.ValidUserByEmployeeAndPassword(obj.NoEmployee, txtOldPassword.Text.Trim());
                    if (!found)
                        throw new Exception("Old password is no correct. Please verify.");
                    bool valid = objBLL.Update(obj);
                    if (valid)
                        MreaMessage.ShowOK("User updated successfully ID: (" + id + ")");
                    else
                        MreaMessage.ShowWarning("User not updated. Something went wrong. " + objBLL._error);
                    this.Close();
                }
                else
                {
                    var user = objBLL.GetByNoEmployee(txtNoEmployee.Text.Trim());
                    if (user != null)
                        throw new Exception("This No Employee already exists. Please verify.");
                    int id = objBLL.Insert(obj);
                    if (id > 0)
                        MreaMessage.ShowOK("User created successfully ID: (" + id + ")");
                    else
                        MreaMessage.ShowWarning("User not created. Something went wrong. " + objBLL._error);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MreaMessage.ShowWarning(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Add_Load(object sender, EventArgs e)
        {

            lblAction.Text = "INSERT";
            lblOldPassword.Visible = false;
            txtOldPassword.Visible = false;
            txtNoEmployee.ReadOnly = false;
            if (id > 0)
            {
                UserBLL objBLL = new UserBLL();
                var obj = objBLL.GetById(id);
                if (obj != null)
                {
                    txtNoEmployee.Text = obj.NoEmployee;
                    txtName.Text = obj.AuthName;
                    update = true;
                    lblAction.Text = "UPDATE";
                    lblOldPassword.Visible = true;
                    txtOldPassword.Visible = true;
                    txtNoEmployee.ReadOnly = true;
                }
            }
        }
    }
}
