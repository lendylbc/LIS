using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lis.Monitoring.Services.Aspects;

namespace Lis.Monitoring.Services.Abstractions {
	public interface IConditionService {
		Dictionary<string, ErrorParameterInfo> DeviceErrors { get; }
		void ResolveConditions();
	}
}
