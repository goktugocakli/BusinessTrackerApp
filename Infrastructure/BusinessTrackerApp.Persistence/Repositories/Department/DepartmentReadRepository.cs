using System;
using BusinessTrackerApp.Application.Repositories.Department;
using BusinessTrackerApp.Domain.Entities;
using BusinessTrackerApp.Persistence.Context;

namespace BusinessTrackerApp.Persistence.Repositories
{
    public class DepartmentReadRepository : ReadRepository<Department>, IDepartmentReadRepository
    {
        public DepartmentReadRepository(BusinessTrackerDbContext context) : base(context)
        {
        }
    }
}

