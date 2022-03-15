using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lis.Monitoring.Domain.Entities;
using Lis.Monitoring.Modbus;
using Lis.Monitoring.Services.Abstractions;
using Lis.Monitoring.Shared.Enums;
using Lis.Monitoring.Shared.Errors;

namespace Lis.Monitoring.Services.Aspects {
	public class ModbusService : IModbusService {
		IDeviceService _deviceService;
		IDeviceParameterDataService _deviceParameterDataService;
		private IDeviceParameterService _deviceParameterService;
		IConditionService _conditionService;

		public List<ErrorParameterInfo> NotifyErrors { get => _conditionService.NotifyDeviceErrors; }
		public bool ErrorsExists { get => _conditionService.ErrorsExists; }

		public ModbusService(IDeviceService deviceService, IDeviceParameterDataService deviceParameterDataService, IDeviceParameterService deviceParameterService, IConditionService conditionService) {
			_deviceService = deviceService;
			_deviceParameterDataService = deviceParameterDataService;
			_deviceParameterService = deviceParameterService;
			_conditionService = conditionService;
		}

		public void GetDevicesData() {
			ModbusController modbusController = new ModbusController();
			List<Device> devices = _deviceService.GetAllDevicesWithParams((int)DeviceType.Modbus).ToList();

			foreach(Device device in devices) {
				List<string> paramAddress = device.DeviceParameter.Select(x => x.Address).ToList();
				if(paramAddress.Count > 0) {
					Dictionary<string, object> deviceData = modbusController.RequestData(device.IpAddress, (int)device.Port, "public", paramAddress);//device.Port, device.Community

					if(deviceData != null) {
						foreach(KeyValuePair<string, object> data in deviceData) {
							DeviceParameter parameter = device.DeviceParameter.Where(x => x.Address == data.Key).FirstOrDefault();
							if(parameter != null) {
								Type typ = data.Value.GetType();
								decimal value = 0;
								if(typ.Name.Equals("Int32")) {
									value = (decimal)Convert.ToInt32(data.Value);
								}

								_deviceParameterDataService.Save(new DeviceParameterData() { DeviceParameterId = parameter.Id, Inserted = DateTime.Now, Value = value });
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
