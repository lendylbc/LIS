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

namespace Lis.Monitoring.Services.Entities {
	public class DeviceParameterConditionService : BaseEntityService<DeviceParameterCondition, long, DeviceParameterConditionQuery, DeviceParameterConditionDto>, IDeviceParameterConditionService {

		public DeviceParameterConditionService(DbService dbService) : base(dbService) {
		}
	}
}
