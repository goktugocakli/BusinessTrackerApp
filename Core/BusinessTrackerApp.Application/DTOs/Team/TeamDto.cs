using System;
using BusinessTrackerApp.Application.DTOs.Employee;
using BusinessTrackerApp.Domain.Entities;

namespace BusinessTrackerApp.Application.DTOs.Team
{
	public record TeamDto
	{
        public int Id { get; set; }
        public string Name { get; init; }
        public string DepartmentName { get; init; }

        public EmployeeDto? Leader { get; init; }
       
    }
}

