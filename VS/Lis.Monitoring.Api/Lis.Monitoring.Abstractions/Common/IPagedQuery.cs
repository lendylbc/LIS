namespace Lis.Monitoring.Abstractions.Common
{
	public interface IPagedQuery
	{
		/// <summary>
		/// Číslo stránky - indexováno od 0
		/// </summary>
		int Page { get; set; }
		/// <summary>
		/// Počet záznamů na stranu
		/// </summary>
		int Size { get; set; }
	}
}