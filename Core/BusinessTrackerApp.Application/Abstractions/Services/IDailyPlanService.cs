using System;
using BusinessTrackerApp.Application.DTOs.DailyPlan;
using BusinessTrackerApp.Application.RequestParameters;
using BusinessTrackerApp.Application.ViewModels.DailyPlan;

namespace BusinessTrackerApp.Application.Abstractions.Services
{
	public interface IDailyPlanService
	{
        IEnumerable<DailyPlanDto> FindAll(DailyPlanParameters parameters);

        Task<DailyPlanDto> FindByIdAsync(string id);

        Task CreateDaiyPlanAsync(CreateDailyPlanRequestVM createDailyPlanRequest);

        Task UpdateDailyPlanAsync(UpdateDailyPlanRequestVM updateDailyPlanRequest);

        Task DeleteByIdAsync(string id);

    }
}

