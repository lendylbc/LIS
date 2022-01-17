using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lis.Monitoring.Dto.Core;

namespace Lis.Monitoring.Dto.Communication {
	public class DeviceParameterConditionDto : BaseDto<long?> {
		public long DeviceParameterId { get; set; }
		public Decimal Value { get; set; }
		public int Operator { get; set; }
		public DateTime Inserted { get; set; }
	}
}
