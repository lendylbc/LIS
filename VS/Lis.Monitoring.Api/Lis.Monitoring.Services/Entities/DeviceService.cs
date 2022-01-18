using Lis.Monitoring.Infrastructure;
using Lis.Monitoring.Services.Abstractions;
using Lis.Monitoring.Dto.Core;
using Lis.Monitoring.Domain.Entities;
using Lis.Monitoring.Services.Queries;
using Lis.Monitoring.Dto.Communication;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Lis.Monitoring.Services.Entities {
	public class DeviceService : BaseEntityService<Device, long, DeviceQuery, DeviceDto>, IDeviceService {

		public DeviceService(DbService dbService) : base(dbService) {
		}

		public IEnumerable<Device> GetAllDevicesWithParams(int deviceType) {
			var devices = EntitySet.Where(x => x.Active && x.DeviceType == deviceType)
				 .Include(d => d.DeviceParameter);

			return devices;
		}

		public async Task<IEnumerable<ActiveDeviceLastData>> GetAllActiveDevicesWithLastData() {
			DbSet<ActiveDeviceLastData> lastDataSet = DbService.Set<ActiveDeviceLastData>();

			return await lastDataSet.ToListAsync();
		}

		/// <summary>
		/// Provede změnu pro daného uživatele
		/// </summary>
		/// <param name="id">Identifikátor uživatele</param>
		/// <param name="data">Data, která mají být změněná</param>
		/// <returns></returns>
		public override async Task<Device> UpdateAsync(long id, DeviceDto data) {
			Device device = await EntitySet.SingleOrDefaultAsync(u => u.Id == id);
			if(device == null) {
				throw new Exception("Zařízení nebylo nalezeno!");
			}

			device.Description = data.Description;
			device.IpAddress = data.IpAddress;
			device.Port = data.Port;
			device.DeviceType = data.DeviceType;
			device.Active = data.Active;

			await DbService.SaveChangesAsync();

			return device;
		}
	}
}
