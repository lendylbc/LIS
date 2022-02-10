using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lis.Monitoring.Domain.Entities;
using Lis.Monitoring.Dto.Communication;
using Lis.Monitoring.Infrastructure;
using Lis.Monitoring.Services.Abstractions;
using Lis.Monitoring.Services.Queries;
using Microsoft.EntityFrameworkCore;

namespace Lis.Monitoring.Services.Entities {
	public class DeviceParameterService : BaseEntityService<DeviceParameter, long, DeviceParameterQuery, DeviceParameterDto>, IDeviceParameterService {
		public DeviceParameterService(DbService dbService) : base(dbService) {
		}

		public override IQueryable<DeviceParameter> EntityFilter(IQueryable<DeviceParameter> query, DeviceParameterQuery filtr) {
			return query.Where(x => x.DeviceId == filtr.DeviceId);
		}

		/// <summary>
		/// Provede změnu pro daný parametr
		/// </summary>
		/// <param name="id">Identifikátor parametru</param>
		/// <param name="data">Data, která mají být změněná</param>
		/// <returns></returns>
		public override async Task<DeviceParameter> UpdateAsync(long id, DeviceParameterDto data) {
			DeviceParameter deviceParam = await EntitySet.SingleOrDefaultAsync(u => u.Id == id);
			if(deviceParam == null) {
				throw new Exception("Parametr nebyl nalezen!");
			}

			deviceParam.Description = data.Description;
			deviceParam.Address = data.Address;
			deviceParam.Unit = data.Unit;			
			deviceParam.Active = data.Active;

			await DbService.SaveChangesAsync();

			return deviceParam;
		}

		/// <summary>
		/// Provede změnu informace o chybě pro daný parametr
		/// </summary>
		/// <param name="id">Identifikátor parametru</param>
		/// <param name="data">Data, která mají být změněná</param>
		/// <returns></returns>
		//public async Task<bool> UpdateErrorInfoAsync(DeviceParameter data) {
		public bool UpdateErrorInfoAsync(DeviceParameter data) {
			DeviceParameter deviceParam = EntitySet.SingleOrDefault(u => u.Id == data.Id);
			if(deviceParam == null) {
				throw new Exception("Parametr nebyl nalezen!");
			}

			deviceParam.ErrorDetected = data.ErrorDetected;
			deviceParam.Notified = data.Notified;

			DbService.SaveChanges();

			return true;
		}
	}
}
