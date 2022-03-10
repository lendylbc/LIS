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

			foreach(Shared.Enums.ValueType condition in (Shared.Enums.ValueType[])Enum.GetValues(typeof(Shared.Enums.ValueType))) {
				cmbValueType.Items.Add(condition.ToDescriptionString());
			}

			cmbValueType.SelectedIndex = -1;

			if(_deviceParameter != null) {
				edtDescription.Text = _deviceParameter.Description;
				edtAddress.Text = _deviceParameter.Address;
				edtUnit.Text = _deviceParameter.Unit;
				if(_deviceParameter.Multiplier != null) {
					edtMultiplier.Value = (decimal)_deviceParameter.Multiplier;
				} else {
					edtMultiplier.Value = 0;
				}
				chkActive.Checked = _deviceParameter.Active;

				string description = ((Shared.Enums.ValueType)_deviceParameter.ValueType).ToDescriptionString();
				for(int i = 0; i < cmbValueType.Items.Count; i++) {
					if((String)cmbValueType.Items[i] == description) {
						cmbValueType.SelectedIndex = i;
						break;
					}
				}

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

				_deviceParameter.Multiplier = edtMultiplier.Value;

				Shared.Enums.ValueType valueType = EnumExtensions.GetValueFromDescription<Shared.Enums.ValueType>((string)cmbValueType.SelectedItem);

				_deviceParameter.ValueType = (int)valueType;

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

			if(cmbValueType.SelectedIndex < 0) {
				_errors.Add("Zvolte typ hodnoty!");
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
