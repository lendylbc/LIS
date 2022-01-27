using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lis.Monitoring.Domain.Entities;
using Lis.Monitoring.Services.Aspects;

namespace Lis.Monitoring.Services.Abstractions {
	public interface IConditionService {
		List<ErrorParameterInfo> DeviceErrors { get; }
		void ResolveConditions(ICollection<DeviceParameter> deviceParameters, Dictionary<string, object> deviceData);
	}
}
