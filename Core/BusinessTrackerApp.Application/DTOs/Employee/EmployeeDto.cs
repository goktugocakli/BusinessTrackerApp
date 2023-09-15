using System;
using BusinessTrackerApp.Application.DTOs.DailyPlan;

namespace BusinessTrackerApp.Application.DTOs.Employee
{
	public record EmployeeDto
	{
		public string Id { get; init; }
		public string NameSurname { get; init; }
		public string Username { get; set; }
		public string Email { get; init; }
		public string PhoneNumber { get; init; }

	}
}

