using System;
using BusinessTrackerApp.Application.Repositories.DailyPlan;
using BusinessTrackerApp.Domain.Entities;
using BusinessTrackerApp.Persistence.Context;

namespace BusinessTrackerApp.Persistence.Repositories
{
    public class DailyPlanReadRepoistory : ReadRepository<DailyPlan>, IDailyPlanReadRepository
    {
        public DailyPlanReadRepoistory(BusinessTrackerDbContext context) : base(context)
        {
        }
    }
}

