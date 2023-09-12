using System;
using BusinessTrackerApp.Domain.Entities;

namespace BusinessTrackerApp.Persistence.Repositories
{
	public static class EmployeeRepositoryExtensions
	{
		public static IQueryable<Employee> FilterEmployee(this IQueryable<Employee> employees, string? departmentName )
		{
			if(!string.IsNullOrWhiteSpace(departmentName))
				return employees.Where(employee => employee.Department.Name.Equals(departmentName));

			return employees;
		}
	}
}

