using System;
using BusinessTrackerApp.Application.DTOs.DailyPlan;
using BusinessTrackerApp.Application.RequestParameters;
using BusinessTrackerApp.Application.ViewModels.DailyPlan;

namespace BusinessTrackerApp.Application.Abstractions.Services
{
	public interface IDailyPlanService
	{
        (IEnumerable<DailyPlanDto> dailyPlans, MetaData metaData) FindAll(DailyPlanParameters parameters);

        Task<DailyPlanDto> FindByIdAsync(int id);

        Task CreateDaiyPlanAsync(CreateDailyPlanRequestVM createDailyPlanRequest);

        Task UpdateDailyPlanAsync(UpdateDailyPlanRequestVM updateDailyPlanRequest);

        Task DeleteByIdAsync(int id);

    }
}

