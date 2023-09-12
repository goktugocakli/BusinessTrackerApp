using System;
using BusinessTrackerApp.Application.Abstractions.Services;
using BusinessTrackerApp.Application.Exceptions;
using BusinessTrackerApp.Application.Repositories.DailyPlan;
using BusinessTrackerApp.Application.Repositories.Employee;
using BusinessTrackerApp.Application.RequestParameters;
using BusinessTrackerApp.Application.ViewModels.DailyPlan;
using BusinessTrackerApp.Domain.Entities;

namespace BusinessTrackerApp.Persistence.Services
{
	public class DailyPlanService : IDailyPlanService
	{
		readonly IDailyPlanReadRepository _dailyPlanReadRepository;
        readonly IDailyPlanWriteRepository _dailyPlanWriteRepository;

        readonly IEmployeeReadRepository _employeeReadRepository;

        public DailyPlanService(IDailyPlanWriteRepository dailyPlanWriteRepository, IDailyPlanReadRepository dailyPlanReadRepository, IEmployeeReadRepository employeeReadRepository)
        {
            _dailyPlanWriteRepository = dailyPlanWriteRepository;
            _dailyPlanReadRepository = dailyPlanReadRepository;
            _employeeReadRepository = employeeReadRepository;
        }

        public PagedList<DailyPlan> FindAll(DailyPlanParameters parameters)
        {
            var dailyPlans = _dailyPlanReadRepository.FindByCondition(d => parameters.StartTime <= d.Date && d.Date <= parameters.EndTime);


            if (!string.IsNullOrWhiteSpace(parameters.EmployeeId))
            {
                dailyPlans = dailyPlans.Where(d => d.EmployeeId == Guid.Parse(parameters.EmployeeId));
            }

            if (!string.IsNullOrWhiteSpace(parameters.DepartmentName))
            {
                dailyPlans = dailyPlans.Where(d => d.Employee.Department.Name == parameters.DepartmentName);

                if (!string.IsNullOrWhiteSpace(parameters.TeamName))
                {
                    dailyPlans = dailyPlans.Where(d => d.Employee.Team.Name == parameters.TeamName);
                }
            }

            var response = PagedList<DailyPlan>.ToPagedList(dailyPlans, parameters.PageNumber, parameters.PageSize);

            return response;
        }

        public async Task<DailyPlan> FindByIdAsync(string id)
        {
            return await GetByIdAndCheckExistAsync(id);
        }

        private async Task<DailyPlan> GetByIdAndCheckExistAsync(string id)
        {
            DailyPlan? dailyPlan = await _dailyPlanReadRepository.FindByIdAsync(id);

            return dailyPlan ?? throw new DailyPlanNotFoundException(id);    
        }

        public async Task  CreateDaiyPlanAsync(CreateDailyPlanRequestVM createDailyPlanRequest)
        {
            Employee? employee = await _employeeReadRepository.FindByIdAsync(createDailyPlanRequest.EmployeeId);
            if (employee is null)
                throw new EmployeeNotFoundException(createDailyPlanRequest.EmployeeId);

            await _dailyPlanWriteRepository.AddAsync(new()
            {
                Header = createDailyPlanRequest.Header,
                Description = createDailyPlanRequest.Description,
                Date = createDailyPlanRequest.Date,
                Employee = employee
            });

            await _dailyPlanWriteRepository.SaveAsync();
        }

        public async Task UpdateDailyPlanAsync(UpdateDailyPlanRequestVM updateDailyPlanRequest)
        {
            DailyPlan dailyPlan = await GetByIdAndCheckExistAsync(updateDailyPlanRequest.Id);

            dailyPlan.Header = updateDailyPlanRequest.Header;
            dailyPlan.Description = updateDailyPlanRequest.Description;
            dailyPlan.Date = updateDailyPlanRequest.Date;
            dailyPlan.Status = updateDailyPlanRequest.Status;
            dailyPlan.ResultDescription = updateDailyPlanRequest.ResultDescription;

            _dailyPlanWriteRepository.Update(dailyPlan);
            await _dailyPlanWriteRepository.SaveAsync();
        }

        public async Task DeleteByIdAsync(string id)
        {
            DailyPlan dailyPlan = await GetByIdAndCheckExistAsync(id);

            _dailyPlanWriteRepository.Remove(dailyPlan);
            await _dailyPlanWriteRepository.SaveAsync();
        }
    }
}

