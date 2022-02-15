using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Lis.Monitoring.Abstractions.Services;
using Serilog;

namespace Lis.Monitoring.Services.Aspects {
	public class BeaconService : IBeaconService {
		private static readonly ILogger log = Serilog.Log.ForContext<BeaconService>();

		private const string _SET_OUTPUT_PARAMETER = "http://{0}/set.xml?type={1}&id=1";

		private readonly string _host;
		private readonly int _port;
		private readonly string _username;
		private readonly string _password;

		public BeaconService(
			string host,
			int port,
			string username,
			string password) {
			_host = host;
			_port = port;
			_username = username;
			_password = password;
		}

		public void LightOff() {
			SendSetRequest(string.Format(_SET_OUTPUT_PARAMETER, _host, "r"));
		}

		public void LightOn() {
			SendSetRequest(string.Format(_SET_OUTPUT_PARAMETER, _host, "s"));
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
