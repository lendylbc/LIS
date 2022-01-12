using Lis.Monitoring.Dto.Core;
using Lis.Monitoring.Domain.Entities;
using Lis.Monitoring.Services.Queries;
using Lis.Monitoring.Dto.Communication;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Lis.Monitoring.Services.Abstractions {
	public interface IDeviceService : IBaseEntityService<Device, long, DeviceQuery, DeviceDto> {
		IEnumerable<Device> GetAllDevicesWithParams(int deviceType);		
	}
}
