using System;
using System.Linq.Expressions;
using BusinessTrackerApp.Application.Abstractions.Services;
using BusinessTrackerApp.Application.Repositories;

namespace BusinessTrackerApp.Persistence.Services
{
    public class BaseService<T, G> : IBaseService<T, G> where T : class
    {
        private readonly IReadRepository<T> _readRepository;
        private readonly IWriteRepository<T> _writeRepository;

        public BaseService(IReadRepository<T> readRepository, IWriteRepository<T> writeRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }

        public async Task AddAsync(T entity)
        {
            await _writeRepository.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _writeRepository.AddRangeAsync(entities);
        }

        public  Task<IEnumerable<G>> FindAll(bool tracking = false)
        {
            IEnumerable<T> entity = _readRepository.FindAll(tracking).ToList();
            throw new NotImplementedException();

        }

        public Task<G> FindByCondition(Expression<Func<T, bool>> method, bool tracking = true)
        {
            throw new NotImplementedException();
        }

        public Task<G> FindByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<G> FindByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<G> FindSingleByConditionAsync(Expression<Func<T, bool>> method, bool tracking = true)
        {
            throw new NotImplementedException();
        }

        public void Remove(T entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync()
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}

