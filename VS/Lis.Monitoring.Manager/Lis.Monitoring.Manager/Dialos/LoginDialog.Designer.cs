
namespace Lis.Monitoring.Manager.Dialos {
	partial class LoginDialog {
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
			this.label1 = new System.Windows.Forms.Label();
			this.edtLogin = new System.Windows.Forms.TextBox();
			this.edtPassword = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// btnOk
			// 
			this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.btnOk.ForeColor = System.Drawing.Color.MidnightBlue;
			this.btnOk.Location = new System.Drawing.Point(16, 98);
			this.btnOk.Size = new System.Drawing.Size(176, 28);
			this.btnOk.Text = "Přihlásit se";
			// 
			// btnStorno
			// 
			this.btnStorno.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnStorno.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.btnStorno.ForeColor = System.Drawing.Color.DimGray;
			this.btnStorno.Location = new System.Drawing.Point(16, 132);
			this.btnStorno.Size = new System.Drawing.Size(176, 28);
			this.btnStorno.Text = "Zavřít";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(16, 11);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(38, 13);
			this.label1.TabIndex = 6;
			this.label1.Text = "Jméno";
			// 
			// edtLogin
			// 
			this.edtLogin.Location = new System.Drawing.Point(16, 27);
			this.edtLogin.MaxLength = 30;
			this.edtLogin.Name = "edtLogin";
			this.edtLogin.Size = new System.Drawing.Size(176, 20);
			this.edtLogin.TabIndex = 7;
			this.edtLogin.Text = "LENDY";
			// 
			// edtPassword
			// 
			this.edtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.edtPassword.Location = new System.Drawing.Point(16, 66);
			this.edtPassword.MaxLength = 30;
			this.edtPassword.Name = "edtPassword";
			this.edtPassword.PasswordChar = '*';
			this.edtPassword.Size = new System.Drawing.Size(176, 20);
			this.edtPassword.TabIndex = 9;
			this.edtPassword.Text = "admin";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(16, 50);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(34, 13);
			this.label2.TabIndex = 8;
			this.label2.Text = "Heslo";
			// 
			// LoginDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(210, 167);
			this.Controls.Add(this.edtPassword);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.edtLogin);
			this.Controls.Add(this.label1);
			this.Name = "LoginDialog";
			this.Text = "Přihlášení uživatele";
			this.Controls.SetChildIndex(this.btnOk, 0);
			this.Controls.SetChildIndex(this.btnStorno, 0);
			this.Controls.SetChildIndex(this.label1, 0);
			this.Controls.SetChildIndex(this.edtLogin, 0);
			this.Controls.SetChildIndex(this.label2, 0);
			this.Controls.SetChildIndex(this.edtPassword, 0);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox edtLogin;
		private System.Windows.Forms.TextBox edtPassword;
		private System.Windows.Forms.Label label2;
	}
}