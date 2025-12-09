namespace Andon_V3
{
    partial class PanelView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblPanelDesc = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblTimeStateRunning = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblStatusTower = new System.Windows.Forms.Label();
            this.lblState = new System.Windows.Forms.Label();
            this.tablePanelView = new System.Windows.Forms.TableLayoutPanel();
            this.TimerCheckButtonState = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Teal;
            this.panel1.Controls.Add(this.lblPanelDesc);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(302, 91);
            this.panel1.TabIndex = 0;
            // 
            // lblPanelDesc
            // 
            this.lblPanelDesc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPanelDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPanelDesc.ForeColor = System.Drawing.Color.White;
            this.lblPanelDesc.Location = new System.Drawing.Point(0, 0);
            this.lblPanelDesc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPanelDesc.Name = "lblPanelDesc";
            this.lblPanelDesc.Size = new System.Drawing.Size(302, 91);
            this.lblPanelDesc.TabIndex = 0;
            this.lblPanelDesc.Text = "lblPanelDesc";
            this.lblPanelDesc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 91);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(91, 827);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lblTimeStateRunning);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(203, 91);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(99, 827);
            this.panel3.TabIndex = 2;
            // 
            // lblTimeStateRunning
            // 
            this.lblTimeStateRunning.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblTimeStateRunning.Location = new System.Drawing.Point(0, 801);
            this.lblTimeStateRunning.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTimeStateRunning.Name = "lblTimeStateRunning";
            this.lblTimeStateRunning.Size = new System.Drawing.Size(99, 26);
            this.lblTimeStateRunning.TabIndex = 4;
            this.lblTimeStateRunning.Text = "label2";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Teal;
            this.panel4.Controls.Add(this.lblStatusTower);
            this.panel4.Controls.Add(this.lblState);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(91, 795);
            this.panel4.Margin = new System.Windows.Forms.Padding(4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(112, 123);
            this.panel4.TabIndex = 3;
            // 
            // lblStatusTower
            // 
            this.lblStatusTower.AutoSize = true;
            this.lblStatusTower.Location = new System.Drawing.Point(22, 95);
            this.lblStatusTower.Name = "lblStatusTower";
            this.lblStatusTower.Size = new System.Drawing.Size(44, 16);
            this.lblStatusTower.TabIndex = 1;
            this.lblStatusTower.Text = "label1";
            this.lblStatusTower.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblState
            // 
            this.lblState.BackColor = System.Drawing.Color.Teal;
            this.lblState.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblState.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblState.ForeColor = System.Drawing.Color.White;
            this.lblState.Location = new System.Drawing.Point(0, 0);
            this.lblState.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(112, 123);
            this.lblState.TabIndex = 0;
            this.lblState.Text = "label1";
            this.lblState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tablePanelView
            // 
            this.tablePanelView.ColumnCount = 2;
            this.tablePanelView.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tablePanelView.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tablePanelView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanelView.Location = new System.Drawing.Point(91, 91);
            this.tablePanelView.Margin = new System.Windows.Forms.Padding(4);
            this.tablePanelView.Name = "tablePanelView";
            this.tablePanelView.RowCount = 2;
            this.tablePanelView.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tablePanelView.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tablePanelView.Size = new System.Drawing.Size(112, 704);
            this.tablePanelView.TabIndex = 4;
            this.tablePanelView.Paint += new System.Windows.Forms.PaintEventHandler(this.tablePanelView_Paint);
            // 
            // TimerCheckButtonState
            // 
            this.TimerCheckButtonState.Enabled = true;
            this.TimerCheckButtonState.Interval = 2000;
            this.TimerCheckButtonState.Tick += new System.EventHandler(this.TimerCheckButtonState_Tick);
            // 
            // PanelView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 918);
            this.Controls.Add(this.tablePanelView);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "PanelView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PanelView";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.PanelView_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

       

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TableLayoutPanel tablePanelView;
        private System.Windows.Forms.Timer TimerCheckButtonState;
        private System.Windows.Forms.Label lblPanelDesc;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.Label lblTimeStateRunning;
        private System.Windows.Forms.Label lblStatusTower;
    }
}