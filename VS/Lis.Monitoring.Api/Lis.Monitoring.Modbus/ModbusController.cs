using System;
using System.Collections.Generic;
using Lis.Monitoring.Abstractions.Controllers;

namespace Lis.Monitoring.Modbus {
	public class ModbusController : ISensorDataController {
		public ModbusController() {

		}

		public Dictionary<string, object> RequestData(string ip, int port, string community, List<string> addressList) {
			Dictionary<string, object> result = null;
			try {
			
				//if(sensorData?.Count > 0) {
				//	result = new Dictionary<string, object>();
				//	foreach(KeyValuePair<Oid, AsnType> data in sensorData) {
				//		result.Add(data.Key.ToString(), (object)data.Value);
				//	}
				//}

				return result;
			} catch {
				return null;
			}
		}
	}
}
