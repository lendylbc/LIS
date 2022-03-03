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
	public partial class DeviceParameterEdit : BaseEdit {
		private ApiController _apiController;
		private DeviceParameterDto _deviceParameter;
		private long _deviceId;
		public DeviceParameterEdit(long deviceId, DeviceParameterDto DeviceParameter, ApiController apiController) : base(DeviceParameter) {
			_deviceId = deviceId;
			_apiController = apiController;
			_deviceParameter = DeviceParameter;
			InitializeComponent();
		}

		private void edit_TextChanged(object sender, EventArgs e) {
			ComponentModified();
		}

		protected override bool LoadData() {

			if(_deviceParameter != null) {
				edtDescription.Text = _deviceParameter.Description;
				edtAddress.Text = _deviceParameter.Address;
				edtUnit.Text = _deviceParameter.Unit;
				edtMultiplier.Text = _deviceParameter.Multiplier.ToString();
				chkActive.Checked = _deviceParameter.Active;

				edtDescription.Focus();

				return true;
			} else {
				_deviceParameter = new DeviceParameterDto();
				_deviceParameter.Inserted = DateTime.Now;
				_deviceParameter.DeviceId = _deviceId;
				return true;
			}
		}

		protected override bool SaveData() {
			try {
				_deviceParameter.Description = edtDescription.Text;
				_deviceParameter.Address = edtAddress.Text;
				_deviceParameter.Unit = edtUnit.Text;

				if(string.IsNullOrEmpty(edtMultiplier.Text)) {
					_deviceParameter.Multiplier = null;
				} else {
					try {
						_deviceParameter.Multiplier = Convert.ToInt32(edtMultiplier.Text);
					} catch {
						_deviceParameter.Multiplier = null;
					}
				}

				_deviceParameter.Active = chkActive.Checked;

				if(_deviceParameter.Id == null) {
					return _apiController.SaveDeviceParameter(_deviceParameter) != null;
				} else {
					return _apiController.UpdateDeviceParameter(_deviceParameter);
				}

			} catch(Exception ex) {
				//if(log.IsErrorEnabled) log.Error(ex.Message);
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
		}

		protected override bool ValidateData() {
			_errors.Clear();

			if(string.IsNullOrEmpty(edtDescription.Text)) {
				_errors.Add("Zadejte popis!");
			}

			if(string.IsNullOrEmpty(edtAddress.Text)) {
				_errors.Add("Zadejte adresu pro čtení hodnoty!");
			}

			//if(string.IsNullOrEmpty(edtAddress.Text)) {
			//	_errors.Add("Zadejte jednotku!");
			//}

			if(_errors.Count > 0) {
				MessageBox.Show(string.Join(Environment.NewLine, _errors), Lis.Monitoring.Manager.Properties.Resources.Warning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
			return _errors.Count == 0;
		}
	}
}
