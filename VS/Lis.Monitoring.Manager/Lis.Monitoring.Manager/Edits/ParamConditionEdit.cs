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
		private int _valueType;
		public ParamConditionEdit(long deviceParameterId, DeviceParameterConditionDto ParamCondition, int valueType, ApiController apiController) : base(ParamCondition) {
			_deviceParameterId = deviceParameterId;
			_apiController = apiController;
			_paramCondition = ParamCondition;
			_valueType = valueType;
			InitializeComponent();
			//cmbOperator.FormattingEnabled = true;
			//cmbOperator.Format += delegate (object sender, ListControlConvertEventArgs e) {
			//	e.Value = ((ConditionType)e.Value).ToDescriptionString();
			//};
		}

		private void edit_TextChanged(object sender, EventArgs e) {
			ComponentModified();
		}

		protected override bool LoadData() {
			foreach(ConditionNumericType condition in (ConditionNumericType[])Enum.GetValues(typeof(ConditionNumericType))) {
				cmbOperatorNumeric.Items.Add(condition.ToDescriptionString());
			}

			foreach(ConditionTextType condition in (ConditionTextType[])Enum.GetValues(typeof(ConditionTextType))) {
				cmbOperatorText.Items.Add(condition.ToDescriptionString());
			}

			//cmbOperator.DataSource = (ConditionType[])Enum.GetValues(typeof(ConditionType));
			cmbOperatorNumeric.SelectedIndex = -1;
			cmbOperatorText.SelectedIndex = -1;
			pnlNumericValue.Visible = _valueType == (int)Shared.Enums.ValueType.Numeric;
			pnlTextValue.Visible = _valueType == (int)Shared.Enums.ValueType.String;
			if(_paramCondition != null) {
				if(_valueType == (int)Shared.Enums.ValueType.Numeric) {
					string description = ((ConditionNumericType)_paramCondition.Operator).ToDescriptionString();
					for(int i = 0; i < cmbOperatorNumeric.Items.Count; i++) {
						if((String)cmbOperatorNumeric.Items[i] == description) {
							cmbOperatorNumeric.SelectedIndex = i;
							break;
						}
					}
					edtValueNumeric.Value = (decimal)_paramCondition.Value;
					cmbOperatorNumeric.Focus();
				} else {
					string description = ((ConditionTextType)_paramCondition.OperatorString).ToDescriptionString();
					for(int i = 0; i < cmbOperatorText.Items.Count; i++) {
						if((String)cmbOperatorText.Items[i] == description) {
							cmbOperatorText.SelectedIndex = i;
							break;
						}
					}
					edtValueText.Text = _paramCondition.ValueString;
					cmbOperatorText.Focus();
				}
								
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
				if(_valueType == (int)Shared.Enums.ValueType.Numeric) {
					_paramCondition.Value = edtValueNumeric.Value;

					ConditionNumericType conditionType = EnumExtensions.GetValueFromDescription<ConditionNumericType>((string)cmbOperatorNumeric.SelectedItem);

					_paramCondition.Operator = (int)conditionType;
				} else {
					_paramCondition.ValueString = edtValueText.Text;

					ConditionTextType conditionType = EnumExtensions.GetValueFromDescription<ConditionTextType>((string)cmbOperatorText.SelectedItem);

					_paramCondition.OperatorString = (int)conditionType;
				}

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

			if(_valueType == (int)Shared.Enums.ValueType.Numeric) {
				if(cmbOperatorNumeric.SelectedIndex < 0) {
					_errors.Add("Zvolte typ operátoru!");
				}
			} else {
				if(cmbOperatorText.SelectedIndex < 0) {
					_errors.Add("Zvolte typ operátoru!");
				}
			}
			if(_errors.Count > 0) {
				MessageBox.Show(string.Join(Environment.NewLine, _errors), Lis.Monitoring.Manager.Properties.Resources.Warning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
			return _errors.Count == 0;			
		}
	}
}
