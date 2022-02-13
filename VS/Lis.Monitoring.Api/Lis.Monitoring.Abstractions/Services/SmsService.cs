using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lis.Monitoring.Abstractions.Services {
	public interface ISmsService {
		void Send(string predmet, string zprava, string[] prijemci);
	}
}
