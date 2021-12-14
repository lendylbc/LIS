using Lis.Monitoring.Infrastructure;
using Lis.Monitoring.Services.Abstractions;
using Lis.Monitoring.Domain.Entities;
using Lis.Monitoring.Services.Queries;
using Lis.Monitoring.Dto.Communication;

namespace Lis.Monitoring.Services.Entities {
	public class MemberService : BaseEntityService<Member, long, MemberQuery, MemberDto>, IMemberService {

		public MemberService(DbService dbService) : base(dbService) {
			
		}

		//public async Task<Member> Update(long id, MemberDto data) {
		//	//Uzivatel uzivatel = await EntitySet.SingleOrDefaultAsync(u => u.Id == id);
		//	//if(uzivatel == null) {
		//	//   throw new Exception("Uživatel nebyl nalezen");
		//	//}

		//	//uzivatel.Jmeno = data.Jmeno;
		//	//uzivatel.Prijmeni = data.Prijmeni;
		//	//uzivatel.ZasilatNotifikace = data.ZasilatNotifikace;

		//	//if(!string.IsNullOrEmpty(data.Heslo)) {
		//	//   // check if password is correct
		//	//   if(!PasswordHelper.IsPasswordRight(data.Heslo, uzivatel.HesloHash, Convert.FromBase64String(uzivatel.HesloSul))) {
		//	//      throw new Exception("Současné heslo bylo zadáno špatně");
		//	//   }
		//	//   VygenerovatHashHeslo(uzivatel, data.HesloNove);
		//	//}

		//	//await DbService.SaveChangesAsync();
		//	Member uzivatel = null;
		//	return uzivatel;
		//}
	}
}
