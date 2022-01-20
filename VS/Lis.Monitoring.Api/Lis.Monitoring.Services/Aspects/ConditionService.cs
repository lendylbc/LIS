using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lis.Monitoring.Services.Abstractions;

namespace Lis.Monitoring.Services.Aspects {
	public class ConditionService : IConditionService {
		Dictionary<string, ErrorParameterInfo> _deviceErrors;

		public Dictionary<string, ErrorParameterInfo> DeviceErrors { get => _deviceErrors; }

		public void ResolveConditions() {
			return;
		}
	}

	public class ErrorParameterInfo {
		public string Description { get; set; }
		public string Address { get; set; }
		public string Unit { get; set; }
	}
}
