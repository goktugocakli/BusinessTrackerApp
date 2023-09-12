using System;
namespace BusinessTrackerApp.Application.Repositories
{
	public interface IWriteRepository<T> : IRepository<T> where T : class
	{
		Task AddAsync(T entity);
		Task AddRangeAsync(IEnumerable<T> entities);
		void Remove(T entity);
		void RemoveRange(IEnumerable<T> entities);
		
		void Update(T entity);

		Task SaveAsync();
	}
}

