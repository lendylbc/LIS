using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lis.Monitoring.Domain.Entities;

namespace Lis.Monitoring.Api.Authentication {
	public interface IAuthJwt {
		string Authenticate(Member member);
	}
}
