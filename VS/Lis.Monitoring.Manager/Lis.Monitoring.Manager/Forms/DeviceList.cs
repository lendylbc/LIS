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
using Lis.Monitoring.Dto.Core;
using Lis.Monitoring.Manager.Edits;
using Lis.Monitoring.Shared.Enums;

namespace Lis.Monitoring.Manager.Forms {
	public partial class DeviceList : Form {
		private ApiController _apiController;
		public DeviceList(ApiController apiController) {
			_apiController = apiController;
			InitializeComponent();			
		}

		private void DesignDeviceGrid() {
			grdDevices.Columns["Id"].Visible = false;
			grdDevices.Columns["DeviceType"].Visible = false;
			grdDevices.Columns["Inserted"].Visible = false;
			grdDevices.Columns["ModbusDeviceAddress"].Visible = false;
		}

		private void DesignParamGrid() {
			grdParams.Columns["Id"].Visible = false;
			grdParams.Columns["DeviceId"].Visible = false;
			grdParams.Columns["Inserted"].Visible = false;
		}

		private void DesignConditionGrid() {
			grdConditions.Columns["Id"].Visible = false;
			grdConditions.Columns["DeviceParameterId"].Visible = false;
			grdConditions.Columns["Inserted"].Visible = false;
		}

		private void RefreshDeviceGrid() {
			GetDeviceList();
		}

		private void RefreshParamGrid() {
			DeviceDto device = (DeviceDto)grdDevices.CurrentRow.DataBoundItem;
			GetParamList((long)device?.Id);
		}

		private void RefreshConditionGrid() {
			DeviceParameterDto deviceParam = (DeviceParameterDto)grdParams.CurrentRow.DataBoundItem;
			GetConditionList((long)deviceParam?.Id);
		}

		private void GetDeviceList() {
			PagedResponse<DeviceDto> result = _apiController.GetDeviceList();
			if(result != null) {				
				grdDevices.DataSource = result.Data;
			} else {
				grdDevices.DataSource = null;
			}
		}

		private void GetParamList(long id) {
			PagedResponse<DeviceParameterDto> result = _apiController.GetFilteredParameterList(id);
			if(result != null) {
				grdParams.DataSource = result.Data;
			} else {
				grdParams.DataSource = null;
			}
		}

		private void GetConditionList(long id) {
			PagedResponse<DeviceParameterConditionDto> result = _apiController.GetFilteredConditionList(id);
			if(result != null) {
				grdConditions.DataSource = result.Data;
			} else {
				grdConditions.DataSource = null;
			}
		}
		private void grdDevices_DataSourceChanged(object sender, EventArgs e) {
			DesignDeviceGrid();			
		}

		private void DeviceList_Load(object sender, EventArgs e) {
			RefreshDeviceGrid();
		}			

		private void EditDevice(DeviceDto deviceDto) {
			using(DeviceEdit edt = new DeviceEdit(deviceDto, _apiController)) {
				if(edt.ShowDialog() == DialogResult.OK) {
					if(deviceDto != null) {
						RefreshDeviceGrid();
					} else {
						RefreshDeviceGrid();
					}
				}
			}
		}

		private void EditParam(long idDevice, DeviceParameterDto deviceParameterDto) {
			using(DeviceParameterEdit edt = new DeviceParameterEdit(idDevice, deviceParameterDto, _apiController)) {
				if(edt.ShowDialog() == DialogResult.OK) {
					if(deviceParameterDto != null) {
						RefreshParamGrid();
					} else {
						RefreshParamGrid();
					}
				}
			}
		}

		private void EditCondition(long idParameter, DeviceParameterConditionDto deviceParameterConditionDto) {
			using(ParamConditionEdit edt = new ParamConditionEdit(idParameter, deviceParameterConditionDto, _apiController)) {
				if(edt.ShowDialog() == DialogResult.OK) {
					if(deviceParameterConditionDto != null) {
						RefreshConditionGrid();
					} else {
						RefreshConditionGrid();
					}
				}
			}
		}

		private void btnInsert_Click(object sender, EventArgs e) {
			EditDevice(null);
		}

		private void btnEdit_Click(object sender, EventArgs e) {
			EditDevice((DeviceDto)grdDevices.CurrentRow.DataBoundItem);
		}

