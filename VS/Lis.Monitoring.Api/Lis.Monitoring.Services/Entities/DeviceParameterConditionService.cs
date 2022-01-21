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
	public class DeviceParameterConditionService : BaseEntityService<DeviceParameterCondition, long, DeviceParameterConditionQuery, DeviceParameterConditionDto>, IDeviceParameterConditionService {
		public DeviceParameterConditionService(DbService dbService) : base(dbService) {
		}

		public override IQueryable<DeviceParameterCondition> EntityFilter(IQueryable<DeviceParameterCondition> query, DeviceParameterConditionQuery filtr) {
			return query.Where(x => x.DeviceParameterId == filtr.DeviceParameterId);
		}

		/// <summary>
		/// Provede změnu pro dané zařízení
		/// </summary>
		/// <param name="id">Identifikátor zařízení</param>
		/// <param name="data">Data, která mají být změněná</param>
		/// <returns></returns>
		public override async Task<DeviceParameterCondition> UpdateAsync(long id, DeviceParameterConditionDto data) {
			DeviceParameterCondition condition = await EntitySet.SingleOrDefaultAsync(u => u.Id == id);
			if(condition == null) {
				throw new Exception("Podmínka nebyla nalezena!");
			}

			condition.Operator = data.Operator;
			condition.Value = data.Value;

			await DbService.SaveChangesAsync();

			return condition;
		}
	}
}
