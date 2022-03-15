using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
using Lis.Monitoring.Shared.Enums;

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
			labLoggedUser.Text = $"{_apiController.Member.Name} {_apiController.Member.Surname}";// _member.Login;
			grdData.AutoGenerateColumns = false;
		}

		#region Events

		private void GetActiveDeviceData() {
			grdData.ClearSelection();
			PagedResponse<ActiveDeviceLastDataDto> result = _apiController.GetActiveDeviceLastData();
			if(result != null) {
				var data = result.Data.OrderBy(x => x.DeviceDesc).ToList();
				grdData.DataSource = data;
			} else {
				List<ActiveDeviceLastDataDto> data = new List<ActiveDeviceLastDataDto>();
				grdData.DataSource = data;
				////edtLog.Text = result.
				//edtLog.Text = _apiController.Request;
				//edtLog.Text += Environment.NewLine + "___________________________________" + Environment.NewLine + _apiController.Response;
			}
		}
		#endregion

		private void AddLogText(string text) {
			//edtLog.Text += Environment.NewLine + text;
		}

		private void MainForm_Load(object sender, EventArgs e) {
			UseRights();			
			GetActiveDeviceData();
			timer.Enabled = true;
		}

		private void UseRights() {
			btnDevices.Enabled = _apiController.Member?.MemberType == (int)MemberType.Admin;
			btnUsers.Enabled = _apiController.Member?.MemberType == (int)MemberType.Admin;
		}

		private void DesignDataGrid() {
			try {
				//grdData.Columns["Id"].Visible = false;
				//grdData.Columns["DeviceId"].Visible = false;
				//grdData.Columns["ParamId"].Visible = false;
				////grdData.Columns["ParamDesc"].Visible = false;
				//grdData.Columns["Value"].Visible = false;
				//grdData.Columns["Unit"].Visible = false;
				//grdData.Columns["ErrorDetected"].Visible = false;
				//grdData.Columns["Notified"].Visible = false;
				grdData.EnableHeadersVisualStyles = false;
				grdData.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;			
			} catch { }
		}

		private void grdData_DataSourceChanged(object sender, EventArgs e) {
			DesignDataGrid();
		}

		private void timer_Tick(object sender, EventArgs e) {
			timer.Enabled = false;
			try {
				labStatusInfo.Text = "Aktualizace";
				GetActiveDeviceData();
				AddLogText(DateTime.Now.ToString());

				//JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

				//TokenValidationParameters tokenValidationParameters = new TokenValidationParameters() {
				//	ValidateIssuerSigningKey = true,
				//	IssuerSigningKey = symmetricSecurityKey
				//};

				//tokenHandler.ValidateToken(_apiController.JwtToken, tokenValidationParameters, out SecurityToken validatedToken);

				//AddLogText(validatedToken.ValidTo.ToString());
			} finally {
				timer.Enabled = true;
				labStatusInfo.Text = string.Empty;
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

		private void grdData_Click(object sender, EventArgs e) {
			//DrawChartForParameter();
		}

		private void DrawChartForParameter() {
			ActiveDeviceLastDataDto data = (ActiveDeviceLastDataDto)grdData.CurrentRow.DataBoundItem;

			if(data.ValueType != (int)Shared.Enums.ValueType.Numeric) {
				MessageBox.Show("Měřený parametr neobsahuje číselné hodnoty.", Properties.Resources.Informace, MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}

			DeviceParameterDataQuery query = new DeviceParameterDataQuery();

			query.DeviceParameterId = data.ParamId;
			query.DateTimeFrom = DateTime.Now.AddHours(-24);
			query.DateTimeTo = DateTime.Now;

			PagedResponse<DeviceParameterDataDto> result = _apiController.GetFilteredDeviceData(query);
			if(result != null) {

				ChartForm frm = new ChartForm(result.Data);
				frm.Show();
				//var data = result.Data.OrderByDescending(x => x.Inserted).ToList();
				//grdData.DataSource = data;

			}
		}

		private void grdData_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e) {
			if(grdData.DataSource != null && ((ICollection<ActiveDeviceLastDataDto>)grdData.DataSource).Count > 0) {
				ActiveDeviceLastDataDto activeDevice = grdData.Rows[e.RowIndex].DataBoundItem as ActiveDeviceLastDataDto;
				if(activeDevice.ErrorDetected != null || activeDevice.Notified != null) {
					grdData.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red;
				}
			}
		}

		private void grdData_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e) {
			//if(grdData.DataSource != null && ((ICollection<ActiveDeviceLastDataDto>)grdData.DataSource).Count > 0) {
			//	ActiveDeviceLastDataDto activeDevice = grdData.Rows[e.RowIndex].DataBoundItem as ActiveDeviceLastDataDto;
			//	if(activeDevice.ErrorDetected != null || activeDevice.Notified != null) {
			//		grdData.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red;
			//	}
			//}
		}

		private void btnCsvExport_Click(object sender, EventArgs e) {
			if(grdData.Rows.Count > 0) {
				SaveFileDialog sfd = new SaveFileDialog();
				sfd.Filter = "CSV (*.csv)|*.csv";
				sfd.FileName = "Data.csv";
				bool fileError = false;
				if(sfd.ShowDialog() == DialogResult.OK) {
					if(File.Exists(sfd.FileName)) {
						try {
							File.Delete(sfd.FileName);
						} catch(IOException ex) {
							fileError = true;
							MessageBox.Show("Nelze zapsat data do souboru.");
						}
					}
					if(!fileError) {
						try {
							int columnCount = grdData.Columns.Count;
							string columnNames = "";
							string[] outputCsv = new string[grdData.Rows.Count + 1];
							for(int i = 0; i < columnCount; i++) {
								columnNames += grdData.Columns[i].HeaderText.ToString() + ",";
							}
							outputCsv[0] += columnNames;

							for(int i = 1; (i - 1) < grdData.Rows.Count; i++) {
								for(int j = 0; j < columnCount; j++) {
									outputCsv[i] += grdData.Rows[i - 1].Cells[j].Value.ToString() + ",";
								}
							}

							File.WriteAllLines(sfd.FileName, outputCsv, Encoding.UTF8);
							MessageBox.Show("Data úspěšně exportována.", "Info");
						} catch(Exception ex) {
							MessageBox.Show("Chyba exportu dat.");
						}
					}
				}
			} else {
				MessageBox.Show("Žádná data pro export.", "Info");
			}
		}

		private void grdData_SelectionChanged(object sender, EventArgs e) {
			grdData.ClearSelection();
		}

		private void grdData_DoubleClick(object sender, EventArgs e) {
			DrawChartForParameter();
		}
	}
}
