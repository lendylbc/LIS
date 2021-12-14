using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;

namespace Lis.Monitoring.Api.Authentication {
	public class Auth : IAuthJwt {
		private readonly string username = "Tom";
		private readonly string password = "Lendy";
		private readonly string key;
		public Auth(string key) {
			this.key = key;
		}
		public string Authenticate(string username, string password) {
			if(!(username.Equals(username) || password.Equals(password))) {
				return null;
			}

			//var member = EntityService.Authenticate(userDto.Email, userDto.Heslo);

			//if(member == null){
			//	return BadRequest(new { message = "Uživatelské jméno nebo helso bylo zadáno špatně" });
			//}

			// 1. Create Security Token Handler
			var tokenHandler = new JwtSecurityTokenHandler();

			// 2. Create Private Key to Encrypted
			var tokenKey = Encoding.ASCII.GetBytes(key);

			//3. Create JETdescriptor
			var tokenDescriptor = new SecurityTokenDescriptor() {
				Subject = new ClaimsIdentity(
					  new Claim[]
					  {
								new Claim(ClaimTypes.Name, username)
					//			new Claim(ClaimTypes.GivenName, user.Jmeno),
					//new Claim(ClaimTypes.Surname, user.Prijmeni),
					//new Claim(ClaimTypes.Email, user.Email),
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
