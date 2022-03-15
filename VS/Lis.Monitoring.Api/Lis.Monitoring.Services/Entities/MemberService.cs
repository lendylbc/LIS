using Lis.Monitoring.Infrastructure;
using Lis.Monitoring.Services.Abstractions;
using Lis.Monitoring.Domain.Entities;
using Lis.Monitoring.Services.Queries;
using Lis.Monitoring.Dto.Communication;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;

namespace Lis.Monitoring.Services.Entities {
	public class MemberService : BaseEntityService<Member, long, MemberQuery, MemberDto>, IMemberService {

		public MemberService(DbService dbService) : base(dbService) {
			
		}

		public Member GetByCredentials(string login, string password) {
			Task<Member> entity = EntitySet.SingleOrDefaultAsync(x => x.Login.Equals(login) && x.Password.Equals(password));
			return entity.Result;			
		}

		/// <summary>
		/// Provede změnu pro daného uživatele
		/// </summary>
		/// <param name="id">Identifikátor uživatele</param>
		/// <param name="data">Data, která mají být změněná</param>
		/// <returns></returns>
		public override async Task<Member> UpdateAsync(long id, MemberDto data) {
			Member member = await EntitySet.SingleOrDefaultAsync(u => u.Id == id);
			if(member == null) {
				throw new Exception("Zařízení nebylo nalezeno!");
			}

			member.Name = data.Name;
			member.Surname = data.Surname;
			member.Email = data.Email;
			member.Phone = data.Phone;
			member.Login = data.Login;
			member.Password = data.Password;
			member.MemberType = data.MemberType;
			member.SendNotifications = data.SendNotifications;
			member.Active = data.Active;

			await DbService.SaveChangesAsync();

			return member;
		}
	}
}
