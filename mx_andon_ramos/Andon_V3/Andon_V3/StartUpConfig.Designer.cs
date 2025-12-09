namespace Andon_V3
{
    partial class StartUpConfig
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
            this.label2 = new System.Windows.Forms.Label();
            this.lblZM = new System.Windows.Forms.Label();
            this.lblDivs = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblHostname = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.cmbApp = new System.Windows.Forms.ComboBox();
            this.cmbLine = new System.Windows.Forms.ComboBox();
            this.txtDivitions = new System.Windows.Forms.TextBox();
            this.chkAlways = new System.Windows.Forms.CheckBox();
            this.cmbScreen = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkTabletMode = new System.Windows.Forms.CheckBox();
            this.listBoxZones = new System.Windows.Forms.ListBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbPanelGroup = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Hostname";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Line";
            // 
            // lblZM
            // 
            this.lblZM.AutoSize = true;
            this.lblZM.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblZM.Location = new System.Drawing.Point(168, 17);
            this.lblZM.Name = "lblZM";
            this.lblZM.Size = new System.Drawing.Size(162, 17);
            this.lblZM.TabIndex = 2;
            this.lblZM.Text = "Choose zones to display";
            // 
            // lblDivs
            // 
            this.lblDivs.AutoSize = true;
            this.lblDivs.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDivs.Location = new System.Drawing.Point(26, 22);
            this.lblDivs.Name = "lblDivs";
            this.lblDivs.Size = new System.Drawing.Size(113, 17);
            this.lblDivs.TabIndex = 3;
            this.lblDivs.Text = "Parts per screen";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 149);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "Screen";
            // 
            // lblHostname
            // 
            this.lblHostname.AutoSize = true;
            this.lblHostname.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblHostname.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHostname.Location = new System.Drawing.Point(129, 41);
            this.lblHostname.Name = "lblHostname";
            this.lblHostname.Size = new System.Drawing.Size(72, 17);
            this.lblHostname.TabIndex = 6;
            this.lblHostname.Text = "Hostname";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.DarkCyan;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(178, 403);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(83, 55);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Start";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cmbApp
            // 
            this.cmbApp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbApp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbApp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbApp.FormattingEnabled = true;
            this.cmbApp.IntegralHeight = false;
            this.cmbApp.ItemHeight = 20;
            this.cmbApp.Location = new System.Drawing.Point(132, 71);
            this.cmbApp.Name = "cmbApp";
            this.cmbApp.Size = new System.Drawing.Size(340, 28);
            this.cmbApp.TabIndex = 9;
            this.cmbApp.SelectedIndexChanged += new System.EventHandler(this.cmbApp_SelectedIndexChanged);
            // 
            // cmbLine
            // 
            this.cmbLine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbLine.FormattingEnabled = true;
            this.cmbLine.Location = new System.Drawing.Point(132, 104);
            this.cmbLine.Name = "cmbLine";
            this.cmbLine.Size = new System.Drawing.Size(340, 28);
            this.cmbLine.TabIndex = 10;
            // 
            // txtDivitions
            // 
            this.txtDivitions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDivitions.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDivitions.Location = new System.Drawing.Point(29, 48);
            this.txtDivitions.Name = "txtDivitions";
            this.txtDivitions.Size = new System.Drawing.Size(136, 22);
            this.txtDivitions.TabIndex = 12;
            // 
            // chkAlways
            // 
            this.chkAlways.AutoSize = true;
            this.chkAlways.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAlways.Location = new System.Drawing.Point(177, 367);
            this.chkAlways.Name = "chkAlways";
            this.chkAlways.Size = new System.Drawing.Size(243, 21);
            this.chkAlways.TabIndex = 13;
            this.chkAlways.Text = "Start always with this configuration";
            this.chkAlways.UseVisualStyleBackColor = true;
            // 
            // cmbScreen
            // 
            this.cmbScreen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbScreen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbScreen.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbScreen.FormattingEnabled = true;
            this.cmbScreen.Location = new System.Drawing.Point(131, 138);
            this.cmbScreen.Name = "cmbScreen";
            this.cmbScreen.Size = new System.Drawing.Size(340, 28);
            this.cmbScreen.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(11, 82);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 17);
            this.label6.TabIndex = 14;
            this.label6.Text = "App";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Silver;
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.chkTabletMode);
            this.groupBox1.Controls.Add(this.listBoxZones);
            this.groupBox1.Controls.Add(this.lblZM);
            this.groupBox1.Controls.Add(this.lblDivs);
            this.groupBox1.Controls.Add(this.txtDivitions);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(6, 207);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(486, 154);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Supermarket";
            // 
            // chkTabletMode
            // 
            this.chkTabletMode.AutoSize = true;
            this.chkTabletMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTabletMode.Location = new System.Drawing.Point(29, 115);
            this.chkTabletMode.Name = "chkTabletMode";
            this.chkTabletMode.Size = new System.Drawing.Size(15, 14);
            this.chkTabletMode.TabIndex = 21;
            this.chkTabletMode.UseVisualStyleBackColor = true;
            // 
            // listBoxZones
            // 
            this.listBoxZones.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxZones.FormattingEnabled = true;
            this.listBoxZones.ItemHeight = 24;
            this.listBoxZones.Location = new System.Drawing.Point(171, 48);
            this.listBoxZones.Name = "listBoxZones";
            this.listBoxZones.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBoxZones.Size = new System.Drawing.Size(295, 100);
            this.listBoxZones.TabIndex = 21;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Firebrick;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(267, 403);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(83, 55);
            this.button2.TabIndex = 17;
            this.button2.Text = "Close";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(157, 15);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(182, 26);
            this.label8.TabIndex = 18;
            this.label8.Text = "ANDON SETUP";
            // 
            // cmbPanelGroup
            // 
            this.cmbPanelGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPanelGroup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbPanelGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPanelGroup.FormattingEnabled = true;
            this.cmbPanelGroup.Location = new System.Drawing.Point(131, 173);
            this.cmbPanelGroup.Name = "cmbPanelGroup";
            this.cmbPanelGroup.Size = new System.Drawing.Size(340, 28);
            this.cmbPanelGroup.TabIndex = 20;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 184);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 17);
            this.label3.TabIndex = 19;
            this.label3.Text = "Panel Group";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(26, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 17);
            this.label4.TabIndex = 22;
            this.label4.Text = "Tablet mode";
            // 
            // StartUpConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(527, 487);
            this.Controls.Add(this.cmbPanelGroup);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.cmbScreen);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.chkAlways);
            this.Controls.Add(this.cmbLine);
            this.Controls.Add(this.cmbApp);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblHostname);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Name = "StartUpConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Startup Config";
            this.Load += new System.EventHandler(this.StartUpConfig_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblZM;
        private System.Windows.Forms.Label lblDivs;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblHostname;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox cmbApp;
        private System.Windows.Forms.ComboBox cmbLine;
        private System.Windows.Forms.TextBox txtDivitions;
        private System.Windows.Forms.CheckBox chkAlways;
        private System.Windows.Forms.ComboBox cmbScreen;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbPanelGroup;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox listBoxZones;
        private System.Windows.Forms.CheckBox chkTabletMode;
        private System.Windows.Forms.Label label4;
    }
}