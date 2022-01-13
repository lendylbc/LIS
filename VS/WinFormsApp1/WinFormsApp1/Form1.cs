using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lextm.SharpSnmpLib;
using Lextm.SharpSnmpLib.Messaging;
using NModbus;
using SnmpSharpNet;

namespace WinFormsApp1 {
	public partial class Form1 : Form {

		public Form1() {
			InitializeComponent();
		}

		private void btnSendReq_Click(object sender, EventArgs e) {
			SnmpRequest(edtSnmpIp.Text);
		}

		//private void SnmpGetAll() {
		//	for()

		//			edtIp.Text
		//}
		private void SnmpRequest(string ip) {
			//IList<Variable> result = Messenger.Get(VersionCode.V1,
			//									new IPEndPoint(IPAddress.Parse(ip), 161),
			//									new Lextm.SharpSnmpLib.OctetString("public"),
			//									new List<Variable> {
			//							new Variable(new ObjectIdentifier("1.3.6.1.2.1.1.1.0")),


			//						new Variable(new ObjectIdentifier("1.3.6.1.4.1.18248.31.1.2.1.1.3.1")),

			//									},
			//									60000);

			//if(result != null) {
			//	foreach(Variable variable in result) {
			//		if(variable.Id.ToString().Equals("1.3.6.1.4.1.18248.31.1.2.1.1.3.1")) {
			//			string data = variable.Data.ToString();
			//			edtLog.Text += "\t" + data.Insert(data.Length - 1, ".") + "°C";
			//		} else {
			//			edtLog.Text += variable.Data.ToString();//Environment.NewLine + variable.Id.ToString() + "  " + 
			//		}
			//	}
			//	edtLog.Text += Environment.NewLine;
			//}

			//	************************************************************************************************

			SimpleSnmp snmp = new SimpleSnmp(ip, 161, "public");

			if(!snmp.Valid) {
				return;
			}

			string[] oids = edtOids.Text.Split(Environment.NewLine);

			Dictionary<Oid, AsnType> result = snmp.Get(SnmpVersion.Ver1, oids);


			//	new string[] {
			//"1.3.6.1.4.1.18248.16.1.1.0",


			//	//"1.3.6.1.4.1.18248.16.2.1.1.1.1"//,
			////"1.3.6.1.2.1.1.1.0",
			////"1.3.6.1.4.1.18248.31.1.2.1.1.3.1"
			//});
			
			if(result != null) {
				foreach(KeyValuePair<Oid, AsnType> variable in result) {
					if(variable.Key.ToString().Equals("1.3.6.1.4.1.18248.31.1.2.1.1.3.1") ||
						variable.Key.ToString().Equals("1.3.6.1.4.1.18248.31.1.2.1.1.3.4") ||
						variable.Key.ToString().Equals("1.3.6.1.4.1.18248.1.1.1.0") ||
						variable.Key.ToString().Equals("1.3.6.1.4.1.18248.16.1.1.0")) {						
						string data = variable.Value.ToString();
						edtLog.Text += "\t" + data.Insert(data.Length - 1, ".") + "°C";
					} else {
						edtLog.Text += variable.Value.ToString();//Environment.NewLine + variable.Id.ToString() + "  " + 
					}
					edtLog.Text += Environment.NewLine;
				}				
			}

			//	************************************************************************************************

			//SnmpSharpNet.OctetString community = new SnmpSharpNet.OctetString("public");

			//AgentParameters param = new AgentParameters(community);
			//param.Version = SnmpVersion.Ver1;
			//IpAddress agent = new IpAddress(ip);

			//// Construct target
			//UdpTarget target = new UdpTarget((IPAddress)agent, 161, 2000, 1);

			//Pdu pdu = new Pdu(PduType.Get);
			//pdu.VbList.Add("1.3.6.1.2.1.1.1.0");
			//pdu.VbList.Add("1.3.6.1.4.1.18248.31.1.2.1.1.3.1");

			//SnmpV1Packet result = (SnmpV1Packet)target.Request(pdu, param);

			//if(result != null) {
			//	foreach(Vb variable in result.Pdu.VbList) {
			//		if(variable.Oid.ToString().Equals("1.3.6.1.4.1.18248.31.1.2.1.1.3.1")) {
			//			string data = variable.Value.ToString();
			//			edtLog.Text += "\t" + data.Insert(data.Length - 1, ".") + "°C";
			//		} else {
			//			edtLog.Text += variable.Value.ToString();//Environment.NewLine + variable.Id.ToString() + "  " + 
			//		}
			//	}
			//	edtLog.Text += Environment.NewLine;
			//}


		}

		private void btnSick_Click(object sender, EventArgs e) {
			SickRequest();
		}

		private void SickRequest() {
			TcpClient client;

			client = new TcpClient(edtSickIp.Text, (int)edtSickPort.Value);
			client.ReceiveTimeout = 2000;

			byte[] commandTestBytes = Encoding.ASCII.GetBytes(edtSickCommand.Text);

			byte[] dataCommand = new byte[commandTestBytes.Length + 2];

			Array.Copy(commandTestBytes, 0, dataCommand, 1, commandTestBytes.Length);

			dataCommand[0] = 0x02;
			dataCommand[dataCommand.Length - 1] = 0x03;

			byte[] data = RequestData(dataCommand, client);

			if(data != null) {
				//edtLog.Text = BitConverter.ToString(data).Replace("-", "");

				edtLog.Text += Environment.NewLine + Encoding.ASCII.GetString(data);
			}
		}

