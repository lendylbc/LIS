using System;
using System.Collections.Generic;
using SnmpSharpNet;

namespace Lis.Monitoring.Snmp {
	public class SnmpController {
		SnmpVersion _snmpVersion = SnmpVersion.Ver1;
		public SnmpController() {

		}

		public Dictionary<Oid, AsnType> SnmpRequest(string ip, int port, string community, List<string> oidList) {
			try {
				SimpleSnmp snmp = new SimpleSnmp(ip, port, community);

				if(!snmp.Valid) {
					return null;
				}

				return snmp.Get(_snmpVersion, oidList.ToArray());
			} catch {
				return null;
			}
		}
	}
}
