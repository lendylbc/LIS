using System;
using Lis.Monitoring.Dto.Core;

namespace Lis.Monitoring.Dto.Communication {
	public class DeviceDto : BaseDto<long?> {
		public string Description { get; set; }
		public string IpAddress { get; set; }
		public DateTime Inserted { get; set; }
	}
}
