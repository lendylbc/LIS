using System.Collections.Generic;
using System.Threading.Tasks;
using Lis.Monitoring.Abstractions.Entities;

namespace Lis.Monitoring.Services.Abstractions {
   public interface IBaseEntityService<TEntity, TId, TFilter, TUpdateDto>
       where TEntity : class, IEntity<TId>
       where TId : struct
       where TFilter : class {
      Task<TEntity> GetByIdAsync(TId id);
      TEntity GetById(TId id);
      Task<TEntity> Save(TEntity entity);
      Task<ICollection<TEntity>> GetList(TFilter query);
      Task<TEntity> Update(TId id, TUpdateDto data);
   }
}