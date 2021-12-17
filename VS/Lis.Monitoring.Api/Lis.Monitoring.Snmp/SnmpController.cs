using System;
using System.Collections.Generic;
using SnmpSharpNet;

namespace Lis.Monitoring.Snmp {
	public class SnmpController {
		SnmpVersion _snmpVersion = SnmpVersion.Ver1;
		public SnmpController() {

		}

		public Dictionary<string, object> SnmpRequest(string ip, int port, string community, List<string> oidList) {
			Dictionary<string, object> result = null;
			try {
				SimpleSnmp snmp = new SimpleSnmp(ip, port, community);

				if(!snmp.Valid) {
					return null;
				}
				Dictionary<Oid, AsnType> sensorData = snmp.Get(_snmpVersion, oidList.ToArray());

				if(sensorData.Count > 0) {
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
