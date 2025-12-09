namespace Andon_V3.TblHistory
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
            this.pnlTopAndonHist = new System.Windows.Forms.Panel();
            this.btnToExcel = new System.Windows.Forms.Button();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.line = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idMsg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.msg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.endDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.endTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.endRepairDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.endRepairTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdData
            // 
            this.grdData.AllowUserToDeleteRows = false;
            this.grdData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.date,
            this.line,
            this.type,
            this.idMsg,
            this.msg,
            this.endDate,
            this.endTime,
            this.endRepairDate,
            this.endRepairTime});
            this.grdData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdData.Location = new System.Drawing.Point(0, 259);
            this.grdData.Name = "grdData";
            this.grdData.ReadOnly = true;
            this.grdData.Size = new System.Drawing.Size(1216, 436);
            this.grdData.TabIndex = 0;
            // 
            // dtpFrom
            // 
            this.dtpFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFrom.Location = new System.Drawing.Point(12, 21);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(200, 26);
            this.dtpFrom.TabIndex = 1;
            // 
            // dtpTo
            // 
            this.dtpTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTo.Location = new System.Drawing.Point(235, 21);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(200, 26);
            this.dtpTo.TabIndex = 2;
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(453, 21);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 26);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pnlTopAndonHist);
            this.panel1.Controls.Add(this.btnToExcel);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.dtpFrom);
            this.panel1.Controls.Add(this.dtpTo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1216, 259);
            this.panel1.TabIndex = 4;
            // 
            // pnlTopAndonHist
            // 
            this.pnlTopAndonHist.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlTopAndonHist.Location = new System.Drawing.Point(0, 60);
            this.pnlTopAndonHist.Name = "pnlTopAndonHist";
            this.pnlTopAndonHist.Size = new System.Drawing.Size(1216, 199);
            this.pnlTopAndonHist.TabIndex = 5;
            // 
            // btnToExcel
            // 
            this.btnToExcel.BackColor = System.Drawing.Color.Teal;
            this.btnToExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnToExcel.ForeColor = System.Drawing.Color.White;
            this.btnToExcel.Location = new System.Drawing.Point(1007, 12);
            this.btnToExcel.Name = "btnToExcel";
            this.btnToExcel.Size = new System.Drawing.Size(197, 42);
            this.btnToExcel.TabIndex = 4;
            this.btnToExcel.Text = "Export to EXCEL";
            this.btnToExcel.UseVisualStyleBackColor = false;
            this.btnToExcel.Click += new System.EventHandler(this.btnToExcel_Click);
            // 
            // id
            // 
            this.id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.id.DataPropertyName = "id";
            this.id.FillWeight = 50F;
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Width = 43;
            // 
            // date
            // 
            this.date.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.date.DataPropertyName = "date";
            this.date.HeaderText = "START DATETIME";
            this.date.Name = "date";
            this.date.ReadOnly = true;
            this.date.Width = 150;
            // 
            // line
            // 
            this.line.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.line.DataPropertyName = "line";
            this.line.HeaderText = "LINE";
            this.line.Name = "line";
            this.line.ReadOnly = true;
            this.line.Width = 140;
            // 
            // type
            // 
            this.type.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.type.DataPropertyName = "type";
            this.type.HeaderText = "DEPARTMENT";
            this.type.Name = "type";
            this.type.ReadOnly = true;
            this.type.Width = 140;
            // 
            // idMsg
            // 
            this.idMsg.DataPropertyName = "idMsg";
            this.idMsg.HeaderText = "ID MSG";
            this.idMsg.Name = "idMsg";
            this.idMsg.ReadOnly = true;
            this.idMsg.Visible = false;
            // 
            // msg
            // 
            this.msg.DataPropertyName = "msg";
            this.msg.HeaderText = "MESSAGE";
            this.msg.Name = "msg";
            this.msg.ReadOnly = true;
            // 
            // endDate
            // 
            this.endDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.endDate.DataPropertyName = "endDate";
            this.endDate.HeaderText = "RESPONSE DATETIME";
            this.endDate.Name = "endDate";
            this.endDate.ReadOnly = true;
            this.endDate.Width = 150;
            // 
            // endTime
            // 
            this.endTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.endTime.DataPropertyName = "endTime";
            this.endTime.HeaderText = "RESPONSE TIME";
            this.endTime.Name = "endTime";
            this.endTime.ReadOnly = true;
            this.endTime.Width = 150;
            // 
            // endRepairDate
            // 
            this.endRepairDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.endRepairDate.DataPropertyName = "endRepairDate";
            this.endRepairDate.HeaderText = "REPAIR DATETIME";
            this.endRepairDate.Name = "endRepairDate";
            this.endRepairDate.ReadOnly = true;
            this.endRepairDate.Width = 150;
            // 
            // endRepairTime
            // 
            this.endRepairTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.endRepairTime.DataPropertyName = "endRepairTime";
            this.endRepairTime.HeaderText = "REPAIR TIME";
            this.endRepairTime.Name = "endRepairTime";
            this.endRepairTime.ReadOnly = true;
            this.endRepairTime.Width = 150;
            // 
            // List
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1216, 695);
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
        private System.Windows.Forms.Panel pnlTopAndonHist;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn date;
        private System.Windows.Forms.DataGridViewTextBoxColumn line;
        private System.Windows.Forms.DataGridViewTextBoxColumn type;
        private System.Windows.Forms.DataGridViewTextBoxColumn idMsg;
        private System.Windows.Forms.DataGridViewTextBoxColumn msg;
        private System.Windows.Forms.DataGridViewTextBoxColumn endDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn endTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn endRepairDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn endRepairTime;
    }
}