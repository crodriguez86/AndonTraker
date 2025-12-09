using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using MreaShared.BLL;
using MreaShared.Objects;

namespace Andon_V3
{
    public partial class KeyPad : Form
    {
        public int _idMsg { get; set; }
        public string _title { get; set; }
        public bool _operator { get; set; }
        public int _timeToWait { get; set; } = 0;
        private int _decreaseTime { get; set; } = 0;
        public KeyPad()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            lblMessage.Visible = false;
            AndonPinsBLL andonPinsBLL = new AndonPinsBLL();
            bool validCode = false;
            if (_operator)
            {//Si es para validar el pin de un operador
                validCode = andonPinsBLL.ValidOperatorCodeByIdMsg(_idMsg, txtNumber.Text);
            }
            else
            {//Si es para validar el pin del personal de soporte
                validCode = andonPinsBLL.ValidCodeByIdMsg(_idMsg, txtNumber.Text);
            }
            if (validCode)
            {
                this.Close();
            }
            else
            {
                lblMessage.Text = "Wrong password. Try again.";
                lblMessage.Visible = true;
            }
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            addNumberToTextbox("1");
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            addNumberToTextbox("2");
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            addNumberToTextbox("3");
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            addNumberToTextbox("4");
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            addNumberToTextbox("5");
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            addNumberToTextbox("6");
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            addNumberToTextbox("7");
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            addNumberToTextbox("8");
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            addNumberToTextbox("9");
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            addNumberToTextbox("0");
        }

        private void btnBackspace_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            lblMessage.Visible = false;
            if (txtNumber.Text.Length > 0)
            {
                txtNumber.Text = txtNumber.Text.Substring(0, txtNumber.Text.Length - 1);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            lblMessage.Visible = false;
            txtNumber.Text = string.Empty;
        }
        private void addNumberToTextbox(string number)
        {
            lblMessage.Text = "";
            lblMessage.Visible = false;
            if (txtNumber.Text.Length > 8)
            {
                lblMessage.Text = "Maximum number of characters has been reached.";
                lblMessage.Visible = true;
            }
            else
            {
                txtNumber.Text = txtNumber.Text + number;
            }
        }

        private void KeyPad_Load(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            lblMessage.Visible = false;
            lblTitle.Text = _title;
            if (_timeToWait > 0)
            {
                _decreaseTime = _timeToWait;
                btnEnter.Text = "Wait " + _decreaseTime + " seconds.";
                btnEnter.Enabled = false;
            }
        }

        private void timeToWait_Tick(object sender, EventArgs e)
        {
            if (_timeToWait > 0)
            {
                btnEnter.Text = "Wait " + _decreaseTime + " seconds.";
                btnEnter.Enabled = false;
                _decreaseTime--;
                if (_decreaseTime == 0)
                {
                    btnEnter.Text = "Enter";
                    btnEnter.Enabled = true;
                    timeToWait.Enabled = false;
                }
            }
        }
    }
}
