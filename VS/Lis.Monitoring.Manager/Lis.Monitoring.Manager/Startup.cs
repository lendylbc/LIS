using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lis.Monitoring.Api;

namespace Lis.Monitoring.Manager {
	public class Startup {
		private ApiController _apiController;

		public ApiController ApiController { get => _apiController; }

		public Startup() {
			Init();
		}

		private void Init() {
			_apiController = new ApiController();
		}
	}
}
