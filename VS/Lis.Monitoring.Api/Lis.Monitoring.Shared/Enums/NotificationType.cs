namespace Lis.Monitoring.Shared.Enums {
	/// <summary>
	/// Typy událostí, na které je navázán veškerý messaging
	/// </summary>
	public enum NotificationType
	{
		#region Události pro správu uživatelů

		/// <summary>
		/// Registrace uživatele
		/// </summary>
		MemberRegistrace = 1,
		/// <summary>
		/// Uživatel zažádal o reset hesla
		/// </summary>
		MemberHesloReset = 2,

		#endregion
		/// <summary>
		/// Vyhodnocení podmínky hlídané hodnoty
		/// </summary>
		ValueCondition = 3,
	}
}