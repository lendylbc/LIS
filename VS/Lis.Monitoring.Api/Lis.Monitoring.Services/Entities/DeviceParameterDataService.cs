using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lis.Monitoring.Domain.Entities;
using Lis.Monitoring.Dto.Communication;
using Lis.Monitoring.Infrastructure;
using Lis.Monitoring.Services.Abstractions;
using Lis.Monitoring.Services.Queries;
using Microsoft.EntityFrameworkCore;

namespace Lis.Monitoring.Services.Entities {
	public class DeviceParameterDataService : BaseEntityService<DeviceParameterData, long, DeviceParameterDataQuery, DeviceParameterDataDto>, IDeviceParameterDataService {
		public DeviceParameterDataService(DbService dbService) : base(dbService) {
		}

		public override IQueryable<DeviceParameterData> EntityFilter(IQueryable<DeviceParameterData> query, DeviceParameterDataQuery filtr) {
			return query.Where(x => x.DeviceParameterId == filtr.DeviceParameterId && x.Inserted >= filtr.DateTimeFrom && x.Inserted <= filtr.DateTimeTo);
		}

		public async Task<IEnumerable<ActiveDeviceLastData>> GetLastDataAllActiveDevices() {
			DbSet<ActiveDeviceLastData> lastDataSet = DbService.Set<ActiveDeviceLastData>();

			return await lastDataSet.ToListAsync();
		}

		public void DeleteOldData() {
			IEnumerable<object> parameters = new List<object>();

			DbService.Database.ExecuteSqlRaw("EXECUTE dbo.spDeleteOldData", parameters);			
		}
	}
}
