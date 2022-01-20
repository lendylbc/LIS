using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lis.Monitoring.Abstractions.Services;
using Lis.Monitoring.Domain.Entities;
using Lis.Monitoring.Services.Abstractions;
using Lis.Monitoring.Shared.Enums;
using Lis.Monitoring.Snmp;
using Microsoft.Extensions.Logging;

namespace Lis.Monitoring.Services.Aspects {
	public class SnmpService: ISnmpService {		
		private IDeviceService _deviceService;
		private IDeviceParameterDataService _deviceParameterDataService;
		private INotificationService _notificationService;
		private IConditionService _conditionService;

		public SnmpService(IDeviceService deviceService, IDeviceParameterDataService deviceParameterDataService, IConditionService conditionService, INotificationService notificationService) {
			_deviceService = deviceService;
			_deviceParameterDataService = deviceParameterDataService;
			_notificationService = notificationService;
			_conditionService = conditionService;			
		}

		public void GetDevicesData() {			
			SnmpController snmpController = new SnmpController();
			List<Device> devices = _deviceService.GetAllDevicesWithParams((int)DeviceType.Snmp).ToList();

			foreach(Device device in devices) {
				List<string> paramOids = device.DeviceParameter.Select(x => x.Address).ToList();
				Dictionary<string, object> deviceData = snmpController.RequestData(device.IpAddress, 161, "public", paramOids);//device.Port, device.Community

				if(deviceData != null) {
					foreach(KeyValuePair<string, object> data in deviceData) {
						DeviceParameter parameter = device.DeviceParameter.Where(x => x.Address == data.Key).FirstOrDefault();
						if(parameter != null) {
							Type typ = data.Value.GetType();
							Decimal value = 0;
							if(typ.Name.Equals("Integer32")) {
								value = (decimal)Convert.ToInt32(data.Value.ToString()) / 10;
							}

							_deviceParameterDataService.Save(new DeviceParameterData() { DeviceParameterId = parameter.Id, Inserted = DateTime.Now, Value = value });							
						}
					}
				}
				_conditionService.ResolveConditions();
			}
			if(_conditionService.DeviceErrors?.Count > 0) {
				_notificationService.ZpracujUdalost((int)UdalostTyp.ValueCondition, null, null, false);
			}		
		}
	}
}
