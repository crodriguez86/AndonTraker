namespace Andon_V3.Notifications
{
    partial class ManageLevel
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.rdLevel1 = new System.Windows.Forms.RadioButton();
            this.rdLevel2 = new System.Windows.Forms.RadioButton();
            this.rdLevel3 = new System.Windows.Forms.RadioButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Delete = new System.Windows.Forms.DataGridViewLinkColumn();
            this.idCorreo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.levelEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Add = new System.Windows.Forms.DataGridViewLinkColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdData3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdData2)).BeginInit();
            this.SuspendLayout();
            // 
            // grdData3
            // 
            this.grdData3.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdData3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdData3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idCorreo,
            this.name,
            this.levelEmail,
            this.Add});
            this.grdData3.Location = new System.Drawing.Point(554, 113);
            this.grdData3.Name = "grdData3";
            this.grdData3.Size = new System.Drawing.Size(429, 309);
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
            this.idLevel,
            this.Delete});
            this.grdData2.Location = new System.Drawing.Point(171, 84);
            this.grdData2.Name = "grdData2";
            this.grdData2.Size = new System.Drawing.Size(377, 338);
            this.grdData2.TabIndex = 11;
            this.grdData2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdData2_CellContentClick);
            this.grdData2.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.grdData2_DataBindingComplete);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 24);
            this.label1.TabIndex = 13;
            this.label1.Text = "Levels";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(334, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 24);
            this.label2.TabIndex = 14;
            this.label2.Text = "Email by Level";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(769, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 24);
            this.label3.TabIndex = 15;
            this.label3.Text = "Emails";
            // 
            // rdLevel1
            // 
            this.rdLevel1.AutoSize = true;
            this.rdLevel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdLevel1.Location = new System.Drawing.Point(13, 84);
            this.rdLevel1.Name = "rdLevel1";
            this.rdLevel1.Size = new System.Drawing.Size(77, 24);
            this.rdLevel1.TabIndex = 16;
            this.rdLevel1.TabStop = true;
            this.rdLevel1.Text = "Level 1";
            this.rdLevel1.UseVisualStyleBackColor = true;
            this.rdLevel1.CheckedChanged += new System.EventHandler(this.rdLevel1_CheckedChanged);
            // 
            // rdLevel2
            // 
            this.rdLevel2.AutoSize = true;
            this.rdLevel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdLevel2.Location = new System.Drawing.Point(13, 124);
            this.rdLevel2.Name = "rdLevel2";
            this.rdLevel2.Size = new System.Drawing.Size(77, 24);
            this.rdLevel2.TabIndex = 17;
            this.rdLevel2.TabStop = true;
            this.rdLevel2.Text = "Level 2";
            this.rdLevel2.UseVisualStyleBackColor = true;
            this.rdLevel2.CheckedChanged += new System.EventHandler(this.rdLevel2_CheckedChanged);
            // 
            // rdLevel3
            // 
            this.rdLevel3.AutoSize = true;
            this.rdLevel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdLevel3.Location = new System.Drawing.Point(13, 166);
            this.rdLevel3.Name = "rdLevel3";
            this.rdLevel3.Size = new System.Drawing.Size(77, 24);
            this.rdLevel3.TabIndex = 18;
            this.rdLevel3.TabStop = true;
            this.rdLevel3.Text = "Level 3";
            this.rdLevel3.UseVisualStyleBackColor = true;
            this.rdLevel3.CheckedChanged += new System.EventHandler(this.rdLevel3_CheckedChanged);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(554, 84);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(429, 23);
            this.textBox1.TabIndex = 19;
            this.textBox1.Text = "Search...";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // ID
            // 
            this.ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.ID.DataPropertyName = "idExl";
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
            // idLevel
            // 
            this.idLevel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.idLevel.DataPropertyName = "idLevel";
            this.idLevel.HeaderText = "Level";
            this.idLevel.Name = "idLevel";
            this.idLevel.Width = 58;
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
            // levelEmail
            // 
            this.levelEmail.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.levelEmail.DataPropertyName = "levelEmail";
            this.levelEmail.HeaderText = "Level Assigned";
            this.levelEmail.Name = "levelEmail";
            this.levelEmail.Width = 96;
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
            // ManageLevel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1005, 450);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.rdLevel3);
            this.Controls.Add(this.rdLevel2);
            this.Controls.Add(this.rdLevel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grdData2);
            this.Controls.Add(this.grdData3);
            this.Name = "ManageLevel";
            this.Text = "Manage";
            this.Load += new System.EventHandler(this.Manage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdData3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdData2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grdData3;
        private System.Windows.Forms.DataGridView grdData2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rdLevel1;
        private System.Windows.Forms.RadioButton rdLevel2;
        private System.Windows.Forms.RadioButton rdLevel3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCorreo;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn levelEmail;
        private System.Windows.Forms.DataGridViewLinkColumn Add;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn idLevel;
        private System.Windows.Forms.DataGridViewLinkColumn Delete;
    }
}