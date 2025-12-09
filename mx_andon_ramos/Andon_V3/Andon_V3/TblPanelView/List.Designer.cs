namespace Andon_V3.TblPanelView
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
            this.IdPanel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PanelName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PanelDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PanelLastUpdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PanelColumns = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PanelRows = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.update = new System.Windows.Forms.DataGridViewLinkColumn();
            this.delete = new System.Windows.Forms.DataGridViewLinkColumn();
            this.PanelButtons = new System.Windows.Forms.DataGridViewLinkColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Panel views";
            // 
            // grdData
            // 
            this.grdData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdPanel,
            this.PanelName,
            this.PanelDesc,
            this.PanelLastUpdate,
            this.PanelColumns,
            this.PanelRows,
            this.update,
            this.delete,
            this.PanelButtons});
            this.grdData.Location = new System.Drawing.Point(28, 78);
            this.grdData.Name = "grdData";
            this.grdData.Size = new System.Drawing.Size(706, 338);
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
            this.button1.Location = new System.Drawing.Point(659, 28);
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
            // IdPanel
            // 
            this.IdPanel.DataPropertyName = "IdPanel";
            this.IdPanel.HeaderText = "ID";
            this.IdPanel.Name = "IdPanel";
            this.IdPanel.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // PanelName
            // 
            this.PanelName.DataPropertyName = "PanelName";
            this.PanelName.HeaderText = "Name";
            this.PanelName.Name = "PanelName";
            this.PanelName.ReadOnly = true;
            // 
            // PanelDesc
            // 
            this.PanelDesc.DataPropertyName = "PanelDesc";
            this.PanelDesc.HeaderText = "Desc";
            this.PanelDesc.Name = "PanelDesc";
            // 
            // PanelLastUpdate
            // 
            this.PanelLastUpdate.DataPropertyName = "PanelLastUpdate";
            this.PanelLastUpdate.HeaderText = "Last Update";
            this.PanelLastUpdate.Name = "PanelLastUpdate";
            // 
            // PanelColumns
            // 
            this.PanelColumns.DataPropertyName = "PanelColumns";
            this.PanelColumns.HeaderText = "Column";
            this.PanelColumns.Name = "PanelColumns";
            // 
            // PanelRows
            // 
            this.PanelRows.DataPropertyName = "PanelRows";
            this.PanelRows.HeaderText = "Row";
            this.PanelRows.Name = "PanelRows";
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
            // PanelButtons
            // 
            this.PanelButtons.DataPropertyName = "PanelButtons";
            this.PanelButtons.HeaderText = "Buttons";
            this.PanelButtons.Name = "PanelButtons";
            // 
            // List
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(757, 450);
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
        private System.Windows.Forms.DataGridViewTextBoxColumn IdPanel;
        private System.Windows.Forms.DataGridViewTextBoxColumn PanelName;
        private System.Windows.Forms.DataGridViewTextBoxColumn PanelDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn PanelLastUpdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn PanelColumns;
        private System.Windows.Forms.DataGridViewTextBoxColumn PanelRows;
        private System.Windows.Forms.DataGridViewLinkColumn update;
        private System.Windows.Forms.DataGridViewLinkColumn delete;
        private System.Windows.Forms.DataGridViewLinkColumn PanelButtons;
    }
}