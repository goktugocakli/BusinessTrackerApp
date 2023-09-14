using System;
using BusinessTrackerApp.Application.DTOs.DailyPlan;

namespace BusinessTrackerApp.Application.DTOs.Employee
{
	public class EmployeeDetailsDto
	{
        public string Id { get; set; }
        public string NameSurname { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string DepartmentName { get; set; }
        public string? TeamName { get; set; }
        public List<DailyPlanDto> DailyPlanDtos { get; set; }
    }
}

