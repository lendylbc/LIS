using Lis.Monitoring.Dto.Core;
using Lis.Monitoring.Domain.Entities;
using Lis.Monitoring.Services.Queries;
using Lis.Monitoring.Dto.Communication;

namespace Lis.Monitoring.Services.Abstractions {
	public interface IDeviceService : IBaseEntityService<Device, long, DeviceQuery, DeviceDto> {
	}
}
