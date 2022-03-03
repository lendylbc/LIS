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
	public partial class DeviceEdit : BaseEdit {
		private ApiController _apiController;
		private DeviceDto _device;
		public DeviceEdit(DeviceDto device, ApiController apiController) : base(device) {
			_apiController = apiController;
			_device = device;
			InitializeComponent();
		}

		private void edit_TextChanged(object sender, EventArgs e) {
			ComponentModified();
		}

		protected override bool LoadData() {
			cmbDeviceType.DataSource = (DeviceType[])Enum.GetValues(typeof(DeviceType));
			cmbDeviceType.SelectedIndex = -1;
			if(_device != null) {
				edtDescription.Text = _device.Description;
				edtIpAddress.Text = _device.IpAddress;
				edtPort.Text = _device.Port.ToString();
				cmbDeviceType.SelectedIndex = _device.DeviceType - 1;
				edtModbusAddress.Text = _device.ModbusDeviceAddress;
				chkActive.Checked = _device.Active;

				edtDescription.Focus();

				return true;
			} else {
				_device = new DeviceDto();
				_device.Inserted = DateTime.Now;
				return true;
			}
		}

		protected override bool SaveData() {
			try {
				_device.Description = edtDescription.Text;
				_device.IpAddress = edtIpAddress.Text;

				if(string.IsNullOrEmpty(edtPort.Text)) {
					_device.Port = null;
				} else {
					try {
						_device.Port = Convert.ToInt32(edtPort.Text);
					} catch {
						_device.Port = null;
					}
				}

				DeviceType deviceType = (DeviceType)cmbDeviceType.SelectedItem;

				_device.DeviceType = (int)deviceType;

				if(deviceType == DeviceType.Modbus) {
					_device.ModbusDeviceAddress = edtModbusAddress.Text;
				} else {
					_device.ModbusDeviceAddress = null;
				}

				_device.Active = chkActive.Checked;

				if(_device.Id == null) {
					return _apiController.SaveDevice(_device) != null;
				} else {
					return _apiController.UpdateDevice(_device);
				}

			} catch(Exception ex) {
				//if(log.IsErrorEnabled) log.Error(ex.Message);
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
		}

		protected override bool ValidateData() {
			_errors.Clear();
			IPAddress ipAddress;

			if(string.IsNullOrEmpty(edtDescription.Text)) {
				_errors.Add("Zadejte popis!");
			}

			if(string.IsNullOrEmpty(edtIpAddress.Text) || !IPAddress.TryParse(edtIpAddress.Text.Replace(',', '.'), out ipAddress)) {
				_errors.Add("Zadejte IP adresu zařízení!");
			}

			if(string.IsNullOrEmpty(edtPort.Text)) {
				_errors.Add("Zadejte port zařízení!");
			}

			if(cmbDeviceType.SelectedIndex < 0) {
				_errors.Add("Zvolte typ zařízení!");
			}

			DeviceType deviceType = (DeviceType)cmbDeviceType.SelectedItem;
			if(deviceType == DeviceType.Modbus && string.IsNullOrEmpty(edtModbusAddress.Text)) {
				_errors.Add("Zadejte adresu MODBUS zařízení!");
			}

			if(_errors.Count > 0) {
				MessageBox.Show(string.Join(Environment.NewLine, _errors), Lis.Monitoring.Manager.Properties.Resources.Warning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
			return _errors.Count == 0;
		}

		private void cmbDeviceType_SelectedIndexChanged(object sender, EventArgs e) {
			if(cmbDeviceType.SelectedItem != null) {
				DeviceType deviceType = (DeviceType)cmbDeviceType.SelectedItem;
				labModbusAddress.Visible = deviceType == DeviceType.Modbus;
				edtModbusAddress.Visible = deviceType == DeviceType.Modbus;
				if(!edtModbusAddress.Visible) {
					edtModbusAddress.Text = string.Empty;
				}

				edit_TextChanged(sender, e);
			}
		}
	}
}
