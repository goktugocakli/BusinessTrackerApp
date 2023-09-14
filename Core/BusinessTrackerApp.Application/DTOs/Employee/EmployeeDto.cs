using System;
using BusinessTrackerApp.Application.DTOs.DailyPlan;

namespace BusinessTrackerApp.Application.DTOs.Employee
{
	public record EmployeeDto
	{
		public Guid Id { get; init; }
		public string NameSurname { get; init; }
		public string Username { get; set; }
		public string Email { get; init; }
		public string PhoneNumber { get; init; }
		public string DepartmentId { get; init; }
		public string TeamId { get; init; }

	}
}

