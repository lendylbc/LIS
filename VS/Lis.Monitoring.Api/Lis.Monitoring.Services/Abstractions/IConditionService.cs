﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lis.Monitoring.Domain.Entities;
using Lis.Monitoring.Services.Aspects;
using Lis.Monitoring.Shared.Errors;

namespace Lis.Monitoring.Services.Abstractions {
	public interface IConditionService {
		List<ErrorParameterInfo> NotifyDeviceErrors { get; }
		bool ErrorsExists { get; }
		void ResolveConditions(ICollection<DeviceParameter> deviceParameters, Dictionary<string, object> deviceData);
	}
}
