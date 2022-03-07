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
using Lis.Monitoring.Snmp;
using Microsoft.Extensions.Logging;
using SnmpSharpNet;

namespace Lis.Monitoring.Services.Aspects {
	public class SnmpService : ISnmpService {
		private IDeviceService _deviceService;
		private IDeviceParameterDataService _deviceParameterDataService;
		private IDeviceParameterService _deviceParameterService;
		private IConditionService _conditionService;

		public List<ErrorParameterInfo> NotifyErrors { get => _conditionService.NotifyDeviceErrors; }
		public bool ErrorsExists { get => _conditionService.ErrorsExists; }

		public SnmpService(IDeviceService deviceService, IDeviceParameterDataService deviceParameterDataService, IDeviceParameterService deviceParameterService, IConditionService conditionService) {
			_deviceService = deviceService;
			_deviceParameterDataService = deviceParameterDataService;
			_deviceParameterService = deviceParameterService;
			_conditionService = conditionService;
		}

		public void GetDevicesData() {
			SnmpController snmpController = new SnmpController();
			List<Device> devices = _deviceService.GetAllDevicesWithParams((int)DeviceType.Snmp).ToList();

			foreach(Device device in devices) {
				decimal? valueNumeric = null;
				string valueString = null;
				List<string> paramOids = device.DeviceParameter.Select(x => x.Address).ToList();
				if(paramOids.Count > 0) {
					Dictionary<string, object> deviceData = snmpController.RequestData(device.IpAddress, (int)device.Port, "public", paramOids);//device.Port, device.Community

					if(deviceData != null) {
						foreach(KeyValuePair<string, object> data in deviceData) {
							DeviceParameter parameter = device.DeviceParameter.Where(x => x.Address == data.Key).FirstOrDefault();
							if(parameter != null) {
								Type typ = data.Value.GetType();
								//decimal value = 0;
								//if(typ.Name.Equals("Integer32")) {
								if(parameter.ValueType == (int)Shared.Enums.ValueType.Numeric) {
									valueNumeric = (decimal)Convert.ToInt32(data.Value.ToString());
									if(parameter.Multiplier != null) {
										valueNumeric *= (decimal)parameter.Multiplier;
									}
									valueString = string.Empty;
								} else {
									OctetString ostr = (OctetString)data.Value;
									valueString = ostr.ToString();
									valueNumeric = null;
								}

								_deviceParameterDataService.Save(new DeviceParameterData() { DeviceParameterId = parameter.Id, Inserted = DateTime.Now, Value = valueNumeric, ValueString = valueString });
							}
						}
					}
					_conditionService.ResolveConditions(device.DeviceParameter, deviceData);
					foreach(DeviceParameter parameter in device.DeviceParameter) {
						if(parameter.ErrorInfoChange) {
							try {
								_deviceParameterService.UpdateErrorInfoAsync(parameter);
							} catch {
								//	log
							}
						}
					}
				}
			}
		}
	}
}
