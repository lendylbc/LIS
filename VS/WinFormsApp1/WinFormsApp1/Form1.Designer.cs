
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
			this.btnSendReq = new System.Windows.Forms.Button();
			this.edtSnmpIp = new System.Windows.Forms.TextBox();
			this.btnSick = new System.Windows.Forms.Button();
			this.edtSickIp = new System.Windows.Forms.TextBox();
			this.edtSickPort = new System.Windows.Forms.NumericUpDown();
			this.edtSickCommand = new System.Windows.Forms.TextBox();
			this.edtLog = new System.Windows.Forms.TextBox();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.rbtnSnmp = new System.Windows.Forms.RadioButton();
			this.rbtnSick = new System.Windows.Forms.RadioButton();
			this.edtSnmpCount = new System.Windows.Forms.NumericUpDown();
			((System.ComponentModel.ISupportInitialize)(this.edtSickPort)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.edtSnmpCount)).BeginInit();
			this.SuspendLayout();
			// 
			// btnSendReq
			// 
			this.btnSendReq.Location = new System.Drawing.Point(217, 11);
			this.btnSendReq.Name = "btnSendReq";
			this.btnSendReq.Size = new System.Drawing.Size(75, 23);
			this.btnSendReq.TabIndex = 0;
			this.btnSendReq.Text = "SNMP";
			this.btnSendReq.UseVisualStyleBackColor = true;
			this.btnSendReq.Click += new System.EventHandler(this.btnSendReq_Click);
			// 
			// edtSnmpIp
			// 
			this.edtSnmpIp.Location = new System.Drawing.Point(38, 12);
			this.edtSnmpIp.Name = "edtSnmpIp";
			this.edtSnmpIp.Size = new System.Drawing.Size(173, 23);
			this.edtSnmpIp.TabIndex = 1;
			this.edtSnmpIp.Text = "172.20.1.55";
			// 
			// btnSick
			// 
			this.btnSick.Location = new System.Drawing.Point(217, 124);
			this.btnSick.Name = "btnSick";
			this.btnSick.Size = new System.Drawing.Size(75, 23);
			this.btnSick.TabIndex = 2;
			this.btnSick.Text = "SICK";
			this.btnSick.UseVisualStyleBackColor = true;
			this.btnSick.Click += new System.EventHandler(this.btnSick_Click);
			// 
			// edtSickIp
			// 
			this.edtSickIp.Location = new System.Drawing.Point(38, 124);
			this.edtSickIp.Name = "edtSickIp";
			this.edtSickIp.Size = new System.Drawing.Size(173, 23);
			this.edtSickIp.TabIndex = 3;
			this.edtSickIp.Text = "192.168.0.1";
			// 
			// edtSickPort
			// 
			this.edtSickPort.Location = new System.Drawing.Point(38, 163);
			this.edtSickPort.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			this.edtSickPort.Name = "edtSickPort";
			this.edtSickPort.Size = new System.Drawing.Size(120, 23);
			this.edtSickPort.TabIndex = 4;
			this.edtSickPort.Value = new decimal(new int[] {
            2111,
            0,
            0,
            0});
			// 
			// edtSickCommand
			// 
			this.edtSickCommand.Location = new System.Drawing.Point(38, 206);
			this.edtSickCommand.Name = "edtSickCommand";
			this.edtSickCommand.Size = new System.Drawing.Size(173, 23);
			this.edtSickCommand.TabIndex = 5;
			this.edtSickCommand.Text = "sMN IVSingleInv 1";
			// 
			// edtLog
			// 
			this.edtLog.Dock = System.Windows.Forms.DockStyle.Right;
			this.edtLog.Location = new System.Drawing.Point(298, 0);
			this.edtLog.Multiline = true;
			this.edtLog.Name = "edtLog";
			this.edtLog.Size = new System.Drawing.Size(528, 450);
			this.edtLog.TabIndex = 6;
			// 
			// timer1
			// 
			this.timer1.Interval = 500;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(217, 79);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 7;
			this.button1.Text = "Timer";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(217, 50);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 8;
			this.button2.Text = "Clear log";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// rbtnSnmp
			// 
			this.rbtnSnmp.AutoSize = true;
			this.rbtnSnmp.Checked = true;
			this.rbtnSnmp.Location = new System.Drawing.Point(12, 16);
			this.rbtnSnmp.Name = "rbtnSnmp";
			this.rbtnSnmp.Size = new System.Drawing.Size(14, 13);
			this.rbtnSnmp.TabIndex = 9;
			this.rbtnSnmp.TabStop = true;
			this.rbtnSnmp.UseVisualStyleBackColor = true;
			// 
			// rbtnSick
			// 
			this.rbtnSick.AutoSize = true;
			this.rbtnSick.Location = new System.Drawing.Point(12, 128);
			this.rbtnSick.Name = "rbtnSick";
			this.rbtnSick.Size = new System.Drawing.Size(14, 13);
			this.rbtnSick.TabIndex = 10;
			this.rbtnSick.TabStop = true;
			this.rbtnSick.UseVisualStyleBackColor = true;
			// 
			// edtSnmpCount
			// 
			this.edtSnmpCount.Location = new System.Drawing.Point(38, 41);
			this.edtSnmpCount.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
			this.edtSnmpCount.Name = "edtSnmpCount";
			this.edtSnmpCount.Size = new System.Drawing.Size(48, 23);
			this.edtSnmpCount.TabIndex = 11;
			this.edtSnmpCount.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(826, 450);
			this.Controls.Add(this.edtSnmpCount);
			this.Controls.Add(this.rbtnSick);
			this.Controls.Add(this.rbtnSnmp);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.edtLog);
			this.Controls.Add(this.edtSickCommand);
			this.Controls.Add(this.edtSickPort);
			this.Controls.Add(this.edtSickIp);
			this.Controls.Add(this.btnSick);
			this.Controls.Add(this.edtSnmpIp);
			this.Controls.Add(this.btnSendReq);
			this.Name = "Form1";
			this.Text = "Form1";
			((System.ComponentModel.ISupportInitialize)(this.edtSickPort)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.edtSnmpCount)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnSendReq;
		private System.Windows.Forms.TextBox edtSnmpIp;
		private System.Windows.Forms.Button btnSick;
		private System.Windows.Forms.TextBox edtSickIp;
		private System.Windows.Forms.NumericUpDown edtSickPort;
		private System.Windows.Forms.TextBox edtSickCommand;
		private System.Windows.Forms.TextBox edtLog;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.RadioButton rbtnSnmp;
		private System.Windows.Forms.RadioButton rbtnSick;
		private System.Windows.Forms.NumericUpDown edtSnmpCount;
	}
}

