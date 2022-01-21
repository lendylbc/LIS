using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lis.Monitoring.Dto.Core;

namespace Lis.Monitoring.Dto.Communication {
	public class DeviceParameterDto : BaseDto<long?> {
		public string Description { get; set; }
		public string Address { get; set; }
		public string Unit { get; set; }
		public long DeviceId { get; set; }		
		public DateTime Inserted { get; set; }
		public bool Active { get; set; }
	}
}
