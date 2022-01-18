﻿using System;
using System.Windows.Forms;

namespace VQFramework.Win.Dialogs {

	public partial class BaseDialog : Form {

		protected bool _modified;
		public BaseDialog() {
			InitializeComponent();
		}
		private void btnStorno_Click(object sender, EventArgs e) {
			if(CloseAction()) {
				Close();
			}
		}

		private void btnOk_Click(object sender, EventArgs e) {
			if(OkAction()) {
				Close();
			}
		}

		private void BaseDialog_KeyDown(object sender, KeyEventArgs e) {
			if(e.KeyCode == Keys.Enter) {
				btnOk_Click(null, null);
			}
			if(e.KeyCode == Keys.Escape) {
				btnStorno_Click(null, null);
			}
		}

		protected virtual bool OkAction() {
			return true;
		}

		protected virtual bool CloseAction() {
			return true;
		}

	}
}
