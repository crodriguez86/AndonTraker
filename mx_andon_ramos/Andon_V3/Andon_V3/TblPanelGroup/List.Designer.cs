namespace Andon_V3.TblPanelGroup
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.IdGroup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LineName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TowerIp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TowerTest = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TowerClear = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TowerActive = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.update = new System.Windows.Forms.DataGridViewLinkColumn();
            this.delete = new System.Windows.Forms.DataGridViewLinkColumn();
            this.PanelView = new System.Windows.Forms.DataGridViewLinkColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "PanelGroup";
            // 
            // grdData
            // 
            this.grdData.AllowUserToDeleteRows = false;
            this.grdData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdGroup,
            this.GroupName,
            this.GroupDesc,
            this.LineName,
            this.TowerIp,
            this.TowerTest,
            this.TowerClear,
            this.TowerActive,
            this.update,
            this.delete,
            this.PanelView});
            this.grdData.Location = new System.Drawing.Point(28, 78);
            this.grdData.Name = "grdData";
            this.grdData.ReadOnly = true;
            this.grdData.Size = new System.Drawing.Size(871, 338);
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
            this.button1.Location = new System.Drawing.Point(824, 28);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 44);
            this.button1.TabIndex = 2;
            this.button1.Text = "New";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(28, 49);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(326, 23);
            this.textBox1.TabIndex = 17;
            this.textBox1.Text = "Search...";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // IdGroup
            // 
            this.IdGroup.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.IdGroup.DataPropertyName = "IdGroup";
            this.IdGroup.HeaderText = "ID";
            this.IdGroup.Name = "IdGroup";
            this.IdGroup.ReadOnly = true;
            this.IdGroup.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IdGroup.Width = 43;
            // 
            // GroupName
            // 
            this.GroupName.DataPropertyName = "GroupName";
            this.GroupName.HeaderText = "Name";
            this.GroupName.Name = "GroupName";
            this.GroupName.ReadOnly = true;
            // 
            // GroupDesc
            // 
            this.GroupDesc.DataPropertyName = "GroupDesc";
            this.GroupDesc.HeaderText = "Desc";
            this.GroupDesc.Name = "GroupDesc";
            this.GroupDesc.ReadOnly = true;
            // 
            // LineName
            // 
            this.LineName.DataPropertyName = "LineName";
            this.LineName.HeaderText = "Line";
            this.LineName.Name = "LineName";
            this.LineName.ReadOnly = true;
            // 
            // TowerIp
            // 
            this.TowerIp.DataPropertyName = "GroupTowerIp";
            this.TowerIp.HeaderText = "Tower IP";
            this.TowerIp.Name = "TowerIp";
            this.TowerIp.ReadOnly = true;
            // 
            // TowerTest
            // 
            this.TowerTest.DataPropertyName = "GroupTowerTestCommand";
            this.TowerTest.HeaderText = "Tower Test";
            this.TowerTest.Name = "TowerTest";
            this.TowerTest.ReadOnly = true;
            // 
            // TowerClear
            // 
            this.TowerClear.DataPropertyName = "GroupTowerClearCommand";
            this.TowerClear.HeaderText = "Tower Clear";
            this.TowerClear.Name = "TowerClear";
            this.TowerClear.ReadOnly = true;
            // 
            // TowerActive
            // 
            this.TowerActive.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.TowerActive.DataPropertyName = "GroupTowerActive";
            this.TowerActive.HeaderText = "Tower Active";
            this.TowerActive.Name = "TowerActive";
            this.TowerActive.ReadOnly = true;
            this.TowerActive.Width = 76;
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
            // PanelView
            // 
            this.PanelView.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.PanelView.HeaderText = "Panel Views";
            this.PanelView.Name = "PanelView";
            this.PanelView.ReadOnly = true;
            this.PanelView.Width = 71;
            // 
            // List
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(922, 450);
            this.Controls.Add(this.textBox1);
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
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdGroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn GroupName;
        private System.Windows.Forms.DataGridViewTextBoxColumn GroupDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn LineName;
        private System.Windows.Forms.DataGridViewTextBoxColumn TowerIp;
        private System.Windows.Forms.DataGridViewTextBoxColumn TowerTest;
        private System.Windows.Forms.DataGridViewTextBoxColumn TowerClear;
        private System.Windows.Forms.DataGridViewCheckBoxColumn TowerActive;
        private System.Windows.Forms.DataGridViewLinkColumn update;
        private System.Windows.Forms.DataGridViewLinkColumn delete;
        private System.Windows.Forms.DataGridViewLinkColumn PanelView;
    }
}