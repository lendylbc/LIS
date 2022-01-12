using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Lis.Monitoring.Dto;
using Newtonsoft.Json;
using RestSharp;

namespace Lis.Monitoring.Api {
	public class RequestController: ApiBase {
		public string JwtToken { get; set; }

		public RestResponse Post(BaseDto bodyData, bool useAuthToken = true) {
			
			RestClient client = new RestClient("https://localhost:44336");
			//client.Timeout = -1;
			RestRequest request = new RestRequest("api/Member/authentication/", Method.Post);
			request.AddHeader("Content-Type", "application/json");

			request.RequestFormat = DataFormat.Json;
			string body = JsonConvert.SerializeObject(bodyData);
			//request.AddParameter("application/json", body, ParameterType.RequestBody);
			request.AddBody(body, "application/json");
			Task<RestResponse> response = client.ExecuteAsync(request);

			LogRequest(client, request, response.Result);


			return response?.Result;
		}

		public object Post(bool useAuthToken = true) {
			UzivatelLogin UzivatelLogin = new UzivatelLogin();// { Email = edtLogin.Text, Heslo = edtPassword.Text };
			var client = new RestClient("https://localhost:44336");
			//client.Timeout = -1;
			var request = new RestRequest("api/Member/authentication/", Method.Post);
			request.AddHeader("Content-Type", "application/json");
			
			request.RequestFormat = DataFormat.Json;
			var body = @"{
" + "\n" +
			@"  ""userName"": ""LENDY"",
" + "\n" +
			@"  ""password"": ""admin""
" + "\n" +
			@"}";
			//request.AddParameter("application/json", body, ParameterType.RequestBody);
			request.AddBody(body, "application/json");
			Task<RestResponse> response = client.ExecuteAsync(request);

			LogRequest(client, request, response.Result);


			return response.Result;
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