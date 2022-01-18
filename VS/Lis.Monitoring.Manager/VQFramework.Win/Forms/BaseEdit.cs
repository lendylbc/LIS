using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Lis.Monitoring.Dto.Core;

namespace VQFramework.Win.Edit {

	public partial class BaseEdit : Form {

		protected List<string> _errors;
		protected virtual bool Modified {
			get;
			set;
		}
		public BaseDto<long?> Dto { get; set; }

		public BaseEdit() {
			InitializeComponent();
			_errors = new List<string>();
		}
		public BaseEdit(BaseDto<long?> dto) : this() {
			Dto = dto;
			//Init();
		}
		public void Init() {
			LoadData();
			Modified = false;
			btnSave.Enabled = false;
		}

		private void btnSave_Click(object sender, EventArgs e) {
			if(Modified) {
				Save();
			}
		}

		protected virtual void CloseForm() {
			DialogResult = DialogResult.OK;
			if(!Modal) {
				this.Close();
			}
		}


		private bool Save() {
			bool result = ValidateData();
			if(result) {
				result = SaveData();
				if(result) {
					CloseForm();
				}
			}
			return result;
		}

		private void btnStorno_Click(object sender, EventArgs e) {
			Close();
		}

		protected virtual bool LoadData() {
			throw new NotImplementedException();
		}

		protected virtual bool SaveData() {
			throw new NotImplementedException();
		}

		protected virtual bool ValidateData() {
			throw new NotImplementedException();
		}

		private void BaseEdit_FormClosing(object sender, FormClosingEventArgs e) {
			//if (!RunTime(this)) return;

			ClosingForm(e);
		}

		protected virtual void ClosingForm(FormClosingEventArgs e) {
			switch(this.DialogResult) {

				case DialogResult.OK:
					break;
				case DialogResult.Cancel:
					if(Modified) {
						switch(MessageBox.Show("Save changes?", "Question", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3)) {
							case DialogResult.Yes:
								e.Cancel = !Save();
								if(!e.Cancel) {
									this.DialogResult = DialogResult.OK;
								}
								break;
							case DialogResult.No:
								e.Cancel = false;
								break;
							case DialogResult.Cancel:
								e.Cancel = true;
								break;
						}
					}
					break;
			}
		}

		protected void ComponentModified() {
			Modified = true;
			btnSave.Enabled = Modified;
		}

		private void BaseEdit_Load(object sender, EventArgs e) {
			if(System.ComponentModel.LicenseManager.UsageMode != System.ComponentModel.LicenseUsageMode.Designtime) {
				Init();
			}
		}

		private void BaseEdit_KeyDown(object sender, KeyEventArgs e) {
			if(e.KeyCode == Keys.Enter) {
				btnSave_Click(null, null);
			}
			if(e.KeyCode == Keys.Escape) {
				btnStorno_Click(null, null);
			}
		}
	}
}
