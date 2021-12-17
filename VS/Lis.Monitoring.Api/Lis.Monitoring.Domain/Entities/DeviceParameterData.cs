using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lis.Monitoring.Abstractions.Entities;

namespace Lis.Monitoring.Domain.Entities {
	public class DeviceParameterData : Entity {
		public long IdDeviceParameter { get; set; }
		public Decimal Value { get; set; }
		public DateTime Inserted { get; set; }		
	}
}
