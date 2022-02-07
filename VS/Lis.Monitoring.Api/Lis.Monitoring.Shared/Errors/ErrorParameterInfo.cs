using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lis.Monitoring.Shared.Errors {
	public class ErrorParameterInfo {
		public string Description { get; set; }
		public string Address { get; set; }
		public string Unit { get; set; }
		public string ErrorType { get; set; }

		public override string ToString() {
			return $"{Description} - {Address} ({Unit} - {ErrorType})";
		}
	}
}
