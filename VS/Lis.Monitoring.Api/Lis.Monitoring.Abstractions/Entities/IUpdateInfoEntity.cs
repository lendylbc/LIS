using System;

namespace Lis.Monitoring.Abstractions.Entities
{
	public interface IUpdateInfoEntity<TUzivatelId> : IDatumVytvoreniSourceEntity where TUzivatelId: struct
	{
		//DateTimeOffset? DatumZmena { get; set; }

		//string UzivatelVytvoreni { get; set; }

		//string UzivatelZmena { get; set; }

		//TUzivatelId? UzivatelVytvoreniId { get; set; }

		//TUzivatelId? UzivatelZmenaId { get; set; }
	}
}