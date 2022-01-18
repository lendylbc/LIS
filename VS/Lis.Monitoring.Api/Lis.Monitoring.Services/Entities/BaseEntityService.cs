using System;
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

		public virtual TEntity GetById(TId id) {
			TEntity entity = EntitySet.SingleOrDefault(x => x.Id.Equals(id));
			return entity;
		}
		public virtual TEntity Save(TEntity entity) {
			EntitySet.Add(entity);
			DbService.SaveChanges();
			return entity;
		}

		public virtual async Task<TEntity> GetByIdAsync(TId id) {
			TEntity entity = await EntitySet.SingleOrDefaultAsync(x => x.Id.Equals(id));
			return entity;
		}

		public virtual async Task<TEntity> SaveAsync(TEntity entity) {
			EntitySet.Add(entity);
			await DbService.SaveChangesAsync();
			return entity;
		}

		public virtual async Task<ICollection<TEntity>> GetListAsync(TFilter query) {
			IQueryable<TEntity> queryable = EntitySet;

			queryable = EntityFilter(queryable, query);

			if(query.Size > 0) {
				queryable = queryable.Skip(query.Page * query.Size)
					.Take(query.Size);
			}

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

		public virtual Task<TEntity> UpdateAsync(TId id, TUpdateDto data) {
			throw new System.NotImplementedException();
		}

		public virtual async Task<TEntity> DeleteAsync(TId id) {
			var entity = await GetByIdAsync(id);

			if(entity == null) {
				throw new Exception($"Id = {id} nebylo nenalezeno!");
			}

			EntitySet.Remove(entity);

			await DbService.SaveChangesAsync();
			return entity;
		}

	}
}