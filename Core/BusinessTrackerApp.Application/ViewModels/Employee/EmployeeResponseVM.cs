using System;
using BusinessTrackerApp.Application.DTOs.DailyPlan;
using BusinessTrackerApp.Application.DTOs.Employee;

namespace BusinessTrackerApp.Application.ViewModels.Employee
{
	public record EmployeeResponseVM
	{
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }
        public string Phone { get; set; }

        public string DepartmentId { get; set; }
        public string TeamId { get; set; }
        public List<DailyPlanDto> DailyPlanDtos { get; set; }

    }
}

