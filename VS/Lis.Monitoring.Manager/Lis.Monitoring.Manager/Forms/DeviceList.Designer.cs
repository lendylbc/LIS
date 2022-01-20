
namespace Lis.Monitoring.Manager.Forms {
	partial class DeviceList {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeviceList));
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnClose = new System.Windows.Forms.Button();
			this.btnDeviceDelete = new System.Windows.Forms.Button();
			this.btnDeviceEdit = new System.Windows.Forms.Button();
			this.btnDeviceInsert = new System.Windows.Forms.Button();
			this.panel2 = new System.Windows.Forms.Panel();
			this.panel3 = new System.Windows.Forms.Panel();
			this.grdDevices = new System.Windows.Forms.DataGridView();
			this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.IpAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Active = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.panel4 = new System.Windows.Forms.Panel();
			this.panel6 = new System.Windows.Forms.Panel();
			this.grdConditions = new System.Windows.Forms.DataGridView();
			this.panel8 = new System.Windows.Forms.Panel();
			this.btnConditionDelete = new System.Windows.Forms.Button();
			this.btnConditionEdit = new System.Windows.Forms.Button();
			this.btnConditionInsert = new System.Windows.Forms.Button();
			this.panel5 = new System.Windows.Forms.Panel();
			this.grdParams = new System.Windows.Forms.DataGridView();
			this.panel7 = new System.Windows.Forms.Panel();
			this.btnParamDelete = new System.Windows.Forms.Button();
			this.btnParamEdit = new System.Windows.Forms.Button();
			this.btnParamInsert = new System.Windows.Forms.Button();
			this.tipDevice = new System.Windows.Forms.ToolTip(this.components);
			this.Operator = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdDevices)).BeginInit();
			this.panel4.SuspendLayout();
			this.panel6.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdConditions)).BeginInit();
			this.panel8.SuspendLayout();
			this.panel5.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdParams)).BeginInit();
			this.panel7.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.btnClose);
			this.panel1.Controls.Add(this.btnDeviceDelete);
			this.panel1.Controls.Add(this.btnDeviceEdit);
			this.panel1.Controls.Add(this.btnDeviceInsert);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(800, 32);
			this.panel1.TabIndex = 0;
			// 
			// btnClose
			// 
			this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnClose.Image = global::Lis.Monitoring.Manager.Properties.Resources.close;
			this.btnClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.btnClose.Location = new System.Drawing.Point(770, 2);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(28, 28);
			this.btnClose.TabIndex = 9;
			this.tipDevice.SetToolTip(this.btnClose, "Zavřít");
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// btnDeviceDelete
			// 
			this.btnDeviceDelete.Image = global::Lis.Monitoring.Manager.Properties.Resources.delete;
			this.btnDeviceDelete.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.btnDeviceDelete.Location = new System.Drawing.Point(63, 2);
			this.btnDeviceDelete.Name = "btnDeviceDelete";
			this.btnDeviceDelete.Size = new System.Drawing.Size(28, 28);
			this.btnDeviceDelete.TabIndex = 8;
			this.tipDevice.SetToolTip(this.btnDeviceDelete, "Smazat zařízení");
			this.btnDeviceDelete.UseVisualStyleBackColor = true;
			this.btnDeviceDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// btnDeviceEdit
			// 
			this.btnDeviceEdit.Image = global::Lis.Monitoring.Manager.Properties.Resources.edit;
			this.btnDeviceEdit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.btnDeviceEdit.Location = new System.Drawing.Point(33, 2);
			this.btnDeviceEdit.Name = "btnDeviceEdit";
			this.btnDeviceEdit.Size = new System.Drawing.Size(28, 28);
			this.btnDeviceEdit.TabIndex = 7;
			this.tipDevice.SetToolTip(this.btnDeviceEdit, "Upravit zařízení");
			this.btnDeviceEdit.UseVisualStyleBackColor = true;
			this.btnDeviceEdit.Click += new System.EventHandler(this.btnEdit_Click);
			// 
			// btnDeviceInsert
			// 
			this.btnDeviceInsert.Image = ((System.Drawing.Image)(resources.GetObject("btnDeviceInsert.Image")));
			this.btnDeviceInsert.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.btnDeviceInsert.Location = new System.Drawing.Point(3, 2);
			this.btnDeviceInsert.Name = "btnDeviceInsert";
			this.btnDeviceInsert.Size = new System.Drawing.Size(28, 28);
			this.btnDeviceInsert.TabIndex = 6;
			this.tipDevice.SetToolTip(this.btnDeviceInsert, "Přidat zařízení");
			this.btnDeviceInsert.UseVisualStyleBackColor = true;
			this.btnDeviceInsert.Click += new System.EventHandler(this.btnInsert_Click);
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.panel3);
			this.panel2.Controls.Add(this.panel4);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(0, 32);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(800, 509);
			this.panel2.TabIndex = 1;
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.grdDevices);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel3.Location = new System.Drawing.Point(0, 0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(800, 343);
			this.panel3.TabIndex = 2;
			// 
			// grdDevices
			// 
			this.grdDevices.AllowUserToAddRows = false;
			this.grdDevices.AllowUserToDeleteRows = false;
			this.grdDevices.AllowUserToResizeRows = false;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.grdDevices.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.grdDevices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.grdDevices.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Description,
            this.IpAddress,
            this.Active});
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.grdDevices.DefaultCellStyle = dataGridViewCellStyle2;
			this.grdDevices.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grdDevices.Location = new System.Drawing.Point(0, 0);
			this.grdDevices.Name = "grdDevices";
			this.grdDevices.ReadOnly = true;
			this.grdDevices.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.grdDevices.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
			this.grdDevices.RowHeadersVisible = false;
			this.grdDevices.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.grdDevices.Size = new System.Drawing.Size(800, 343);
			this.grdDevices.TabIndex = 9;
			this.grdDevices.DataSourceChanged += new System.EventHandler(this.grdDevices_DataSourceChanged);
			this.grdDevices.SelectionChanged += new System.EventHandler(this.grdDevices_SelectionChanged);
			this.grdDevices.DoubleClick += new System.EventHandler(this.grdDevices_DoubleClick);
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
			// panel4
			// 
			this.panel4.Controls.Add(this.panel6);
			this.panel4.Controls.Add(this.panel5);
			this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel4.Location = new System.Drawing.Point(0, 343);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(800, 166);
			this.panel4.TabIndex = 1;
			// 
			// panel6
			// 
			this.panel6.Controls.Add(this.grdConditions);
			this.panel6.Controls.Add(this.panel8);
			this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel6.Location = new System.Drawing.Point(366, 0);
			this.panel6.Name = "panel6";
			this.panel6.Size = new System.Drawing.Size(434, 166);
			this.panel6.TabIndex = 1;
			// 
			// grdConditions
			// 
			this.grdConditions.AllowUserToAddRows = false;
			this.grdConditions.AllowUserToDeleteRows = false;
			this.grdConditions.AllowUserToResizeRows = false;
			dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.grdConditions.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
			this.grdConditions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.grdConditions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Operator,
            this.Value});
			dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.grdConditions.DefaultCellStyle = dataGridViewCellStyle5;
			this.grdConditions.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grdConditions.Location = new System.Drawing.Point(0, 32);
			this.grdConditions.Name = "grdConditions";
			this.grdConditions.ReadOnly = true;
			this.grdConditions.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.grdConditions.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
			this.grdConditions.RowHeadersVisible = false;
			this.grdConditions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.grdConditions.Size = new System.Drawing.Size(434, 134);
			this.grdConditions.TabIndex = 10;
			this.grdConditions.DataSourceChanged += new System.EventHandler(this.grdConditions_DataSourceChanged);
			this.grdConditions.DoubleClick += new System.EventHandler(this.grdConditions_DoubleClick);
			// 
			// panel8
			// 
			this.panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel8.Controls.Add(this.btnConditionDelete);
			this.panel8.Controls.Add(this.btnConditionEdit);
			this.panel8.Controls.Add(this.btnConditionInsert);
			this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel8.Location = new System.Drawing.Point(0, 0);
			this.panel8.Name = "panel8";
			this.panel8.Size = new System.Drawing.Size(434, 32);
			this.panel8.TabIndex = 1;
			// 
			// btnConditionDelete
			// 
			this.btnConditionDelete.Image = global::Lis.Monitoring.Manager.Properties.Resources.delete;
			this.btnConditionDelete.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.btnConditionDelete.Location = new System.Drawing.Point(64, 2);
			this.btnConditionDelete.Name = "btnConditionDelete";
			this.btnConditionDelete.Size = new System.Drawing.Size(28, 28);
			this.btnConditionDelete.TabIndex = 11;
			this.tipDevice.SetToolTip(this.btnConditionDelete, "Smazat podmínku");
			this.btnConditionDelete.UseVisualStyleBackColor = true;
			this.btnConditionDelete.Click += new System.EventHandler(this.btnConditionDelete_Click);
			// 
			// btnConditionEdit
			// 
			this.btnConditionEdit.Image = global::Lis.Monitoring.Manager.Properties.Resources.edit;
			this.btnConditionEdit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.btnConditionEdit.Location = new System.Drawing.Point(34, 2);
			this.btnConditionEdit.Name = "btnConditionEdit";
			this.btnConditionEdit.Size = new System.Drawing.Size(28, 28);
			this.btnConditionEdit.TabIndex = 10;
			this.tipDevice.SetToolTip(this.btnConditionEdit, "Upravit podmínku");
			this.btnConditionEdit.UseVisualStyleBackColor = true;
			this.btnConditionEdit.Click += new System.EventHandler(this.btnConditionEdit_Click);
			// 
			// btnConditionInsert
			// 
			this.btnConditionInsert.Image = ((System.Drawing.Image)(resources.GetObject("btnConditionInsert.Image")));
			this.btnConditionInsert.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.btnConditionInsert.Location = new System.Drawing.Point(4, 2);
			this.btnConditionInsert.Name = "btnConditionInsert";
			this.btnConditionInsert.Size = new System.Drawing.Size(28, 28);
			this.btnConditionInsert.TabIndex = 9;
			this.tipDevice.SetToolTip(this.btnConditionInsert, "Přidat podmínku");
			this.btnConditionInsert.UseVisualStyleBackColor = true;
			this.btnConditionInsert.Click += new System.EventHandler(this.btnConditionInsert_Click);
			// 
			// panel5
			// 
			this.panel5.Controls.Add(this.grdParams);
			this.panel5.Controls.Add(this.panel7);
			this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel5.Location = new System.Drawing.Point(0, 0);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(366, 166);
			this.panel5.TabIndex = 0;
			// 
			// grdParams
			// 
			this.grdParams.AllowUserToAddRows = false;
			this.grdParams.AllowUserToDeleteRows = false;
			this.grdParams.AllowUserToResizeRows = false;
			dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.grdParams.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
			this.grdParams.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.grdParams.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.Address,
            this.Unit,
            this.dataGridViewCheckBoxColumn1});
			dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.grdParams.DefaultCellStyle = dataGridViewCellStyle8;
			this.grdParams.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grdParams.Location = new System.Drawing.Point(0, 32);
			this.grdParams.Name = "grdParams";
			this.grdParams.ReadOnly = true;
			this.grdParams.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.grdParams.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
			this.grdParams.RowHeadersVisible = false;
			this.grdParams.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.grdParams.Size = new System.Drawing.Size(366, 134);
			this.grdParams.TabIndex = 10;
			this.grdParams.DataSourceChanged += new System.EventHandler(this.grdParams_DataSourceChanged);
			this.grdParams.SelectionChanged += new System.EventHandler(this.grdParams_SelectionChanged);
			this.grdParams.DoubleClick += new System.EventHandler(this.grdParams_DoubleClick);
			// 
			// panel7
			// 
			this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel7.Controls.Add(this.btnParamDelete);
			this.panel7.Controls.Add(this.btnParamEdit);
			this.panel7.Controls.Add(this.btnParamInsert);
			this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel7.Location = new System.Drawing.Point(0, 0);
			this.panel7.Name = "panel7";
			this.panel7.Size = new System.Drawing.Size(366, 32);
			this.panel7.TabIndex = 0;
			// 
			// btnParamDelete
			// 
			this.btnParamDelete.Image = global::Lis.Monitoring.Manager.Properties.Resources.delete;
			this.btnParamDelete.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.btnParamDelete.Location = new System.Drawing.Point(63, 2);
			this.btnParamDelete.Name = "btnParamDelete";
			this.btnParamDelete.Size = new System.Drawing.Size(28, 28);
			this.btnParamDelete.TabIndex = 11;
			this.tipDevice.SetToolTip(this.btnParamDelete, "Smazat parametr");
			this.btnParamDelete.UseVisualStyleBackColor = true;
			this.btnParamDelete.Click += new System.EventHandler(this.btnParamDelete_Click);
			// 
			// btnParamEdit
			// 
			this.btnParamEdit.Image = global::Lis.Monitoring.Manager.Properties.Resources.edit;
			this.btnParamEdit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.btnParamEdit.Location = new System.Drawing.Point(33, 2);
			this.btnParamEdit.Name = "btnParamEdit";
			this.btnParamEdit.Size = new System.Drawing.Size(28, 28);
			this.btnParamEdit.TabIndex = 10;
			this.tipDevice.SetToolTip(this.btnParamEdit, "Upravit parametr");
			this.btnParamEdit.UseVisualStyleBackColor = true;
			this.btnParamEdit.Click += new System.EventHandler(this.btnParamEdit_Click);
			// 
			// btnParamInsert
			// 
			this.btnParamInsert.Image = ((System.Drawing.Image)(resources.GetObject("btnParamInsert.Image")));
			this.btnParamInsert.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.btnParamInsert.Location = new System.Drawing.Point(3, 2);
			this.btnParamInsert.Name = "btnParamInsert";
			this.btnParamInsert.Size = new System.Drawing.Size(28, 28);
			this.btnParamInsert.TabIndex = 9;
			this.tipDevice.SetToolTip(this.btnParamInsert, "Přidat parametr");
			this.btnParamInsert.UseVisualStyleBackColor = true;
			this.btnParamInsert.Click += new System.EventHandler(this.btnParamInsert_Click);
			// 
			// Operator
			// 
			this.Operator.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.Operator.DataPropertyName = "Operator";
			this.Operator.HeaderText = "Operátor";
			this.Operator.Name = "Operator";
			this.Operator.ReadOnly = true;
			// 
			// Value
			// 
			this.Value.DataPropertyName = "Value";
			this.Value.HeaderText = "Hodnota";
			this.Value.Name = "Value";
			this.Value.ReadOnly = true;
			// 
			// dataGridViewTextBoxColumn1
			// 
			this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.dataGridViewTextBoxColumn1.DataPropertyName = "Description";
			this.dataGridViewTextBoxColumn1.HeaderText = "Parametr";
			this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
			this.dataGridViewTextBoxColumn1.ReadOnly = true;
			// 
			// Address
			// 
			this.Address.DataPropertyName = "Address";
			this.Address.HeaderText = "Adresa";
			this.Address.Name = "Address";
			this.Address.ReadOnly = true;
			// 
			// Unit
			// 
			this.Unit.DataPropertyName = "Unit";
			this.Unit.HeaderText = "Jednotka";
			this.Unit.Name = "Unit";
			this.Unit.ReadOnly = true;
			this.Unit.Width = 60;
			// 
			// dataGridViewCheckBoxColumn1
			// 
			this.dataGridViewCheckBoxColumn1.DataPropertyName = "Active";
			this.dataGridViewCheckBoxColumn1.HeaderText = "Aktivní";
			this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
			this.dataGridViewCheckBoxColumn1.ReadOnly = true;
			this.dataGridViewCheckBoxColumn1.Width = 50;
			// 
			// DeviceList
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 541);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "DeviceList";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Seznam zařízení";
			this.Load += new System.EventHandler(this.DeviceList_Load);
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.grdDevices)).EndInit();
			this.panel4.ResumeLayout(false);
			this.panel6.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.grdConditions)).EndInit();
			this.panel8.ResumeLayout(false);
			this.panel5.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.grdParams)).EndInit();
			this.panel7.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Button btnDeviceDelete;
		private System.Windows.Forms.Button btnDeviceEdit;
		private System.Windows.Forms.Button btnDeviceInsert;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.ToolTip tipDevice;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.DataGridView grdDevices;
		private System.Windows.Forms.DataGridViewTextBoxColumn Description;
		private System.Windows.Forms.DataGridViewTextBoxColumn IpAddress;
		private System.Windows.Forms.DataGridViewCheckBoxColumn Active;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Panel panel6;
		private System.Windows.Forms.Panel panel8;
		private System.Windows.Forms.Button btnConditionDelete;
		private System.Windows.Forms.Button btnConditionEdit;
		private System.Windows.Forms.Button btnConditionInsert;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.Panel panel7;
		private System.Windows.Forms.Button btnParamDelete;
		private System.Windows.Forms.Button btnParamEdit;
		private System.Windows.Forms.Button btnParamInsert;
		private System.Windows.Forms.DataGridView grdConditions;
		private System.Windows.Forms.DataGridView grdParams;
		private System.Windows.Forms.DataGridViewTextBoxColumn Operator;
		private System.Windows.Forms.DataGridViewTextBoxColumn Value;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
		private System.Windows.Forms.DataGridViewTextBoxColumn Address;
		private System.Windows.Forms.DataGridViewTextBoxColumn Unit;
		private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
	}
}