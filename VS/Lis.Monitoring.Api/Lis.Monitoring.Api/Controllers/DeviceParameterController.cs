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
using Microsoft.Extensions.Logging;

namespace Lis.Monitoring.Api.Controllers {
	[Authorize]
	[Route("api/[controller]/[Action]")]
	[ApiController]
	public class DeviceParameterController : BaseController<DeviceParameter, long, IDeviceParameterService, DeviceParameterDto, DeviceParameterDto, DeviceParameterDto, DeviceParameterQuery> {

		public DeviceParameterController(IDeviceParameterService deviceService, IMapper mapper) : base(deviceService, mapper) {// : base(entityService, mapper) { //IDeviceService entityService, IMapper mapper
		}
	}
}
