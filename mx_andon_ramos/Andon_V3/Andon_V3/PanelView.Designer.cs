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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.btnToggleCollapse = new System.Windows.Forms.Button();
            this.lblPanelDesc = new System.Windows.Forms.Label();
            this.tablePanelView = new System.Windows.Forms.TableLayoutPanel();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.lblStatusTower = new System.Windows.Forms.Label();
            this.lblState = new System.Windows.Forms.Label();
            this.lblTimeStateRunning = new System.Windows.Forms.Label();
            this.TimerCheckButtonState = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pnlHeader.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.pnlHeader.Controls.Add(this.btnToggleCollapse);
            this.pnlHeader.Controls.Add(this.lblPanelDesc);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(135, 32);
            this.pnlHeader.TabIndex = 0;
            // 
            // btnToggleCollapse
            // 
            this.btnToggleCollapse.BackColor = System.Drawing.Color.White;
            this.btnToggleCollapse.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnToggleCollapse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnToggleCollapse.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.btnToggleCollapse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToggleCollapse.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnToggleCollapse.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.btnToggleCollapse.Location = new System.Drawing.Point(0, 0);
            this.btnToggleCollapse.Margin = new System.Windows.Forms.Padding(0);
            this.btnToggleCollapse.Name = "btnToggleCollapse";
            this.btnToggleCollapse.Size = new System.Drawing.Size(135, 32);
            this.btnToggleCollapse.TabIndex = 0;
            this.btnToggleCollapse.Text = "<";
            this.btnToggleCollapse.UseVisualStyleBackColor = false;
            this.btnToggleCollapse.Click += new System.EventHandler(this.btnToggleCollapse_Click);
            // 
            // lblPanelDesc
            // 
            this.lblPanelDesc.Location = new System.Drawing.Point(0, 0);
            this.lblPanelDesc.Name = "lblPanelDesc";
            this.lblPanelDesc.Size = new System.Drawing.Size(0, 0);
            this.lblPanelDesc.TabIndex = 1;
            this.lblPanelDesc.Visible = false;
            // 
            // tablePanelView
            // 
            this.tablePanelView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.tablePanelView.ColumnCount = 1;
            this.tablePanelView.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tablePanelView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanelView.Location = new System.Drawing.Point(0, 32);
            this.tablePanelView.Margin = new System.Windows.Forms.Padding(0);
            this.tablePanelView.Name = "tablePanelView";
            this.tablePanelView.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tablePanelView.RowCount = 1;
            this.tablePanelView.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tablePanelView.Size = new System.Drawing.Size(135, 668);
            this.tablePanelView.TabIndex = 1;
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.pnlFooter.Controls.Add(this.lblStatusTower);
            this.pnlFooter.Controls.Add(this.lblState);
            this.pnlFooter.Controls.Add(this.lblTimeStateRunning);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 700);
            this.pnlFooter.Margin = new System.Windows.Forms.Padding(0);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(135, 20);
            this.pnlFooter.TabIndex = 2;
            // 
            // lblStatusTower
            // 
            this.lblStatusTower.Location = new System.Drawing.Point(0, 0);
            this.lblStatusTower.Name = "lblStatusTower";
            this.lblStatusTower.Size = new System.Drawing.Size(0, 0);
            this.lblStatusTower.TabIndex = 2;
            this.lblStatusTower.Visible = false;
            // 
            // lblState
            // 
            this.lblState.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblState.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblState.ForeColor = System.Drawing.Color.DimGray;
            this.lblState.Location = new System.Drawing.Point(0, 0);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(135, 20);
            this.lblState.TabIndex = 0;
            this.lblState.Text = "ONLINE";
            this.lblState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTimeStateRunning
            // 
            this.lblTimeStateRunning.Location = new System.Drawing.Point(0, 0);
            this.lblTimeStateRunning.Name = "lblTimeStateRunning";
            this.lblTimeStateRunning.Size = new System.Drawing.Size(0, 0);
            this.lblTimeStateRunning.TabIndex = 1;
            this.lblTimeStateRunning.Visible = false;
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
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(135, 720);
            this.Controls.Add(this.tablePanelView);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "PanelView";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "PanelView";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.PanelView_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlFooter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Button btnToggleCollapse;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.TableLayoutPanel tablePanelView;
        private System.Windows.Forms.Timer TimerCheckButtonState;
        private System.Windows.Forms.Label lblPanelDesc;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.Label lblTimeStateRunning;
        private System.Windows.Forms.Label lblStatusTower;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}