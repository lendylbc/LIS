using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lis.Monitoring.Api.Authentication {
	public interface IAuthJwt {
		string Authenticate(string username, string password);
	}
}
