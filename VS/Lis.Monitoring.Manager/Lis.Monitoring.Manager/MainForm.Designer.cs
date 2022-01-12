
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
			this.btnGetToken = new System.Windows.Forms.Button();
			this.edtLogin = new System.Windows.Forms.TextBox();
			this.edtPassword = new System.Windows.Forms.TextBox();
			this.edtLog = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// btnGetToken
			// 
			this.btnGetToken.Location = new System.Drawing.Point(36, 100);
			this.btnGetToken.Name = "btnGetToken";
			this.btnGetToken.Size = new System.Drawing.Size(75, 23);
			this.btnGetToken.TabIndex = 0;
			this.btnGetToken.Text = "Get token";
			this.btnGetToken.UseVisualStyleBackColor = true;
			this.btnGetToken.Click += new System.EventHandler(this.btnGetToken_Click);
			// 
			// edtLogin
			// 
			this.edtLogin.Location = new System.Drawing.Point(36, 16);
			this.edtLogin.Name = "edtLogin";
			this.edtLogin.Size = new System.Drawing.Size(100, 20);
			this.edtLogin.TabIndex = 1;
			this.edtLogin.Text = "LENDY";
			// 
			// edtPassword
			// 
			this.edtPassword.Location = new System.Drawing.Point(36, 53);
			this.edtPassword.Name = "edtPassword";
			this.edtPassword.Size = new System.Drawing.Size(100, 20);
			this.edtPassword.TabIndex = 2;
			this.edtPassword.Text = "admin";
			// 
			// edtLog
			// 
			this.edtLog.Location = new System.Drawing.Point(302, 16);
			this.edtLog.Multiline = true;
			this.edtLog.Name = "edtLog";
			this.edtLog.Size = new System.Drawing.Size(250, 422);
			this.edtLog.TabIndex = 3;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.edtLog);
			this.Controls.Add(this.edtPassword);
			this.Controls.Add(this.edtLogin);
			this.Controls.Add(this.btnGetToken);
			this.Name = "MainForm";
			this.Text = "Form1";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnGetToken;
		private System.Windows.Forms.TextBox edtLogin;
		private System.Windows.Forms.TextBox edtPassword;
		private System.Windows.Forms.TextBox edtLog;
	}
}

