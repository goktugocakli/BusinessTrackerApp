using System;
using BusinessTrackerApp.Application.Repositories.Employee;
using BusinessTrackerApp.Application.RequestParameters;
using BusinessTrackerApp.Domain.Entities;
using BusinessTrackerApp.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace BusinessTrackerApp.Persistence.Repositories
{
    public sealed class EmployeeReadRepository : ReadRepository<Employee>, IEmployeeReadRepository
    {
        public EmployeeReadRepository(BusinessTrackerDbContext context) : base(context)
        {
        }

        public PagedList<Employee> FindAll(EmployeeParameters employeeParameters, bool tracking = false)
        {
            var employees = FindAll(tracking)
                .FilterEmployee(employeeParameters.DepartmentName);

            return PagedList<Employee>
                .ToPagedList(employees,
                employeeParameters.PageNumber,
                employeeParameters.PageSize);


                
        }
    }
}

