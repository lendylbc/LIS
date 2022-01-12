using System;
using System.Collections.Generic;
using Lis.Monitoring.Abstractions.Controllers;
using SnmpSharpNet;

namespace Lis.Monitoring.Snmp {
	public class SnmpController : ISensorDataController {
		SnmpVersion _snmpVersion = SnmpVersion.Ver1;
		public SnmpController() {

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ip"></param>
		/// <param name="port"></param>
		/// <param name="community"></param>
		/// <param name="addressList">oids</param>
		/// <returns></returns>
		public Dictionary<string, object> RequestData(string ip, int port, string community, List<string> addressList) {
			Dictionary<string, object> result = null;
			try {
				SimpleSnmp snmp = new SimpleSnmp(ip, port, community);

				if(!snmp.Valid) {
					return null;
				}
				Dictionary<Oid, AsnType> sensorData = snmp.Get(_snmpVersion, addressList.ToArray());

				if(sensorData?.Count > 0) {
					result = new Dictionary<string, object>();
					foreach(KeyValuePair<Oid, AsnType> data in sensorData) {
						result.Add(data.Key.ToString(), (object)data.Value);
					}
				}


				return result;
			} catch {
				return null;
			}
		}
	}
}
