using System.Collections.Generic;

namespace Lis.Monitoring.Dto.Core
{
	/// <summary>
	/// Stránkovaná odpověď pro daný typ
	/// </summary>
	/// <typeparam name="TResponseItem">Typ záznamu, který bude vrácen jako položka seznamu v property Data</typeparam>
	public interface IPagedResponse<TResponseItem>
	{
		/// <summary>
		/// Číslo stránky - indexováno od 0
		/// </summary>
		int Page { get; set; }
		/// <summary>
		/// Počet záznamů na stránce
		/// </summary>
		int Size { get; set; }
		/// <summary>
		/// Počet všech záznamů, které daný dotaz může vrátit
		/// </summary>
		int Total { get; set; }
		/// <summary>
		/// Data příslušná dané stránce
		/// </summary>
		ICollection<TResponseItem> Data { get; set; }
	}
}