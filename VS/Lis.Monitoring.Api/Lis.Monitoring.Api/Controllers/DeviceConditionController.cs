using System;
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
	public class DeviceConditionController : BaseController<DeviceParameterCondition, long, IDeviceParameterConditionService, DeviceParameterConditionDto, DeviceParameterConditionDto, DeviceParameterConditionDto, DeviceParameterConditionQuery> {
		private static readonly ILogger log = Serilog.Log.ForContext<DeviceConditionController>();
		public DeviceConditionController(IDeviceParameterConditionService deviceService, IMapper mapper) : base(deviceService, mapper) {// : base(entityService, mapper) { //IDeviceService entityService, IMapper mapper
		}
	}
}
