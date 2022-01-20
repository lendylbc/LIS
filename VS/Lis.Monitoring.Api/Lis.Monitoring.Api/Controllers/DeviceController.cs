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
	[Authorize]
	[Route("api/[controller]/[Action]")]
	[ApiController]
	public class DeviceController : BaseController<Device, long, IDeviceService, DeviceDto, DeviceDto, DeviceDto, DeviceQuery> {//<Device, long, IDeviceService, DeviceDto, DeviceDto, DeviceDto, DeviceQuery> {
		private static readonly ILogger log = Serilog.Log.ForContext<DeviceController>();
		public DeviceController(IDeviceService deviceService, IMapper mapper) :base(deviceService, mapper) {// : base(entityService, mapper) { //IDeviceService entityService, IMapper mapper
		}

		//public DeviceController(ILogger<DeviceController> logger) {
		//	_logger = logger;
		//}

		//[Route("GetActiveDeviceLastData")]
		[HttpGet(Name = "GetActiveDeviceLastData")]
		public async Task<IPagedResponse<ActiveDeviceLastDataDto>> GetActiveDeviceLastData() {
			IEnumerable<ActiveDeviceLastData> items = await EntityService.GetAllActiveDevicesWithLastData();

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