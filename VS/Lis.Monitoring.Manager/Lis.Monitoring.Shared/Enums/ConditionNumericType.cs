using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lis.Monitoring.Shared.Enums {
	public enum ConditionNumericType {
		//NoValue = 0,
		[Description("Větší než")]
		Greater = 1,
		[Description("Menší než")]
		Smaller = 2,
		[Description("Rovno")]
		Equal = 3,
		[Description("Nerovno")]
		NotEqual = 4
	}
}
