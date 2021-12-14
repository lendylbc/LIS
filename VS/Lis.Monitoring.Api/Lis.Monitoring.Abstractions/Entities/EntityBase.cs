using System.ComponentModel.DataAnnotations.Schema;

namespace Lis.Monitoring.Abstractions.Entities
{
	/// <summary>
	/// Bázová třída pro entity
	/// </summary>
	/// <typeparam name="TId">Typ identifikátoru entity</typeparam>
	public abstract class EntityBase<TId> : IEntity<TId>
		where TId : struct
	{
		protected EntityBase()
		{
			IsNew = true;
		}

		TId IEntity<TId>.Id => Id;
		private TId _id;

		[NotMapped]
		public virtual bool IsNew { get; private set; }

		public virtual TId Id
		{
			get => _id;
			set { 
				_id = value; 
				IsNew = false;
			}
		}

		protected virtual void SetInitialId(TId id)
		{
			_id = id;
		}
	}
}