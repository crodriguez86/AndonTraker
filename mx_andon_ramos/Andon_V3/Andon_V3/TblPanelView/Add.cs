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

namespace Andon_V3.TblPanelView
{
    public partial class Add : Form
    {
        public int id = -1;
        public int idGroup = -1;
        public bool update = false;
        public Add()
        {
            InitializeComponent();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            try
            {
                AndonPanelViewBLL objBLL = new AndonPanelViewBLL();

                if (string.IsNullOrEmpty(txtName.Text))
                    throw new Exception("Name required.");

                AndonPanelView obj = new AndonPanelView();
                obj.PanelName = txtName.Text;
                obj.PanelDesc = txtDesc.Text;
                obj.PanelColumns = Convert.ToInt32(nmbColumn.Value);
                obj.PanelRows = Convert.ToInt32(nmbRow.Value);
                obj.IdGroup = idGroup;
                obj.IdPanel = id;
                if (update)
                {
                    bool valid = objBLL.Update(obj);
                    if (valid)
                        ShowOK("Panel view updated successfully ID: (" + id + ")");
                    else
                        ShowWarning("Panel view not updated. Something went wrong. " + objBLL._error);
                    this.Close();
                }
                else
                {

                    int id = objBLL.Insert(obj);
                    if (id > 0)
                        ShowOK("Panel view created successfully ID: (" + id + ")");
                    else
                        ShowWarning("Panel view not created. Something went wrong. " + objBLL._error);
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

            lblAction.Text = "INSERT";
            if (id > 0)
            {
                AndonPanelViewBLL objBLL = new AndonPanelViewBLL();
                var obj = objBLL.GetById(id);
                if (obj != null)
                {
                    txtName.Text = obj.PanelName;
                    txtDesc.Text = obj.PanelDesc;
                    nmbColumn.Value = Convert.ToInt32(obj.PanelColumns);
                    nmbRow.Value = Convert.ToInt32(obj.PanelRows);
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
    }
}
