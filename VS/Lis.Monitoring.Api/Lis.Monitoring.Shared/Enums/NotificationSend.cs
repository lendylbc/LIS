using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lis.Monitoring.Shared.Enums {
	public enum NotificationSend {
		Email = 1 << 0,
		SMS = 1 << 0
	}
}
