using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lis.Monitoring.Dto;
using Lis.Monitoring.Dto.Authentication;
using Lis.Monitoring.Dto.Communication;
using Lis.Monitoring.Dto.Core;
using Newtonsoft.Json;
using RestSharp;

namespace Lis.Monitoring.Api {
	public class ApiController {
		RequestController _requestController;

		public string Request { get { return _requestController.Request; } }
		public string Response { get { return _requestController.Response; } }

		public ApiController() {
			_requestController = new RequestController();
		}

		public bool Authenticate(string login, string password) {
			MemberCredentialDto memberCredentialDto = new MemberCredentialDto() { UserName = login, Password = password };
			RestResponse response = _requestController.Post(memberCredentialDto, "Member/authentication/", Method.Post, false);

			if(response != null && response.StatusCode == System.Net.HttpStatusCode.OK && !string.IsNullOrEmpty(response.Content)) {				
				_requestController.JwtToken = (string)JsonConvert.DeserializeObject(response.Content);
				return true;
			} else {
				return false;
			}
		}

		public PagedResponse<DeviceDto> GetDevicesData() {//?Page=0&Size=4
			RestResponse response = _requestController.Post(null, "Device/Get", Method.Get, true);
			if(response != null && response.StatusCode == System.Net.HttpStatusCode.OK && !string.IsNullOrEmpty(response.Content)) {
				return (PagedResponse<DeviceDto>)JsonConvert.DeserializeObject<PagedResponse<DeviceDto>>(response.Content);
			} else {
				return null;
			}
		}

		public PagedResponse<ActiveDeviceLastDataDto> GetActiveDeviceLastData() {//?Page=0&Size=4
			RestResponse response = _requestController.Post(null, "DeviceData/GetLastDataAllActiveDevices", Method.Get, true);
			if(response != null && response.StatusCode == System.Net.HttpStatusCode.OK && !string.IsNullOrEmpty(response.Content)) {
				return (PagedResponse<ActiveDeviceLastDataDto>)JsonConvert.DeserializeObject<PagedResponse<ActiveDeviceLastDataDto>>(response.Content);
			} else {
				return null;
			}
		}
		public DeviceDto GetDeviceById(long id) {
			RestResponse response = _requestController.Post(null, $"Device/GetById/{id}", Method.Get, true);
			if(response != null && response.StatusCode == System.Net.HttpStatusCode.OK && !string.IsNullOrEmpty(response.Content)) {
				return (DeviceDto)JsonConvert.DeserializeObject<DeviceDto>(response.Content);
			} else {
				return null;
			}
		}
		public DeviceDto SaveDevice(DeviceDto device) {
			RestResponse response = _requestController.Post(device, $"Device/Save/", Method.Post, true);
			if(response != null && response.StatusCode == System.Net.HttpStatusCode.Created && !string.IsNullOrEmpty(response.Content)) {
				return (DeviceDto)JsonConvert.DeserializeObject<DeviceDto>(response.Content);
			} else {
				return null;
			}
		}

		public bool UpdateDevice(DeviceDto device) {
			RestResponse response = _requestController.Post(device, $"Device/Put/{device.Id}", Method.Put, true);
			if(response != null && response.StatusCode == System.Net.HttpStatusCode.OK) {
				return true;
			} else {
				return false;
			}
		}

		public bool DeleteDevice(long id) {
			RestResponse response = _requestController.Post(null, $"Device/Delete/{id}", Method.Delete, true);
			if(response != null && response.StatusCode == System.Net.HttpStatusCode.OK) {
				return true;
			} else {
				return false;
			}
		}
	}
}
