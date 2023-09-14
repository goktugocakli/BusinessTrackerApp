using System;
using BusinessTrackerApp.Application.Repositories.DailyPlan;
using BusinessTrackerApp.Application.RequestParameters;
using BusinessTrackerApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BusinessTrackerApp.Persistence.Repositories
{
	public static class DailyPlanRepositoryExtension
	{
		public static IQueryable<DailyPlan> FilterDailyPlan(this IQueryable<DailyPlan> dailyPlans, DailyPlanParameters parameters)
		{
            dailyPlans = dailyPlans.Where(d => parameters.StartTime <= d.Date && d.Date <= parameters.EndTime);

            if (!string.IsNullOrWhiteSpace(parameters.EmployeeUserName))
            {
                dailyPlans = dailyPlans.Where(d => d.Employee.UserName == parameters.EmployeeUserName);
            }

            if (!string.IsNullOrWhiteSpace(parameters.DepartmentName))
            {
                dailyPlans = dailyPlans.Where(d => d.Employee.Department.Name == parameters.DepartmentName);

                if (!string.IsNullOrWhiteSpace(parameters.TeamName))
                {
                    dailyPlans = dailyPlans.Where(d => d.Employee.Team.Name.Equals(parameters.TeamName));
                }
            }

            return dailyPlans;
        }
	}
}

