using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lis.Monitoring.Abstractions.Common;
using Lis.Monitoring.Abstractions.Entities;
using Lis.Monitoring.Infrastructure;
using Lis.Monitoring.Services.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Lis.Monitoring.Services.Entities {
	public abstract class BaseEntityService<TEntity, TId, TFilter, TUpdateDto> : IBaseEntityService<TEntity, TId, TFilter, TUpdateDto>
		 where TEntity : class, IEntity<TId>
		where TId : struct
		where TFilter : class, IPagedQuery {
		protected readonly DbService DbService;
		protected readonly DbSet<TEntity> EntitySet;

		protected BaseEntityService(DbService dbService) {
			DbService = dbService;
			EntitySet = DbService.Set<TEntity>();
		}

		public virtual async Task<TEntity> GetByIdAsync(TId id) {
			TEntity entity = await EntitySet.SingleOrDefaultAsync(x => x.Id.Equals(id));
			return entity;
		}

		public virtual TEntity GetById(TId id) {
			TEntity entity = EntitySet.SingleOrDefault(x => x.Id.Equals(id));
			return entity;
		}

		public virtual async Task<TEntity> Save(TEntity entity) {
			EntitySet.Add(entity);
			await DbService.SaveChangesAsync();
			return entity;
		}

		public virtual async Task<ICollection<TEntity>> GetList(TFilter query) {
			IQueryable<TEntity> queryable = EntitySet
				.Skip(query.Page * query.Size)
				.Take(query.Size);

			queryable = EntityFilter(queryable, query);

			var entities = await queryable
				.ToListAsync();

			return entities;
		}

		/// <summary>
		/// Implementace filtrování nad entitou
		/// </summary>
		/// <param name="query"></param>
		/// <param name="filtr">Filtr pro danou entitu</param>
		/// <returns></returns>
		public virtual IQueryable<TEntity> EntityFilter(IQueryable<TEntity> query, TFilter filtr) {
			return query;
		}

		public virtual Task<TEntity> Update(TId id, TUpdateDto data) {
			throw new System.NotImplementedException();
		}

	}
}