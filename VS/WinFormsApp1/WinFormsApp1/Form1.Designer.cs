﻿
namespace WinFormsApp1 {
	partial class Form1 {
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.edtLog = new System.Windows.Forms.TextBox();
			this.panel3 = new System.Windows.Forms.Panel();
			this.button2 = new System.Windows.Forms.Button();
			this.panel4 = new System.Windows.Forms.Panel();
			this.edtOids = new System.Windows.Forms.TextBox();
			this.panel5 = new System.Windows.Forms.Panel();
			this.btnPapouch = new System.Windows.Forms.Button();
			this.btnTme = new System.Windows.Forms.Button();
			this.btnQuido = new System.Windows.Forms.Button();
			this.panel6 = new System.Windows.Forms.Panel();
			this.button3 = new System.Windows.Forms.Button();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.button4 = new System.Windows.Forms.Button();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.edtModbusData = new System.Windows.Forms.TextBox();
			this.edtModbusPort = new System.Windows.Forms.NumericUpDown();
			this.edtModbusIp = new System.Windows.Forms.TextBox();
			this.btnModbus = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.edtSnmpPort = new System.Windows.Forms.NumericUpDown();
			this.edtSnmpCount = new System.Windows.Forms.NumericUpDown();
			this.rbtnSnmp = new System.Windows.Forms.RadioButton();
			this.button1 = new System.Windows.Forms.Button();
			this.edtSnmpIp = new System.Windows.Forms.TextBox();
			this.btnSendReq = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.rbtnSick = new System.Windows.Forms.RadioButton();
			this.edtSickCommand = new System.Windows.Forms.TextBox();
			this.edtSickPort = new System.Windows.Forms.NumericUpDown();
			this.edtSickIp = new System.Windows.Forms.TextBox();
			this.btnSick = new System.Windows.Forms.Button();
			this.edtComPort = new System.Windows.Forms.TextBox();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel3.SuspendLayout();
			this.panel4.SuspendLayout();
			this.panel5.SuspendLayout();
			this.panel6.SuspendLayout();
			this.groupBox3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.edtModbusPort)).BeginInit();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.edtSnmpPort)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.edtSnmpCount)).BeginInit();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.edtSickPort)).BeginInit();
			this.SuspendLayout();
			// 
			// timer1
			// 
			this.timer1.Interval = 500;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.panel2);
			this.panel1.Controls.Add(this.panel4);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
			this.panel1.Location = new System.Drawing.Point(342, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(484, 450);
			this.panel1.TabIndex = 15;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.edtLog);
			this.panel2.Controls.Add(this.panel3);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(200, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(284, 450);
			this.panel2.TabIndex = 17;
			// 
			// edtLog
			// 
			this.edtLog.Dock = System.Windows.Forms.DockStyle.Fill;
			this.edtLog.Location = new System.Drawing.Point(0, 34);
			this.edtLog.Multiline = true;
			this.edtLog.Name = "edtLog";
			this.edtLog.Size = new System.Drawing.Size(284, 416);
			this.edtLog.TabIndex = 15;
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.button2);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel3.Location = new System.Drawing.Point(0, 0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(284, 34);
			this.panel3.TabIndex = 0;
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(170, 5);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 16;
			this.button2.Text = "Clear log";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.btnClearLog_Click);
			// 
			// panel4
			// 
			this.panel4.Controls.Add(this.edtOids);
			this.panel4.Controls.Add(this.panel5);
			this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel4.Location = new System.Drawing.Point(0, 0);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(200, 450);
			this.panel4.TabIndex = 16;
			// 
			// edtOids
			// 
			this.edtOids.Dock = System.Windows.Forms.DockStyle.Fill;
			this.edtOids.Location = new System.Drawing.Point(0, 34);
			this.edtOids.Multiline = true;
			this.edtOids.Name = "edtOids";
			this.edtOids.Size = new System.Drawing.Size(200, 416);
			this.edtOids.TabIndex = 15;
			this.edtOids.Text = "1.3.6.1.4.1.476.1.42.3.4.1.3.3.1.3.3";
			// 
			// panel5
			// 
			this.panel5.Controls.Add(this.btnPapouch);
			this.panel5.Controls.Add(this.btnTme);
			this.panel5.Controls.Add(this.btnQuido);
			this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel5.Location = new System.Drawing.Point(0, 0);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(200, 34);
			this.panel5.TabIndex = 0;
			// 
			// btnPapouch
			// 
			this.btnPapouch.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnPapouch.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.btnPapouch.Location = new System.Drawing.Point(90, 0);
			this.btnPapouch.Name = "btnPapouch";
			this.btnPapouch.Size = new System.Drawing.Size(51, 34);
			this.btnPapouch.TabIndex = 2;
			this.btnPapouch.Text = "PAP";
			this.btnPapouch.UseVisualStyleBackColor = true;
			this.btnPapouch.Click += new System.EventHandler(this.btnPapouch_Click);
			// 
			// btnTme
			// 
			this.btnTme.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnTme.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.btnTme.Location = new System.Drawing.Point(39, 0);
			this.btnTme.Name = "btnTme";
			this.btnTme.Size = new System.Drawing.Size(51, 34);
			this.btnTme.TabIndex = 1;
			this.btnTme.Text = "TME";
			this.btnTme.UseVisualStyleBackColor = true;
			this.btnTme.Click += new System.EventHandler(this.btnTme_Click);
			// 
			// btnQuido
			// 
			this.btnQuido.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnQuido.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.btnQuido.Location = new System.Drawing.Point(0, 0);
			this.btnQuido.Name = "btnQuido";
			this.btnQuido.Size = new System.Drawing.Size(39, 34);
			this.btnQuido.TabIndex = 0;
			this.btnQuido.Text = "Q";
			this.btnQuido.UseVisualStyleBackColor = true;
			this.btnQuido.Click += new System.EventHandler(this.btnQuido_Click);
			// 
			// panel6
			// 
			this.panel6.Controls.Add(this.button3);
			this.panel6.Controls.Add(this.groupBox3);
			this.panel6.Controls.Add(this.groupBox2);
			this.panel6.Controls.Add(this.groupBox1);
			this.panel6.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel6.Location = new System.Drawing.Point(0, 0);
			this.panel6.Name = "panel6";
			this.panel6.Size = new System.Drawing.Size(336, 450);
			this.panel6.TabIndex = 16;
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(224, 257);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(75, 23);
			this.button3.TabIndex = 18;
			this.button3.Text = "SMTP test";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.edtComPort);
			this.groupBox3.Controls.Add(this.button4);
			this.groupBox3.Controls.Add(this.radioButton1);
			this.groupBox3.Controls.Add(this.edtModbusData);
			this.groupBox3.Controls.Add(this.edtModbusPort);
			this.groupBox3.Controls.Add(this.edtModbusIp);
			this.groupBox3.Controls.Add(this.btnModbus);
			this.groupBox3.Location = new System.Drawing.Point(10, 99);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(316, 152);
			this.groupBox3.TabIndex = 17;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "MODBUS";
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(214, 61);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(75, 23);
			this.button4.TabIndex = 16;
			this.button4.Text = "Send serial";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// radioButton1
			// 
			this.radioButton1.AutoSize = true;
			this.radioButton1.Location = new System.Drawing.Point(-17, 26);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Size = new System.Drawing.Size(14, 13);
			this.radioButton1.TabIndex = 15;
			this.radioButton1.TabStop = true;
			this.radioButton1.UseVisualStyleBackColor = true;
			// 
			// edtModbusData
			// 
			this.edtModbusData.Location = new System.Drawing.Point(9, 104);
			this.edtModbusData.Name = "edtModbusData";
			this.edtModbusData.Size = new System.Drawing.Size(173, 23);
			this.edtModbusData.TabIndex = 14;
			this.edtModbusData.Text = "010403F30001C1BD";
			this.edtModbusData.TextChanged += new System.EventHandler(this.edtModbusData_TextChanged);
			// 
			// edtModbusPort
			// 
			this.edtModbusPort.Location = new System.Drawing.Point(9, 61);
			this.edtModbusPort.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
			this.edtModbusPort.Name = "edtModbusPort";
			this.edtModbusPort.Size = new System.Drawing.Size(120, 23);
			this.edtModbusPort.TabIndex = 13;
			this.edtModbusPort.Value = new decimal(new int[] {
            10001,
            0,
            0,
            0});
			// 
			// edtModbusIp
			// 
			this.edtModbusIp.Location = new System.Drawing.Point(9, 22);
			this.edtModbusIp.Name = "edtModbusIp";
			this.edtModbusIp.Size = new System.Drawing.Size(173, 23);
			this.edtModbusIp.TabIndex = 12;
			this.edtModbusIp.Text = "172.20.1.86";
			// 
			// btnModbus
			// 
			this.btnModbus.Location = new System.Drawing.Point(214, 21);
			this.btnModbus.Name = "btnModbus";
			this.btnModbus.Size = new System.Drawing.Size(75, 23);
			this.btnModbus.TabIndex = 11;
			this.btnModbus.Text = "Get values";
			this.btnModbus.UseVisualStyleBackColor = true;
			this.btnModbus.Click += new System.EventHandler(this.btnModbus_Click);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.edtSnmpPort);
			this.groupBox2.Controls.Add(this.edtSnmpCount);
			this.groupBox2.Controls.Add(this.rbtnSnmp);
			this.groupBox2.Controls.Add(this.button1);
			this.groupBox2.Controls.Add(this.edtSnmpIp);
			this.groupBox2.Controls.Add(this.btnSendReq);
			this.groupBox2.Location = new System.Drawing.Point(10, 6);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(323, 87);
			this.groupBox2.TabIndex = 16;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "SNMP";
			// 
			// edtSnmpPort
			// 
			this.edtSnmpPort.Location = new System.Drawing.Point(36, 50);
			this.edtSnmpPort.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
			this.edtSnmpPort.Name = "edtSnmpPort";
			this.edtSnmpPort.Size = new System.Drawing.Size(76, 23);
			this.edtSnmpPort.TabIndex = 18;
			this.edtSnmpPort.Value = new decimal(new int[] {
            161,
            0,
            0,
            0});
			// 
			// edtSnmpCount
			// 
			this.edtSnmpCount.Location = new System.Drawing.Point(162, 50);
			this.edtSnmpCount.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
			this.edtSnmpCount.Name = "edtSnmpCount";
			this.edtSnmpCount.Size = new System.Drawing.Size(48, 23);
			this.edtSnmpCount.TabIndex = 17;
			this.edtSnmpCount.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
			// 
			// rbtnSnmp
			// 
			this.rbtnSnmp.AutoSize = true;
			this.rbtnSnmp.Checked = true;
			this.rbtnSnmp.Location = new System.Drawing.Point(11, 26);
			this.rbtnSnmp.Name = "rbtnSnmp";
			this.rbtnSnmp.Size = new System.Drawing.Size(14, 13);
			this.rbtnSnmp.TabIndex = 16;
			this.rbtnSnmp.TabStop = true;
			this.rbtnSnmp.UseVisualStyleBackColor = true;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(216, 50);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 14;
			this.button1.Text = "Timer";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.btnTimer_Click);
			// 
			// edtSnmpIp
			// 
			this.edtSnmpIp.Location = new System.Drawing.Point(37, 22);
			this.edtSnmpIp.Name = "edtSnmpIp";
			this.edtSnmpIp.Size = new System.Drawing.Size(173, 23);
			this.edtSnmpIp.TabIndex = 13;
			this.edtSnmpIp.Text = "172.20.0.111";
			// 
			// btnSendReq
			// 
			this.btnSendReq.Location = new System.Drawing.Point(216, 21);
			this.btnSendReq.Name = "btnSendReq";
			this.btnSendReq.Size = new System.Drawing.Size(75, 23);
			this.btnSendReq.TabIndex = 12;
			this.btnSendReq.Text = "SNMP";
			this.btnSendReq.UseVisualStyleBackColor = true;
			this.btnSendReq.Click += new System.EventHandler(this.btnSendReq_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.rbtnSick);
			this.groupBox1.Controls.Add(this.edtSickCommand);
			this.groupBox1.Controls.Add(this.edtSickPort);
			this.groupBox1.Controls.Add(this.edtSickIp);
			this.groupBox1.Controls.Add(this.btnSick);
			this.groupBox1.Location = new System.Drawing.Point(10, 292);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(316, 152);
			this.groupBox1.TabIndex = 15;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "SICK";
			// 
			// rbtnSick
			// 
			this.rbtnSick.AutoSize = true;
			this.rbtnSick.Location = new System.Drawing.Point(-17, 26);
			this.rbtnSick.Name = "rbtnSick";
			this.rbtnSick.Size = new System.Drawing.Size(14, 13);
			this.rbtnSick.TabIndex = 15;
			this.rbtnSick.TabStop = true;
			this.rbtnSick.UseVisualStyleBackColor = true;
			// 
			// edtSickCommand
			// 
			this.edtSickCommand.Location = new System.Drawing.Point(9, 104);
			this.edtSickCommand.Name = "edtSickCommand";
			this.edtSickCommand.Size = new System.Drawing.Size(173, 23);
			this.edtSickCommand.TabIndex = 14;
			this.edtSickCommand.Text = "sMN IVSingleInv 1";
			// 
			// edtSickPort
			// 
			this.edtSickPort.Location = new System.Drawing.Point(9, 61);
			this.edtSickPort.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			this.edtSickPort.Name = "edtSickPort";
			this.edtSickPort.Size = new System.Drawing.Size(120, 23);
			this.edtSickPort.TabIndex = 13;
			this.edtSickPort.Value = new decimal(new int[] {
            2111,
            0,
            0,
            0});
			// 
			// edtSickIp
			// 
			this.edtSickIp.Location = new System.Drawing.Point(9, 22);
			this.edtSickIp.Name = "edtSickIp";
			this.edtSickIp.Size = new System.Drawing.Size(173, 23);
			this.edtSickIp.TabIndex = 12;
			this.edtSickIp.Text = "192.168.0.1";
			// 
			// btnSick
			// 
			this.btnSick.Location = new System.Drawing.Point(214, 21);
			this.btnSick.Name = "btnSick";
			this.btnSick.Size = new System.Drawing.Size(75, 23);
			this.btnSick.TabIndex = 11;
			this.btnSick.Text = "Get values";
			this.btnSick.UseVisualStyleBackColor = true;
			this.btnSick.Click += new System.EventHandler(this.btnSick_Click);
			// 
			// edtComPort
			// 
			this.edtComPort.Location = new System.Drawing.Point(214, 104);
			this.edtComPort.Name = "edtComPort";
			this.edtComPort.Size = new System.Drawing.Size(77, 23);
			this.edtComPort.TabIndex = 17;
			this.edtComPort.Text = "COM16";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(826, 450);
			this.Controls.Add(this.panel6);
			this.Controls.Add(this.panel1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.panel3.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			this.panel4.PerformLayout();
			this.panel5.ResumeLayout(false);
			this.panel6.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.edtModbusPort)).EndInit();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.edtSnmpPort)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.edtSnmpCount)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.edtSickPort)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.TextBox edtOids;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.Button btnPapouch;
		private System.Windows.Forms.Button btnTme;
		private System.Windows.Forms.Button btnQuido;
		private System.Windows.Forms.Panel panel6;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.NumericUpDown edtSnmpCount;
		private System.Windows.Forms.RadioButton rbtnSnmp;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox edtSnmpIp;
		private System.Windows.Forms.Button btnSendReq;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton rbtnSick;
		private System.Windows.Forms.TextBox edtSickCommand;
		private System.Windows.Forms.NumericUpDown edtSickPort;
		private System.Windows.Forms.TextBox edtSickIp;
		private System.Windows.Forms.Button btnSick;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.TextBox edtLog;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.RadioButton radioButton1;
		private System.Windows.Forms.TextBox edtModbusData;
		private System.Windows.Forms.NumericUpDown edtModbusPort;
		private System.Windows.Forms.TextBox edtModbusIp;
		private System.Windows.Forms.Button btnModbus;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.NumericUpDown edtSnmpPort;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.TextBox edtComPort;
	}
}

