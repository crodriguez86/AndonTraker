using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Andon_V3
{
    public static class ThreadHelperClass
    {
        delegate void SetTextCallback(Form f, Control ctrl, string text);
        delegate void SetBackColorCallback(Form f, Control ctrl, Color color);
        delegate void SetValueCallback(Form f, NumericUpDown ctrl, decimal value);
        /// <summary>
        /// Set text property of various controls
        /// </summary>
        /// <param name="form">The calling form</param>
        /// <param name="ctrl"></param>
        /// <param name="text"></param>
        public static void SetText(Form form, Control ctrl, string text)
        {
            // InvokeRequired required compares the thread ID of the 
            // calling thread to the thread ID of the creating thread. 
            // If these threads are different, it returns true. 
            if (ctrl.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                form.Invoke(d, new object[] { form, ctrl, text });
            }
            else
            {
                ctrl.Text = text;
            }
        }
        public static void SetValue(Form form, NumericUpDown ctrl, decimal value)
        {
            // InvokeRequired required compares the thread ID of the 
            // calling thread to the thread ID of the creating thread. 
            // If these threads are different, it returns true. 
            if (ctrl.InvokeRequired)
            {
                SetValueCallback d = new SetValueCallback(SetValue);
                form.Invoke(d, new object[] { form, ctrl, value });
            }
            else
            {
                ctrl.Value = value;
            }
        }
        public static void SetBackColor(Form form, Control ctrl, Color color)
        {
            // InvokeRequired required compares the thread ID of the 
            // calling thread to the thread ID of the creating thread. 
            // If these threads are different, it returns true. 
            if (ctrl.InvokeRequired)
            {
                SetBackColorCallback d = new SetBackColorCallback(SetBackColor);
                form.Invoke(d, new object[] { form, ctrl, color });
            }
            else
            {
                ctrl.BackColor = color;
            }
        }
    }
}