		private void btnDelete_Click(object sender, EventArgs e) {
			if(grdDevices.SelectedCells.Count > 0) {
				if(MessageBox.Show("Přejete si smazat zařízení?", Lis.Monitoring.Manager.Properties.Resources.Dotaz, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
					DeviceDto deviceDto = (DeviceDto)grdDevices.CurrentRow.DataBoundItem;
					try {
						if(!_apiController.DeleteDevice((long)deviceDto.Id)) {
							MessageBox.Show("Zařízení nelze smazat, pravděpodobně má podřízené záznamy.", Properties.Resources.Warning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
						}
						RefreshDeviceGrid();
					} catch {
						MessageBox.Show("Zařízení nelze smazat." + Environment.NewLine +
							"Pravděpodobně má podřízené záznamy.", Lis.Monitoring.Manager.Properties.Resources.Chyba, MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
			}
		}

		private void btnParamInsert_Click(object sender, EventArgs e) {
			DeviceDto deviceDto = (DeviceDto)grdDevices.CurrentRow.DataBoundItem;
			EditParam((long)deviceDto.Id, null);
		}

		private void btnParamEdit_Click(object sender, EventArgs e) {
			DeviceDto deviceDto = (DeviceDto)grdDevices.CurrentRow.DataBoundItem;
			EditParam((long)deviceDto.Id, (DeviceParameterDto)grdParams.CurrentRow.DataBoundItem);
		}

		private void btnParamDelete_Click(object sender, EventArgs e) {
			if(grdParams.SelectedCells.Count > 0) {
				if(MessageBox.Show("Přejete si smazat parametr?", Lis.Monitoring.Manager.Properties.Resources.Dotaz, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
					DeviceParameterDto deviceParam = (DeviceParameterDto)grdParams.CurrentRow.DataBoundItem;
					try {
						if(!_apiController.DeleteParameter((long)deviceParam.Id)) {
							MessageBox.Show("Parametr nelze smazat, pravděpodobně má podřízené záznamy.", Properties.Resources.Warning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
						}
						RefreshParamGrid();
					} catch {
						MessageBox.Show("Parametr nelze smazat." + Environment.NewLine +
							"Pravděpodobně má podřízené záznamy.", Lis.Monitoring.Manager.Properties.Resources.Chyba, MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
			}
		}

		private void btnConditionInsert_Click(object sender, EventArgs e) {
			DeviceParameterDto deviceParam = (DeviceParameterDto)grdParams.CurrentRow.DataBoundItem;
			EditCondition((long)deviceParam.Id, null);
		}

		private void btnConditionEdit_Click(object sender, EventArgs e) {
			DeviceParameterDto deviceParam = (DeviceParameterDto)grdParams.CurrentRow.DataBoundItem;
			EditCondition((long)deviceParam.Id, (DeviceParameterConditionDto)grdConditions.CurrentRow.DataBoundItem);
		}

		private void btnConditionDelete_Click(object sender, EventArgs e) {
			if(grdConditions.SelectedCells.Count > 0) {
				if(MessageBox.Show("Přejete si smazat podmínku?", Lis.Monitoring.Manager.Properties.Resources.Dotaz, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
					DeviceParameterConditionDto deviceCondition = (DeviceParameterConditionDto)grdConditions.CurrentRow.DataBoundItem;
					try {
						if(!_apiController.DeleteCondition((long)deviceCondition.Id)) {
							MessageBox.Show("Podmínku se nepodařilo smazat.", Properties.Resources.Warning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
						}
						RefreshConditionGrid();
					} catch {
						MessageBox.Show("Podmínku nelze smazat.", Lis.Monitoring.Manager.Properties.Resources.Chyba, MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
			}
		}

		private void btnClose_Click(object sender, EventArgs e) {
			Close();
		}

		private void grdParams_DataSourceChanged(object sender, EventArgs e) {
			DesignParamGrid();			
		}

		private void grdConditions_DataSourceChanged(object sender, EventArgs e) {
			DesignConditionGrid();
		}

		private void grdDevices_SelectionChanged(object sender, EventArgs e) {
			RefreshParamGrid();
		}

		private void grdParams_SelectionChanged(object sender, EventArgs e) {
			RefreshConditionGrid();
		}

		private void grdDevices_DoubleClick(object sender, EventArgs e) {
			btnEdit_Click(sender, e);
		}

		private void grdParams_DoubleClick(object sender, EventArgs e) {
			btnParamEdit_Click(sender, e);
		}

		private void grdConditions_DoubleClick(object sender, EventArgs e) {
			btnConditionEdit_Click(sender, e);
		}

		private void grdConditions_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e) {
			if(grdConditions.Columns[e.ColumnIndex].Name.Equals("Operator")) {
				e.Value = ((ConditionType)e.Value).ToDescriptionString();				
			}
		}
	}
}
