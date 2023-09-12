using System;
using System.Linq.Expressions;

namespace BusinessTrackerApp.Application.Abstractions.Services
{
	public interface IBaseService<T, G> 
	{
        Task<IEnumerable<G>> FindAll(bool tracking = false);
        Task<G> FindByCondition(Expression<Func<T, bool>> method, bool tracking = true);
        Task<G> FindSingleByConditionAsync(Expression<Func<T, bool>> method, bool tracking = true);
        Task<G> FindByIdAsync(string id);
        Task<G> FindByIdAsync(int id);
        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
        void Update(T entity);
        Task SaveAsync();
    }
}

