using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Lis.Monitoring.Domain.Entities;
using Microsoft.IdentityModel.Tokens;

namespace Lis.Monitoring.Api.Authentication {
	public class Auth : IAuthJwt {

		private readonly string key;
		public Auth(string key) {
			this.key = key;
		}
		public string Authenticate(Member member) {
			if(member == null) {
				return null;
			}

			// 1. Create Security Token Handler
			var tokenHandler = new JwtSecurityTokenHandler();

			// 2. Create Private Key to Encrypted
			var tokenKey = Encoding.ASCII.GetBytes(key);

			//3. Create JETdescriptor
			var tokenDescriptor = new SecurityTokenDescriptor() {
				Subject = new ClaimsIdentity(
					  new Claim[]
					  {
							new Claim(ClaimTypes.Name, member.Name),
							new Claim(ClaimTypes.Surname, member.Surname),
							new Claim(ClaimTypes.Email, member.Email)
					  }),
				Expires = DateTime.UtcNow.AddHours(1),
				SigningCredentials = new SigningCredentials(
					  new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
			};
			//4. Create Token
			var token = tokenHandler.CreateToken(tokenDescriptor);

			// 5. Return Token from method
			return tokenHandler.WriteToken(token);
		}
	}
}
