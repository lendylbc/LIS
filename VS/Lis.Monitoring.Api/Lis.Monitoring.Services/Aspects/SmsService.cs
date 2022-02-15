using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Lis.Monitoring.Abstractions.Services;
using Serilog;

namespace Lis.Monitoring.Services.Aspects {
	public class SmsService : ISmsService {

		private static readonly ILogger log = Serilog.Log.ForContext<SmsService>();

		private const string _SEND_SMS = "http://{0}/cgi-bin/sms_send?username={1}&password={2}&number={3}&text={4}";

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
			foreach(string prijemce in prijemci) {
				SendSetRequest(string.Format(_SEND_SMS, _host, _username, _password, prijemce, HttpUtility.UrlEncode(predmet + ": " + zprava)));
			}			
		}

		private async void SendSetRequest(string request) {

			HttpClient client = new HttpClient();
			try {
				var responseString = await client.GetStringAsync(request);

			} catch(Exception ex) {
				log.Error("Error beacon request: " + ex.Message);
			}

			//var client = new RestClient("http://192.168.1.240/set.xml?type=r&id=1");
			//client.Timeout = -1;
			//var request = new RestRequest(Method.GET);
			//IRestResponse response = client.Execute(request);
		}
	}
}
