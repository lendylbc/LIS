using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lis.Monitoring.Abstractions.Services;

namespace Lis.Monitoring.Services.Aspects {
	public class SmsService : ISmsService {

		private readonly string _host;
		private readonly int _port;
		private readonly string _username;
		private readonly string _password;		

		public SmsService(
			string host,
			int port,
			string username,
			string password) {
			_host = host;
			_port = port;
			_username = username;
			_password = password;			
		}

		public void Send(string predmet, string zprava, string[] prijemci) {
			//throw new NotImplementedException();
		}
	}
}
