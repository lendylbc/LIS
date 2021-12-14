using Lis.Monitoring.Abstractions.Common;

namespace Lis.Monitoring.Services.Queries
{
	public class PagedQuery : IPagedQuery
	{
        /// <summary>
        /// Číslo stránky, kterou chceme zobrazit - indexováno od 0. Default hodnota: 0
        /// </summary>
		public int Page { get; set; } = 0;
        /// <summary>
        /// Počet záznamů na stránce. Default hodnota: 20
        /// </summary>
		public int Size { get; set; } = 20;
	}
}