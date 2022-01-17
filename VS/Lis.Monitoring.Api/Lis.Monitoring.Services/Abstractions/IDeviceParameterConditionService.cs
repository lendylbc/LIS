using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lis.Monitoring.Domain.Entities;
using Lis.Monitoring.Dto.Communication;
using Lis.Monitoring.Services.Queries;

namespace Lis.Monitoring.Services.Abstractions {
	public interface IDeviceParameterConditionService : IBaseEntityService<DeviceParameterCondition, long, DeviceParameterConditionQuery, DeviceParameterConditionDto> {
	}
}
