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
	public partial class ParamConditionEdit : BaseEdit {
		private ApiController _apiController;
		private DeviceParameterConditionDto _paramCondition;
		private long _deviceParameterId;
		public ParamConditionEdit(long deviceParameterId, DeviceParameterConditionDto ParamCondition, ApiController apiController) : base(ParamCondition) {
			_deviceParameterId = deviceParameterId;
			_apiController = apiController;
			_paramCondition = ParamCondition;
			InitializeComponent();
		}

		private void edit_TextChanged(object sender, EventArgs e) {
			ComponentModified();
		}

		protected override bool LoadData() {
			cmbOperator.DataSource = (ConditionType[])Enum.GetValues(typeof(ConditionType));
			cmbOperator.SelectedIndex = -1;
			if(_paramCondition != null) {
			
				cmbOperator.SelectedIndex = _paramCondition.Operator;
				edtValue.Value = _paramCondition.Value;

				cmbOperator.Focus();

				return true;
			} else {
				_paramCondition = new DeviceParameterConditionDto();
				_paramCondition.Inserted = DateTime.Now;
				_paramCondition.DeviceParameterId = _deviceParameterId;
				return true;
			}
		}

		protected override bool SaveData() {
			try {				
				_paramCondition.Value = edtValue.Value;				

				ConditionType conditionType = (ConditionType)cmbOperator.SelectedItem;

				_paramCondition.Operator = (int)conditionType;

				if(_paramCondition.Id == null) {
					return _apiController.SaveParamCondition(_paramCondition) != null;
				} else {
					return _apiController.UpdateParamCondition(_paramCondition);
				}

			} catch(Exception ex) {
				//if(log.IsErrorEnabled) log.Error(ex.Message);
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}			
		}

		protected override bool ValidateData() {
			_errors.Clear();

			if(cmbOperator.SelectedIndex < 0) {
				_errors.Add("Zvolte typ operátor!");
			}
			if(_errors.Count > 0) {
				MessageBox.Show(string.Join(Environment.NewLine, _errors), Lis.Monitoring.Manager.Properties.Resources.Upozornění, MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
			return _errors.Count == 0;			
		}
	}
}
