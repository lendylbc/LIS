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
using Lis.Monitoring.Dto.Communication;
using Lis.Monitoring.Dto.Core;
using Lis.Monitoring.Manager.Forms;

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

		#region Events
		private void btnGetToken_Click(object sender, EventArgs e) {
			Authenticate();
		}

		private void Authenticate() {
			if(_apiController.Authenticate(edtLogin.Text, edtPassword.Text)) {
				AddLogText("Logged");
			}
		}

		private void btnGetDevices_Click(object sender, EventArgs e) {
			
		}

		

		private void btnGetData_Click(object sender, EventArgs e) {
			GetActiveDeviceData();
		}

		private void GetActiveDeviceData() {
			PagedResponse<ActiveDeviceLastDataDto> result = _apiController.GetActiveDeviceLastData();
			if(result != null) {
				var data = result.Data.OrderByDescending(x => x.Inserted).ToList();
				grdData.DataSource = data;
			} else {
				//edtLog.Text = result.
				edtLog.Text = _apiController.Request;
				edtLog.Text += Environment.NewLine + "___________________________________" + Environment.NewLine + _apiController.Response;
			}
		}
		#endregion

		private void AddLogText(string text) {
			edtLog.Text += Environment.NewLine + text;
		}		

		private void MainForm_Load(object sender, EventArgs e) {
			Authenticate();
			
			GetActiveDeviceData();
			timer.Enabled = true;
		}
	
		private void DesignDataGrid() {
			try {
				grdData.Columns["Id"].Visible = false;
				grdData.Columns["DeviceId"].Visible = false;
				grdData.Columns["ParamId"].Visible = false;
				//grdData.Columns["ParamDesc"].Visible = false;
				grdData.Columns["Value"].Visible = false;
				grdData.Columns["Unit"].Visible = false;
			} catch { }
		}

		private void grdData_DataSourceChanged(object sender, EventArgs e) {
			DesignDataGrid();
		}

		private void timer_Tick(object sender, EventArgs e) {
			timer.Enabled = false;
			try {
				GetActiveDeviceData();
				AddLogText(DateTime.Now.ToString());
			} finally {
				timer.Enabled = true;
			}
		}

		private void btnDevices_Click(object sender, EventArgs e) {
			using(DeviceList form = new DeviceList(_apiController)) {
				if(form.ShowDialog() == DialogResult.OK) {
					
				}
			}
		}
	}
}
