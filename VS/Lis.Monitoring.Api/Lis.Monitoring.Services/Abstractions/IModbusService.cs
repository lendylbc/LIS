using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lis.Monitoring.Services.Aspects;
using Lis.Monitoring.Shared.Errors;

namespace Lis.Monitoring.Services.Abstractions {
	public interface IModbusService {
		List<ErrorParameterInfo> Errors { get; }
		void GetDevicesData();
	}
}
