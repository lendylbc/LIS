
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnGetData = new System.Windows.Forms.Button();
			this.edtPassword = new System.Windows.Forms.TextBox();
			this.edtLogin = new System.Windows.Forms.TextBox();
			this.btnGetToken = new System.Windows.Forms.Button();
			this.panel2 = new System.Windows.Forms.Panel();
			this.edtLog = new System.Windows.Forms.TextBox();
			this.btnGetDevices = new System.Windows.Forms.Button();
			this.panel3 = new System.Windows.Forms.Panel();
			this.grdDevices = new System.Windows.Forms.DataGridView();
			this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.IpAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Active = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.grdData = new System.Windows.Forms.DataGridView();
			this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.ParamDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.timer = new System.Windows.Forms.Timer(this.components);
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdDevices)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.grdData)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.btnGetDevices);
			this.panel1.Controls.Add(this.btnGetData);
			this.panel1.Controls.Add(this.edtPassword);
			this.panel1.Controls.Add(this.edtLogin);
			this.panel1.Controls.Add(this.btnGetToken);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(886, 65);
			this.panel1.TabIndex = 6;
			// 
			// btnGetData
			// 
			this.btnGetData.Location = new System.Drawing.Point(296, 13);
			this.btnGetData.Name = "btnGetData";
			this.btnGetData.Size = new System.Drawing.Size(75, 23);
			this.btnGetData.TabIndex = 8;
			this.btnGetData.Text = "Get data";
			this.btnGetData.UseVisualStyleBackColor = true;
			this.btnGetData.Click += new System.EventHandler(this.btnGetData_Click);
			// 
			// edtPassword
			// 
			this.edtPassword.Location = new System.Drawing.Point(12, 39);
			this.edtPassword.Name = "edtPassword";
			this.edtPassword.Size = new System.Drawing.Size(100, 20);
			this.edtPassword.TabIndex = 7;
			this.edtPassword.Text = "admin";
			// 
			// edtLogin
			// 
			this.edtLogin.Location = new System.Drawing.Point(12, 13);
			this.edtLogin.Name = "edtLogin";
			this.edtLogin.Size = new System.Drawing.Size(100, 20);
			this.edtLogin.TabIndex = 6;
			this.edtLogin.Text = "LENDY";
			// 
			// btnGetToken
			// 
			this.btnGetToken.Location = new System.Drawing.Point(118, 13);
			this.btnGetToken.Name = "btnGetToken";
			this.btnGetToken.Size = new System.Drawing.Size(75, 23);
			this.btnGetToken.TabIndex = 5;
			this.btnGetToken.Text = "Get token";
			this.btnGetToken.UseVisualStyleBackColor = true;
			this.btnGetToken.Click += new System.EventHandler(this.btnGetToken_Click);
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.panel3);
			this.panel2.Controls.Add(this.edtLog);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(0, 65);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(886, 499);
			this.panel2.TabIndex = 7;
			// 
			// edtLog
			// 
			this.edtLog.Dock = System.Windows.Forms.DockStyle.Right;
			this.edtLog.Location = new System.Drawing.Point(636, 0);
			this.edtLog.Multiline = true;
			this.edtLog.Name = "edtLog";
			this.edtLog.Size = new System.Drawing.Size(250, 499);
			this.edtLog.TabIndex = 4;
			// 
			// btnGetDevices
			// 
			this.btnGetDevices.Location = new System.Drawing.Point(199, 12);
			this.btnGetDevices.Name = "btnGetDevices";
			this.btnGetDevices.Size = new System.Drawing.Size(75, 23);
			this.btnGetDevices.TabIndex = 9;
			this.btnGetDevices.Text = "Get devices";
			this.btnGetDevices.UseVisualStyleBackColor = true;
			this.btnGetDevices.Click += new System.EventHandler(this.btnGetDevices_Click);
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.grdData);
			this.panel3.Controls.Add(this.grdDevices);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel3.Location = new System.Drawing.Point(0, 0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(636, 499);
			this.panel3.TabIndex = 5;
			// 
			// grdDevices
			// 
			this.grdDevices.AllowUserToAddRows = false;
			this.grdDevices.AllowUserToDeleteRows = false;
			this.grdDevices.AllowUserToResizeRows = false;
			dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.grdDevices.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
			this.grdDevices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.grdDevices.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Description,
            this.IpAddress,
            this.Active});
			dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.grdDevices.DefaultCellStyle = dataGridViewCellStyle8;
			this.grdDevices.Dock = System.Windows.Forms.DockStyle.Top;
			this.grdDevices.Location = new System.Drawing.Point(0, 0);
			this.grdDevices.Name = "grdDevices";
			this.grdDevices.ReadOnly = true;
			this.grdDevices.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.grdDevices.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
			this.grdDevices.RowHeadersVisible = false;
			this.grdDevices.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.grdDevices.Size = new System.Drawing.Size(636, 224);
			this.grdDevices.TabIndex = 7;
			this.grdDevices.DataSourceChanged += new System.EventHandler(this.grdDevices_DataSourceChanged);
			// 
			// Description
			// 
			this.Description.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.Description.DataPropertyName = "Description";
			this.Description.HeaderText = "Popis zařízení";
			this.Description.Name = "Description";
			this.Description.ReadOnly = true;
			// 
			// IpAddress
			// 
			this.IpAddress.DataPropertyName = "IpAddress";
			this.IpAddress.HeaderText = "IP adresa";
			this.IpAddress.Name = "IpAddress";
			this.IpAddress.ReadOnly = true;
			// 
			// Active
			// 
			this.Active.DataPropertyName = "Active";
			this.Active.HeaderText = "Aktivní";
			this.Active.Name = "Active";
			this.Active.ReadOnly = true;
			this.Active.Width = 50;
			// 
			// grdData
			// 
			this.grdData.AllowUserToAddRows = false;
			this.grdData.AllowUserToDeleteRows = false;
			this.grdData.AllowUserToResizeRows = false;
			dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.grdData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
			this.grdData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.grdData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.ParamDesc,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewCheckBoxColumn1});
			dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.grdData.DefaultCellStyle = dataGridViewCellStyle11;
			this.grdData.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grdData.Location = new System.Drawing.Point(0, 224);
			this.grdData.Name = "grdData";
			this.grdData.ReadOnly = true;
			this.grdData.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.grdData.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
			this.grdData.RowHeadersVisible = false;
			this.grdData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.grdData.Size = new System.Drawing.Size(636, 275);
			this.grdData.TabIndex = 8;
			this.grdData.DataSourceChanged += new System.EventHandler(this.grdData_DataSourceChanged);
			// 
			// dataGridViewTextBoxColumn1
			// 
			this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewTextBoxColumn1.DataPropertyName = "DeviceDesc";
			this.dataGridViewTextBoxColumn1.HeaderText = "Popis zařízení";
			this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn1.ReadOnly = true;
			// 
			// ParamDesc
			// 
			this.ParamDesc.DataPropertyName = "ParamDesc";
			this.ParamDesc.HeaderText = "Parametr";
			this.ParamDesc.Name = "ParamDesc";
			this.ParamDesc.ReadOnly = true;
			// 
			// dataGridViewTextBoxColumn2
			// 
			this.dataGridViewTextBoxColumn2.DataPropertyName = "Inserted";
			this.dataGridViewTextBoxColumn2.HeaderText = "Datum";
			this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
			this.dataGridViewTextBoxColumn2.ReadOnly = true;
			// 
			// dataGridViewCheckBoxColumn1
			// 
			this.dataGridViewCheckBoxColumn1.DataPropertyName = "ValueUnit";
			this.dataGridViewCheckBoxColumn1.HeaderText = "Hodnota";
			this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
			this.dataGridViewCheckBoxColumn1.ReadOnly = true;
			this.dataGridViewCheckBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridViewCheckBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
			this.dataGridViewCheckBoxColumn1.Width = 50;
			// 
			// timer
			// 
			this.timer.Interval = 30000;
			this.timer.Tick += new System.EventHandler(this.timer_Tick);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(886, 564);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.panel3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.grdDevices)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grdData)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button btnGetData;
		private System.Windows.Forms.TextBox edtPassword;
		private System.Windows.Forms.TextBox edtLogin;
		private System.Windows.Forms.Button btnGetToken;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.TextBox edtLog;
		private System.Windows.Forms.Button btnGetDevices;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.DataGridView grdData;
		private System.Windows.Forms.DataGridView grdDevices;
		private System.Windows.Forms.DataGridViewTextBoxColumn Description;
		private System.Windows.Forms.DataGridViewTextBoxColumn IpAddress;
		private System.Windows.Forms.DataGridViewCheckBoxColumn Active;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
		private System.Windows.Forms.DataGridViewTextBoxColumn ParamDesc;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewCheckBoxColumn1;
		private System.Windows.Forms.Timer timer;
	}
}

