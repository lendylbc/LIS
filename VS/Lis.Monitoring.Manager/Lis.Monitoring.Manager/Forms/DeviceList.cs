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
		}

		private void RefreshGrid() {
			GetDeviceList();
		}

		private void GetDeviceList() {
			PagedResponse<DeviceDto> result = _apiController.GetDevicesData();
			if(result != null) {				
				grdDevices.DataSource = result.Data;
			} else {
				grdDevices.DataSource = null;
			}
		}

		private void grdDevices_DataSourceChanged(object sender, EventArgs e) {
			DesignDeviceGrid();
		}

		private void DeviceList_Load(object sender, EventArgs e) {
			RefreshGrid();
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
						_apiController.DeleteDevice((long)deviceDto.Id);
						RefreshGrid();
					} catch {
						MessageBox.Show("Zařízení nelze smazat." + Environment.NewLine +
							"Pravděpodobně má podřízené záznamy.", Lis.Monitoring.Manager.Properties.Resources.Chyba, MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
			}
		}

		private void btnClose_Click(object sender, EventArgs e) {
			Close();
		}

		private void EditDevice(DeviceDto deviceDto) {
			using(DeviceEdit edt = new DeviceEdit(deviceDto, _apiController)) {
				if(edt.ShowDialog() == DialogResult.OK) {
					if(deviceDto != null) {
						RefreshGrid();
					} else {
						RefreshGrid();
					}
				}
			}
		}
	}
}
