using System;
namespace BusinessTrackerApp.Application.RequestParameters
{
	public class PagedList <T> : List<T>
	{
		public MetaData MetaData { get; set; }

		public PagedList(List<T> items, int count, int pageNumber,int pageSize)
		{
			MetaData = new()
			{
				TotalCount = count,
				PageSize = pageSize,
				CurrentPage = pageNumber,
				TotalPage = (int)Math.Ceiling(count / (double)pageSize)
			};

			AddRange(items);
		}

		public static PagedList<T> ToPagedList(IQueryable<T> source, int pageNumber, int pageSize)
		{
			var count = source.Count();
			var item = source
				.Skip((pageNumber - 1) * pageSize)
				.Take(pageSize)
				.ToList();

			return new PagedList<T>(item, count, pageNumber, pageSize);
		}


	}
}

