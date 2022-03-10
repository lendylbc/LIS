using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using Lextm.SharpSnmpLib;
//using Lextm.SharpSnmpLib.Messaging;
using NModbus;
using NModbus.IO;
using SnmpSharpNet;

namespace WinFormsApp1 {
	public partial class MainForm : Form {

		public MainForm() {
			InitializeComponent();
		}

		private void btnSendReq_Click(object sender, EventArgs e) {
			SnmpRequest(edtSnmpIp.Text, (int)edtSnmpPort.Value);
		}

		//private void SnmpGetAll() {
		//	for()

		//			edtIp.Text
		//}
		private void SnmpRequest(string ip, int port) {
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

			SimpleSnmp snmp = new SimpleSnmp(ip, port, "public");

			if(!snmp.Valid) {
				return;
			}

			string[] oids = edtOids.Text.Split(Environment.NewLine);

			Dictionary<Oid, AsnType> result = snmp.Get(SnmpVersion.Ver1, oids);

			//Pdu pdu = new Pdu(PduType.Set);
			//pdu.VbList.Add(new Oid("1.3.6.1.4.1.18248.16.3.1.1.1.1"), new SnmpSharpNet.Integer32(1));
			//pdu.

			//SnmpV2Packet response;
			//try {
			//	// Send request and wait for response
			//	response = target.Request(pdu, aparam) as SnmpV2Packet;
			//} catch(Exception ex) {
			//	// If exception happens, it will be returned here
			//	Console.WriteLine(String.Format("Request failed with exception: {0}", ex.Message));
			//	target.Close();
			//	return;
			//}

			//Pdu pdu = new Pdu(PduType.Set);
			////pdu.Type = SnmpConstants.; // type SET
			//Oid setOid = new Oid("1.3.6.1.4.1.18248.16.3.1.1.1.1"); // sysDescr.0
			//Integer32 setValue = new Integer32(1);
			//pdu.VbList.Add(setOid, setValue);

			//Dictionary<Oid, AsnType> result1 = snmp.Set(SnmpVersion.Ver1, pdu);


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
			//if(rbtnSick.Checked) {
			//	SickRequest();
			//} else {
			//	SnmpRequest(edtSnmpIp.Text);
			//	SnmpRequest("172.20.1.56");
			//	SnmpRequest("172.20.1.57");
			//	SnmpRequest("172.20.1.58");
			//}
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

			//using(TcpClient client = new TcpClient(edtModbusIp.Text, (int)edtModbusPort.Value)) {

			//	//int byteCount = Encoding.ASCII.GetByteCount(edtModbusData.Text);
			//	//byte[] sendData = new byte[byteCount + 1];

			//	//Array.Copy(Encoding.ASCII.GetBytes(edtModbusData.Text), sendData, byteCount);
			//	//sendData[byteCount] = 0xFF;
			//	if(!client.Connected) {
			//		edtLog.Text += "not connected";
			//		//client.Connect();
			//	}
			//	byte[] sendData = Encoding.ASCII.GetBytes(edtModbusData.Text);

			//	client.SendBufferSize = 0;
			//	//Task.Delay(1000);

			//	using(NetworkStream stream = client.GetStream()) {
			//		//Task.Delay(1000);
			//		if(stream.CanWrite) {
			//			edtLog.Text += "can write";
			//			stream.Write(sendData, 0, sendData.Length);
			//			//stream.Write(sendData, 0, sendData.Length);
			//			//stream.Flush();
			//			//stream.
			//		} else {
			//			edtLog.Text += "can't write";
			//		}

			//		//stream.Write(sendData, 0, sendData.Length);
			//		//stream.Write(sendData, 0, sendData.Length);
			//		//stream.Write(sendData, 0, sendData.Length);
			//		//stream.Write(sendData, 0, sendData.Length);

			//		//Task.Delay(1000);
			//		stream.Close();
			//		//stream.Dispose();
			//	}
			//	client.Close();
			//	//client.Dispose();
			//}


			//TcpClient client;

			//client = new TcpClient();
			//client.SendBufferSize = 0;
			//client.ReceiveTimeout = 2000;

			//try {
			//	//client.BeginConnect(edtModbusIp.Text, (int)edtModbusPort.Value, null, null);
			//	client.SendBufferSize = 0;
			//	// Create modbus master device on the tcp client
			//	//ModbusIpMaster master = ModbusIpMaster.CreateIp(tcpClient);

			//	//RequestData(new byte[] { 0xaa, 0x55, 0x5a }, client);
			//	//return;

			IStreamResource streamResource = new StreamModbus();


			ModbusFactory modbusFactory = new ModbusFactory();

			IModbusSerialMaster modbusSerialMaster = modbusFactory.CreateRtuMaster(streamResource);
			try {
				//modbusSerialMaster.ReadHoldingRegisters(1, 1900, 4);
				modbusSerialMaster.ReadInputRegisters(1, 1032, 4);
			} catch {

			}
			edtModbusData.Text = (streamResource as StreamModbus).write;
			//	IModbusMaster modbusMaster = modbusFactory.CreateMaster(client);

			//	client.Connect(edtModbusIp.Text, (int)edtModbusPort.Value);
			//	//modbusSlaveTransport = modbusFactory.CreateSlaveNetwork(tcpListener);
			//	if(client.Connected) {
			//		try {
			//			//ushort[] data = modbusMaster.ReadHoldingRegisters(1, 1011, 4);

			//			ushort[] data = modbusMaster.ReadInputRegisters(1, 1011, 1);

			//			//bool[] dInputs = modbusMaster.ReadInputs(1, 1500, 1);
			//			//modbusMaster.WriteSingleRegister(6, 6, 18);
			//			//modbusMaster.WriteMultipleRegisters(0, 0, new ushort[] { 1, 2, 3, 4, 5 });
			//			//modbusMaster.WriteMultipleCoils(0, 0, new bool[] { true, false, true, false, true });

			//			//	WriteMultipleRegisters
			//		} catch {

			//		}
			//		//bool[] dInputs = modbusMaster.ReadInputs(0, 0, 5);
			//	}
			//} catch {

			//}

			//client.Close();





			TcpClient client;

			client = new TcpClient(edtModbusIp.Text, (int)edtModbusPort.Value);
			client.ReceiveTimeout = 5000;
			client.SendBufferSize = 0;

			byte[] commandTestBytes = StringToByteArray(edtModbusData.Text);

			//byte[] dataCommand = new byte[commandTestBytes.Length + 2];

			//Array.Copy(commandTestBytes, 0, dataCommand, 1, commandTestBytes.Length);

			//dataCommand[0] = 0x02;
			//dataCommand[dataCommand.Length - 1] = 0x03;
			byte[] data = null;
			try {

				data = RequestData(commandTestBytes, client);
			} catch {
				edtLog.Text += Environment.NewLine + "Nevrátil data";
			}

			if(data != null) {
				//edtLog.Text = BitConverter.ToString(data).Replace("-", "");

				//edtLog.Text += Environment.NewLine + Encoding.ASCII.GetString(data);
				edtLog.Text += Environment.NewLine + BitConverter.ToString(data).Replace("-", "");
			} else {
				//edtLog.Text = BitConverter.ToString(data).Replace("-", "");

				edtLog.Text += Environment.NewLine + "NO DATA";
			}

			client.Close();
		}