		private byte[] RequestData(byte[] commandMessage, TcpClient client) {
			List<byte> responseBytes = new List<byte>();
			NetworkStream stream = client.GetStream();
			int dataLength = 0;
			try { //	Check if test connected, can write, can read is OK.
				if(client.Connected) {
					if(stream.CanWrite) {
						stream.Write(commandMessage, 0, commandMessage.Length);
					}
					if(stream.CanRead) {
						List<byte> requestedBytes = new List<byte>();
						// Incoming message may be larger than the buffer size hence read it by chunks
						//while(true) {
						byte[] buffer = new byte[1024];
						int bytesRec = stream.Read(buffer, 0, buffer.Length);
						//if(bytesRec == 0) {
						//	break;
						//}

						responseBytes.AddRange(buffer.Take(bytesRec));
						//if(responseBytes.Count >= dataLength + 7) {  //	Plus header length
						//	break;
						//}
						//}
					}
				}

				if(responseBytes.Count > 0) {
					byte[] data = responseBytes.ToArray();

					return data;

				} else {
					return null;
				}
				//return null;// responseBytes.ToArray();

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

		private void timer1_Tick(object sender, EventArgs e) {
			if(rbtnSick.Checked) {
				SickRequest();
			} else {
				SnmpRequest(edtSnmpIp.Text);
				SnmpRequest("172.20.1.56");
				SnmpRequest("172.20.1.57");
				SnmpRequest("172.20.1.58");
			}
		}

		private void btnTimer_Click(object sender, EventArgs e) {
			if(timer1.Enabled)
				timer1.Stop();
			else
				timer1.Start();
		}

		private void btnClearLog_Click(object sender, EventArgs e) {
			edtLog.Clear();
		}

		private void btnQuido_Click(object sender, EventArgs e) {			
			edtOids.Text = "1.3.6.1.4.1.18248.16.1.3.0" + Environment.NewLine +
			"1.3.6.1.4.1.18248.16.1.1.0" + Environment.NewLine +
			"1.3.6.1.4.1.18248.16.2.1.1.2.1" + Environment.NewLine +
			 "1.3.6.1.4.1.18248.16.2.1.1.1.1";
			edtSnmpIp.Text = "192.168.1.243";
		}

		private void btnTme_Click(object sender, EventArgs e) {			
			edtOids.Text = "1.3.6.1.4.1.18248.1.1.3.0" + Environment.NewLine + 
				"1.3.6.1.4.1.18248.1.1.1.0";
			edtSnmpIp.Text = "192.168.1.244";
		}

		private void btnPapouch_Click(object sender, EventArgs e) {
			edtOids.Text = "1.3.6.1.4.1.18248.31.1.1.1.0" + Environment.NewLine +
				"1.3.6.1.4.1.18248.31.1.2.1.1.3.1" + Environment.NewLine +
			"1.3.6.1.4.1.18248.31.1.2.1.1.3.4";
			edtSnmpIp.Text = "192.168.1.245";
		}

		private void btnModbus_Click(object sender, EventArgs e) {
			TcpClient client;

			client = new TcpClient();
			client.ReceiveTimeout = 2000;

			try {
				client.BeginConnect(edtModbusIp.Text, (int)edtModbusPort.Value, null, null);

				// Create modbus master device on the tcp client
				//ModbusIpMaster master = ModbusIpMaster.CreateIp(tcpClient);

				//RequestData(new byte[] { 0xaa, 0x55, 0x5a }, client);
				//return;
				 
				ModbusFactory modbusFactory = new ModbusFactory();
				IModbusMaster modbusMaster = modbusFactory.CreateMaster(client);

				//modbusSlaveTransport = modbusFactory.CreateSlaveNetwork(tcpListener);
				if(client.Connected) {
					try {
						//modbusMaster.WriteSingleRegister(0, 0, 10);
						//modbusMaster.WriteMultipleRegisters(0, 0, new ushort[] { 1, 2, 3, 4, 5 });
						modbusMaster.WriteMultipleCoils(0, 0, new bool[] { true, false, true, false, true });

						//	WriteMultipleRegisters
					} catch {

					}
					//bool[] dInputs = modbusMaster.ReadInputs(0, 0, 5);
				}
			} catch {

			}
			
			client.Close();
				

			//TcpClient client;

			//client = new TcpClient(edtModbusIp.Text, (int)edtModbusPort.Value);
			//client.ReceiveTimeout = 2000;

			//byte[] commandTestBytes = Encoding.ASCII.GetBytes(edtModbusData.Text);

			////byte[] dataCommand = new byte[commandTestBytes.Length + 2];

			////Array.Copy(commandTestBytes, 0, dataCommand, 1, commandTestBytes.Length);

			////dataCommand[0] = 0x02;
			////dataCommand[dataCommand.Length - 1] = 0x03;

			//byte[] data = RequestData(commandTestBytes, client);

			//if(data != null) {
			//	//edtLog.Text = BitConverter.ToString(data).Replace("-", "");

			//	edtLog.Text += Environment.NewLine + Encoding.ASCII.GetString(data);
			//}

			//client.Close();
		}
	}
}
