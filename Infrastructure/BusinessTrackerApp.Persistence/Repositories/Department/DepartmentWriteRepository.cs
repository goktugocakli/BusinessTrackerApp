using System;
using BusinessTrackerApp.Application.Repositories.Department;
using BusinessTrackerApp.Domain.Entities;
using BusinessTrackerApp.Persistence.Context;

namespace BusinessTrackerApp.Persistence.Repositories
{
    public class DepartmentWriteRepository : WriteRepository<Department>, IDepartmentWriteRepository
    {
        public DepartmentWriteRepository(BusinessTrackerDbContext context) : base(context)
        {
        }
    }
}