		public static byte[] StringToByteArray(string hex) {
			return Enumerable.Range(0, hex.Length)
								  .Where(x => x % 2 == 0)
								  .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
								  .ToArray();
		}

		private void button3_Click(object sender, EventArgs e) {
			MailAddress from = new MailAddress("lendy@sender.cz", "Lendy");
			MailAddress to = new MailAddress("lendy@test.cz", "Lendy");
			List<MailAddress> cc = new List<MailAddress>();
			cc.Add(new MailAddress("lendy@centrum.cz", "Lendy"));
			SendEmail("Test", from, to, cc);
		}

		protected void SendEmail(string _subject, MailAddress _from, MailAddress _to, List<MailAddress> _cc, List<MailAddress> _bcc = null) {
			string Text = "";
			SmtpClient mailClient = new SmtpClient("smtp.mailtrap.io", 2525);
			MailMessage msgMail;
			Text = "Stuff";
			msgMail = new MailMessage();
			msgMail.From = _from;
			msgMail.To.Add(_to);
			foreach(MailAddress addr in _cc) {
				msgMail.CC.Add(addr);
			}
			if(_bcc != null) {
				foreach(MailAddress addr in _bcc) {
					msgMail.Bcc.Add(addr);
				}
			}

			mailClient.Credentials = new NetworkCredential("9c157fd76d3fda", "e33f6bd197d71f");
			mailClient.EnableSsl = true;

			msgMail.Subject = _subject;
			msgMail.Body = Text;
			msgMail.IsBodyHtml = true;
			mailClient.Send(msgMail);
			msgMail.Dispose();
		}

		private void button4_Click(object sender, EventArgs e) {
			SerialPort _serialPort = new SerialPort();

			//_serialPort.PortName = edtModAdr.Text;
			_serialPort.BaudRate = 19200;// SetPortBaudRate(_serialPort.BaudRate);
			_serialPort.Parity = Parity.Even;
			//_serialPort.DataBits = SetPortDataBits(_serialPort.DataBits);
			//_serialPort.StopBits = SetPortStopBits(_serialPort.StopBits);
			//_serialPort.Handshake = SetPortHandshake(_serialPort.Handshake);

			// Set the read/write timeouts
			_serialPort.ReadTimeout = 2000;
			_serialPort.WriteTimeout = 2000;

			byte[] commandTestBytes = StringToByteArray(edtModbusData.Text);
			try {
				try {
					_serialPort.Open();
					_serialPort.Write(commandTestBytes, 0, commandTestBytes.Length);
					edtLog.Text += Environment.NewLine + "Odesláno: " + BitConverter.ToString(commandTestBytes).Replace("-", "");
					for(int i = 0; i < commandTestBytes.Length; i++) {
						commandTestBytes[i] = 0;
					}

					_serialPort.Read(commandTestBytes, 0, commandTestBytes.Length);
					edtLog.Text += Environment.NewLine + "Přijato: " + BitConverter.ToString(commandTestBytes).Replace("-", "");


				} catch(Exception ex) {
					if(ex.Message.Contains("time")) {
						edtLog.Text += Environment.NewLine + "Timeout";
					} else {
						edtLog.Text += Environment.NewLine + "Chyba portu";
					}
				}
			} finally {
				_serialPort.Close();
			}
		}
			

		private void Form1_Load(object sender, EventArgs e) {
				foreach(string s in SerialPort.GetPortNames()) {
					edtLog.Text += s + Environment.NewLine;
				}
			}

			public string SetPortName(string defaultPortName) {
				string portName;

				//Console.WriteLine("Available Ports:");
				//foreach(string s in SerialPort.GetPortNames()) {
				//	Console.WriteLine("   {0}", s);
				//}

				//Console.Write("Enter COM port value (Default: {0}): ", defaultPortName);
				portName = Console.ReadLine();

				if(portName == "" || !(portName.ToLower()).StartsWith("com")) {
					portName = defaultPortName;
				}
				return portName;
			}

			private void edtModbusData_TextChanged(object sender, EventArgs e) {

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
				read = "AAAA";
			}
		}
	}
