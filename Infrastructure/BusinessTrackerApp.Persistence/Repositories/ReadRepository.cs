using System;
using System.Linq.Expressions;
using BusinessTrackerApp.Application.Repositories;
using BusinessTrackerApp.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace BusinessTrackerApp.Persistence.Repositories
{
	public class ReadRepository<T> : IReadRepository<T> where T : class 
	{
        private readonly BusinessTrackerDbContext _context;

		public ReadRepository(BusinessTrackerDbContext context)
		{
            _context = context;
		}

        public DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> FindAll(bool tracking = false)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();
            return query;
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> method, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query=query.AsNoTracking();

            return query.Where(method);
        }

        public async Task<T?> FindByIdAsync(string id)
        {
            return await Table.FindAsync(id);
            
        }

        public async Task<T?> FindByIdAsync(int id)
        {
            return await Table.FindAsync(id);

        }

        public async Task<T?> FindSingleByConditionAsync(Expression<Func<T, bool>> method, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query.AsNoTracking();
            return await query.FirstOrDefaultAsync(method);
        }



        
    }
}

