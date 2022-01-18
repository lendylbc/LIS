namespace VQFramework.Win.Edit {
    partial class BaseEdit {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseEdit));
			this.btnSave = new System.Windows.Forms.Button();
			this.btnStorno = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnSave
			// 
			this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSave.Location = new System.Drawing.Point(21, 133);
			this.btnSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(113, 28);
			this.btnSave.TabIndex = 4;
			this.btnSave.Text = "Uložit";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
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
			this.btnStorno.Text = "Storno";
			this.btnStorno.UseVisualStyleBackColor = true;
			this.btnStorno.Click += new System.EventHandler(this.btnStorno_Click);
			// 
			// BaseEdit
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(276, 175);
			this.ControlBox = false;
			this.Controls.Add(this.btnStorno);
			this.Controls.Add(this.btnSave);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			
			this.KeyPreview = true;
			this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.MinimizeBox = false;
			this.Name = "BaseEdit";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "BaseEdit";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BaseEdit_FormClosing);
			this.Load += new System.EventHandler(this.BaseEdit_Load);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BaseEdit_KeyDown);
			this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Button btnSave;
        protected System.Windows.Forms.Button btnStorno;
    }
}