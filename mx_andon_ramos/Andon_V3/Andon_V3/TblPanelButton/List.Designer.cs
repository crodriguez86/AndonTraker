namespace Andon_V3.TblPanelButton
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
            this.IdButton = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ButtonName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Msg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ButtonColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ButtonRow = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TowerIp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TowerConfig = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TowerConfig1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TowerCmd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TowerCmd2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ButtonState = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.IsBinary = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.update = new System.Windows.Forms.DataGridViewLinkColumn();
            this.delete = new System.Windows.Forms.DataGridViewLinkColumn();
            this.TestTower = new System.Windows.Forms.DataGridViewLinkColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Panel buttons";
            // 
            // grdData
            // 
            this.grdData.AllowUserToAddRows = false;
            this.grdData.AllowUserToDeleteRows = false;
            this.grdData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdButton,
            this.ButtonName,
            this.Msg,
            this.ButtonColumn,
            this.ButtonRow,
            this.TowerIp,
            this.TowerConfig,
            this.TowerConfig1,
            this.TowerCmd,
            this.TowerCmd2,
            this.ButtonState,
            this.IsBinary,
            this.update,
            this.delete,
            this.TestTower});
            this.grdData.Location = new System.Drawing.Point(28, 78);
            this.grdData.Name = "grdData";
            this.grdData.ReadOnly = true;
            this.grdData.Size = new System.Drawing.Size(1085, 464);
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
            this.button1.Location = new System.Drawing.Point(1038, 28);
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
            // IdButton
            // 
            this.IdButton.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.IdButton.DataPropertyName = "IdButton";
            this.IdButton.HeaderText = "ID";
            this.IdButton.Name = "IdButton";
            this.IdButton.ReadOnly = true;
            this.IdButton.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IdButton.Width = 43;
            // 
            // ButtonName
            // 
            this.ButtonName.DataPropertyName = "ButtonName";
            this.ButtonName.HeaderText = "Name";
            this.ButtonName.Name = "ButtonName";
            this.ButtonName.ReadOnly = true;
            // 
            // Msg
            // 
            this.Msg.DataPropertyName = "Msg";
            this.Msg.HeaderText = "Msg Andon";
            this.Msg.Name = "Msg";
            this.Msg.ReadOnly = true;
            // 
            // ButtonColumn
            // 
            this.ButtonColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.ButtonColumn.DataPropertyName = "ButtonColumn";
            this.ButtonColumn.HeaderText = "Column";
            this.ButtonColumn.Name = "ButtonColumn";
            this.ButtonColumn.ReadOnly = true;
            this.ButtonColumn.Width = 67;
            // 
            // ButtonRow
            // 
            this.ButtonRow.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.ButtonRow.DataPropertyName = "ButtonRow";
            this.ButtonRow.HeaderText = "Row";
            this.ButtonRow.Name = "ButtonRow";
            this.ButtonRow.ReadOnly = true;
            this.ButtonRow.Width = 54;
            // 
            // TowerIp
            // 
            this.TowerIp.DataPropertyName = "ButtonTowerIp";
            this.TowerIp.HeaderText = "Tower IP";
            this.TowerIp.Name = "TowerIp";
            this.TowerIp.ReadOnly = true;
            // 
            // TowerConfig
            // 
            this.TowerConfig.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.TowerConfig.DataPropertyName = "ButtonTowerConfig";
            this.TowerConfig.HeaderText = "Id Config";
            this.TowerConfig.Name = "TowerConfig";
            this.TowerConfig.ReadOnly = true;
            this.TowerConfig.Visible = false;
            this.TowerConfig.Width = 74;
            // 
            // TowerConfig1
            // 
            this.TowerConfig1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.TowerConfig1.DataPropertyName = "ButtonTowerConfigName";
            this.TowerConfig1.HeaderText = "Tower Config";
            this.TowerConfig1.Name = "TowerConfig1";
            this.TowerConfig1.ReadOnly = true;
            this.TowerConfig1.Width = 95;
            // 
            // TowerCmd
            // 
            this.TowerCmd.DataPropertyName = "ButtonTowerCommand";
            this.TowerCmd.HeaderText = "Tower Cmd";
            this.TowerCmd.Name = "TowerCmd";
            this.TowerCmd.ReadOnly = true;
            // 
            // TowerCmd2
            // 
            this.TowerCmd2.DataPropertyName = "ButtonTowerCommand2";
            this.TowerCmd2.HeaderText = "Tower Cmd2";
            this.TowerCmd2.Name = "TowerCmd2";
            this.TowerCmd2.ReadOnly = true;
            // 
            // ButtonState
            // 
            this.ButtonState.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.ButtonState.DataPropertyName = "ButtonState";
            this.ButtonState.HeaderText = "State";
            this.ButtonState.Name = "ButtonState";
            this.ButtonState.ReadOnly = true;
            this.ButtonState.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ButtonState.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ButtonState.Width = 57;
            // 
            // IsBinary
            // 
            this.IsBinary.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.IsBinary.DataPropertyName = "IsBinary";
            this.IsBinary.HeaderText = "Is Binary";
            this.IsBinary.Name = "IsBinary";
            this.IsBinary.ReadOnly = true;
            this.IsBinary.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IsBinary.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.IsBinary.Width = 72;
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
            // TestTower
            // 
            this.TestTower.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.TestTower.HeaderText = "Test Tower";
            this.TestTower.Name = "TestTower";
            this.TestTower.ReadOnly = true;
            this.TestTower.Width = 67;
            // 
            // List
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1141, 554);
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
        private System.Windows.Forms.DataGridViewTextBoxColumn IdButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn ButtonName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Msg;
        private System.Windows.Forms.DataGridViewTextBoxColumn ButtonColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ButtonRow;
        private System.Windows.Forms.DataGridViewTextBoxColumn TowerIp;
        private System.Windows.Forms.DataGridViewTextBoxColumn TowerConfig;
        private System.Windows.Forms.DataGridViewTextBoxColumn TowerConfig1;
        private System.Windows.Forms.DataGridViewTextBoxColumn TowerCmd;
        private System.Windows.Forms.DataGridViewTextBoxColumn TowerCmd2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ButtonState;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsBinary;
        private System.Windows.Forms.DataGridViewLinkColumn update;
        private System.Windows.Forms.DataGridViewLinkColumn delete;
        private System.Windows.Forms.DataGridViewLinkColumn TestTower;
    }
}