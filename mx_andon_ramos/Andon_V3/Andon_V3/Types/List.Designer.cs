namespace Andon_V3.Types
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
            this.idLine = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colorBG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fontsize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FontMonitor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShowProd = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ShowMonitor = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ShowSpare1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ShowSpare2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColorMonitor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timeLimitLv2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timeLimitLv3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.update = new System.Windows.Forms.DataGridViewLinkColumn();
            this.delete = new System.Windows.Forms.DataGridViewLinkColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Types of support";
            // 
            // grdData
            // 
            this.grdData.AllowUserToDeleteRows = false;
            this.grdData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idLine,
            this.name,
            this.nameText,
            this.colorBG,
            this.Fontsize,
            this.FontMonitor,
            this.ShowProd,
            this.ShowMonitor,
            this.ShowSpare1,
            this.ShowSpare2,
            this.ColorMonitor,
            this.timeLimitLv2,
            this.timeLimitLv3,
            this.update,
            this.delete});
            this.grdData.Location = new System.Drawing.Point(28, 78);
            this.grdData.Name = "grdData";
            this.grdData.ReadOnly = true;
            this.grdData.Size = new System.Drawing.Size(1302, 338);
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
            this.button1.Location = new System.Drawing.Point(1255, 28);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 44);
            this.button1.TabIndex = 2;
            this.button1.Text = "New";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // idLine
            // 
            this.idLine.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.idLine.DataPropertyName = "idType";
            this.idLine.HeaderText = "ID";
            this.idLine.Name = "idLine";
            this.idLine.ReadOnly = true;
            this.idLine.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.idLine.Width = 43;
            // 
            // name
            // 
            this.name.DataPropertyName = "name";
            this.name.HeaderText = "Name";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            // 
            // nameText
            // 
            this.nameText.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.nameText.DataPropertyName = "nameText";
            this.nameText.HeaderText = "Font color";
            this.nameText.Name = "nameText";
            this.nameText.ReadOnly = true;
            this.nameText.Width = 79;
            // 
            // colorBG
            // 
            this.colorBG.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.colorBG.DataPropertyName = "nameBg";
            this.colorBG.HeaderText = "BG color";
            this.colorBG.Name = "colorBG";
            this.colorBG.ReadOnly = true;
            this.colorBG.Width = 73;
            // 
            // Fontsize
            // 
            this.Fontsize.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Fontsize.DataPropertyName = "nameFontProduction";
            this.Fontsize.HeaderText = "Fontsize Production";
            this.Fontsize.Name = "Fontsize";
            this.Fontsize.ReadOnly = true;
            this.Fontsize.Width = 70;
            // 
            // FontMonitor
            // 
            this.FontMonitor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.FontMonitor.DataPropertyName = "nameFontMonitor";
            this.FontMonitor.HeaderText = "Fontsize Monitor";
            this.FontMonitor.Name = "FontMonitor";
            this.FontMonitor.ReadOnly = true;
            this.FontMonitor.Width = 70;
            // 
            // ShowProd
            // 
            this.ShowProd.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.ShowProd.DataPropertyName = "showProduction";
            this.ShowProd.HeaderText = "Show Production";
            this.ShowProd.Name = "ShowProd";
            this.ShowProd.ReadOnly = true;
            this.ShowProd.Width = 85;
            // 
            // ShowMonitor
            // 
            this.ShowMonitor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.ShowMonitor.DataPropertyName = "showMonitor";
            this.ShowMonitor.HeaderText = "Show Monitor";
            this.ShowMonitor.Name = "ShowMonitor";
            this.ShowMonitor.ReadOnly = true;
            this.ShowMonitor.ToolTipText = "Mostrar en tipo de soporte en Andon Monitor";
            this.ShowMonitor.Width = 70;
            // 
            // ShowSpare1
            // 
            this.ShowSpare1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.ShowSpare1.DataPropertyName = "showSpare1";
            this.ShowSpare1.HeaderText = "Show Monitor Charts";
            this.ShowSpare1.Name = "ShowSpare1";
            this.ShowSpare1.ReadOnly = true;
            this.ShowSpare1.ToolTipText = "Ver tipo de soporte en las graficas del Andon Monitor";
            // 
            // ShowSpare2
            // 
            this.ShowSpare2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.ShowSpare2.DataPropertyName = "showSpare2";
            this.ShowSpare2.HeaderText = "Track this type";
            this.ShowSpare2.Name = "ShowSpare2";
            this.ShowSpare2.ReadOnly = true;
            this.ShowSpare2.ToolTipText = "Set true if you want to save this type in andon_history";
            this.ShowSpare2.Width = 57;
            // 
            // ColorMonitor
            // 
            this.ColorMonitor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.ColorMonitor.DataPropertyName = "nameMonitorBg";
            this.ColorMonitor.HeaderText = "Color Chart Monitor";
            this.ColorMonitor.Name = "ColorMonitor";
            this.ColorMonitor.ReadOnly = true;
            this.ColorMonitor.Width = 112;
            // 
            // timeLimitLv2
            // 
            this.timeLimitLv2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.timeLimitLv2.DataPropertyName = "timeLimitLv2";
            this.timeLimitLv2.HeaderText = "Limit Time Level 2";
            this.timeLimitLv2.Name = "timeLimitLv2";
            this.timeLimitLv2.ReadOnly = true;
            this.timeLimitLv2.Width = 80;
            // 
            // timeLimitLv3
            // 
            this.timeLimitLv3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.timeLimitLv3.DataPropertyName = "timeLimitLv3";
            this.timeLimitLv3.HeaderText = "Limit Time Level 3";
            this.timeLimitLv3.Name = "timeLimitLv3";
            this.timeLimitLv3.ReadOnly = true;
            this.timeLimitLv3.Width = 80;
            // 
            // update
            // 
            this.update.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.update.HeaderText = "Update";
            this.update.Name = "update";
            this.update.ReadOnly = true;
            this.update.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.update.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.update.Text = "Update";
            this.update.Width = 67;
            // 
            // delete
            // 
            this.delete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.delete.DataPropertyName = "Update";
            this.delete.HeaderText = "Delete";
            this.delete.Name = "delete";
            this.delete.ReadOnly = true;
            this.delete.Text = "Delete";
            this.delete.Width = 44;
            // 
            // List
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1342, 450);
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
        private System.Windows.Forms.DataGridViewTextBoxColumn idLine;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameText;
        private System.Windows.Forms.DataGridViewTextBoxColumn colorBG;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fontsize;
        private System.Windows.Forms.DataGridViewTextBoxColumn FontMonitor;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ShowProd;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ShowMonitor;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ShowSpare1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ShowSpare2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColorMonitor;
        private System.Windows.Forms.DataGridViewTextBoxColumn timeLimitLv2;
        private System.Windows.Forms.DataGridViewTextBoxColumn timeLimitLv3;
        private System.Windows.Forms.DataGridViewLinkColumn update;
        private System.Windows.Forms.DataGridViewLinkColumn delete;
    }
}