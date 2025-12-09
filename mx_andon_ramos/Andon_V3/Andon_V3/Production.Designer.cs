namespace Andon_V3
{
    partial class Production
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Production));
            this.Timer1 = new System.Windows.Forms.Timer(this.components);
            this.pnlTimeElapsed = new System.Windows.Forms.Panel();
            this.AndonNotify = new System.Windows.Forms.NotifyIcon(this.components);
            this.AndonContext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlAndon = new System.Windows.Forms.Panel();
            this.AndonContext.SuspendLayout();
            this.SuspendLayout();
            // 
            // Timer1
            // 
            this.Timer1.Enabled = true;
            this.Timer1.Interval = 1000;
            this.Timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // pnlTimeElapsed
            // 
            this.pnlTimeElapsed.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlTimeElapsed.Location = new System.Drawing.Point(0, 508);
            this.pnlTimeElapsed.Name = "pnlTimeElapsed";
            this.pnlTimeElapsed.Size = new System.Drawing.Size(1378, 272);
            this.pnlTimeElapsed.TabIndex = 3;
            // 
            // AndonNotify
            // 
            this.AndonNotify.ContextMenuStrip = this.AndonContext;
            this.AndonNotify.Icon = ((System.Drawing.Icon)(resources.GetObject("AndonNotify.Icon")));
            this.AndonNotify.Text = "AndonRunning";
            this.AndonNotify.Visible = true;
            // 
            // AndonContext
            // 
            this.AndonContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem,
            this.restartToolStripMenuItem,
            this.toolStripMenuItem2,
            this.toolStripMenuItem3});
            this.AndonContext.Name = "contextMenuStrip1";
            this.AndonContext.Size = new System.Drawing.Size(111, 92);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.exitToolStripMenuItem.Text = "Restart";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // restartToolStripMenuItem
            // 
            this.restartToolStripMenuItem.Name = "restartToolStripMenuItem";
            this.restartToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.restartToolStripMenuItem.Text = " ";
            this.restartToolStripMenuItem.Click += new System.EventHandler(this.restartToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(110, 22);
            this.toolStripMenuItem2.Text = "  ";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(110, 22);
            this.toolStripMenuItem3.Text = " ";
            // 
            // pnlAndon
            // 
            this.pnlAndon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAndon.Location = new System.Drawing.Point(0, 0);
            this.pnlAndon.Name = "pnlAndon";
            this.pnlAndon.Size = new System.Drawing.Size(1378, 508);
            this.pnlAndon.TabIndex = 4;
            // 
            // Production
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1378, 780);
            this.Controls.Add(this.pnlAndon);
            this.Controls.Add(this.pnlTimeElapsed);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Production";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.AndonContext.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        internal System.Windows.Forms.Timer Timer1;
        private System.Windows.Forms.Panel pnlTimeElapsed;
        private System.Windows.Forms.NotifyIcon AndonNotify;
        private System.Windows.Forms.ContextMenuStrip AndonContext;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.Panel pnlAndon;
    }
}

