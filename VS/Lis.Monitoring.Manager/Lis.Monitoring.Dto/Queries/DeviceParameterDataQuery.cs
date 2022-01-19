using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lis.Monitoring.Dto.Queries {
	public class DeviceParameterDataQuery : PagedQuery {
		public long DeviceParameterId { get; set; }
		public DateTime DateTimeFrom { get; set; }
		public DateTime DateTimeTo { get; set; }
	}
}
