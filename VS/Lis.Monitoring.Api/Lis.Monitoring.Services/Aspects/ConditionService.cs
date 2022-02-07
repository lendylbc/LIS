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

namespace Lis.Monitoring.Services.Aspects {
	public class ConditionService : IConditionService {
		private const int _RETRY_NOTIFICATION_AFTER_MINUTES = -30;

		List<ErrorParameterInfo> _deviceErrors;

		public List<ErrorParameterInfo> DeviceErrors { get => _deviceErrors; }

		public ConditionService() {
			_deviceErrors = new List<ErrorParameterInfo>();
		}

		public void ResolveConditions(ICollection<DeviceParameter> deviceParameters, Dictionary<string, object> deviceData) {
			//	TODO:	If no data for 
			IEnumerable<DeviceParameter> noParamData = deviceParameters.Where(x => deviceData == null || !deviceData.Keys.Contains(x.Address));

			foreach(DeviceParameter param in noParamData) {
				AddError(param);
			}

			if(deviceData != null) {
				IEnumerable<DeviceParameter> paramData = deviceParameters.Where(x => deviceData.Keys.Contains(x.Address));

				foreach(DeviceParameter param in paramData) {
					decimal? value = null;
					if(deviceData.TryGetValue(param.Address, out object valueData)) {
						try {
							Type typ = valueData.GetType();

							if(typ.Name.Equals("Integer32")) {
								value = (decimal)Convert.ToInt32(valueData.ToString());
							}
							foreach(DeviceParameterCondition condition in param.DeviceParameterCondition) {
								if(!ConditionOk(condition, value)) {
									AddError(param);
								}
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

		private void AddError(DeviceParameter param) {
			if(param.ErrorDetected == null || param.Notified == null || param.Notified < DateTime.Now.AddMinutes(_RETRY_NOTIFICATION_AFTER_MINUTES)) {
				_deviceErrors.Add(new ErrorParameterInfo() { Description = $"{param.Device?.Description} - {param.Description}", Address = param.Address, Unit = param.Unit, ErrorType = "No data" });
				param.ErrorDetected = DateTime.Now;
				param.Notified = DateTime.Now;
			}
		}

		private bool ConditionOk(DeviceParameterCondition condition, decimal? value) {
			bool result = false;
			switch((ConditionType)condition.Operator) {
				case ConditionType.NoValue:
					result = value != null;
					break;
				case ConditionType.Greater:
					result = value <= condition.Value;
					break;
				case ConditionType.Smaller:
					result = value >= condition.Value;
					break;
				case ConditionType.Equal:
					result = value != condition.Value;
					break;
				case ConditionType.NotEqual:
					result = value == condition.Value;
					break;
				default:
					result = false;
					break;
			}

			return result;
		}
	}
}
