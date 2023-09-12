using System;
using BusinessTrackerApp.Application.DTOs.DailyPlan;

namespace BusinessTrackerApp.Application.DTOs.Employee
{
	public record EmployeeDto
	{
		public Guid Id { get; init; }
		public string Name { get; init; }
		public string Mail { get; init; }
		public string Phone { get; init; }
		public string DepartmentId { get; init; }
		public string TeamId { get; init; }

	}
}

