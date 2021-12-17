using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lis.Monitoring.Abstractions.Entities;

namespace Lis.Monitoring.Domain.Entities {
	public class Device : Entity {
		public string Description { get; set; }
		public string IpAddress { get; set; }
		//public int Port { get; set; }
		//public string Community { get; set; }
		public DateTime Inserted { get; set; }
		public bool Active { get; set; }
		public ICollection<DeviceParameter> DeviceParameter { get; set; } = new List<DeviceParameter>();
	}
}
