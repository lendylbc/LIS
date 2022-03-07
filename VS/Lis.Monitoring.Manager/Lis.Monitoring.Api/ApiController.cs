using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lis.Monitoring.Dto;
using Lis.Monitoring.Dto.Authentication;
using Lis.Monitoring.Dto.Communication;
using Lis.Monitoring.Dto.Core;
using Lis.Monitoring.Dto.Queries;
using Newtonsoft.Json;
using RestSharp;

namespace Lis.Monitoring.Api {
	public class ApiController {
		RequestController _requestController;

		public string Request { get { return _requestController.Request; } }
		public string Response { get { return _requestController.Response; } }
		public MemberDto Member { get; set; }
		public string JwtToken { get => _requestController.JwtToken; }

		public ApiController() {
			_requestController = new RequestController();
		}

		public bool Authenticate(string login, string password) {
			MemberCredentialDto memberCredentialDto = new MemberCredentialDto() { UserName = login, Password = password };
			RestResponse response = _requestController.Post("Member/authentication/", Method.Post, memberCredentialDto, null, false);

			if(response != null && response.StatusCode == System.Net.HttpStatusCode.OK && !string.IsNullOrEmpty(response.Content)) {
				MemberTokenDto memberToken = (MemberTokenDto)JsonConvert.DeserializeObject<MemberTokenDto>(response.Content);
				_requestController.JwtToken = memberToken.Token;
				Member = memberToken.Member;
				return true;
			} else {
				return false;
			}
		}

		public bool CheckResponse(RestResponse response) {
			bool result = false;
			try {
				if(response != null) {
					if(response.StatusCode == System.Net.HttpStatusCode.OK) {
						result = true;
					} else if(response.StatusCode == System.Net.HttpStatusCode.Created) {
						result = true;
					} else if(response.StatusCode == System.Net.HttpStatusCode.Unauthorized) {
						if(Member != null) {
							Authenticate(Member.Login, Member.Password);
						}
					}
				}
				return result;
			} catch {
				return false;
			}
		}

		public bool CheckResponse<T>(RestResponse response, out T data) {
			bool result = false;
			data = default(T);
			try {
				if(response != null) {
					if(response.StatusCode == System.Net.HttpStatusCode.OK) {
						if(!string.IsNullOrEmpty(response.Content)) {
							data = (T)JsonConvert.DeserializeObject<T>(response.Content);
						}
						result = true;
					} else if(response.StatusCode == System.Net.HttpStatusCode.Unauthorized) {
						if(Member != null) {
							Authenticate(Member.Login, Member.Password);
						}
					}
				}
				return result;
			} catch {
				return false;
			}
		}

		public PagedResponse<DeviceDto> GetDeviceList() {//?Page=0&Size=4
			RestResponse response = _requestController.Post("Device/Get", Method.Get, null, null, true);
			PagedResponse<DeviceDto> data;
			if(CheckResponse<PagedResponse<DeviceDto>>(response, out data)) {
				return data;// (PagedResponse<DeviceDto>)JsonConvert.DeserializeObject<PagedResponse<DeviceDto>>(response.Content);
			} else {
				return null;
			}

		}

		public PagedResponse<ActiveDeviceLastDataDto> GetActiveDeviceLastData() {//?Page=0&Size=4
			RestResponse response = _requestController.Post("DeviceData/GetLastDataAllActiveDevices", Method.Get, null, null, true);
			if(CheckResponse(response)) {
				return (PagedResponse<ActiveDeviceLastDataDto>)JsonConvert.DeserializeObject<PagedResponse<ActiveDeviceLastDataDto>>(response.Content);
			} else {
				return null;
			}
		}
		public DeviceDto GetDeviceById(long id) {
			RestResponse response = _requestController.Post($"Device/GetById/{id}", Method.Get, null, null, true);
			if(CheckResponse(response)) {
				return (DeviceDto)JsonConvert.DeserializeObject<DeviceDto>(response.Content);
			} else {
				return null;
			}
		}
		public DeviceDto SaveDevice(DeviceDto device) {
			RestResponse response = _requestController.Post($"Device/Save/", Method.Post, device, null, true);
			if(CheckResponse(response)) {
				return (DeviceDto)JsonConvert.DeserializeObject<DeviceDto>(response.Content);
			} else {
				return null;
			}
		}

		public bool UpdateDevice(DeviceDto device) {
			RestResponse response = _requestController.Post($"Device/Put/{device.Id}", Method.Put, device, null, true);
			if(CheckResponse(response)) {
				return true;
			} else {
				return false;
			}
		}

		public bool DeleteDevice(long id) {
			RestResponse response = _requestController.Post($"Device/Delete/{id}", Method.Delete, null, null, true);
			if(response != null && response.StatusCode == System.Net.HttpStatusCode.OK) {
				return true;
			} else {
				return false;
			}
		}

		public PagedResponse<MemberDto> GetMemberList() {//?Page=0&Size=4
			RestResponse response = _requestController.Post("Member/Get", Method.Get, null, null, true);
			if(CheckResponse(response)) {
				return (PagedResponse<MemberDto>)JsonConvert.DeserializeObject<PagedResponse<MemberDto>>(response.Content);
			} else {
				return null;
			}
		}

