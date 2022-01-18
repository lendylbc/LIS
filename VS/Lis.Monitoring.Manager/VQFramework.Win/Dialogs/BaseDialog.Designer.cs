namespace VQFramework.Win.Dialogs
{
	partial class BaseDialog
	{
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseDialog));
			this.btnOk = new System.Windows.Forms.Button();
			this.btnStorno = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnOk
			// 
			this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOk.Location = new System.Drawing.Point(21, 133);
			this.btnOk.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(113, 28);
			this.btnOk.TabIndex = 4;
			this.btnOk.Text = "Ok";
			this.btnOk.UseVisualStyleBackColor = true;
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// btnStorno
			// 
			this.btnStorno.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnStorno.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnStorno.Location = new System.Drawing.Point(143, 133);
			this.btnStorno.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btnStorno.Name = "btnStorno";
			this.btnStorno.Size = new System.Drawing.Size(113, 28);
			this.btnStorno.TabIndex = 5;
			this.btnStorno.Text = "Cancel";
			this.btnStorno.UseVisualStyleBackColor = true;
			this.btnStorno.Click += new System.EventHandler(this.btnStorno_Click);
			// 
			// BaseDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(276, 175);
			this.ControlBox = false;
			this.Controls.Add(this.btnStorno);
			this.Controls.Add(this.btnOk);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.MinimizeBox = false;
			this.Name = "BaseDialog";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "BaseEdit";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BaseDialog_KeyDown);
			this.ResumeLayout(false);

		}

		#endregion

		protected System.Windows.Forms.Button btnOk;
		protected System.Windows.Forms.Button btnStorno;
	}
}