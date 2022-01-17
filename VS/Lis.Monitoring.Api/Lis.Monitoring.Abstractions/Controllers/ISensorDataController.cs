using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lis.Monitoring.Abstractions.Controllers {
	public interface ISensorDataController {
		public Dictionary<string, object> RequestData(string ip, int port, string community, List<string> addressList);
	}
}
