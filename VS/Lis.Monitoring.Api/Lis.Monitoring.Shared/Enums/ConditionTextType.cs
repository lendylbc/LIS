using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lis.Monitoring.Shared.Enums {
	public enum ConditionTextType {
		[Description("Rovno")]
		Equal = 3,
		[Description("Nerovno")]
		NotEqual = 4	
}
}
