using System;
namespace BusinessTrackerApp.Application.ViewModels.DailyPlan
{
	public record CreateDailyPlanRequestVM
	{
		public string Header { get; init; }
		public string Description { get; init; }
		public DateOnly Date { get; init; }

	}
}

