namespace Andon_V3.AndonConfig2
{
    partial class List
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
            this.label1 = new System.Windows.Forms.Label();
            this.grdData = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.idConfig = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.application = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.line = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.startScreen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.smZone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.divisions = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hostname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.startAlways = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastUpdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.update = new System.Windows.Forms.DataGridViewLinkColumn();
            this.delete = new System.Windows.Forms.DataGridViewLinkColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Andon Config";
            // 
            // grdData
            // 
            this.grdData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdData.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.grdData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idConfig,
            this.application,
            this.line,
            this.startScreen,
            this.smZone,
            this.divisions,
            this.hostname,
            this.startAlways,
            this.lastUpdate,
            this.update,
            this.delete});
            this.grdData.Location = new System.Drawing.Point(12, 78);
            this.grdData.Name = "grdData";
            this.grdData.Size = new System.Drawing.Size(918, 338);
            this.grdData.TabIndex = 1;
            this.grdData.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdLines_CellContentClick);
            this.grdData.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.grdLines_DataBindingComplete);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Teal;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(855, 28);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 44);
            this.button1.TabIndex = 2;
            this.button1.Text = "New";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Teal;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(774, 28);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 44);
            this.button2.TabIndex = 3;
            this.button2.Text = "Reload";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // idConfig
            // 
            this.idConfig.DataPropertyName = "idConfig";
            this.idConfig.HeaderText = "ID";
            this.idConfig.Name = "idConfig";
            this.idConfig.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // application
            // 
            this.application.DataPropertyName = "application";
            this.application.HeaderText = "Application";
            this.application.Name = "application";
            this.application.ReadOnly = true;
            // 
            // line
            // 
            this.line.DataPropertyName = "line";
            this.line.HeaderText = "Line";
            this.line.Name = "line";
            this.line.ReadOnly = true;
            // 
            // startScreen
            // 
            this.startScreen.DataPropertyName = "startScreen";
            this.startScreen.HeaderText = "Screen Index";
            this.startScreen.Name = "startScreen";
            this.startScreen.ReadOnly = true;
            // 
            // smZone
            // 
            this.smZone.DataPropertyName = "smZone";
            this.smZone.HeaderText = "Zone";
            this.smZone.Name = "smZone";
            this.smZone.ReadOnly = true;
            // 
            // divisions
            // 
            this.divisions.DataPropertyName = "smDivs";
            this.divisions.HeaderText = "Divisions";
            this.divisions.Name = "divisions";
            // 
            // hostname
            // 
            this.hostname.DataPropertyName = "hostname";
            this.hostname.HeaderText = "Hostname";
            this.hostname.Name = "hostname";
            // 
            // startAlways
            // 
            this.startAlways.DataPropertyName = "startAlways";
            this.startAlways.HeaderText = "Start this config";
            this.startAlways.Name = "startAlways";
            // 
            // lastUpdate
            // 
            this.lastUpdate.DataPropertyName = "lastUpdate";
            this.lastUpdate.HeaderText = "Last Update";
            this.lastUpdate.Name = "lastUpdate";
            // 
            // update
            // 
            this.update.HeaderText = "Update";
            this.update.Name = "update";
            this.update.ReadOnly = true;
            this.update.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.update.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.update.Text = "Update";
            // 
            // delete
            // 
            this.delete.DataPropertyName = "Update";
            this.delete.HeaderText = "Delete";
            this.delete.Name = "delete";
            this.delete.ReadOnly = true;
            this.delete.Text = "Delete";
            // 
            // List
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(948, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.grdData);
            this.Controls.Add(this.label1);
            this.Name = "List";
            this.Text = "List";
            this.Load += new System.EventHandler(this.List_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView grdData;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridViewTextBoxColumn idConfig;
        private System.Windows.Forms.DataGridViewTextBoxColumn application;
        private System.Windows.Forms.DataGridViewTextBoxColumn line;
        private System.Windows.Forms.DataGridViewTextBoxColumn startScreen;
        private System.Windows.Forms.DataGridViewTextBoxColumn smZone;
        private System.Windows.Forms.DataGridViewTextBoxColumn divisions;
        private System.Windows.Forms.DataGridViewTextBoxColumn hostname;
        private System.Windows.Forms.DataGridViewTextBoxColumn startAlways;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastUpdate;
        private System.Windows.Forms.DataGridViewLinkColumn update;
        private System.Windows.Forms.DataGridViewLinkColumn delete;
    }
}