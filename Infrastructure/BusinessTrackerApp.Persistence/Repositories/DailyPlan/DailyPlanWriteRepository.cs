using System;
using BusinessTrackerApp.Application.Repositories.DailyPlan;
using BusinessTrackerApp.Domain.Entities;
using BusinessTrackerApp.Persistence.Context;

namespace BusinessTrackerApp.Persistence.Repositories
{
    public class DailyPlanWriteRepository : WriteRepository<DailyPlan>, IDailyPlanWriteRepository
    {
        public DailyPlanWriteRepository(BusinessTrackerDbContext context) : base(context)
        {
        }
    }
}

