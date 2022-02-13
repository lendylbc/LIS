using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lis.Monitoring.Abstractions.Services {
	public interface IBeaconService {
		void LightOn();
		void LightOff();
	}
}
