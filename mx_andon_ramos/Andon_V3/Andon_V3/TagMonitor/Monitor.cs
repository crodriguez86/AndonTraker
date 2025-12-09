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

namespace Andon_V3.TagMonitor
{
    public partial class Monitor : Form
    {
        public int id = -1;
        public Monitor()
        {
            InitializeComponent();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Add_Load(object sender, EventArgs e)
        {
            AndonPlcBLL objBLL = new AndonPlcBLL();
            

            if (id > 0)
            {
                AndonValueBLL objABLL = new AndonValueBLL();
                AndonValues objParam = new AndonValues();
                objParam.idAv = id;
                List<AndonValues> listObj = objABLL.getAndonValues(objParam);
                if (listObj != null)
                {
                    if (listObj.Any())
                    {
                        List<AndonPlc> list3 = objBLL.getAndonPlc(new AndonPlc { idPlc = listObj.First().idPlc });
                        if (list3 == null)
                            ShowWarning("No se obtuvieron PLC's en base de datos");
                        lblPLC.Text = list3.First().name;
                        lblTagName.Text = listObj.First().tagName;
                        lblIP.Text = list3.First().ip;
                        lblAndonValue.Text = Convert.ToString(listObj.First().andonValue);
                        lblDate.Text = listObj.First().andonDate == null ? DateTime.Now.ToString() : listObj.First().andonDate.Value.ToString();
                    }
                }
            }
        }
        private void ShowWarning(string msg)
        {
            MessageBox.Show(msg, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        private void ShowOK(string msg)
        {
            MessageBox.Show(msg, "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            AndonPlcBLL objBLL = new AndonPlcBLL();
            if (id > 0)
            {
                AndonValueBLL objABLL = new AndonValueBLL();
                AndonValues objParam = new AndonValues();
                objParam.idAv = id;
                List<AndonValues> listObj = objABLL.getAndonValues(objParam);
                if (listObj != null)
                {
                    if (listObj.Any())
                    {
                        lblAndonValue.BackColor = lblAndonValue.BackColor == Color.Red ? Color.Black : Color.Red;
                        lblAndonValue.Text = Convert.ToString(listObj.First().andonValue);
                        lblDate.Text = listObj.First().andonDate == null ? DateTime.Now.ToString() : listObj.First().andonDate.Value.ToString();
                    }
                }
            }
        }
    }
}
