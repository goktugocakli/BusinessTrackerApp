using System;
using System.Reflection;
using BusinessTrackerApp.Application.Validations.DailyPlans;
using BusinessTrackerApp.Application.Validations.Departments;
using BusinessTrackerApp.Application.Validations.Employees;
using BusinessTrackerApp.Application.Validations.Teams;
using BusinessTrackerApp.Application.ViewModels.DailyPlan;
using BusinessTrackerApp.Application.ViewModels.Department;
using BusinessTrackerApp.Application.ViewModels.Employee;
using BusinessTrackerApp.Application.ViewModels.Team;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessTrackerApp.Application
{
	static public class ServiceRegistration
	{
		public static void AddApplicationServices(this IServiceCollection services)
		{
			services.AddAutoMapper(Assembly.GetExecutingAssembly());

			services.AddScoped<IValidator<CreateEmployeeRequestVM>, CreateEmployeeValidation>();
            services.AddScoped<IValidator<UpdateEmployeeRequestVM>, UpdateEmployeeValidation>();
			services.AddScoped<IValidator<CreateTeamRequestVM>, CreateTeamValidation>();
			services.AddScoped<IValidator<UpdateTeamRequestVM>, UpdateTeamRequestValidation>();
			services.AddScoped<IValidator<CreateDepartmentRequestVM>, CreateDepartmentValidation>();
			services.AddScoped<IValidator<UpdateDepartmentRequestVM>, UpdateDepartmentValidation>();
			services.AddScoped<IValidator<CreateDailyPlanRequestVM>, CreateDailyPlansRequestValidation>();
            services.AddScoped<IValidator<UpdateDailyPlanRequestVM>, UpdateDailyPlansRequestValidation>();


        }
    }
}

