using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lis.Monitoring.Dto.Communication {
	public class DeviceParameterDataDto {
		public long DeviceParameterId { get; set; }
		public Decimal Value { get; set; }
		public DateTime Inserted { get; set; }
	}
}
