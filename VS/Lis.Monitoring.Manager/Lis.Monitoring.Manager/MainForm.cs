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
using Lis.Monitoring.Dto;

namespace Lis.Monitoring.Manager {
	public partial class MainForm : Form {

		ApiController _apiController;


		public MainForm() {
			InitializeComponent();
			Init();
		}

		private void Init() {
			_apiController = new ApiController();
		}

		private void btnGetToken_Click(object sender, EventArgs e) {
			
			
			if(_apiController.Authenticate(edtLogin.Text, edtPassword.Text)) {
				edtLog.Text = "logged";
			}

			//edtLog.Text = result.
			//edtLog.Text = requestController.Request;
			//edtLog.Text += Environment.NewLine + "___________________________________" + Environment.NewLine + requestController.Response;
		}
	}
}
