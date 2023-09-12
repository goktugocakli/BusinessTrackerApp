using System;
using BusinessTrackerApp.Application.Repositories;
using BusinessTrackerApp.Application.Repositories.Employee;
using BusinessTrackerApp.Domain.Entities;
using BusinessTrackerApp.Persistence.Context;

namespace BusinessTrackerApp.Persistence.Repositories
{
    public class EmployeeWriteRepository : WriteRepository<Employee>, IEmployeeWriteRepository
    {
        public EmployeeWriteRepository(BusinessTrackerDbContext context) : base(context)
        {
        }
    }
}

