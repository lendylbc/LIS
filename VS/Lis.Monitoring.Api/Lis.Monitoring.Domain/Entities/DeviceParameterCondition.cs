using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lis.Monitoring.Abstractions.Entities;

namespace Lis.Monitoring.Domain.Entities {
	public class DeviceParameterCondition : Entity {
		public long DeviceParameterId { get; set; }
		public Decimal? Value { get; set; }
		public int? Operator { get; set; }
		public string ValueString { get; set; }
		public int? OperatorString { get; set; }
		public DateTime Inserted { get; set; }
		public DeviceParameter DeviceParameter { get; set; }

	}
}
