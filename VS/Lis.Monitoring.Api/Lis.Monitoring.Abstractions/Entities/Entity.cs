using System;

namespace Lis.Monitoring.Abstractions.Entities
{
	public abstract class Entity : EntityBase<long>, IUpdateInfoEntity<long>
	{
		protected Entity()
		{
			//SetInitialId(Guid.NewGuid());
		}

		//public DateTimeOffset DatumVytvoreni { get; set; }
		//public DateTimeOffset? DatumZmena { get; set; }
		//public string UzivatelVytvoreni { get; set; }

	}
}