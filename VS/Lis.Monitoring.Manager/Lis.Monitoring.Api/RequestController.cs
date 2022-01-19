using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Lis.Monitoring.Dto;
using Lis.Monitoring.Dto.Core;
using Newtonsoft.Json;
using RestSharp;

namespace Lis.Monitoring.Api {
	public class RequestController: ApiBase {
		private const string _API_URL = "https://localhost:44336";
		public string JwtToken { get; set; }
		//BaseDto<long>
		public RestResponse Post(string resource, Method method, object bodyData, Dictionary<string, string> parameters, bool useAuthToken = true) {
			
			RestClient client = new RestClient(_API_URL);
			//client.Timeout = -1;
			RestRequest request = new RestRequest($"api/{resource}", method);
			if(bodyData != null) {
				request.AddHeader("Content-Type", "application/json");
			}
			if(useAuthToken) {
				if(!string.IsNullOrEmpty(JwtToken)) {
					request.AddHeader("Authorization", $"Bearer {JwtToken}");
				} else {
					throw new UnauthorizedAccessException("Uživatel musí být přihlášen!");
				}
			}

			request.RequestFormat = DataFormat.Json;

			if(bodyData != null) {
				
				string body = JsonConvert.SerializeObject(bodyData);
				//request.AddParameter("application/json", body, ParameterType.RequestBody);
				request.AddBody(body, "application/json");
			}

			if(parameters != null && parameters.Count > 0) {
				foreach(KeyValuePair<string, string> parameter in parameters) {					
					request.AddQueryParameter(parameter.Key, parameter.Value);
				}				
			}

			Task<RestResponse> response = client.ExecuteAsync(request);

			LogRequest(client, request, response.Result);


			return response?.Result;
		}	
	}
}

//var client = new RestClient("https://localhost:44336/api/Device?Page=0&Size=4");
//client.Timeout = -1;
//var request = new RestRequest(Method.GET);
//request.AddHeader("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IlRvbSIsImZhbWlseV9uYW1lIjoiTGVuZHkiLCJlbWFpbCI6ImxlbmRyQHZpc2lvbi5jeiIsIm5iZiI6MTY0MTk4MjY2OSwiZXhwIjoxNjQxOTg2MjY5LCJpYXQiOjE2NDE5ODI2Njl9.wxqMltst9pNhps1m92pfqxQ2fbIEhhxkLM9x6l374ZI");
//IRestResponse response = client.Execute(request);
//Console.WriteLine(response.Content);


//var client = new RestClient("https://localhost:44336/api/Member/authentication");
//client.Timeout = -1;
//var request = new RestRequest(Method.POST);
//request.AddHeader("Content-Type", "application/json");
//var body = @"{
//" + "\n" +
//@"  ""userName"": ""LENDY"",
//" + "\n" +
//@"  ""password"": ""admin""
//" + "\n" +
//@"}";
//request.AddParameter("application/json", body, ParameterType.RequestBody);
//IRestResponse response = client.Execute(request);
//Console.WriteLine(response.Content);