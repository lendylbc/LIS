
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
			this.label2 = new System.Windows.Forms.Label();
			this.pnlNumericValue = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.edtValueNumeric = new System.Windows.Forms.NumericUpDown();
			this.label3 = new System.Windows.Forms.Label();
			this.cmbOperatorNumeric = new System.Windows.Forms.ComboBox();
			this.pnlTextValue = new System.Windows.Forms.Panel();
			this.edtValueText = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.cmbOperatorText = new System.Windows.Forms.ComboBox();
			this.pnlNumericValue.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.edtValueNumeric)).BeginInit();
			this.pnlTextValue.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnSave
			// 
			this.btnSave.Location = new System.Drawing.Point(125, 98);
			this.btnSave.TabIndex = 2;
			// 
			// btnStorno
			// 
			this.btnStorno.Location = new System.Drawing.Point(214, 98);
			this.btnStorno.TabIndex = 3;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 10);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(252, 13);
			this.label2.TabIndex = 22;
			this.label2.Text = "Upozornit, pokud naměřená hodnot splní podmínku";
			// 
			// pnlNumericValue
			// 
			this.pnlNumericValue.Controls.Add(this.label1);
			this.pnlNumericValue.Controls.Add(this.edtValueNumeric);
			this.pnlNumericValue.Controls.Add(this.label3);
			this.pnlNumericValue.Controls.Add(this.cmbOperatorNumeric);
			this.pnlNumericValue.Location = new System.Drawing.Point(12, 35);
			this.pnlNumericValue.Name = "pnlNumericValue";
			this.pnlNumericValue.Size = new System.Drawing.Size(290, 54);
			this.pnlNumericValue.TabIndex = 23;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label1.Location = new System.Drawing.Point(135, 7);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(48, 13);
			this.label1.TabIndex = 25;
			this.label1.Text = "Hodnota";
			// 
			// edtValueNumeric
			// 
			this.edtValueNumeric.DecimalPlaces = 1;
			this.edtValueNumeric.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.edtValueNumeric.Location = new System.Drawing.Point(138, 23);
			this.edtValueNumeric.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.edtValueNumeric.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
			this.edtValueNumeric.Name = "edtValueNumeric";
			this.edtValueNumeric.Size = new System.Drawing.Size(139, 20);
			this.edtValueNumeric.TabIndex = 23;
			this.edtValueNumeric.ValueChanged += new System.EventHandler(this.edit_TextChanged);
			this.edtValueNumeric.KeyUp += new System.Windows.Forms.KeyEventHandler(this.edtValueNumeric_KeyUp);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label3.Location = new System.Drawing.Point(16, 6);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(48, 13);
			this.label3.TabIndex = 24;
			this.label3.Text = "Operátor";
			// 
			// cmbOperatorNumeric
			// 
			this.cmbOperatorNumeric.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbOperatorNumeric.FormattingEnabled = true;
			this.cmbOperatorNumeric.Location = new System.Drawing.Point(16, 22);
			this.cmbOperatorNumeric.Name = "cmbOperatorNumeric";
			this.cmbOperatorNumeric.Size = new System.Drawing.Size(116, 21);
			this.cmbOperatorNumeric.TabIndex = 22;
			this.cmbOperatorNumeric.SelectedIndexChanged += new System.EventHandler(this.edit_TextChanged);
			// 
			// pnlTextValue
			// 
			this.pnlTextValue.Controls.Add(this.edtValueText);
			this.pnlTextValue.Controls.Add(this.label4);
			this.pnlTextValue.Controls.Add(this.label5);
			this.pnlTextValue.Controls.Add(this.cmbOperatorText);
			this.pnlTextValue.Location = new System.Drawing.Point(12, 35);
			this.pnlTextValue.Name = "pnlTextValue";
			this.pnlTextValue.Size = new System.Drawing.Size(290, 54);
			this.pnlTextValue.TabIndex = 24;
			// 
			// edtValueText
			// 
			this.edtValueText.Location = new System.Drawing.Point(138, 22);
			this.edtValueText.Name = "edtValueText";
			this.edtValueText.Size = new System.Drawing.Size(139, 20);
			this.edtValueText.TabIndex = 26;
			this.edtValueText.TextChanged += new System.EventHandler(this.edit_TextChanged);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label4.Location = new System.Drawing.Point(135, 7);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(48, 13);
			this.label4.TabIndex = 25;
			this.label4.Text = "Hodnota";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.label5.Location = new System.Drawing.Point(16, 7);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(48, 13);
			this.label5.TabIndex = 24;
			this.label5.Text = "Operátor";
			// 
			// cmbOperatorText
			// 
			this.cmbOperatorText.FormattingEnabled = true;
			this.cmbOperatorText.Location = new System.Drawing.Point(16, 22);
			this.cmbOperatorText.Name = "cmbOperatorText";
			this.cmbOperatorText.Size = new System.Drawing.Size(116, 21);
			this.cmbOperatorText.TabIndex = 22;
			this.cmbOperatorText.SelectedIndexChanged += new System.EventHandler(this.edit_TextChanged);
			// 
			// ParamConditionEdit
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(313, 133);
			this.Controls.Add(this.pnlNumericValue);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.pnlTextValue);
			this.Name = "ParamConditionEdit";
			this.Text = "Změna podmínky parametru";
			this.Controls.SetChildIndex(this.pnlTextValue, 0);
			this.Controls.SetChildIndex(this.btnSave, 0);
			this.Controls.SetChildIndex(this.btnStorno, 0);
			this.Controls.SetChildIndex(this.label2, 0);
			this.Controls.SetChildIndex(this.pnlNumericValue, 0);
			this.pnlNumericValue.ResumeLayout(false);
			this.pnlNumericValue.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.edtValueNumeric)).EndInit();
			this.pnlTextValue.ResumeLayout(false);
			this.pnlTextValue.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Panel pnlNumericValue;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.NumericUpDown edtValueNumeric;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox cmbOperatorNumeric;
		private System.Windows.Forms.Panel pnlTextValue;
		private System.Windows.Forms.TextBox edtValueText;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ComboBox cmbOperatorText;
	}
}