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
using System.Configuration;

namespace Andon_V3
{
    public partial class Materials : Form
    {
        public int resetCount = 0;
        /// <summary>
        /// Propiedad para validar que los mensajes solo se vean en un solo cuadrante.
        /// </summary>
        public List<KeyValuePair<int, int>> arrayPanels = new List<KeyValuePair<int, int>>();
        public Materials()
        {
            InitializeComponent();
        }

        private void Materials_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;
            clearArray();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            AndonBLL andonBLL = new AndonBLL();
            List<Andon> list = andonBLL.selectAllScreens();
            
            if (list != null)
            {
                if (list.Any())
                {
                    list = list.FindAll(l => l.nameType == Convert.ToString(ConfigurationManager.AppSettings["type"]));
                    if (list.Count() > 0)
                    {
                        panel1.Visible = true;
                    }
                    resetCount = 0;
                    foreach (var objAndon in list)
                    {
                        //findFreePanel(objAndon);
                        string line = EnumBLL.GetEnumDescription((EIdLine)objAndon.idLine);
                        buildPanel(line, objAndon.message, null, objAndon.nameText, objAndon.font);
                    }
                }
                else
                {
                    clearPanels();
                    resetCount++;
                }
            }
            else
            {
                clearPanels();
                resetCount++;
            }
            if (resetCount == 5)
            {
                clearArray();
            }

        }
        private void findFreePanel(Andon objAndon)
        {
            var find = arrayPanels.Find(x => x.Value == objAndon.idLine);
            if(find.Value == 0)
            {
                var freePanel = arrayPanels.Find(x => x.Value == -1);
                if (freePanel.Value != 0)
                {
                    var newEntry = new KeyValuePair<int, int>(freePanel.Key, objAndon.idLine);
                    arrayPanels.Remove(freePanel);
                    arrayPanels.Add(newEntry);
                    drawPanel(objAndon, freePanel.Key);
                }

            }
            else
            {
                drawPanel(objAndon, find.Key);
            }
            
        }
        private void clearPanels()
        {
            panel1.Visible = false;
        }
        private void drawPanel(Andon objAndon, int i)
        {
            //tblLayMat.Controls.Clear();
            //string line = EnumBLL.GetEnumDescription((EStationId)objAndon.recScreen);
            //int col = 0;
            //int row = 0;
            //switch (i)
            //{
            //    case 1:
            //        col = 0;
            //        row = 0;
            //        break;
            //    case 2:
            //        col = 0;
            //        row = 1;
            //        break;
            //    case 3:
            //        col = 1;
            //        row = 0;
            //        break;
            //    case 4:
            //        col = 1;
            //        row = 1;
            //        break;
            //    default:
            //        break;
            //}
            //var control = tblLayMat.GetControlFromPosition(col, row);
            //tblLayMat.Controls.Remove(control);
            //if (control == null)
            //{
            //    tblLayMat.Controls.Add(buildPanel(line, objAndon.msgMessage, null, objAndon.coltDescription, objAndon.fontSize2), col, row);
            //    //tblLayMat.Controls.Remove(control);
            //}
        }

        private void buildPanel(string line, string station, string noPart, string fontColor, int fontSize)
        {
            panel1.Controls.Clear();
            int width = panel1.Width;
            int height = panel1.Height;
            //Panel panel = new Panel();
            //panel.BackColor = Color.Blue;
            //panel.Size = new Size(width[0], height[0]);
            //LINEA
            Label label0 = new Label();
            label0.Text = "MATERIALES";
            label0.ForeColor = Color.FromName(fontColor);
            label0.Location = new Point(0, 30);
            label0.AutoSize = false;
            label0.TextAlign = ContentAlignment.MiddleCenter;
            label0.Width = width;
            label0.Height = 150;
            label0.Font = new Font(this.Font.FontFamily, fontSize, FontStyle.Bold);
            panel1.Controls.Add(label0);

            Label label1 = new Label();
            label1.Text = line;
            label1.ForeColor = Color.FromName(fontColor);
            label1.Location = new Point(0, 270);
            label1.AutoSize = false;
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.Width = width;
            label1.Height = 150;
            label1.Font = new Font(this.Font.FontFamily, fontSize, FontStyle.Bold);
            panel1.Controls.Add(label1);
            //ESTACION
            Label label2 = new Label();
            label2.Text = station;
            label2.ForeColor = Color.FromName(fontColor);
            label2.Location = new Point(0, 500);
            label2.AutoSize = false;
            label2.TextAlign = ContentAlignment.MiddleCenter;
            label2.Width = width;
            label2.Height = 150;
            label2.Font = new Font(this.Font.FontFamily, fontSize, FontStyle.Bold);
            panel1.Controls.Add(label2);
            //NUMERO DE PARTE
            if(noPart != null)
            {
                Label label3 = new Label();
                label3.Text = noPart;
                label3.ForeColor = Color.FromName(fontColor);
                label3.Location = new Point(0, 350);
                label3.AutoSize = false;
                label3.TextAlign = ContentAlignment.MiddleCenter;
                label3.Width = width;
                label3.Height = 70;
                label3.Font = new Font(this.Font.FontFamily, fontSize, FontStyle.Bold);
                panel1.Controls.Add(label3);
            }

            //return panel;
        }

        protected void clearArray()
        {
            arrayPanels.Clear();
            arrayPanels.Add(new KeyValuePair<int, int>(1, -1));
            arrayPanels.Add(new KeyValuePair<int, int>(2, -1));
            arrayPanels.Add(new KeyValuePair<int, int>(3, -1));
            arrayPanels.Add(new KeyValuePair<int, int>(4, -1));
        }
    }
}
