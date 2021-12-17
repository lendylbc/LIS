using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lis.Monitoring.Domain.Entities;
using Lis.Monitoring.Services.Abstractions;

namespace Lis.Monitoring.Services.Aspects {
	public class SnmpService {
		IDeviceService _deviceService;
		public SnmpService(IDeviceService deviceService) {
			_deviceService = deviceService;
		}

		public void GetDevicesData() {
			List<Device> devices = _deviceService.GetList(null).Result.Where(x => x.Active).ToList();

			foreach(Device device in devices) {

			}
		}
	}
}
