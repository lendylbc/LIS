using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lis.Monitoring.Dto.Core;

namespace Lis.Monitoring.Dto.Communication {
	public class ActiveDeviceLastDataDto : BaseDto<long?> {
		public int DeviceId { get; set; }
		public string DeviceDesc { get; set; }
		public int ParamId { get; set; }
		public string ParamDesc { get; set; }
		public string Unit { get; set; }
		public int ValueType { get; set; }
		public Decimal? Value { get; set; }
		public string ValueString { get; set; }
		public DateTime? Inserted { get; set; }
		public DateTime? ErrorDetected { get; set; }
		public DateTime? Notified { get; set; }
	}
}
