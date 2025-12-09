using MreaShared.BLL;
using MreaShared.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Andon_V3
{
    public partial class TestAndon : Form
    {
        public TestAndon()
        {
            InitializeComponent();
        }

        private void testAndon(int msgID)
        {
            AndonBLL andonBLL = new AndonBLL();
            andonBLL.testAndon(msgID);
        }

        private void TestAndon_Load(object sender, EventArgs e)
        {
            AndonBLL andonBLL = new AndonBLL();
            List<Andon> list = andonBLL.getLines();
            List<AndonType> list2 = andonBLL.getAndonTypes(new AndonType());
            comboBox1.DataSource = list2;
            comboBox1.DisplayMember = "name";
            comboBox1.ValueMember = "idType";
            cmbLines.DataSource = list;
            cmbLines.DisplayMember = "nameLine";
            cmbLines.ValueMember = "idLine";
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            int line = Convert.ToInt32(cmbLines.SelectedValue);
            int msg = Convert.ToInt32(cmbMessages.SelectedValue);
            if (!msg.Equals(0))
            {
                if (!msg.Equals(0))
                {
                    for (int i = 0; i < 4; i++)
                    {
                        Thread.Sleep(300);
                        testAndon(msg);
                    }
                    lblLinea.Text = cmbLines.Text;
                    lblType.Text = comboBox1.Text;
                    lblMsj.Text = cmbMessages.Text;
                    lblFecha.Text = DateTime.Now.ToString();
                }
                else
                {
                    MessageBox.Show("Selecciona una linea.");
                }
            }
            else
            {
                MessageBox.Show("Selecciona un mensaje.");
            }
        }

        private void cmbLines_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string line = cmbLines.SelectedValue?.ToString();
            string type = comboBox1.SelectedValue?.ToString();
            if (int.TryParse(line, out int idLine))
            {
                if (int.TryParse(type, out int idType))
                {
                    AndonBLL andonBLL = new AndonBLL();
                    cmbMessages.DataSource = andonBLL.getMessages(idLine, idType);
                    cmbMessages.DisplayMember = "message";
                    cmbMessages.ValueMember = "idMessage";
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbLines_SelectedIndexChanged_1(null, null);
        }

        private void bntReset_Click(object sender, EventArgs e)
        {
            try
            {
                int msg = Convert.ToInt32(cmbMessages.SelectedValue);
                if (msg.Equals(0))
                    throw new Exception("Selecciona un mensaje.");
                Andon objAndon = new Andon();
                AndonBLL andonBLL = new AndonBLL();
                objAndon = andonBLL.getMessage(msg);
                if (objAndon == null)
                    throw new Exception("No se pudo obtener datos del mensaje");
                andonBLL.setAndonValue(objAndon.idAndonValue, 0);
                lblLinea.Text = cmbLines.Text;
                lblType.Text = comboBox1.Text;
                lblMsj.Text = "0";
                lblFecha.Text = DateTime.Now.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK ,MessageBoxIcon.Error);
            }
        }
    }
}
