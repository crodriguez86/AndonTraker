namespace Andon_V3.Lines
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
            this.grdLines = new System.Windows.Forms.DataGridView();
            this.idLine = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idZone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.update = new System.Windows.Forms.DataGridViewLinkColumn();
            this.delete = new System.Windows.Forms.DataGridViewLinkColumn();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdLines)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Lines";
            // 
            // grdLines
            // 
            this.grdLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdLines.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idLine,
            this.name,
            this.desd,
            this.idZone,
            this.update,
            this.delete});
            this.grdLines.Location = new System.Drawing.Point(28, 78);
            this.grdLines.Name = "grdLines";
            this.grdLines.Size = new System.Drawing.Size(593, 338);
            this.grdLines.TabIndex = 1;
            this.grdLines.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdLines_CellContentClick);
            this.grdLines.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.grdLines_DataBindingComplete);
            // 
            // idLine
            // 
            this.idLine.DataPropertyName = "idLine";
            this.idLine.HeaderText = "ID";
            this.idLine.Name = "idLine";
            this.idLine.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.idLine.Width = 40;
            // 
            // name
            // 
            this.name.DataPropertyName = "name";
            this.name.HeaderText = "Name";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.Width = 120;
            // 
            // desd
            // 
            this.desd.DataPropertyName = "desc";
            this.desd.HeaderText = "Description";
            this.desd.Name = "desd";
            this.desd.ReadOnly = true;
            this.desd.Width = 200;
            // 
            // idZone
            // 
            this.idZone.DataPropertyName = "idZone";
            this.idZone.HeaderText = "Zone";
            this.idZone.Name = "idZone";
            this.idZone.ReadOnly = true;
            this.idZone.Width = 50;
            // 
            // update
            // 
            this.update.HeaderText = "Update";
            this.update.Name = "update";
            this.update.ReadOnly = true;
            this.update.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.update.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.update.Text = "Update";
            this.update.Width = 60;
            // 
            // delete
            // 
            this.delete.DataPropertyName = "Update";
            this.delete.HeaderText = "Delete";
            this.delete.Name = "delete";
            this.delete.ReadOnly = true;
            this.delete.Text = "Delete";
            this.delete.Width = 60;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Teal;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(546, 28);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 44);
            this.button1.TabIndex = 2;
            this.button1.Text = "New";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // List
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.grdLines);
            this.Controls.Add(this.label1);
            this.Name = "List";
            this.Text = "List";
            this.Load += new System.EventHandler(this.List_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdLines)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView grdLines;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idLine;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn desd;
        private System.Windows.Forms.DataGridViewTextBoxColumn idZone;
        private System.Windows.Forms.DataGridViewLinkColumn update;
        private System.Windows.Forms.DataGridViewLinkColumn delete;
    }
}