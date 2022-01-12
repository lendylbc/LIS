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
			GetDeviceList();
		}

		private void GetDeviceList() {
			PagedResponse<DeviceDto> result = _apiController.GetDevicesData();
			if(result != null) {
				foreach(DeviceDto device in result.Data) {
					AddLogText(device.Description);
				}
				grdDevices.DataSource = result.Data;
			} else {
				//edtLog.Text = result.
				edtLog.Text = _apiController.Request;
				edtLog.Text += Environment.NewLine + "___________________________________" + Environment.NewLine + _apiController.Response;
			}
		}

		private void btnGetData_Click(object sender, EventArgs e) {
			GetActiveDeviceData();
		}

		private void GetActiveDeviceData() {
			PagedResponse<ActiveDeviceLastDataDto> result = _apiController.GetActiveDeviceLastData();
			if(result != null) {
				grdData.DataSource = result.Data;
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
			GetDeviceList();
			GetActiveDeviceData();
			timer.Enabled = true;
		}

		private void DesignDeviceGrid() {
			grdDevices.Columns["Id"].Visible = false;
			grdDevices.Columns["DeviceType"].Visible = false;
			grdDevices.Columns["Inserted"].Visible = false;
		}

		private void DesignDataGrid() {
			grdData.Columns["Id"].Visible = false;
			grdData.Columns["DeviceId"].Visible = false;
			grdData.Columns["ParamId"].Visible = false;
			//grdData.Columns["ParamDesc"].Visible = false;
			grdData.Columns["Value"].Visible = false;
			grdData.Columns["Unit"].Visible = false;
		}

		private void grdDevices_DataSourceChanged(object sender, EventArgs e) {
			DesignDeviceGrid();
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
	}
}
