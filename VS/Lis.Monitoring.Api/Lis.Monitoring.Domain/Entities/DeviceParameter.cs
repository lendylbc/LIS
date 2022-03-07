﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lis.Monitoring.Abstractions.Entities;

namespace Lis.Monitoring.Domain.Entities {
	public class DeviceParameter : Entity {
		public string Description { get; set; }
		public string Address { get; set; }
		public string Unit { get; set; }
		public decimal? Multiplier { get; set; }
		public long DeviceId{ get; set; }
		public int ValueType { get; set; }
		public Device Device { get; set; }		
		public DateTime Inserted { get; set; }
		public bool Active { get; set; }
		public DateTime? ErrorDetected { get; set; }
		public DateTime? Notified { get; set; }
				
		[NotMapped]
		public bool ErrorInfoChange { get; set; }
		public ICollection<DeviceParameterCondition> DeviceParameterCondition { get; set; } = new List<DeviceParameterCondition>();
	}
}
