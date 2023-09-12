using System;
using BusinessTrackerApp.Application.DTOs.DailyPlan;

namespace BusinessTrackerApp.Application.DTOs.Employee
{
	public class EmployeeDetailsDto
	{
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }
        public string Phone { get; set; }
        public string Department { get; set; }
        public string Team { get; set; }
        public List<DailyPlanDto> DailyPlanDtos { get; set; }
    }
}

