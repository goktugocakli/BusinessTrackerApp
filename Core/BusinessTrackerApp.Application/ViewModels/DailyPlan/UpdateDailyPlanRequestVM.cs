using System;
using BusinessTrackerApp.Domain.Entities;

namespace BusinessTrackerApp.Application.ViewModels.DailyPlan
{
	public record UpdateDailyPlanRequestVM
	{
        public int Id { get; set; }
        public string Header { get; init; }
        public string Description { get; init; }
        public DateOnly Date { get; init; }
        
        public Status Status { get; init; }
        public string? ResultDescription { get; set; }

    }
}

