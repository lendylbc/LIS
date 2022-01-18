using System.Collections.Generic;
using System.Threading.Tasks;
using Lis.Monitoring.Abstractions.Entities;

namespace Lis.Monitoring.Services.Abstractions {
   public interface IBaseEntityService<TEntity, TId, TFilter, TUpdateDto>
       where TEntity : class, IEntity<TId>
       where TId : struct
       where TFilter : class {
      TEntity GetById(TId id);
      TEntity Save(TEntity entity);
      Task<TEntity> GetByIdAsync(TId id);      
      Task<TEntity> SaveAsync(TEntity entity);
      Task<ICollection<TEntity>> GetListAsync(TFilter query);
      Task<TEntity> UpdateAsync(TId id, TUpdateDto data);
      Task<TEntity> DeleteAsync(TId id);
   }
}