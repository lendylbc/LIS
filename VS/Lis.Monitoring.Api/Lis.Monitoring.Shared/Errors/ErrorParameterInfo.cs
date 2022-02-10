using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lis.Monitoring.Shared.Errors {
	public class ErrorParameterInfo {
		public long Id { get; set; }
		public string Description { get; set; }
		public string Address { get; set; }
		public string Value { get; set; }
		public string Unit { get; set; }
		public string ErrorType { get; set; }
		public DateTime Timestamp { get; set; }

		public override string ToString() {
			return $"{Description} {Value} {Unit} (Chyba: {ErrorType})";
		}
	}
}
