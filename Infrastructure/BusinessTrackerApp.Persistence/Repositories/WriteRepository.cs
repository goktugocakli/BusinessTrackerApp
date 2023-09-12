using System;
using BusinessTrackerApp.Application.Repositories;
using BusinessTrackerApp.Persistence.Context;
using Microsoft.EntityFrameworkCore;


namespace BusinessTrackerApp.Persistence.Repositories
{
	public class WriteRepository<T> : IWriteRepository<T> where T : class
	{
        private readonly BusinessTrackerDbContext _context;
        public WriteRepository(BusinessTrackerDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public async Task AddAsync(T entity)
        {
            await Table.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await Table.AddRangeAsync(entities);
        }

        public void Remove(T entity)
        {
            Table.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            Table.RemoveRange(entities);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(T entity)
        {
            Table.Update(entity);
        }
    }
}

