using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lis.Monitoring.Abstractions.Services;
using Lis.Monitoring.Domain.Entities;
using Lis.Monitoring.Services.Abstractions;
using Lis.Monitoring.Shared.Enums;
using Lis.Monitoring.Shared.Errors;
using Serilog;
using SnmpSharpNet;

namespace Lis.Monitoring.Services.Aspects {
	public class ConditionService : IConditionService {
		private static readonly ILogger log = Serilog.Log.ForContext<ConditionService>();

		private const int _RETRY_NOTIFICATION_AFTER_MINUTES = -30;

		List<ErrorParameterInfo> _deviceErrors;
		bool _errorsExists = false;

		public List<ErrorParameterInfo> NotifyDeviceErrors { get => _deviceErrors; }

		public bool ErrorsExists { get => _errorsExists; }

		public ConditionService() {
			_deviceErrors = new List<ErrorParameterInfo>();
		}

		public void ResolveConditions(ICollection<DeviceParameter> deviceParameters, Dictionary<string, object> deviceData) {
			bool errorConditionExists;
			//	TODO:	If no data for 
			IEnumerable<DeviceParameter> noParamData = deviceParameters.Where(x => deviceData == null || !deviceData.Keys.Contains(x.Address));

			foreach(DeviceParameter param in noParamData) {
				AddError(param);
			}

			if(deviceData != null) {
				IEnumerable<DeviceParameter> paramData = deviceParameters.Where(x => deviceData.Keys.Contains(x.Address));

				foreach(DeviceParameter param in paramData) {
					if(param.ValueType == (int)Shared.Enums.ValueType.Numeric) {
						decimal? value = null;
						if(deviceData.TryGetValue(param.Address, out object valueData)) {
							try {
								Type typ = valueData.GetType();

								if(typ.Name.Equals("Integer32")) {
									value = (decimal)Convert.ToInt32(valueData.ToString());
								}
								if(typ.Name.Equals("Int32")) {
									value = (decimal)Convert.ToInt32(valueData);
								}
								if(param.Multiplier != null) {
									value *= (decimal)param.Multiplier;
								}
								errorConditionExists = false;
								foreach(DeviceParameterCondition condition in param.DeviceParameterCondition) {

									if(!ConditionOk(condition, value)) {
										errorConditionExists = true;
										break;
									}
									log.Debug($"Device: {param.Device.Description} Cond val: {condition.Value} Value: {value} Result: {errorConditionExists}");
								}
								if(errorConditionExists) {
									AddError(param, true, value.ToString());
								} else {
									ClearErrorInfo(param);
								}
							} catch {
								AddError(param);
							}
						} else {
							AddError(param);
						}
					} else {
						string value = string.Empty;
						if(deviceData.TryGetValue(param.Address, out object valueData)) {
							try {
								Type typ = valueData.GetType();

								OctetString ostr = (OctetString)valueData;
								value = ostr.ToString();
								//if(typ.Name.Equals("Integer32")) {
								//	value = (decimal)Convert.ToInt32(valueData.ToString());
								//}

								errorConditionExists = false;
								foreach(DeviceParameterCondition condition in param.DeviceParameterCondition) {

									if(!ConditionOk(condition, value)) {
										errorConditionExists = true;
										break;
									}
								}
								if(errorConditionExists) {
									AddError(param, true, value.ToString());
								} else {
									ClearErrorInfo(param);
								}
							} catch {
								AddError(param);
							}
						} else {
							AddError(param);
						}
					}
				}
			}
		}

		private void AddError(DeviceParameter param, bool condition = false, string value = null) {
			_errorsExists = true;
			if(param.ErrorDetected == null || param.Notified == null || param.Notified < DateTime.Now.AddMinutes(_RETRY_NOTIFICATION_AFTER_MINUTES)) {
				_deviceErrors.Add(new ErrorParameterInfo() {
					Id = param.Id,
					Description = $"{param.Device?.Description} - {param.Description}",
					Address = param.Address,
					Unit = param.Unit,
					Value = value,
					ErrorType = condition ? "Condition" : "No data",
					Timestamp = DateTime.Now
				});
				param.ErrorDetected = DateTime.Now;
				param.Notified = DateTime.Now;
				param.ErrorInfoChange = true;
			}
		}
		private void ClearErrorInfo(DeviceParameter param) {
			if(param.ErrorDetected != null || param.Notified != null) {
				param.ErrorDetected = null;
				param.Notified = null;
				param.ErrorInfoChange = true;
			}
		}

		private bool ConditionOk(DeviceParameterCondition condition, decimal? value) {
			bool result = false;
			switch((ConditionNumericType)condition.Operator) {
				case ConditionNumericType.NoValue:
					result = value != null;
					break;
				case ConditionNumericType.Greater:
					result = value <= condition.Value;
					break;
				case ConditionNumericType.Smaller:
					result = value >= condition.Value;
					break;
				case ConditionNumericType.Equal:
					result = value != condition.Value;
					break;
				case ConditionNumericType.NotEqual:
					result = value == condition.Value;
					break;
				default:
					result = false;
					break;
			}

			return result;
		}

		private bool ConditionOk(DeviceParameterCondition condition, string value) {
			bool result = false;
			switch((ConditionTextType)condition.OperatorString) {
				case ConditionTextType.Equal:
					result = value != condition.ValueString;
					break;
				case ConditionTextType.NotEqual:
					result = value == condition.ValueString;
					break;
				default:
					result = false;
					break;
			}

			return result;
		}
	}
}
