
namespace Lis.Monitoring.Manager.Forms {
	partial class MemberList {
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MemberList));
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnClose = new System.Windows.Forms.Button();
			this.btnDelete = new System.Windows.Forms.Button();
			this.btnEdit = new System.Windows.Forms.Button();
			this.btnInsert = new System.Windows.Forms.Button();
			this.panel2 = new System.Windows.Forms.Panel();
			this.panel3 = new System.Windows.Forms.Panel();
			this.grdMembers = new System.Windows.Forms.DataGridView();
			this.tipMember = new System.Windows.Forms.ToolTip(this.components);
			this.Login = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Jmeno = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Surname = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.MemberTypeText = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Active = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdMembers)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.btnClose);
			this.panel1.Controls.Add(this.btnDelete);
			this.panel1.Controls.Add(this.btnEdit);
			this.panel1.Controls.Add(this.btnInsert);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(800, 32);
			this.panel1.TabIndex = 0;
			// 
			// btnClose
			// 
			this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnClose.Image = global::Lis.Monitoring.Manager.Properties.Resources.close;
			this.btnClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.btnClose.Location = new System.Drawing.Point(770, 2);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(28, 28);
			this.btnClose.TabIndex = 9;
			this.tipMember.SetToolTip(this.btnClose, "Zavřít");
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// btnDelete
			// 
			this.btnDelete.Image = global::Lis.Monitoring.Manager.Properties.Resources.delete;
			this.btnDelete.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.btnDelete.Location = new System.Drawing.Point(63, 2);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(28, 28);
			this.btnDelete.TabIndex = 8;
			this.tipMember.SetToolTip(this.btnDelete, "Smazat uživatele");
			this.btnDelete.UseVisualStyleBackColor = true;
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// btnEdit
			// 
			this.btnEdit.Image = global::Lis.Monitoring.Manager.Properties.Resources.edit;
			this.btnEdit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.btnEdit.Location = new System.Drawing.Point(33, 2);
			this.btnEdit.Name = "btnEdit";
			this.btnEdit.Size = new System.Drawing.Size(28, 28);
			this.btnEdit.TabIndex = 7;
			this.tipMember.SetToolTip(this.btnEdit, "Upravit uživatele");
			this.btnEdit.UseVisualStyleBackColor = true;
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			// 
			// btnInsert
			// 
			this.btnInsert.Image = ((System.Drawing.Image)(resources.GetObject("btnInsert.Image")));
			this.btnInsert.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.btnInsert.Location = new System.Drawing.Point(3, 2);
			this.btnInsert.Name = "btnInsert";
			this.btnInsert.Size = new System.Drawing.Size(28, 28);
			this.btnInsert.TabIndex = 6;
			this.tipMember.SetToolTip(this.btnInsert, "Přidat uživatele");
			this.btnInsert.UseVisualStyleBackColor = true;
			this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.panel3);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(0, 32);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(800, 509);
			this.panel2.TabIndex = 1;
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.grdMembers);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel3.Location = new System.Drawing.Point(0, 0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(800, 509);
			this.panel3.TabIndex = 2;
			// 
			// grdMembers
			// 
			this.grdMembers.AllowUserToAddRows = false;
			this.grdMembers.AllowUserToDeleteRows = false;
			this.grdMembers.AllowUserToResizeRows = false;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.grdMembers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.grdMembers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.grdMembers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Login,
            this.Jmeno,
            this.Surname,
            this.Email,
            this.MemberTypeText,
            this.Active});
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.grdMembers.DefaultCellStyle = dataGridViewCellStyle2;
			this.grdMembers.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grdMembers.Location = new System.Drawing.Point(0, 0);
			this.grdMembers.Name = "grdMembers";
			this.grdMembers.ReadOnly = true;
			this.grdMembers.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.grdMembers.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
			this.grdMembers.RowHeadersVisible = false;
			this.grdMembers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.grdMembers.Size = new System.Drawing.Size(800, 509);
			this.grdMembers.TabIndex = 9;
			this.grdMembers.DataSourceChanged += new System.EventHandler(this.grdMembers_DataSourceChanged);
			// 
			// Login
			// 
			this.Login.DataPropertyName = "Login";
			this.Login.HeaderText = "Login";
			this.Login.Name = "Login";
			this.Login.ReadOnly = true;
			// 
			// Jmeno
			// 
			this.Jmeno.DataPropertyName = "Name";
			this.Jmeno.HeaderText = "Jméno";
			this.Jmeno.Name = "Jmeno";
			this.Jmeno.ReadOnly = true;
			// 
			// Surname
			// 
			this.Surname.DataPropertyName = "Surname";
			this.Surname.HeaderText = "Příjmení";
			this.Surname.Name = "Surname";
			this.Surname.ReadOnly = true;
			// 
			// Email
			// 
			this.Email.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.Email.DataPropertyName = "Email";
			this.Email.HeaderText = "E-mail";
			this.Email.Name = "Email";
			this.Email.ReadOnly = true;
			// 
			// MemberTypeText
			// 
			this.MemberTypeText.DataPropertyName = "MemberTypeText";
			this.MemberTypeText.HeaderText = "Typ";
			this.MemberTypeText.Name = "MemberTypeText";
			this.MemberTypeText.ReadOnly = true;
			// 
			// Active
			// 
			this.Active.DataPropertyName = "Active";
			this.Active.HeaderText = "Aktivní";
			this.Active.Name = "Active";
			this.Active.ReadOnly = true;
			this.Active.Width = 50;
			// 
			// MemberList
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 541);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "MemberList";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Seznam uživatelů";
			this.Load += new System.EventHandler(this.MemberList_Load);
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.grdMembers)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Button btnDelete;
		private System.Windows.Forms.Button btnEdit;
		private System.Windows.Forms.Button btnInsert;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.ToolTip tipMember;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.DataGridView grdMembers;
		private System.Windows.Forms.DataGridViewTextBoxColumn Login;
		private System.Windows.Forms.DataGridViewTextBoxColumn Jmeno;
		private System.Windows.Forms.DataGridViewTextBoxColumn Surname;
		private System.Windows.Forms.DataGridViewTextBoxColumn Email;
		private System.Windows.Forms.DataGridViewTextBoxColumn MemberTypeText;
		private System.Windows.Forms.DataGridViewCheckBoxColumn Active;
	}
}