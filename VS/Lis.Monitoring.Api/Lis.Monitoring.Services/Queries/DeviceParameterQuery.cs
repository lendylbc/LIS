using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lis.Monitoring.Services.Queries {
	public class DeviceParameterQuery : PagedQuery {
		public long DeviceId { get; set; }
	}
}
