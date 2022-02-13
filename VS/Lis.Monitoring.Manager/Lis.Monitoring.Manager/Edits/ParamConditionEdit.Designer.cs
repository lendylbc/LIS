
namespace Lis.Monitoring.Manager.Edits {
	partial class ParamConditionEdit {
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
			this.cmbOperator = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.edtValue = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.edtValue)).BeginInit();
			this.SuspendLayout();
			// 
			// btnSave
			// 
			this.btnSave.Location = new System.Drawing.Point(80, 60);
			this.btnSave.TabIndex = 2;
			// 
			// btnStorno
			// 
			this.btnStorno.Location = new System.Drawing.Point(169, 60);
			this.btnStorno.TabIndex = 3;
			// 
			// cmbOperator
			// 
			this.cmbOperator.FormattingEnabled = true;
			this.cmbOperator.Location = new System.Drawing.Point(12, 23);
			this.cmbOperator.Name = "cmbOperator";
			this.cmbOperator.Size = new System.Drawing.Size(116, 21);
			this.cmbOperator.TabIndex = 0;
			this.cmbOperator.SelectedIndexChanged += new System.EventHandler(this.edit_TextChanged);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label3.Location = new System.Drawing.Point(12, 7);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(48, 13);
			this.label3.TabIndex = 19;
			this.label3.Text = "Operátor";
			// 
			// edtValue
			// 
			this.edtValue.DecimalPlaces = 1;
			this.edtValue.Location = new System.Drawing.Point(134, 24);
			this.edtValue.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
			this.edtValue.Name = "edtValue";
			this.edtValue.Size = new System.Drawing.Size(120, 20);
			this.edtValue.TabIndex = 1;
			this.edtValue.ValueChanged += new System.EventHandler(this.edit_TextChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label1.Location = new System.Drawing.Point(131, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(48, 13);
			this.label1.TabIndex = 21;
			this.label1.Text = "Hodnota";
			// 
			// ParamConditionEdit
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(268, 95);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.edtValue);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.cmbOperator);
			this.Name = "ParamConditionEdit";
			this.Text = "Změna zařízení";
			this.Controls.SetChildIndex(this.btnSave, 0);
			this.Controls.SetChildIndex(this.btnStorno, 0);
			this.Controls.SetChildIndex(this.cmbOperator, 0);
			this.Controls.SetChildIndex(this.label3, 0);
			this.Controls.SetChildIndex(this.edtValue, 0);
			this.Controls.SetChildIndex(this.label1, 0);
			((System.ComponentModel.ISupportInitialize)(this.edtValue)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.ComboBox cmbOperator;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.NumericUpDown edtValue;
		private System.Windows.Forms.Label label1;
	}
}