using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using Lis.Monitoring.Abstractions.Controllers;
using NModbus;
using NModbus.IO;

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
					client.ReceiveTimeout = 2000;
					//client.ReceiveBufferSize = 0;

					if(!client.Connected) {

					}
					foreach(string address in addressList) {
						IStreamResource streamResource = new StreamModbus();

						ModbusFactory modbusFactory = new ModbusFactory();

						IModbusSerialMaster modbusSerialMaster = modbusFactory.CreateRtuMaster(streamResource);
						try {
							ushort addressNumber = Convert.ToUInt16(address);
							modbusSerialMaster.ReadHoldingRegisters(1, addressNumber, 1);
							//modbusSerialMaster.ReadInputRegisters(1, 1032, 4);
						} catch {

						}
						if(!string.IsNullOrEmpty((streamResource as StreamModbus).write)) {
							byte[] commandTestBytes = StringToByteArray((streamResource as StreamModbus).write);

							byte[] data = TcpRequestData(commandTestBytes, client);

							result.Add(address, GetModbusValue(ip, address, data));
						}
					}


					client.Close();
					//client.Dispose();
				}

				return result;
			} catch {
				return null;
			}
		}

		private int GetModbusValue(string ip, string address, byte[] data) {
			if(ip == "172.20.1.86") {
				if(address == "66")
				return (int)data[4];
			}

			return 0;
		}

		private byte[] TcpRequestData(byte[] commandMessage, TcpClient client) {
			List<byte> responseBytes = new List<byte>();
			NetworkStream stream = client.GetStream();
			int dataLength = 0;
			try {
				if(client.Connected) {
					if(stream.CanWrite) {
						stream.Write(commandMessage, 0, commandMessage.Length);
					}
					if(stream.CanRead) {
						List<byte> requestedBytes = new List<byte>();
						byte[] buffer = new byte[1024];
						int bytesRec = stream.Read(buffer, 0, buffer.Length);

						responseBytes.AddRange(buffer.Take(bytesRec));
					}
				}

				if(responseBytes.Count > 0) {
					byte[] data = responseBytes.ToArray();

					return data;

				} else {
					return null;
				}

			} catch(SocketException e) {
				//if(log.IsErrorEnabled) log.Error(e.Message);
				if(responseBytes.Count > 0) {
					return responseBytes.ToArray();
				} else {
					return null;
					//throw e;
				}

			} catch(IOException e) {
				//if(log.IsErrorEnabled) log.Error(e.Message);
				//if(e.InnerException != null && (e.InnerException is SocketException) && (e.InnerException as SocketException).SocketErrorCode == SocketError.TimedOut) {
				//	if(log.IsErrorEnabled) log.Error("TCP/IP timeout: " + e.Message);
				//}
				//throw e;
				return null;
			} catch(ArgumentNullException e) {
				//if(log.IsErrorEnabled) log.Error(e.Message);
				//throw new Exception("Test error!");
				return null;
			} catch(Exception e) {
				//if(log.IsErrorEnabled) log.Error(e.Message);
				//throw new Exception("Test error!");
				return null;
			}

		}

		private static byte[] StringToByteArray(string hex) {
			return Enumerable.Range(0, hex.Length)
								  .Where(x => x % 2 == 0)
								  .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
								  .ToArray();
		}
	}
	public class StreamModbus : IStreamResource {

		public string write;
		public string read;

		public byte[] writeByte;
		public byte[] readByte;
		public int InfiniteTimeout { get; set; }

		public int ReadTimeout { get; set; }
		public int WriteTimeout { get; set; }

		public void DiscardInBuffer() {
			//throw new NotImplementedException();
		}

		public void Dispose() {
			//throw new NotImplementedException();
		}

		public int Read(byte[] buffer, int offset, int count) {
			readByte = buffer;
			read = Encoding.ASCII.GetString(buffer);
			return 1;
		}

		public void Write(byte[] buffer, int offset, int count) {
			writeByte = buffer;
			write = BitConverter.ToString(buffer).Replace("-", "");// Encoding.ASCII.GetString(buffer);				
		}
	}
}
