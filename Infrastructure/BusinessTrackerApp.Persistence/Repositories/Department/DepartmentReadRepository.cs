using System;
using System.Linq.Expressions;
using BusinessTrackerApp.Application.Repositories.Department;
using BusinessTrackerApp.Domain.Entities;
using BusinessTrackerApp.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace BusinessTrackerApp.Persistence.Repositories
{
    public class DepartmentReadRepository : ReadRepository<Department>, IDepartmentReadRepository
    {
        public DepartmentReadRepository(BusinessTrackerDbContext context) : base(context)
        {
        }

        
    }
}

