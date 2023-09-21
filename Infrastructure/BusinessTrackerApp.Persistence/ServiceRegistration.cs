using System;
using BusinessTrackerApp.Persistence.Context;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using BusinessTrackerApp.Persistence.Repositories;
using BusinessTrackerApp.Application.Repositories.Department;
using BusinessTrackerApp.Application.Repositories.Team;
using BusinessTrackerApp.Application.Repositories.DailyPlan;
using BusinessTrackerApp.Application.Abstractions.Services;
using BusinessTrackerApp.Persistence.Services;
using Microsoft.AspNetCore.Identity;
using BusinessTrackerApp.Domain.Entities;

namespace BusinessTrackerApp.Persistence
{
	public static class ServiceRegistration
	{
		public static void AddPersistanceServices(this IServiceCollection service)
		{
			service.AddDbContext<BusinessTrackerDbContext>(options =>
				options.UseNpgsql(Configurations.ConnectionString));


			service.AddIdentity<Employee, IdentityRole>(opts =>
			{
				opts.Password.RequireDigit = false;
				opts.Password.RequireLowercase = false;
				opts.Password.RequireUppercase = false;
				opts.Password.RequireNonAlphanumeric = false;
				opts.Password.RequiredLength = 3;

				opts.User.RequireUniqueEmail = true;
				
			})
				.AddEntityFrameworkStores<BusinessTrackerDbContext>()
				.AddDefaultTokenProviders();


			service.AddScoped<IDepartmentReadRepository, DepartmentReadRepository>();
			service.AddScoped<IDepartmentWriteRepository, DepartmentWriteRepository>();
			service.AddScoped<ITeamReadRepository, TeamReadRepository>();
			service.AddScoped<ITeamWriteRepository, TeamWriteRepository>();
			service.AddScoped<IDailyPlanReadRepository, DailyPlanReadRepoistory>();
			service.AddScoped<IDailyPlanWriteRepository, DailyPlanWriteRepository>();

			service.AddScoped<IEmployeeService, EmployeeService>();
			service.AddScoped<ITeamService, TeamService>();
			service.AddScoped<IDepartmentService, DepartmentService>();
			service.AddScoped<IDailyPlanService, DailyPlanService>();
			service.AddScoped<IAuthenticationService, AuthenticationService>();

		}
	}
}

