using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lis.Monitoring.Api;
using Lis.Monitoring.Dto.Communication;
using VQFramework.Win.Dialogs;

namespace Lis.Monitoring.Manager.Dialos {
	public partial class LoginDialog : BaseDialog {
		private ApiController _apiController;
		private MemberDto _member;

		public MemberDto Member {get => _member; }

		public LoginDialog(ApiController apiController) {
			InitializeComponent();
			_apiController = apiController;
		}

		protected override bool OkAction() {
			labErrorLogin.Visible = false;
			_member = new MemberDto() { Login = edtLogin.Text, Password = edtPassword.Text };
			bool loginOk = _apiController.Authenticate(edtLogin.Text, edtPassword.Text);
			labErrorLogin.Visible = !loginOk;
			return loginOk;
		}

		private void LoginDialog_Load(object sender, EventArgs e) {
			edtLogin.Focus();
		}
	}
}
