using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using Lis.Monitoring.Abstractions.Controllers;

namespace Lis.Monitoring.Modbus {
	public class ModbusController : ISensorDataController {
		public ModbusController() {

		}

		public Dictionary<string, object> RequestData(string ip, int port, string community, List<string> addressList) {
			Dictionary<string, object> result = new Dictionary<string, object>();
			byte[] readData = new byte[256];
			try {

				using(TcpClient client = new TcpClient(ip, port)) {
					client.SendBufferSize = 0;
					client.ReceiveTimeout = 1000;
					client.ReceiveBufferSize = 0;

					if(!client.Connected) {

					}
					using(NetworkStream stream = client.GetStream()) {
						foreach(string str in addressList) {


							byte[] sendData = Encoding.ASCII.GetBytes(str);

							if(stream.CanWrite) {
								stream.Write(sendData, 0, sendData.Length);
							}
							//if(stream.CanRead) {
							//	try {
							//		if(stream.Read(readData, 0, readData.Length) > 0) {
							//			result.Add(str, (object)readData);
							//		}
							//	} catch {

							//	}
							//}
						}

						stream.Close();
						//stream.Dispose();
					}
					client.Close();
					//client.Dispose();
				}

				return result;
			} catch {
				return null;
			}
		}
	}
}
