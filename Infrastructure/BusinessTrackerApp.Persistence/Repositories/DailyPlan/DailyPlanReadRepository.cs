using System;
using BusinessTrackerApp.Application.Repositories.DailyPlan;
using BusinessTrackerApp.Application.RequestParameters;
using BusinessTrackerApp.Domain.Entities;
using BusinessTrackerApp.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace BusinessTrackerApp.Persistence.Repositories
{
    public class DailyPlanReadRepoistory : ReadRepository<DailyPlan>, IDailyPlanReadRepository
    {
        public DailyPlanReadRepoistory(BusinessTrackerDbContext context) : base(context)
        {

        }

        public PagedList<DailyPlan> FindAll(DailyPlanParameters parameters, bool tracking = false)
        {
            var DailyPlans = Table
                .Include(p => p.Employee)
                .FilterDailyPlan(parameters)
                .OrderByDescending(d => d.Date);

            return PagedList<DailyPlan>.
                ToPagedList(DailyPlans,
                parameters.PageNumber,
                parameters.PageSize);
        }
    }
}

