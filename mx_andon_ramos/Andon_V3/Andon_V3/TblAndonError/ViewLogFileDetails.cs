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
    public partial class ViewLogFileDetails : Form
    {
        public string _filename { get; set; }
        public string _content { get; set; }
        public ViewLogFileDetails()
        {
            InitializeComponent();
        }

        private void ViewDetails_Load(object sender, EventArgs e)
        {
            lblFilename.Text = _filename;
            txtFileContent.Text = _content;
        }
    }
}
