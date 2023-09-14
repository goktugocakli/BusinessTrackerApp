using System;
namespace BusinessTrackerApp.Application.DTOs.DailyPlan
{
	public record DailyPlanDto
	{
		public string Id { get; set; }
		public string Header { get; set; }
		public string Description { get; set; }
		public DateOnly Date { get; set; }
		public string Status { get; set; }
		public string ResultDescription { get; set; }
		public string EmployeeId { get; set; }
	}
}

