using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lis.Monitoring.Abstractions.Services;
using Lis.Monitoring.Domain.Entities;
using Lis.Monitoring.Services.Abstractions;
using Lis.Monitoring.Shared.Enums;

namespace Lis.Monitoring.Services.Aspects {
	public class ConditionService : IConditionService {
		List<ErrorParameterInfo> _deviceErrors;
		
		private INotificationService _notificationService;

		public List<ErrorParameterInfo> DeviceErrors { get => _deviceErrors; }

		public ConditionService(INotificationService notificationService) {
			_notificationService = notificationService;
			_deviceErrors = new List<ErrorParameterInfo>();
		}

		public void ResolveConditions(ICollection<DeviceParameter> deviceParameters, Dictionary<string, object> deviceData) {
			//	TODO:	If no data for 
			IEnumerable<DeviceParameter> noParamData = deviceParameters.Where(x => deviceData == null || !deviceData.Keys.Contains(x.Address));

			foreach(DeviceParameter param in noParamData) {
				_deviceErrors.Add(new ErrorParameterInfo() { Description = $"{param.Device?.Description} - {param.Description}", Address = param.Address, Unit = param.Unit, ErrorType = "No data" });
			}

			if(deviceData != null) {
				IEnumerable<DeviceParameter> paramData = deviceParameters.Where(x => deviceData.Keys.Contains(x.Address));

				foreach(DeviceParameter param in paramData) {
					decimal? value = null;
					if(deviceData.TryGetValue(param.Address, out object valueData)) {
						try {
							Type typ = valueData.GetType();

							if(typ.Name.Equals("Integer32")) {
								value = (decimal)Convert.ToInt32(valueData.ToString()) / 10;
							}
							foreach(DeviceParameterCondition condition in param.DeviceParameterCondition) {
								if(!ConditionOk(condition, value)) {
									_deviceErrors.Add(new ErrorParameterInfo() { Description = $"{param.Device?.Description} - {param.Description}", Address = param.Address, Unit = param.Unit, ErrorType = "Condition" });
								}
							}
						} catch {
							_deviceErrors.Add(new ErrorParameterInfo() { Description = $"{param.Device?.Description} - {param.Description}", Address = param.Address, Unit = param.Unit, ErrorType = "No value" });
						}
					} else {
						_deviceErrors.Add(new ErrorParameterInfo() { Description = $"{param.Device?.Description} - {param.Description}", Address = param.Address, Unit = param.Unit, ErrorType = "No value" });
					}
				}
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

	public class ErrorParameterInfo {
		public string Description { get; set; }
		public string Address { get; set; }
		public string Unit { get; set; }
		public string ErrorType { get; set; }

		public override string ToString() {
			return "Description " + Description + Environment.NewLine +
				"Address " + Address + Environment.NewLine +
				"Unit " + Unit + Environment.NewLine +
				"ErrorType " + ErrorType + Environment.NewLine;
		}
	}
}
