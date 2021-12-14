using Lis.Monitoring.Infrastructure;
using Lis.Monitoring.Services.Abstractions;
using Lis.Monitoring.Dto.Core;
using Lis.Monitoring.Domain.Entities;
using Lis.Monitoring.Services.Queries;
using Lis.Monitoring.Dto.Communication;

namespace Lis.Monitoring.Services.Entities {
	public class DeviceService : BaseEntityService<Device, long, DeviceQuery, DeviceDto>, IDeviceService {

		public DeviceService(DbService dbService) : base(dbService) {
																 //_DeviceService = DeviceService;
		}

		//public async Task<Device> Update(long id, DeviceDto data) {
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
		//	Device uzivatel = null;
		//	return uzivatel;
		//} 
	}
}
