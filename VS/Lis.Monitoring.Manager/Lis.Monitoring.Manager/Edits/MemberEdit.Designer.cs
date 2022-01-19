
namespace Lis.Monitoring.Manager.Edits {
	partial class MemberEdit {
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
			this.edtJmeno = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.chkActive = new System.Windows.Forms.CheckBox();
			this.cmbMemberType = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.edtSurname = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.edtEmail = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.edtLogin = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.edtPassword = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.edtPasswordCheck = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// btnSave
			// 
			this.btnSave.Location = new System.Drawing.Point(108, 301);
			// 
			// btnStorno
			// 
			this.btnStorno.Location = new System.Drawing.Point(199, 301);
			// 
			// edtJmeno
			// 
			this.edtJmeno.Location = new System.Drawing.Point(10, 21);
			this.edtJmeno.MaxLength = 20;
			this.edtJmeno.Name = "edtJmeno";
			this.edtJmeno.Size = new System.Drawing.Size(269, 20);
			this.edtJmeno.TabIndex = 13;
			this.edtJmeno.TextChanged += new System.EventHandler(this.edit_TextChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label1.Location = new System.Drawing.Point(10, 5);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(38, 13);
			this.label1.TabIndex = 15;
			this.label1.Text = "Jméno";
			// 
			// chkActive
			// 
			this.chkActive.AutoSize = true;
			this.chkActive.Location = new System.Drawing.Point(131, 270);
			this.chkActive.Name = "chkActive";
			this.chkActive.Size = new System.Drawing.Size(60, 17);
			this.chkActive.TabIndex = 17;
			this.chkActive.Text = "Aktivní";
			this.chkActive.UseVisualStyleBackColor = true;
			this.chkActive.CheckedChanged += new System.EventHandler(this.edit_TextChanged);
			// 
			// cmbMemberType
			// 
			this.cmbMemberType.FormattingEnabled = true;
			this.cmbMemberType.Location = new System.Drawing.Point(10, 268);
			this.cmbMemberType.Name = "cmbMemberType";
			this.cmbMemberType.Size = new System.Drawing.Size(115, 21);
			this.cmbMemberType.TabIndex = 18;
			this.cmbMemberType.TextChanged += new System.EventHandler(this.edit_TextChanged);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label3.Location = new System.Drawing.Point(10, 252);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(25, 13);
			this.label3.TabIndex = 19;
			this.label3.Text = "Typ";
			// 
			// edtSurname
			// 
			this.edtSurname.Location = new System.Drawing.Point(10, 62);
			this.edtSurname.MaxLength = 20;
			this.edtSurname.Name = "edtSurname";
			this.edtSurname.Size = new System.Drawing.Size(269, 20);
			this.edtSurname.TabIndex = 20;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label2.Location = new System.Drawing.Point(10, 46);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(48, 13);
			this.label2.TabIndex = 21;
			this.label2.Text = "Příjmení";
			// 
			// edtEmail
			// 
			this.edtEmail.Location = new System.Drawing.Point(10, 103);
			this.edtEmail.MaxLength = 20;
			this.edtEmail.Name = "edtEmail";
			this.edtEmail.Size = new System.Drawing.Size(269, 20);
			this.edtEmail.TabIndex = 22;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label4.Location = new System.Drawing.Point(10, 87);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(35, 13);
			this.label4.TabIndex = 23;
			this.label4.Text = "E-mail";
			// 
			// edtLogin
			// 
			this.edtLogin.Location = new System.Drawing.Point(10, 144);
			this.edtLogin.MaxLength = 20;
			this.edtLogin.Name = "edtLogin";
			this.edtLogin.Size = new System.Drawing.Size(269, 20);
			this.edtLogin.TabIndex = 24;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label5.Location = new System.Drawing.Point(10, 128);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(33, 13);
			this.label5.TabIndex = 25;
			this.label5.Text = "Login";
			// 
			// edtPassword
			// 
			this.edtPassword.Location = new System.Drawing.Point(10, 185);
			this.edtPassword.MaxLength = 20;
			this.edtPassword.Name = "edtPassword";
			this.edtPassword.PasswordChar = '*';
			this.edtPassword.Size = new System.Drawing.Size(269, 20);
			this.edtPassword.TabIndex = 26;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label6.Location = new System.Drawing.Point(10, 169);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(34, 13);
			this.label6.TabIndex = 27;
			this.label6.Text = "Heslo";
			// 
			// edtPasswordCheck
			// 
			this.edtPasswordCheck.Location = new System.Drawing.Point(10, 226);
			this.edtPasswordCheck.MaxLength = 20;
			this.edtPasswordCheck.Name = "edtPasswordCheck";
			this.edtPasswordCheck.PasswordChar = '*';
			this.edtPasswordCheck.Size = new System.Drawing.Size(269, 20);
			this.edtPasswordCheck.TabIndex = 28;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label7.Location = new System.Drawing.Point(10, 210);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(85, 13);
			this.label7.TabIndex = 29;
			this.label7.Text = "Heslo - kontrolní";
			// 
			// MemberEdit
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(296, 336);
			this.Controls.Add(this.edtPasswordCheck);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.edtPassword);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.edtLogin);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.edtEmail);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.edtSurname);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.cmbMemberType);
			this.Controls.Add(this.chkActive);
			this.Controls.Add(this.edtJmeno);
			this.Controls.Add(this.label1);
			this.Name = "MemberEdit";
			this.Text = "Změna zařízení";
			this.Controls.SetChildIndex(this.btnSave, 0);
			this.Controls.SetChildIndex(this.btnStorno, 0);
			this.Controls.SetChildIndex(this.label1, 0);
			this.Controls.SetChildIndex(this.edtJmeno, 0);
			this.Controls.SetChildIndex(this.chkActive, 0);
			this.Controls.SetChildIndex(this.cmbMemberType, 0);
			this.Controls.SetChildIndex(this.label3, 0);
			this.Controls.SetChildIndex(this.label2, 0);
			this.Controls.SetChildIndex(this.edtSurname, 0);
			this.Controls.SetChildIndex(this.label4, 0);
			this.Controls.SetChildIndex(this.edtEmail, 0);
			this.Controls.SetChildIndex(this.label5, 0);
			this.Controls.SetChildIndex(this.edtLogin, 0);
			this.Controls.SetChildIndex(this.label6, 0);
			this.Controls.SetChildIndex(this.edtPassword, 0);
			this.Controls.SetChildIndex(this.label7, 0);
			this.Controls.SetChildIndex(this.edtPasswordCheck, 0);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.TextBox edtJmeno;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.CheckBox chkActive;
		private System.Windows.Forms.ComboBox cmbMemberType;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox edtSurname;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox edtEmail;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox edtLogin;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox edtPassword;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox edtPasswordCheck;
		private System.Windows.Forms.Label label7;
	}
}