using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lis.Monitoring.Dto.Communication;

namespace Lis.Monitoring.Dto.Authentication {
	public class MemberTokenDto {
		public MemberDto Member { get; set; }
		public string Token { get; set; }
	}
}
