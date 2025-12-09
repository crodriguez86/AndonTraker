namespace Andon_V3
{
    partial class Configuration
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
            this.components = new System.ComponentModel.Container();
            this.grdMessages = new System.Windows.Forms.DataGridView();
            this.idMessage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tagValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.msg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.line = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tagName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.namePlc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.f1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.f2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.f3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Update = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Delete = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Copy = new System.Windows.Forms.DataGridViewLinkColumn();
            this.idAV = new System.Windows.Forms.DataGridViewLinkColumn();
            this.cmbLine = new System.Windows.Forms.ComboBox();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbTag = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblCountMsg = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zonesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addLineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.typesOfSupportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pLCsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tagValuesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.emailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fontsizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fontColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.andonConfigToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notificationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.emailByLevelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.previewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendNowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteAllToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteFromRangeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.usersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.realtimeTAGMonitorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripUserName = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripLastLogin = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.grdMessages)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdMessages
            // 
            this.grdMessages.AllowUserToAddRows = false;
            this.grdMessages.AllowUserToOrderColumns = true;
            this.grdMessages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdMessages.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdMessages.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdMessages.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idMessage,
            this.tagValue,
            this.msg,
            this.line,
            this.type,
            this.tagName,
            this.namePlc,
            this.f1,
            this.f2,
            this.f3,
            this.Update,
            this.Delete,
            this.Copy,
            this.idAV});
            this.grdMessages.Location = new System.Drawing.Point(0, 136);
            this.grdMessages.Name = "grdMessages";
            this.grdMessages.ReadOnly = true;
            this.grdMessages.Size = new System.Drawing.Size(1284, 511);
            this.grdMessages.TabIndex = 0;
            this.grdMessages.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdMessages_CellContentClick);
            this.grdMessages.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdMessages_CellContentDoubleClick);
            this.grdMessages.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.grdMessages_CellMouseDown);
            this.grdMessages.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.grdMessages_DataBindingComplete);
            // 
            // idMessage
            // 
            this.idMessage.DataPropertyName = "idMessage";
            this.idMessage.FillWeight = 8.607324F;
            this.idMessage.HeaderText = "Msg ID";
            this.idMessage.Name = "idMessage";
            this.idMessage.ReadOnly = true;
            // 
            // tagValue
            // 
            this.tagValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.tagValue.DataPropertyName = "tagValue";
            this.tagValue.FillWeight = 16.25574F;
            this.tagValue.HeaderText = "Tag Value";
            this.tagValue.Name = "tagValue";
            this.tagValue.ReadOnly = true;
            this.tagValue.Width = 81;
            // 
            // msg
            // 
            this.msg.DataPropertyName = "message";
            this.msg.FillWeight = 16.25574F;
            this.msg.HeaderText = "Msg";
            this.msg.Name = "msg";
            this.msg.ReadOnly = true;
            // 
            // line
            // 
            this.line.DataPropertyName = "nameLine";
            this.line.FillWeight = 16.25574F;
            this.line.HeaderText = "Line";
            this.line.Name = "line";
            this.line.ReadOnly = true;
            // 
            // type
            // 
            this.type.DataPropertyName = "nameType";
            this.type.FillWeight = 16.25574F;
            this.type.HeaderText = "Type";
            this.type.Name = "type";
            this.type.ReadOnly = true;
            // 
            // tagName
            // 
            this.tagName.DataPropertyName = "tagName";
            this.tagName.FillWeight = 16.25574F;
            this.tagName.HeaderText = "Tag";
            this.tagName.Name = "tagName";
            this.tagName.ReadOnly = true;
            // 
            // namePlc
            // 
            this.namePlc.DataPropertyName = "namePlc";
            this.namePlc.FillWeight = 16.25574F;
            this.namePlc.HeaderText = "PLC";
            this.namePlc.Name = "namePlc";
            this.namePlc.ReadOnly = true;
            // 
            // f1
            // 
            this.f1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.f1.DataPropertyName = "font";
            this.f1.FillWeight = 40F;
            this.f1.HeaderText = "Font 1";
            this.f1.Name = "f1";
            this.f1.ReadOnly = true;
            this.f1.Width = 62;
            // 
            // f2
            // 
            this.f2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.f2.DataPropertyName = "font2";
            this.f2.FillWeight = 40F;
            this.f2.HeaderText = "Font 2";
            this.f2.Name = "f2";
            this.f2.ReadOnly = true;
            this.f2.Width = 58;
            // 
            // f3
            // 
            this.f3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.f3.DataPropertyName = "font3";
            this.f3.FillWeight = 40F;
            this.f3.HeaderText = "Font 3";
            this.f3.Name = "f3";
            this.f3.ReadOnly = true;
            this.f3.Width = 58;
            // 
            // Update
            // 
            this.Update.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Update.FillWeight = 16.25574F;
            this.Update.HeaderText = "Update";
            this.Update.Name = "Update";
            this.Update.ReadOnly = true;
            this.Update.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Update.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Update.Width = 67;
            // 
            // Delete
            // 
            this.Delete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Delete.FillWeight = 16.25574F;
            this.Delete.HeaderText = "Delete";
            this.Delete.Name = "Delete";
            this.Delete.ReadOnly = true;
            this.Delete.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Delete.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Delete.Width = 63;
            // 
            // Copy
            // 
            this.Copy.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Copy.FillWeight = 16.25574F;
            this.Copy.HeaderText = "Copy Values";
            this.Copy.Name = "Copy";
            this.Copy.ReadOnly = true;
            this.Copy.Width = 65;
            // 
            // idAV
            // 
            this.idAV.DataPropertyName = "idAndonValue";
            this.idAV.HeaderText = "AV";
            this.idAV.Name = "idAV";
            this.idAV.ReadOnly = true;
            this.idAV.Visible = false;
            // 
            // cmbLine
            // 
            this.cmbLine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbLine.FormattingEnabled = true;
            this.cmbLine.Location = new System.Drawing.Point(23, 66);
            this.cmbLine.Name = "cmbLine";
            this.cmbLine.Size = new System.Drawing.Size(170, 24);
            this.cmbLine.TabIndex = 1;
            this.cmbLine.SelectedIndexChanged += new System.EventHandler(this.cmbLine_SelectedIndexChanged);
            // 
            // cmbType
            // 
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(215, 67);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(179, 24);
            this.cmbType.TabIndex = 2;
            this.cmbType.SelectedIndexChanged += new System.EventHandler(this.cmbType_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Line";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(211, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Type of support";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Teal;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(739, 38);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 78);
            this.button1.TabIndex = 5;
            this.button1.Text = "Search";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.Color.Teal;
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.ForeColor = System.Drawing.Color.White;
            this.btnNew.Location = new System.Drawing.Point(1033, 38);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(104, 78);
            this.btnNew.TabIndex = 6;
            this.btnNew.Text = "Add new message";
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(413, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Tag name / PLC";
            // 
            // cmbTag
            // 
            this.cmbTag.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTag.Enabled = false;
            this.cmbTag.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTag.FormattingEnabled = true;
            this.cmbTag.Location = new System.Drawing.Point(417, 66);
            this.cmbTag.Name = "cmbTag";
            this.cmbTag.Size = new System.Drawing.Size(316, 24);
            this.cmbTag.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Messages count:";
            // 
            // lblCountMsg
            // 
            this.lblCountMsg.AutoSize = true;
            this.lblCountMsg.Location = new System.Drawing.Point(100, 16);
            this.lblCountMsg.Name = "lblCountMsg";
            this.lblCountMsg.Size = new System.Drawing.Size(27, 13);
            this.lblCountMsg.TabIndex = 10;
            this.lblCountMsg.Text = "N/A";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lblCountMsg);
            this.groupBox1.Location = new System.Drawing.Point(833, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(194, 85);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Information";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem,
            this.notificationsToolStripMenuItem,
            this.reloadToolStripMenuItem,
            this.statusToolStripMenuItem,
            this.logsToolStripMenuItem,
            this.reportToolStripMenuItem,
            this.usersToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1284, 24);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zonesToolStripMenuItem,
            this.addLineToolStripMenuItem,
            this.typesOfSupportToolStripMenuItem,
            this.pLCsToolStripMenuItem,
            this.tagValuesToolStripMenuItem,
            this.emailsToolStripMenuItem,
            this.fontsizeToolStripMenuItem,
            this.fontColorToolStripMenuItem,
            this.backgroundColorToolStripMenuItem,
            this.andonConfigToolStripMenuItem,
            this.panelsToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.menuToolStripMenuItem.Text = "Manage";
            // 
            // zonesToolStripMenuItem
            // 
            this.zonesToolStripMenuItem.Name = "zonesToolStripMenuItem";
            this.zonesToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.zonesToolStripMenuItem.Text = "Zones";
            this.zonesToolStripMenuItem.Click += new System.EventHandler(this.zonesToolStripMenuItem_Click);
            // 
            // addLineToolStripMenuItem
            // 
            this.addLineToolStripMenuItem.Name = "addLineToolStripMenuItem";
            this.addLineToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.addLineToolStripMenuItem.Text = "Lines";
            this.addLineToolStripMenuItem.Click += new System.EventHandler(this.addLineToolStripMenuItem_Click);
            // 
            // typesOfSupportToolStripMenuItem
            // 
            this.typesOfSupportToolStripMenuItem.Name = "typesOfSupportToolStripMenuItem";
            this.typesOfSupportToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.typesOfSupportToolStripMenuItem.Text = "Types";
            this.typesOfSupportToolStripMenuItem.Click += new System.EventHandler(this.typesOfSupportToolStripMenuItem_Click);
            // 
            // pLCsToolStripMenuItem
            // 
            this.pLCsToolStripMenuItem.Name = "pLCsToolStripMenuItem";
            this.pLCsToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.pLCsToolStripMenuItem.Text = "PLC\'s";
            this.pLCsToolStripMenuItem.Click += new System.EventHandler(this.pLCsToolStripMenuItem_Click);
            // 
            // tagValuesToolStripMenuItem
            // 
            this.tagValuesToolStripMenuItem.Name = "tagValuesToolStripMenuItem";
            this.tagValuesToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.tagValuesToolStripMenuItem.Text = "Andon values";
            this.tagValuesToolStripMenuItem.Click += new System.EventHandler(this.tagValuesToolStripMenuItem_Click);
            // 
            // emailsToolStripMenuItem
            // 
            this.emailsToolStripMenuItem.Name = "emailsToolStripMenuItem";
            this.emailsToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.emailsToolStripMenuItem.Text = "Emails";
            this.emailsToolStripMenuItem.Click += new System.EventHandler(this.emailsToolStripMenuItem_Click);
            // 
            // fontsizeToolStripMenuItem
            // 
            this.fontsizeToolStripMenuItem.Name = "fontsizeToolStripMenuItem";
            this.fontsizeToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.fontsizeToolStripMenuItem.Text = "Fontsize";
            this.fontsizeToolStripMenuItem.Click += new System.EventHandler(this.fontsizeToolStripMenuItem_Click);
            // 
            // fontColorToolStripMenuItem
            // 
            this.fontColorToolStripMenuItem.Name = "fontColorToolStripMenuItem";
            this.fontColorToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.fontColorToolStripMenuItem.Text = "Font color";
            this.fontColorToolStripMenuItem.Click += new System.EventHandler(this.fontColorToolStripMenuItem_Click);
            // 
            // backgroundColorToolStripMenuItem
            // 
            this.backgroundColorToolStripMenuItem.Name = "backgroundColorToolStripMenuItem";
            this.backgroundColorToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.backgroundColorToolStripMenuItem.Text = "Background color";
            this.backgroundColorToolStripMenuItem.Click += new System.EventHandler(this.backgroundColorToolStripMenuItem_Click);
            // 
            // andonConfigToolStripMenuItem
            // 
            this.andonConfigToolStripMenuItem.Name = "andonConfigToolStripMenuItem";
            this.andonConfigToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.andonConfigToolStripMenuItem.Text = "Andon config";
            this.andonConfigToolStripMenuItem.Click += new System.EventHandler(this.andonConfigToolStripMenuItem_Click);
            // 
            // panelsToolStripMenuItem
            // 
            this.panelsToolStripMenuItem.Name = "panelsToolStripMenuItem";
            this.panelsToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.panelsToolStripMenuItem.Text = "Panels";
            this.panelsToolStripMenuItem.Click += new System.EventHandler(this.panelsToolStripMenuItem_Click);
            // 
            // notificationsToolStripMenuItem
            // 
            this.notificationsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manageToolStripMenuItem,
            this.emailByLevelToolStripMenuItem});
            this.notificationsToolStripMenuItem.Name = "notificationsToolStripMenuItem";
            this.notificationsToolStripMenuItem.Size = new System.Drawing.Size(87, 20);
            this.notificationsToolStripMenuItem.Text = "Notifications";
            // 
            // manageToolStripMenuItem
            // 
            this.manageToolStripMenuItem.Name = "manageToolStripMenuItem";
            this.manageToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.manageToolStripMenuItem.Text = "Email byType";
            this.manageToolStripMenuItem.Click += new System.EventHandler(this.manageToolStripMenuItem_Click);
            // 
            // emailByLevelToolStripMenuItem
            // 
            this.emailByLevelToolStripMenuItem.Name = "emailByLevelToolStripMenuItem";
            this.emailByLevelToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.emailByLevelToolStripMenuItem.Text = "Email by Level";
            this.emailByLevelToolStripMenuItem.Click += new System.EventHandler(this.emailByLevelToolStripMenuItem_Click);
            // 
            // reloadToolStripMenuItem
            // 
            this.reloadToolStripMenuItem.Name = "reloadToolStripMenuItem";
            this.reloadToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.reloadToolStripMenuItem.Text = "Reload";
            this.reloadToolStripMenuItem.Click += new System.EventHandler(this.reloadToolStripMenuItem_Click);
            // 
            // statusToolStripMenuItem
            // 
            this.statusToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.previewToolStripMenuItem,
            this.sendNowToolStripMenuItem});
            this.statusToolStripMenuItem.Name = "statusToolStripMenuItem";
            this.statusToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.statusToolStripMenuItem.Text = "Status";
            // 
            // previewToolStripMenuItem
            // 
            this.previewToolStripMenuItem.Name = "previewToolStripMenuItem";
            this.previewToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.previewToolStripMenuItem.Text = "Preview";
            this.previewToolStripMenuItem.Click += new System.EventHandler(this.previewToolStripMenuItem_Click);
            // 
            // sendNowToolStripMenuItem
            // 
            this.sendNowToolStripMenuItem.Name = "sendNowToolStripMenuItem";
            this.sendNowToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.sendNowToolStripMenuItem.Text = "Send now";
            this.sendNowToolStripMenuItem.Click += new System.EventHandler(this.sendNowToolStripMenuItem_Click);
            // 
            // logsToolStripMenuItem
            // 
            this.logsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.logsToolStripMenuItem.Name = "logsToolStripMenuItem";
            this.logsToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.logsToolStripMenuItem.Text = "Logs";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewToolStripMenuItem2,
            this.deleteToolStripMenuItem1});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.viewToolStripMenuItem.Text = "Database";
            this.viewToolStripMenuItem.Click += new System.EventHandler(this.viewToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem2
            // 
            this.viewToolStripMenuItem2.Name = "viewToolStripMenuItem2";
            this.viewToolStripMenuItem2.Size = new System.Drawing.Size(107, 22);
            this.viewToolStripMenuItem2.Text = "View";
            this.viewToolStripMenuItem2.Click += new System.EventHandler(this.viewToolStripMenuItem2_Click);
            // 
            // deleteToolStripMenuItem1
            // 
            this.deleteToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteAllToolStripMenuItem1,
            this.deleteFromRangeToolStripMenuItem});
            this.deleteToolStripMenuItem1.Name = "deleteToolStripMenuItem1";
            this.deleteToolStripMenuItem1.Size = new System.Drawing.Size(107, 22);
            this.deleteToolStripMenuItem1.Text = "Delete";
            // 
            // deleteAllToolStripMenuItem1
            // 
            this.deleteAllToolStripMenuItem1.Name = "deleteAllToolStripMenuItem1";
            this.deleteAllToolStripMenuItem1.Size = new System.Drawing.Size(169, 22);
            this.deleteAllToolStripMenuItem1.Text = "Delete All";
            this.deleteAllToolStripMenuItem1.Click += new System.EventHandler(this.deleteAllToolStripMenuItem1_Click);
            // 
            // deleteFromRangeToolStripMenuItem
            // 
            this.deleteFromRangeToolStripMenuItem.Name = "deleteFromRangeToolStripMenuItem";
            this.deleteFromRangeToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.deleteFromRangeToolStripMenuItem.Text = "Delete from range";
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteAllToolStripMenuItem});
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.deleteToolStripMenuItem.Text = "Local files";
            // 
            // deleteAllToolStripMenuItem
            // 
            this.deleteAllToolStripMenuItem.Name = "deleteAllToolStripMenuItem";
            this.deleteAllToolStripMenuItem.Size = new System.Drawing.Size(99, 22);
            this.deleteAllToolStripMenuItem.Text = "View";
            this.deleteAllToolStripMenuItem.Click += new System.EventHandler(this.deleteAllToolStripMenuItem_Click);
            // 
            // reportToolStripMenuItem
            // 
            this.reportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewToolStripMenuItem1});
            this.reportToolStripMenuItem.Name = "reportToolStripMenuItem";
            this.reportToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.reportToolStripMenuItem.Text = "Report";
            // 
            // viewToolStripMenuItem1
            // 
            this.viewToolStripMenuItem1.Name = "viewToolStripMenuItem1";
            this.viewToolStripMenuItem1.Size = new System.Drawing.Size(99, 22);
            this.viewToolStripMenuItem1.Text = "View";
            this.viewToolStripMenuItem1.Click += new System.EventHandler(this.viewToolStripMenuItem1_Click);
            // 
            // usersToolStripMenuItem
            // 
            this.usersToolStripMenuItem.Name = "usersToolStripMenuItem";
            this.usersToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.usersToolStripMenuItem.Text = "Users";
            this.usersToolStripMenuItem.Click += new System.EventHandler(this.usersToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.realtimeTAGMonitorToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(172, 26);
            // 
            // realtimeTAGMonitorToolStripMenuItem
            // 
            this.realtimeTAGMonitorToolStripMenuItem.Name = "realtimeTAGMonitorToolStripMenuItem";
            this.realtimeTAGMonitorToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.realtimeTAGMonitorToolStripMenuItem.Text = "See tag in realtime";
            this.realtimeTAGMonitorToolStripMenuItem.Click += new System.EventHandler(this.realtimeTAGMonitorToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripUserName,
            this.toolStripLastLogin});
            this.statusStrip1.Location = new System.Drawing.Point(0, 625);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1284, 22);
            this.statusStrip1.TabIndex = 13;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripUserName
            // 
            this.toolStripUserName.Name = "toolStripUserName";
            this.toolStripUserName.Size = new System.Drawing.Size(59, 17);
            this.toolStripUserName.Text = "username";
            // 
            // toolStripLastLogin
            // 
            this.toolStripLastLogin.Name = "toolStripLastLogin";
            this.toolStripLastLogin.Size = new System.Drawing.Size(48, 17);
            this.toolStripLastLogin.Text = "laslogin";
            // 
            // Configuration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 647);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbTag);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbType);
            this.Controls.Add(this.cmbLine);
            this.Controls.Add(this.grdMessages);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Configuration";
            this.Text = "Configuration";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Configuration_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdMessages)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView grdMessages;
        private System.Windows.Forms.ComboBox cmbLine;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbTag;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblCountMsg;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addLineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem typesOfSupportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pLCsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tagValuesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem emailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fontsizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fontColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backgroundColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zonesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem notificationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem emailByLevelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reloadToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem realtimeTAGMonitorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem andonConfigToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem statusToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sendNowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem previewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem panelsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem deleteAllToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem deleteFromRangeToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn idMessage;
        private System.Windows.Forms.DataGridViewTextBoxColumn tagValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn msg;
        private System.Windows.Forms.DataGridViewTextBoxColumn line;
        private System.Windows.Forms.DataGridViewTextBoxColumn type;
        private System.Windows.Forms.DataGridViewTextBoxColumn tagName;
        private System.Windows.Forms.DataGridViewTextBoxColumn namePlc;
        private System.Windows.Forms.DataGridViewTextBoxColumn f1;
        private System.Windows.Forms.DataGridViewTextBoxColumn f2;
        private System.Windows.Forms.DataGridViewTextBoxColumn f3;
        private System.Windows.Forms.DataGridViewLinkColumn Update;
        private System.Windows.Forms.DataGridViewLinkColumn Delete;
        private System.Windows.Forms.DataGridViewLinkColumn Copy;
        private System.Windows.Forms.DataGridViewLinkColumn idAV;
        private System.Windows.Forms.ToolStripMenuItem usersToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripUserName;
        private System.Windows.Forms.ToolStripStatusLabel toolStripLastLogin;
    }
}