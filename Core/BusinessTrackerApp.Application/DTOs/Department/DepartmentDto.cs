using System;
using BusinessTrackerApp.Application.DTOs.Employee;

namespace BusinessTrackerApp.Application.DTOs.Department
{
	public record DepartmentDto
	{
        public string Id { get; init; }
        public string Name { get; init; }
        public EmployeeDto Manager { get; init; }
    }
}

