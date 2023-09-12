using System;
namespace BusinessTrackerApp.Application.DTOs.DailyPlan
{
	public record DailyPlanDto
	{
		public Guid Id { get; set; }
		public string Header { get; set; }
		public string Description { get; set; }
		public DateTime Date { get; set; }
		public string Status { get; set; }
		public string ResultDescription { get; set; }


	}
}

