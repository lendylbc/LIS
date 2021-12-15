using Lis.Monitoring.Infrastructure;
using Lis.Monitoring.Services.Abstractions;
using Lis.Monitoring.Dto.Core;
using Lis.Monitoring.Domain.Entities;
using Lis.Monitoring.Services.Queries;
using Lis.Monitoring.Dto.Communication;

namespace Lis.Monitoring.Services.Entities {
	public class DeviceService : BaseEntityService<Device, long, DeviceQuery, DeviceDto>, IDeviceService {

		public DeviceService(DbService dbService) : base(dbService) {
		}

	}
}
