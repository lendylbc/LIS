using System;

namespace Lis.Monitoring.Shared.Enums {
	[Flags]
	public enum SablonaTyp
	{
		Email = 1<<0,
		Notifikace = 1<<1,
		Sms = 1<<2,
	}
}