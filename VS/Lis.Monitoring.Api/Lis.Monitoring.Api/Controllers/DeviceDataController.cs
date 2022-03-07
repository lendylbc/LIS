using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Lis.Monitoring.Domain.Entities;
using Lis.Monitoring.Dto.Communication;
using Lis.Monitoring.Dto.Core;
using Lis.Monitoring.Services.Abstractions;
using Lis.Monitoring.Services.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Lis.Monitoring.Api.Controllers {
	//[Authorize]
	[Route("api/[controller]/[Action]")]
	[ApiController]
	public class DeviceDataController : BaseController<DeviceParameterData, long, IDeviceParameterDataService, DeviceParameterDataDto, DeviceParameterDataDto, DeviceParameterDataDto, DeviceParameterDataQuery> {
		private static readonly ILogger log = Serilog.Log.ForContext<DeviceDataController>();
		public DeviceDataController(IDeviceParameterDataService deviceService, IMapper mapper) : base(deviceService, mapper) {// : base(entityService, mapper) { //IDeviceService entityService, IMapper mapper
		}

		[HttpGet(Name = "GetLastDataAllActiveDevices")]
		public async Task<IPagedResponse<ActiveDeviceLastDataDto>> GetLastDataAllActiveDevices() {
			IEnumerable<ActiveDeviceLastData> items = await EntityService.GetLastDataAllActiveDevices();

			var response = new PagedResponse<ActiveDeviceLastDataDto> {
				Page = 0,
				Size = 0,
				Total = 0,
				Data = Mapper.Map<List<ActiveDeviceLastDataDto>>(items)
			};
			
			return response;
		}

	}
}