		public MemberDto GetMemberById(long id) {
			RestResponse response = _requestController.Post($"Member/GetById/{id}", Method.Get, null, null, true);
			if(CheckResponse(response)) {
				return (MemberDto)JsonConvert.DeserializeObject<MemberDto>(response.Content);
			} else {
				return null;
			}
		}
		public MemberDto SaveMember(MemberDto member) {
			RestResponse response = _requestController.Post($"Member/Save/", Method.Post, member, null, true);
			if(CheckResponse(response)) {
				return (MemberDto)JsonConvert.DeserializeObject<MemberDto>(response.Content);
			} else {
				return null;
			}
		}

		public bool UpdateMember(MemberDto member) {
			RestResponse response = _requestController.Post($"Member/Put/{member.Id}", Method.Put, member, null, true);
			if(response != null && response.StatusCode == System.Net.HttpStatusCode.OK) {
				return true;
			} else {
				return false;
			}
		}

		public bool DeleteMember(long id) {
			RestResponse response = _requestController.Post($"Member/Delete/{id}", Method.Delete, null, null, true);
			if(response != null && response.StatusCode == System.Net.HttpStatusCode.OK) {
				return true;
			} else {
				return false;
			}
		}

		public PagedResponse<DeviceParameterDataDto> GetFilteredDeviceData(DeviceParameterDataQuery query) {//?Page=0&Size=4		
			Dictionary<string, string> parameters = new Dictionary<string, string>();
			parameters.Add("DeviceParameterId", query.DeviceParameterId.ToString());
			parameters.Add("DateTimeFrom", query.DateTimeFrom.ToString("yyyy-MM-ddTHH:mm:ss"));
			parameters.Add("DateTimeTo", query.DateTimeTo.ToString("yyyy-MM-ddTHH:mm:ss"));
			parameters.Add("Page", "0");
			parameters.Add("Size", "0");

			RestResponse response = _requestController.Post("DeviceData/Get", Method.Get, null, parameters, true);
			if(CheckResponse(response)) {
				return (PagedResponse<DeviceParameterDataDto>)JsonConvert.DeserializeObject<PagedResponse<DeviceParameterDataDto>>(response.Content);
			} else {
				return null;
			}
		}

		public PagedResponse<DeviceParameterDto> GetFilteredParameterList(long id) {//?Page=0&Size=4
			Dictionary<string, string> parameters = new Dictionary<string, string>();
			parameters.Add("DeviceId", id.ToString());
			RestResponse response = _requestController.Post("DeviceParameter/Get", Method.Get, null, parameters, true);
			if(CheckResponse(response)) {
				return (PagedResponse<DeviceParameterDto>)JsonConvert.DeserializeObject<PagedResponse<DeviceParameterDto>>(response.Content);
			} else {
				return null;
			}
		}

		public bool DeleteParameter(long id) {
			RestResponse response = _requestController.Post($"DeviceParameter/Delete/{id}", Method.Delete, null, null, true);
			if(response != null && response.StatusCode == System.Net.HttpStatusCode.OK) {
				return true;
			} else {
				return false;
			}
		}
		public PagedResponse<DeviceParameterConditionDto> GetFilteredConditionList(long id) {//?Page=0&Size=4
			Dictionary<string, string> parameters = new Dictionary<string, string>();
			parameters.Add("DeviceParameterId", id.ToString());
			RestResponse response = _requestController.Post("DeviceCondition/Get", Method.Get, null, parameters, true);
			if(CheckResponse(response)) {
				return (PagedResponse<DeviceParameterConditionDto>)JsonConvert.DeserializeObject<PagedResponse<DeviceParameterConditionDto>>(response.Content);
			} else {
				return null;
			}
		}

		public bool DeleteCondition(long id) {
			RestResponse response = _requestController.Post($"DeviceCondition/Delete/{id}", Method.Delete, null, null, true);
			if(response != null && response.StatusCode == System.Net.HttpStatusCode.OK) {
				return true;
			} else {
				return false;
			}
		}

		public DeviceParameterDto SaveDeviceParameter(DeviceParameterDto deviceParameter) {
			RestResponse response = _requestController.Post($"DeviceParameter/Save/", Method.Post, deviceParameter, null, true);
			if(CheckResponse(response)) {
				return (DeviceParameterDto)JsonConvert.DeserializeObject<DeviceParameterDto>(response.Content);
			} else {
				return null;
			}
		}

		public bool UpdateDeviceParameter(DeviceParameterDto deviceParameter) {
			RestResponse response = _requestController.Post($"DeviceParameter/Put/{deviceParameter.Id}", Method.Put, deviceParameter, null, true);
			if(response != null && response.StatusCode == System.Net.HttpStatusCode.OK) {
				return true;
			} else {
				return false;
			}
		}

		public DeviceParameterConditionDto SaveParamCondition(DeviceParameterConditionDto DeviceCondition) {
			RestResponse response = _requestController.Post($"DeviceCondition/Save/", Method.Post, DeviceCondition, null, true);
			if(CheckResponse(response)) {
				return (DeviceParameterConditionDto)JsonConvert.DeserializeObject<DeviceParameterConditionDto>(response.Content);
			} else {
				return null;
			}
		}

		public bool UpdateParamCondition(DeviceParameterConditionDto DeviceCondition) {
			RestResponse response = _requestController.Post($"DeviceCondition/Put/{DeviceCondition.Id}", Method.Put, DeviceCondition, null, true);
			if(response != null && response.StatusCode == System.Net.HttpStatusCode.OK) {
				return true;
			} else {
				return false;
			}
		}
	}
}
