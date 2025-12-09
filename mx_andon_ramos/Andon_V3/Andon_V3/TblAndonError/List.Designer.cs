namespace Andon_V3.TblAndonError
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
            this.grdData = new System.Windows.Forms.DataGridView();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.btnSearch = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnToExcel = new System.Windows.Forms.Button();
            this.IdError = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.message = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stackTrace = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ipAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deviceName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idApp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.errorDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Details = new System.Windows.Forms.DataGridViewLinkColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdData
            // 
            this.grdData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdError,
            this.message,
            this.stackTrace,
            this.ipAddress,
            this.deviceName,
            this.idApp,
            this.errorDate,
            this.Details});
            this.grdData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdData.Location = new System.Drawing.Point(0, 65);
            this.grdData.Name = "grdData";
            this.grdData.Size = new System.Drawing.Size(800, 385);
            this.grdData.TabIndex = 0;
            this.grdData.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdData_CellContentClick);
            this.grdData.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.grdData_DataBindingComplete);
            // 
            // dtpFrom
            // 
            this.dtpFrom.Location = new System.Drawing.Point(12, 21);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(200, 20);
            this.dtpFrom.TabIndex = 1;
            // 
            // dtpTo
            // 
            this.dtpTo.Location = new System.Drawing.Point(235, 21);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(200, 20);
            this.dtpTo.TabIndex = 2;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(453, 18);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnToExcel);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.dtpFrom);
            this.panel1.Controls.Add(this.dtpTo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 65);
            this.panel1.TabIndex = 4;
            // 
            // btnToExcel
            // 
            this.btnToExcel.Location = new System.Drawing.Point(713, 18);
            this.btnToExcel.Name = "btnToExcel";
            this.btnToExcel.Size = new System.Drawing.Size(75, 23);
            this.btnToExcel.TabIndex = 4;
            this.btnToExcel.Text = "Export";
            this.btnToExcel.UseVisualStyleBackColor = true;
            // 
            // IdError
            // 
            this.IdError.DataPropertyName = "idError";
            this.IdError.FillWeight = 48.64719F;
            this.IdError.HeaderText = "ID";
            this.IdError.Name = "IdError";
            // 
            // message
            // 
            this.message.DataPropertyName = "message";
            this.message.FillWeight = 63.22919F;
            this.message.HeaderText = "Message";
            this.message.Name = "message";
            // 
            // stackTrace
            // 
            this.stackTrace.DataPropertyName = "stackTrace";
            this.stackTrace.FillWeight = 63.22919F;
            this.stackTrace.HeaderText = "Stack Trace";
            this.stackTrace.Name = "stackTrace";
            // 
            // ipAddress
            // 
            this.ipAddress.DataPropertyName = "ipAddress";
            this.ipAddress.FillWeight = 63.22919F;
            this.ipAddress.HeaderText = "IP Address";
            this.ipAddress.Name = "ipAddress";
            // 
            // deviceName
            // 
            this.deviceName.DataPropertyName = "deviceName";
            this.deviceName.FillWeight = 63.22919F;
            this.deviceName.HeaderText = "Device name";
            this.deviceName.Name = "deviceName";
            // 
            // idApp
            // 
            this.idApp.DataPropertyName = "idApp";
            this.idApp.FillWeight = 63.22919F;
            this.idApp.HeaderText = "App";
            this.idApp.Name = "idApp";
            // 
            // errorDate
            // 
            this.errorDate.DataPropertyName = "errorDate";
            this.errorDate.FillWeight = 63.22919F;
            this.errorDate.HeaderText = "Error date";
            this.errorDate.Name = "errorDate";
            // 
            // Details
            // 
            this.Details.FillWeight = 30F;
            this.Details.HeaderText = "Details";
            this.Details.Name = "Details";
            // 
            // List
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.grdData);
            this.Controls.Add(this.panel1);
            this.Name = "List";
            this.Text = "List";
            this.Load += new System.EventHandler(this.List_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grdData;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnToExcel;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdError;
        private System.Windows.Forms.DataGridViewTextBoxColumn message;
        private System.Windows.Forms.DataGridViewTextBoxColumn stackTrace;
        private System.Windows.Forms.DataGridViewTextBoxColumn ipAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn deviceName;
        private System.Windows.Forms.DataGridViewTextBoxColumn idApp;
        private System.Windows.Forms.DataGridViewTextBoxColumn errorDate;
        private System.Windows.Forms.DataGridViewLinkColumn Details;
    }
}