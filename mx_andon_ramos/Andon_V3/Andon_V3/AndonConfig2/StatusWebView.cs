using MreaShared.BLL;
using MreaShared.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Andon_V3.AndonConfig2
{
    public partial class StatusWebView : Form
    {
        public StatusWebView()
        {
            InitializeComponent();
        }

        private void StatuWebView_Load(object sender, EventArgs e)
        {
            loadPreview();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            loadPreview();
        }
        private void loadPreview()
        {
            AndonBLL andonBLL = new AndonBLL();
            AndonConfig andonConfig = new AndonConfig();
            MreaMailBLL mreaMailBLL = new MreaMailBLL();
            var list = andonBLL.getAndonConfig(andonConfig);
            if (list != null)
            {
                if (list.Any())
                {
                    var HTML = mreaMailBLL.buildHTMLStatusAndon(list.OrderBy(l => l.line).ToList());
                    webBrowser1.DocumentText = HTML;

                }
            }
        }
    }
}
