using System;
using System.Linq.Expressions;

namespace BusinessTrackerApp.Application.Repositories
{
	public interface IReadRepository<T> : IRepository<T> where T : class
	{
		IQueryable<T> FindAll(bool tracking = false);
		IQueryable<T> FindByCondition(Expression<Func<T, bool>> method, bool tracking = true);
		Task<T?> FindSingleByConditionAsync(Expression<Func<T, bool>> method, bool tracking = true);
		Task<T?> FindByIdAsync(string id);
        Task<T?> FindByIdAsync(int id);
    }
}

