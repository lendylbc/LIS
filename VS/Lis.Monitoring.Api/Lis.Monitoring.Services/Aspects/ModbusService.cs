using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lis.Monitoring.Domain.Entities;
using Lis.Monitoring.Modbus;
using Lis.Monitoring.Services.Abstractions;
using Lis.Monitoring.Shared.Enums;

namespace Lis.Monitoring.Services.Aspects {
	public class ModbusService : IModbusService {
		IDeviceService _deviceService;
		IDeviceParameterDataService _deviceParameterDataService;
		IConditionService _conditionService;

		public List<ErrorParameterInfo> Errors { get => _conditionService.DeviceErrors; }
		public ModbusService(IDeviceService deviceService, IDeviceParameterDataService deviceParameterDataService, IConditionService conditionService) {
			_deviceService = deviceService;
			_deviceParameterDataService = deviceParameterDataService;
			_conditionService = conditionService;
		}

		public void GetDevicesData() {
			ModbusController modbusController = new ModbusController();
			List<Device> devices = _deviceService.GetAllDevicesWithParams((int)DeviceType.Modbus).ToList();

			foreach(Device device in devices) {
				List<string> paramOids = device.DeviceParameter.Select(x => x.Address).ToList();
				if(paramOids.Count > 0) {
					Dictionary<string, object> deviceData = modbusController.RequestData(device.IpAddress, (int)device.Port, "public", paramOids);//device.Port, device.Community

					if(deviceData != null) {
						foreach(KeyValuePair<string, object> data in deviceData) {
							DeviceParameter parameter = device.DeviceParameter.Where(x => x.Address == data.Key).FirstOrDefault();
							if(parameter != null) {
								Type typ = data.Value.GetType();
								decimal value = 0;
								if(typ.Name.Equals("Integer32")) {
									value = (decimal)Convert.ToInt32(data.Value.ToString()) / 10;
								}

								_deviceParameterDataService.Save(new DeviceParameterData() { DeviceParameterId = parameter.Id, Inserted = DateTime.Now, Value = value });
							}
						}
					}
					_conditionService.ResolveConditions(device.DeviceParameter, deviceData);
				}
			}
		}
	}
}
