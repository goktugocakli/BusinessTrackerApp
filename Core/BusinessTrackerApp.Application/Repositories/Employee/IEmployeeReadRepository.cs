using System;
using BusinessTrackerApp.Application.RequestParameters;

namespace BusinessTrackerApp.Application.Repositories.Employee
{
	public interface IEmployeeReadRepository : IReadRepository<Domain.Entities.Employee>
    {
        PagedList<Domain.Entities.Employee> FindAll(EmployeeParameters employeeParameters, bool tracking = false);

    }
}

