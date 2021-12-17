using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lis.Monitoring.Domain.Entities;
using Lis.Monitoring.Services.Abstractions;
using Lis.Monitoring.Snmp;

namespace Lis.Monitoring.Services.Aspects {
	public class SnmpService: ISnmpService {
		IDeviceService _deviceService;
		IDeviceParameterDataService _deviceParameterDataService;

		public SnmpService(IDeviceService deviceService, IDeviceParameterDataService deviceParameterDataService) {
			_deviceService = deviceService;
			_deviceParameterDataService = deviceParameterDataService;
		}

		public void GetDevicesData() {			
			SnmpController snmpController = new SnmpController();
			List<Device> devices = _deviceService.GetAllDevicesWithParams().ToList();

			foreach(Device device in devices) {
				List<string> paramOids = device.DeviceParameter.Select(x => x.Oid).ToList();
				Dictionary<string, object> deviceData = snmpController.SnmpRequest(device.IpAddress, 161, "public", paramOids);//device.Port, device.Community

				foreach(KeyValuePair<string, object> data in deviceData) {
					DeviceParameter parameter = device.DeviceParameter.Where(x => x.Oid == data.Key).FirstOrDefault();
					if(parameter != null) {
						Type typ = data.Value.GetType();
						Decimal value = 0;
						if(typ.Name.Equals("Integer32")){
							value = (decimal)Convert.ToInt32(data.Value.ToString()) / 10;
						}

						_deviceParameterDataService.Save(new DeviceParameterData() { DeviceParameterId = parameter.Id, Inserted = DateTime.Now, Value = value });					
					}
				}
			}
		}
	}
}
