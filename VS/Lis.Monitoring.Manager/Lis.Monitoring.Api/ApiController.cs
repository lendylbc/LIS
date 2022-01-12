using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lis.Monitoring.Dto;
using RestSharp;

namespace Lis.Monitoring.Api {
	public class ApiController {
		RequestController _requestController;

		public ApiController() {
			_requestController = new RequestController();
		}

		public bool Authenticate(string login, string password) {
			UzivatelLogin UzivatelLogin = new UzivatelLogin() { Username = login, Password = password };
			RestResponse response = _requestController.Post(UzivatelLogin, false);

			if(response != null && response.StatusCode == System.Net.HttpStatusCode.OK && string.IsNullOrEmpty(response.Content)) {
				_requestController.JwtToken = response.Content;
				return true;
			} else {
				return false;
			}
		}
	}
}
