
namespace Lis.Monitoring.Manager.Edits {
	partial class DeviceEdit {
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
			this.label2 = new System.Windows.Forms.Label();
			this.edtDescription = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.chkActive = new System.Windows.Forms.CheckBox();
			this.cmbDeviceType = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.edtPort = new System.Windows.Forms.MaskedTextBox();
			this.edtIpAddress = new System.Windows.Forms.MaskedTextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// btnSave
			// 
			this.btnSave.Location = new System.Drawing.Point(108, 145);
			// 
			// btnStorno
			// 
			this.btnStorno.Location = new System.Drawing.Point(199, 145);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label2.Location = new System.Drawing.Point(12, 46);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(16, 13);
			this.label2.TabIndex = 16;
			this.label2.Text = "Ip";
			// 
			// edtDescription
			// 
			this.edtDescription.Location = new System.Drawing.Point(12, 21);
			this.edtDescription.MaxLength = 20;
			this.edtDescription.Name = "edtDescription";
			this.edtDescription.Size = new System.Drawing.Size(269, 20);
			this.edtDescription.TabIndex = 13;
			this.edtDescription.TextChanged += new System.EventHandler(this.edit_TextChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label1.Location = new System.Drawing.Point(12, 5);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(33, 13);
			this.label1.TabIndex = 15;
			this.label1.Text = "Popis";
			// 
			// chkActive
			// 
			this.chkActive.AutoSize = true;
			this.chkActive.Location = new System.Drawing.Point(121, 113);
			this.chkActive.Name = "chkActive";
			this.chkActive.Size = new System.Drawing.Size(60, 17);
			this.chkActive.TabIndex = 17;
			this.chkActive.Text = "Aktivní";
			this.chkActive.UseVisualStyleBackColor = true;
			this.chkActive.CheckedChanged += new System.EventHandler(this.edit_TextChanged);
			// 
			// cmbDeviceType
			// 
			this.cmbDeviceType.FormattingEnabled = true;
			this.cmbDeviceType.Location = new System.Drawing.Point(12, 109);
			this.cmbDeviceType.Name = "cmbDeviceType";
			this.cmbDeviceType.Size = new System.Drawing.Size(100, 21);
			this.cmbDeviceType.TabIndex = 18;
			this.cmbDeviceType.TextChanged += new System.EventHandler(this.edit_TextChanged);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label3.Location = new System.Drawing.Point(12, 93);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(25, 13);
			this.label3.TabIndex = 19;
			this.label3.Text = "Typ";
			// 
			// edtPort
			// 
			this.edtPort.Location = new System.Drawing.Point(118, 64);
			this.edtPort.Mask = "00000";
			this.edtPort.Name = "edtPort";
			this.edtPort.PromptChar = ' ';
			this.edtPort.Size = new System.Drawing.Size(100, 20);
			this.edtPort.TabIndex = 20;
			this.edtPort.TextChanged += new System.EventHandler(this.edit_TextChanged);
			// 
			// edtIpAddress
			// 
			this.edtIpAddress.Location = new System.Drawing.Point(12, 64);
			this.edtIpAddress.Name = "edtIpAddress";
			this.edtIpAddress.Size = new System.Drawing.Size(100, 20);
			this.edtIpAddress.TabIndex = 21;
			this.edtIpAddress.TextChanged += new System.EventHandler(this.edit_TextChanged);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label4.Location = new System.Drawing.Point(118, 48);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(26, 13);
			this.label4.TabIndex = 22;
			this.label4.Text = "Port";
			// 
			// DeviceEdit
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(296, 180);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.edtIpAddress);
			this.Controls.Add(this.edtPort);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.cmbDeviceType);
			this.Controls.Add(this.chkActive);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.edtDescription);
			this.Controls.Add(this.label1);
			this.Name = "DeviceEdit";
			this.Text = "Změna zařízení";
			this.Controls.SetChildIndex(this.btnSave, 0);
			this.Controls.SetChildIndex(this.btnStorno, 0);
			this.Controls.SetChildIndex(this.label1, 0);
			this.Controls.SetChildIndex(this.edtDescription, 0);
			this.Controls.SetChildIndex(this.label2, 0);
			this.Controls.SetChildIndex(this.chkActive, 0);
			this.Controls.SetChildIndex(this.cmbDeviceType, 0);
			this.Controls.SetChildIndex(this.label3, 0);
			this.Controls.SetChildIndex(this.edtPort, 0);
			this.Controls.SetChildIndex(this.edtIpAddress, 0);
			this.Controls.SetChildIndex(this.label4, 0);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox edtDescription;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.CheckBox chkActive;
		private System.Windows.Forms.ComboBox cmbDeviceType;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.MaskedTextBox edtPort;
		private System.Windows.Forms.MaskedTextBox edtIpAddress;
		private System.Windows.Forms.Label label4;
	}
}