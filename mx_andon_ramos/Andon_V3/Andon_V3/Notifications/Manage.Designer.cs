namespace Andon_V3.Notifications
{
    partial class Manage
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
            this.grdData3 = new System.Windows.Forms.DataGridView();
            this.grdData2 = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.levelEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Delete = new System.Windows.Forms.DataGridViewLinkColumn();
            this.grdData1 = new System.Windows.Forms.DataGridView();
            this.idLine = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Search = new System.Windows.Forms.DataGridViewLinkColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.idCorreo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.levelEmail2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Add = new System.Windows.Forms.DataGridViewLinkColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdData3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdData2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdData1)).BeginInit();
            this.SuspendLayout();
            // 
            // grdData3
            // 
            this.grdData3.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdData3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdData3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idCorreo,
            this.name,
            this.levelEmail2,
            this.Add});
            this.grdData3.Location = new System.Drawing.Point(766, 113);
            this.grdData3.Name = "grdData3";
            this.grdData3.Size = new System.Drawing.Size(384, 309);
            this.grdData3.TabIndex = 2;
            this.grdData3.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdData3_CellContentClick);
            this.grdData3.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.grdData3_DataBindingComplete);
            // 
            // grdData2
            // 
            this.grdData2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdData2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdData2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Email,
            this.Type,
            this.levelEmail,
            this.Delete});
            this.grdData2.Location = new System.Drawing.Point(338, 84);
            this.grdData2.Name = "grdData2";
            this.grdData2.Size = new System.Drawing.Size(422, 338);
            this.grdData2.TabIndex = 11;
            this.grdData2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdData2_CellContentClick);
            this.grdData2.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.grdData2_DataBindingComplete);
            // 
            // ID
            // 
            this.ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.ID.DataPropertyName = "idExt";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.Width = 43;
            // 
            // Email
            // 
            this.Email.DataPropertyName = "nameEmail";
            this.Email.HeaderText = "Email";
            this.Email.Name = "Email";
            // 
            // Type
            // 
            this.Type.DataPropertyName = "nameType";
            this.Type.HeaderText = "Type";
            this.Type.Name = "Type";
            // 
            // levelEmail
            // 
            this.levelEmail.DataPropertyName = "levelEmail";
            this.levelEmail.HeaderText = "Level Assigned";
            this.levelEmail.Name = "levelEmail";
            // 
            // Delete
            // 
            this.Delete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Delete.HeaderText = "Delete";
            this.Delete.Name = "Delete";
            this.Delete.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Delete.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Delete.Width = 63;
            // 
            // grdData1
            // 
            this.grdData1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdData1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idLine,
            this.dataGridViewTextBoxColumn1,
            this.Search});
            this.grdData1.Location = new System.Drawing.Point(12, 84);
            this.grdData1.Name = "grdData1";
            this.grdData1.Size = new System.Drawing.Size(320, 338);
            this.grdData1.TabIndex = 12;
            this.grdData1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdData1_CellContentClick);
            this.grdData1.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.grdData1_DataBindingComplete);
            // 
            // idLine
            // 
            this.idLine.DataPropertyName = "idType";
            this.idLine.HeaderText = "ID";
            this.idLine.Name = "idLine";
            this.idLine.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.idLine.Width = 40;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "name";
            this.dataGridViewTextBoxColumn1.HeaderText = "Name";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 150;
            // 
            // Search
            // 
            this.Search.DataPropertyName = "Seach";
            this.Search.HeaderText = "Search";
            this.Search.Name = "Search";
            this.Search.ReadOnly = true;
            this.Search.Text = "Search";
            this.Search.Width = 60;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(91, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 24);
            this.label1.TabIndex = 13;
            this.label1.Text = "Types of support";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(513, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 24);
            this.label2.TabIndex = 14;
            this.label2.Text = "Email by Type";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(936, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 24);
            this.label3.TabIndex = 15;
            this.label3.Text = "Emails";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(766, 84);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(384, 23);
            this.textBox1.TabIndex = 16;
            this.textBox1.Text = "Search...";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // idCorreo
            // 
            this.idCorreo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.idCorreo.DataPropertyName = "id";
            this.idCorreo.HeaderText = "ID";
            this.idCorreo.Name = "idCorreo";
            this.idCorreo.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.idCorreo.Width = 43;
            // 
            // name
            // 
            this.name.DataPropertyName = "correo";
            this.name.HeaderText = "Email";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            // 
            // levelEmail2
            // 
            this.levelEmail2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.levelEmail2.DataPropertyName = "levelEmail";
            this.levelEmail2.HeaderText = "Level Assigned";
            this.levelEmail2.Name = "levelEmail2";
            this.levelEmail2.Width = 96;
            // 
            // Add
            // 
            this.Add.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Add.HeaderText = "Add";
            this.Add.Name = "Add";
            this.Add.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Add.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Add.Width = 51;
            // 
            // Manage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1163, 450);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grdData1);
            this.Controls.Add(this.grdData2);
            this.Controls.Add(this.grdData3);
            this.Name = "Manage";
            this.Text = "Manage";
            this.Load += new System.EventHandler(this.Manage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdData3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdData2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdData1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grdData3;
        private System.Windows.Forms.DataGridView grdData2;
        private System.Windows.Forms.DataGridView grdData1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idLine;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewLinkColumn Search;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn levelEmail;
        private System.Windows.Forms.DataGridViewLinkColumn Delete;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCorreo;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn levelEmail2;
        private System.Windows.Forms.DataGridViewLinkColumn Add;
    }
}