
namespace Lis.Monitoring.Manager.Edits {
	partial class DeviceParameterEdit {
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
			this.label4 = new System.Windows.Forms.Label();
			this.edtAddress = new System.Windows.Forms.TextBox();
			this.edtUnit = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// btnSave
			// 
			this.btnSave.Location = new System.Drawing.Point(108, 138);
			// 
			// btnStorno
			// 
			this.btnStorno.Location = new System.Drawing.Point(199, 138);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label2.Location = new System.Drawing.Point(12, 46);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(40, 13);
			this.label2.TabIndex = 16;
			this.label2.Text = "Adresa";
			// 
			// edtDescription
			// 
			this.edtDescription.Location = new System.Drawing.Point(12, 21);
			this.edtDescription.MaxLength = 50;
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
			this.chkActive.Location = new System.Drawing.Point(118, 106);
			this.chkActive.Name = "chkActive";
			this.chkActive.Size = new System.Drawing.Size(60, 17);
			this.chkActive.TabIndex = 17;
			this.chkActive.Text = "Aktivní";
			this.chkActive.UseVisualStyleBackColor = true;
			this.chkActive.CheckedChanged += new System.EventHandler(this.edit_TextChanged);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label4.Location = new System.Drawing.Point(12, 87);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(51, 13);
			this.label4.TabIndex = 22;
			this.label4.Text = "Jednotka";
			// 
			// edtAddress
			// 
			this.edtAddress.Location = new System.Drawing.Point(12, 64);
			this.edtAddress.MaxLength = 50;
			this.edtAddress.Name = "edtAddress";
			this.edtAddress.Size = new System.Drawing.Size(269, 20);
			this.edtAddress.TabIndex = 23;
			this.edtAddress.TextChanged += new System.EventHandler(this.edit_TextChanged);
			// 
			// edtUnit
			// 
			this.edtUnit.Location = new System.Drawing.Point(12, 104);
			this.edtUnit.MaxLength = 5;
			this.edtUnit.Name = "edtUnit";
			this.edtUnit.Size = new System.Drawing.Size(90, 20);
			this.edtUnit.TabIndex = 24;
			this.edtUnit.TextChanged += new System.EventHandler(this.edit_TextChanged);
			// 
			// DeviceParameterEdit
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(296, 173);
			this.Controls.Add(this.edtUnit);
			this.Controls.Add(this.edtAddress);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.chkActive);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.edtDescription);
			this.Controls.Add(this.label1);
			this.Name = "DeviceParameterEdit";
			this.Text = "Změna zařízení";
			this.Controls.SetChildIndex(this.btnSave, 0);
			this.Controls.SetChildIndex(this.btnStorno, 0);
			this.Controls.SetChildIndex(this.label1, 0);
			this.Controls.SetChildIndex(this.edtDescription, 0);
			this.Controls.SetChildIndex(this.label2, 0);
			this.Controls.SetChildIndex(this.chkActive, 0);
			this.Controls.SetChildIndex(this.label4, 0);
			this.Controls.SetChildIndex(this.edtAddress, 0);
			this.Controls.SetChildIndex(this.edtUnit, 0);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox edtDescription;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.CheckBox chkActive;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox edtAddress;
		private System.Windows.Forms.TextBox edtUnit;
	}
}