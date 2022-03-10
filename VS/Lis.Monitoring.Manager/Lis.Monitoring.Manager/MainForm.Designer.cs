
namespace Lis.Monitoring.Manager {
	partial class MainForm {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if(disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnCsvExport = new System.Windows.Forms.Button();
			this.labLoggedUser = new System.Windows.Forms.Label();
			this.btnUsers = new System.Windows.Forms.Button();
			this.btnDevices = new System.Windows.Forms.Button();
			this.pnlMain = new System.Windows.Forms.Panel();
			this.panel3 = new System.Windows.Forms.Panel();
			this.grdData = new System.Windows.Forms.DataGridView();
			this.edtLog = new System.Windows.Forms.TextBox();
			this.timer = new System.Windows.Forms.Timer(this.components);
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.labStatusInfo = new System.Windows.Forms.ToolStripStatusLabel();
			this.colDeviceDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colParamDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.colValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.panel1.SuspendLayout();
			this.pnlMain.SuspendLayout();
			this.panel3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
			this.statusStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.btnCsvExport);
			this.panel1.Controls.Add(this.labLoggedUser);
			this.panel1.Controls.Add(this.btnUsers);
			this.panel1.Controls.Add(this.btnDevices);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(910, 32);
			this.panel1.TabIndex = 6;
			// 
			// btnCsvExport
			// 
			this.btnCsvExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.btnCsvExport.Location = new System.Drawing.Point(182, 2);
			this.btnCsvExport.Name = "btnCsvExport";
			this.btnCsvExport.Size = new System.Drawing.Size(83, 28);
			this.btnCsvExport.TabIndex = 13;
			this.btnCsvExport.Text = "CSV";
			this.btnCsvExport.UseVisualStyleBackColor = true;
			this.btnCsvExport.Click += new System.EventHandler(this.btnCsvExport_Click);
			// 
			// labLoggedUser
			// 
			this.labLoggedUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.labLoggedUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.labLoggedUser.ForeColor = System.Drawing.Color.MidnightBlue;
			this.labLoggedUser.Location = new System.Drawing.Point(688, 4);
			this.labLoggedUser.Name = "labLoggedUser";
			this.labLoggedUser.Size = new System.Drawing.Size(219, 23);
			this.labLoggedUser.TabIndex = 12;
			this.labLoggedUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// btnUsers
			// 
			this.btnUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.btnUsers.Location = new System.Drawing.Point(93, 2);
			this.btnUsers.Name = "btnUsers";
			this.btnUsers.Size = new System.Drawing.Size(83, 28);
			this.btnUsers.TabIndex = 11;
			this.btnUsers.Text = "Uživatelé";
			this.btnUsers.UseVisualStyleBackColor = true;
			this.btnUsers.Click += new System.EventHandler(this.btnUsers_Click);
			// 
			// btnDevices
			// 
			this.btnDevices.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.btnDevices.Location = new System.Drawing.Point(4, 2);
			this.btnDevices.Name = "btnDevices";
			this.btnDevices.Size = new System.Drawing.Size(83, 28);
			this.btnDevices.TabIndex = 10;
			this.btnDevices.Text = "Zařízení";
			this.btnDevices.UseVisualStyleBackColor = true;
			this.btnDevices.Click += new System.EventHandler(this.btnDevices_Click);
			// 
			// pnlMain
			// 
			this.pnlMain.Controls.Add(this.panel3);
			this.pnlMain.Controls.Add(this.edtLog);
			this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlMain.Location = new System.Drawing.Point(0, 32);
			this.pnlMain.Name = "pnlMain";
			this.pnlMain.Size = new System.Drawing.Size(910, 606);
			this.pnlMain.TabIndex = 7;
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.grdData);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel3.Location = new System.Drawing.Point(0, 0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(910, 606);
			this.panel3.TabIndex = 5;
			// 
			// grdData
			// 
			this.grdData.AllowUserToAddRows = false;
			this.grdData.AllowUserToDeleteRows = false;
			this.grdData.AllowUserToResizeRows = false;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.grdData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.grdData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.grdData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDeviceDesc,
            this.colDate,
            this.colParamDesc,
            this.colValue});
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.grdData.DefaultCellStyle = dataGridViewCellStyle3;
			this.grdData.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grdData.Location = new System.Drawing.Point(0, 0);
			this.grdData.MultiSelect = false;
			this.grdData.Name = "grdData";
			this.grdData.ReadOnly = true;
			this.grdData.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.grdData.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
			this.grdData.RowHeadersVisible = false;
			this.grdData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.grdData.Size = new System.Drawing.Size(910, 606);
			this.grdData.TabIndex = 8;
			this.grdData.DataSourceChanged += new System.EventHandler(this.grdData_DataSourceChanged);
			this.grdData.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.grdData_RowPrePaint);
			this.grdData.SelectionChanged += new System.EventHandler(this.grdData_SelectionChanged);
			this.grdData.Click += new System.EventHandler(this.grdData_Click);
			// 
			// edtLog
			// 
			this.edtLog.Dock = System.Windows.Forms.DockStyle.Right;
			this.edtLog.Location = new System.Drawing.Point(910, 0);
			this.edtLog.Multiline = true;
			this.edtLog.Name = "edtLog";
			this.edtLog.Size = new System.Drawing.Size(0, 606);
			this.edtLog.TabIndex = 4;
			// 
			// timer
			// 
			this.timer.Interval = 30000;
			this.timer.Tick += new System.EventHandler(this.timer_Tick);
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labStatusInfo});
			this.statusStrip1.Location = new System.Drawing.Point(0, 616);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(910, 22);
			this.statusStrip1.TabIndex = 8;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// labStatusInfo
			// 
			this.labStatusInfo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
			this.labStatusInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
			this.labStatusInfo.Name = "labStatusInfo";
			this.labStatusInfo.Size = new System.Drawing.Size(0, 17);
			// 
			// colDeviceDesc
			// 
			this.colDeviceDesc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.colDeviceDesc.DataPropertyName = "DeviceDesc";
			this.colDeviceDesc.HeaderText = "Popis zařízení";
			this.colDeviceDesc.Name = "colDeviceDesc";
			this.colDeviceDesc.ReadOnly = true;
			// 
			// colDate
			// 
			this.colDate.DataPropertyName = "Inserted";
			this.colDate.HeaderText = "Datum odečtu";
			this.colDate.Name = "colDate";
			this.colDate.ReadOnly = true;
			this.colDate.Width = 120;
			// 
			// colParamDesc
			// 
			this.colParamDesc.DataPropertyName = "ParamDesc";
			this.colParamDesc.HeaderText = "Parametr";
			this.colParamDesc.Name = "colParamDesc";
			this.colParamDesc.ReadOnly = true;
			this.colParamDesc.Width = 150;
			// 
			// colValue
			// 
			this.colValue.DataPropertyName = "ValueUnit";
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.colValue.DefaultCellStyle = dataGridViewCellStyle2;
			this.colValue.HeaderText = "Hodnota";
			this.colValue.Name = "colValue";
			this.colValue.ReadOnly = true;
			this.colValue.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.colValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.colValue.Width = 150;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(910, 638);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.pnlMain);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Přehled";
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.panel1.ResumeLayout(false);
			this.pnlMain.ResumeLayout(false);
			this.pnlMain.PerformLayout();
			this.panel3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel pnlMain;
		private System.Windows.Forms.TextBox edtLog;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.DataGridView grdData;
		private System.Windows.Forms.Timer timer;
		private System.Windows.Forms.Button btnUsers;
		private System.Windows.Forms.Button btnDevices;
		private System.Windows.Forms.Label labLoggedUser;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel labStatusInfo;
		private System.Windows.Forms.Button btnCsvExport;
		private System.Windows.Forms.DataGridViewTextBoxColumn colDeviceDesc;
		private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
		private System.Windows.Forms.DataGridViewTextBoxColumn colParamDesc;
		private System.Windows.Forms.DataGridViewTextBoxColumn colValue;
	}
}

