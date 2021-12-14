using System.Collections.Generic;

namespace Lis.Monitoring.Dto.Core
{
	public class PagedResponse<TResponseItem> : IPagedResponse<TResponseItem>
	{
		public int Page { get; set; }
		public int Size { get; set; }
		public int Total { get; set; }
		public ICollection<TResponseItem> Data { get; set; }
	}
}