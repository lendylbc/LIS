using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Lis.Monitoring.Domain.Entities;
using Lis.Monitoring.Dto.Communication;
using Lis.Monitoring.Services.Abstractions;
using Lis.Monitoring.Services.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Lis.Monitoring.Api.Controllers {
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class DeviceController : BaseController<Device, long, IDeviceService, DeviceDto, DeviceDto, DeviceDto, DeviceQuery> {//<Device, long, IDeviceService, DeviceDto, DeviceDto, DeviceDto, DeviceQuery> {

		public DeviceController(IDeviceService deviceService, IMapper mapper) :base(deviceService, mapper) {// : base(entityService, mapper) { //IDeviceService entityService, IMapper mapper
		}

		private static readonly string[] Summaries = new[]
		{
					"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
			  };

		//public DeviceController(ILogger<DeviceController> logger) {
		//	_logger = logger;
		//}

		//[HttpGet]
		//public IEnumerable<DeviceDto> Get() {
		//	var rng = new Random();
		//	return Enumerable.Range(1, 5).Select(index => new DeviceDto {
		//		//Date = DateTime.Now.AddDays(index),
		//		Description = rng.Next(-20, 55).ToString(),
		//		IpAddress = Summaries[rng.Next(Summaries.Length)]
		//	})
		//	.ToArray();
		//}
	}
}
