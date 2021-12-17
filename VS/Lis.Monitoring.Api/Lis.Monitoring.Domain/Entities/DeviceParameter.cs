﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lis.Monitoring.Abstractions.Entities;

namespace Lis.Monitoring.Domain.Entities {
	public class DeviceParameter : Entity {
		public string Description { get; set; }
		public string Oid { get; set; }
		public string Unit { get; set; }
		public long IdDevice { get; set; }
		public Device Device { get; set; }		
		public DateTime Inserted { get; set; }
		public bool Active { get; set; }
	}
}
