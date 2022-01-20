using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lis.Monitoring.Services.Queries {
	public class DeviceParameterConditionQuery : PagedQuery {
		public long DeviceParameterId { get; set; }
	}
}
