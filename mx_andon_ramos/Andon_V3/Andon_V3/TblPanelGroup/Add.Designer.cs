namespace Andon_V3.TblPanelGroup
{
    partial class Add
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
            this.lblAction = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.btnAccept = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbLine = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblTowerIp = new System.Windows.Forms.Label();
            this.txtTowerIp = new System.Windows.Forms.TextBox();
            this.lblTowerCmd = new System.Windows.Forms.Label();
            this.txtTowerTestCmd = new System.Windows.Forms.TextBox();
            this.chkTowerActive = new System.Windows.Forms.CheckBox();
            this.txtTowerResult = new System.Windows.Forms.RichTextBox();
            this.btnTowerTest = new System.Windows.Forms.Button();
            this.btnTowerClear = new System.Windows.Forms.Button();
            this.lblClearCmd = new System.Windows.Forms.Label();
            this.txtClearCmd = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblAction
            // 
            this.lblAction.AutoSize = true;
            this.lblAction.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAction.Location = new System.Drawing.Point(67, 28);
            this.lblAction.Name = "lblAction";
            this.lblAction.Size = new System.Drawing.Size(66, 22);
            this.lblAction.TabIndex = 0;
            this.lblAction.Text = "Action";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(154, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Panel Group";
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(135, 97);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(328, 26);
            this.txtName.TabIndex = 2;
            // 
            // btnAccept
            // 
            this.btnAccept.BackColor = System.Drawing.Color.Teal;
            this.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAccept.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAccept.ForeColor = System.Drawing.Color.White;
            this.btnAccept.Location = new System.Drawing.Point(122, 462);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(109, 49);
            this.btnAccept.TabIndex = 3;
            this.btnAccept.Text = "Accept";
            this.btnAccept.UseVisualStyleBackColor = false;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(27, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Group name:";
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(311, 462);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(109, 49);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(78, 169);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 20);
            this.label3.TabIndex = 13;
            this.label3.Text = "Lines:";
            // 
            // cmbLine
            // 
            this.cmbLine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbLine.FormattingEnabled = true;
            this.cmbLine.Location = new System.Drawing.Point(135, 161);
            this.cmbLine.Name = "cmbLine";
            this.cmbLine.Size = new System.Drawing.Size(328, 28);
            this.cmbLine.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(33, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 20);
            this.label4.TabIndex = 15;
            this.label4.Text = "Group desc:";
            // 
            // txtDesc
            // 
            this.txtDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDesc.Location = new System.Drawing.Point(135, 129);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(328, 26);
            this.txtDesc.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(28, 198);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 20);
            this.label5.TabIndex = 17;
            this.label5.Text = "Tower active:";
            // 
            // lblTowerIp
            // 
            this.lblTowerIp.AutoSize = true;
            this.lblTowerIp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTowerIp.Location = new System.Drawing.Point(54, 233);
            this.lblTowerIp.Name = "lblTowerIp";
            this.lblTowerIp.Size = new System.Drawing.Size(75, 20);
            this.lblTowerIp.TabIndex = 19;
            this.lblTowerIp.Text = "Tower IP:";
            // 
            // txtTowerIp
            // 
            this.txtTowerIp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTowerIp.Location = new System.Drawing.Point(135, 227);
            this.txtTowerIp.Name = "txtTowerIp";
            this.txtTowerIp.Size = new System.Drawing.Size(328, 26);
            this.txtTowerIp.TabIndex = 18;
            // 
            // lblTowerCmd
            // 
            this.lblTowerCmd.AutoSize = true;
            this.lblTowerCmd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTowerCmd.Location = new System.Drawing.Point(8, 265);
            this.lblTowerCmd.Name = "lblTowerCmd";
            this.lblTowerCmd.Size = new System.Drawing.Size(121, 20);
            this.lblTowerCmd.TabIndex = 21;
            this.lblTowerCmd.Text = "Tower test cmd:";
            // 
            // txtTowerTestCmd
            // 
            this.txtTowerTestCmd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTowerTestCmd.Location = new System.Drawing.Point(135, 259);
            this.txtTowerTestCmd.Name = "txtTowerTestCmd";
            this.txtTowerTestCmd.Size = new System.Drawing.Size(262, 26);
            this.txtTowerTestCmd.TabIndex = 20;
            // 
            // chkTowerActive
            // 
            this.chkTowerActive.AutoSize = true;
            this.chkTowerActive.Checked = true;
            this.chkTowerActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTowerActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTowerActive.Location = new System.Drawing.Point(135, 202);
            this.chkTowerActive.Name = "chkTowerActive";
            this.chkTowerActive.Size = new System.Drawing.Size(15, 14);
            this.chkTowerActive.TabIndex = 22;
            this.chkTowerActive.UseVisualStyleBackColor = true;
            this.chkTowerActive.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // txtTowerResult
            // 
            this.txtTowerResult.Location = new System.Drawing.Point(32, 337);
            this.txtTowerResult.Name = "txtTowerResult";
            this.txtTowerResult.ReadOnly = true;
            this.txtTowerResult.Size = new System.Drawing.Size(431, 79);
            this.txtTowerResult.TabIndex = 23;
            this.txtTowerResult.Text = "";
            // 
            // btnTowerTest
            // 
            this.btnTowerTest.BackColor = System.Drawing.Color.Teal;
            this.btnTowerTest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTowerTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTowerTest.ForeColor = System.Drawing.Color.White;
            this.btnTowerTest.Location = new System.Drawing.Point(403, 259);
            this.btnTowerTest.Name = "btnTowerTest";
            this.btnTowerTest.Size = new System.Drawing.Size(60, 26);
            this.btnTowerTest.TabIndex = 24;
            this.btnTowerTest.Text = "Test";
            this.btnTowerTest.UseVisualStyleBackColor = false;
            this.btnTowerTest.Click += new System.EventHandler(this.btnTowerTest_Click);
            // 
            // btnTowerClear
            // 
            this.btnTowerClear.BackColor = System.Drawing.Color.Teal;
            this.btnTowerClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTowerClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTowerClear.ForeColor = System.Drawing.Color.White;
            this.btnTowerClear.Location = new System.Drawing.Point(403, 291);
            this.btnTowerClear.Name = "btnTowerClear";
            this.btnTowerClear.Size = new System.Drawing.Size(60, 26);
            this.btnTowerClear.TabIndex = 28;
            this.btnTowerClear.Text = "Test";
            this.btnTowerClear.UseVisualStyleBackColor = false;
            this.btnTowerClear.Click += new System.EventHandler(this.btnTowerClear_Click);
            // 
            // lblClearCmd
            // 
            this.lblClearCmd.AutoSize = true;
            this.lblClearCmd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClearCmd.Location = new System.Drawing.Point(1, 297);
            this.lblClearCmd.Name = "lblClearCmd";
            this.lblClearCmd.Size = new System.Drawing.Size(128, 20);
            this.lblClearCmd.TabIndex = 26;
            this.lblClearCmd.Text = "Tower clear cmd:";
            // 
            // txtClearCmd
            // 
            this.txtClearCmd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClearCmd.Location = new System.Drawing.Point(135, 291);
            this.txtClearCmd.Name = "txtClearCmd";
            this.txtClearCmd.Size = new System.Drawing.Size(262, 26);
            this.txtClearCmd.TabIndex = 25;
            // 
            // Add
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 523);
            this.Controls.Add(this.btnTowerClear);
            this.Controls.Add(this.lblClearCmd);
            this.Controls.Add(this.txtClearCmd);
            this.Controls.Add(this.btnTowerTest);
            this.Controls.Add(this.txtTowerResult);
            this.Controls.Add(this.chkTowerActive);
            this.Controls.Add(this.lblTowerCmd);
            this.Controls.Add(this.txtTowerTestCmd);
            this.Controls.Add(this.lblTowerIp);
            this.Controls.Add(this.txtTowerIp);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDesc);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbLine);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblAction);
            this.Name = "Add";
            this.Text = "Add";
            this.Load += new System.EventHandler(this.Add_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAction;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbLine;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblTowerIp;
        private System.Windows.Forms.TextBox txtTowerIp;
        private System.Windows.Forms.Label lblTowerCmd;
        private System.Windows.Forms.TextBox txtTowerTestCmd;
        private System.Windows.Forms.CheckBox chkTowerActive;
        private System.Windows.Forms.RichTextBox txtTowerResult;
        private System.Windows.Forms.Button btnTowerTest;
        private System.Windows.Forms.Button btnTowerClear;
        private System.Windows.Forms.Label lblClearCmd;
        private System.Windows.Forms.TextBox txtClearCmd;
    }
}