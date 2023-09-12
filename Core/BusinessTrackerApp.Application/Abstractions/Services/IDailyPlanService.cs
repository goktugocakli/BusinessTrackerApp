using System;
using BusinessTrackerApp.Application.RequestParameters;
using BusinessTrackerApp.Application.ViewModels.DailyPlan;
using BusinessTrackerApp.Domain.Entities;

namespace BusinessTrackerApp.Application.Abstractions.Services
{
	public interface IDailyPlanService
	{
        PagedList<DailyPlan> FindAll(DailyPlanParameters parameters);

        Task<DailyPlan> FindByIdAsync(string id);

        Task CreateDaiyPlanAsync(CreateDailyPlanRequestVM createDailyPlanRequest);

        Task UpdateDailyPlanAsync(UpdateDailyPlanRequestVM updateDailyPlanRequest);

        Task DeleteByIdAsync(string id);

    }
}

