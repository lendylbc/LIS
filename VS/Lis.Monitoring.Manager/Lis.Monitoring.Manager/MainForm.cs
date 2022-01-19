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
using Lis.Monitoring.Dto.Queries;
using Lis.Monitoring.Manager.Forms;

namespace Lis.Monitoring.Manager {
	public partial class MainForm : Form {

		private ApiController _apiController;
		private MemberDto _member;

		public MainForm(ApiController apiController, MemberDto member) {
			_apiController = apiController;
			_member = member;
			InitializeComponent();
			Init();
		}

		private void Init() {
			//_apiController = new ApiController();
			labLoggedUser.Text = _member.Login;
		}

		#region Events
		
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

		private void btnUsers_Click(object sender, EventArgs e) {
			using(MemberList form = new MemberList(_apiController)) {
				if(form.ShowDialog() == DialogResult.OK) {

				}
			}
		}

		private void button1_Click(object sender, EventArgs e) {
			ActiveDeviceLastDataDto data = (ActiveDeviceLastDataDto)grdData.CurrentRow.DataBoundItem;

			DeviceParameterDataQuery query = new DeviceParameterDataQuery();

			query.DeviceParameterId = data.ParamId;
			query.DateTimeFrom = DateTime.Now.AddHours(-2);
			query.DateTimeTo = DateTime.Now.AddHours(1);

			PagedResponse<DeviceParameterDataDto> result = _apiController.GetFilteredData(query);
			if(result != null) {

				ChartForm frm = new ChartForm(result.Data);
				frm.Show();
				//var data = result.Data.OrderByDescending(x => x.Inserted).ToList();
				//grdData.DataSource = data;
				edtLog.Text = _apiController.Request;
				edtLog.Text += Environment.NewLine + "___________________________________" + Environment.NewLine + _apiController.Response;
			} else {
				//edtLog.Text = result.
				edtLog.Text = _apiController.Request;
				edtLog.Text += Environment.NewLine + "___________________________________" + Environment.NewLine + _apiController.Response;
			}
		}
	}
}
