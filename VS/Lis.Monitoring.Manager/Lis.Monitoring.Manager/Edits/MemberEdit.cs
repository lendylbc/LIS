using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lis.Monitoring.Api;
using Lis.Monitoring.Dto.Communication;
using Lis.Monitoring.Dto.Core;
using Lis.Monitoring.Shared.Enums;
using VQFramework.Win.Edit;

namespace Lis.Monitoring.Manager.Edits {
	public partial class MemberEdit : BaseEdit {
		private ApiController _apiController;
		private MemberDto _Member;
		public MemberEdit(MemberDto Member, ApiController apiController) : base(Member) {
			_apiController = apiController;
			_Member = Member;
			InitializeComponent();
		}

		private void edit_TextChanged(object sender, EventArgs e) {
			ComponentModified();
		}

		protected override bool LoadData() {
			cmbMemberType.DataSource = (MemberType[])Enum.GetValues(typeof(MemberType));
			cmbMemberType.SelectedIndex = -1;
			if(_Member != null) {
				edtJmeno.Text = _Member.Name;
				edtSurname.Text = _Member.Surname;
				edtEmail.Text = _Member.Email;
				edtLogin.Text = _Member.Login;
				edtPassword.Text = _Member.Password;
				edtPasswordCheck.Text = _Member.Password;

				cmbMemberType.SelectedIndex = _Member.MemberType - 1;
				chkActive.Checked = _Member.Active;

				edtJmeno.Focus();

				return true;
			} else {
				_Member = new MemberDto();
				//_Member.Inserted = DateTime.Now;
				return true;
			}
		}

		protected override bool SaveData() {
			try {				
				_Member.Name = edtJmeno.Text;
				_Member.Surname = edtSurname.Text;
				_Member.Email = edtEmail.Text;
				_Member.Login = edtLogin.Text;
				_Member.Password = edtPassword.Text;


				MemberType MemberType = (MemberType)cmbMemberType.SelectedItem;

				_Member.MemberType = (int)MemberType;

				_Member.Active = chkActive.Checked;

				if(_Member.Id == null) {
					return _apiController.SaveMember(_Member) != null;
				} else {
					return _apiController.UpdateMember(_Member);
				}

			} catch(Exception ex) {
				//if(log.IsErrorEnabled) log.Error(ex.Message);
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}			
		}

		protected override bool ValidateData() {
			_errors.Clear();

			if(string.IsNullOrEmpty(edtJmeno.Text)) {
				_errors.Add("Zadejte jméno!");
			}

			if(string.IsNullOrEmpty(edtSurname.Text)) {
				_errors.Add("Zadejte příjmení!");
			}

			if(string.IsNullOrEmpty(edtEmail.Text)) {
				_errors.Add("Zadejte e-mail!");
			}

			if(string.IsNullOrEmpty(edtLogin.Text)) {
				_errors.Add("Zadejte login!");
			}

			if(string.IsNullOrEmpty(edtPassword.Text)) {
				_errors.Add("Zadejte heslo!");
			}

			if(string.IsNullOrEmpty(edtPasswordCheck.Text)) {
				_errors.Add("Zadejte heslo pro ověření!");
			}
			if(!string.IsNullOrEmpty(edtPassword.Text) && !string.IsNullOrEmpty(edtPasswordCheck.Text)) {
				if(!edtPassword.Text.Equals(edtPasswordCheck.Text)) {
					_errors.Add("Heslo a heslo pro ověření se neshodují!");
				}
			}

			if(cmbMemberType.SelectedIndex < 0) {
				_errors.Add("Zvolte typ oprávnění uživatele!");
			}
			if(_errors.Count > 0) {
				MessageBox.Show(string.Join(Environment.NewLine, _errors), Lis.Monitoring.Manager.Properties.Resources.Upozornění, MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
			return _errors.Count == 0;			
		}
	}
}
