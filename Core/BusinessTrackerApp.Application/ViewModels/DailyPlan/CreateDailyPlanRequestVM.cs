using System;
namespace BusinessTrackerApp.Application.ViewModels.DailyPlan
{
	public record CreateDailyPlanRequestVM
	{
		public string Header { get; init; }
		public string Description { get; init; }
		public DateTime Date { get; init; }
		public string EmployeeId { get; init; }

	}
}

