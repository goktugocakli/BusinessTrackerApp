using AutoMapper;
using BusinessTrackerApp.Application.Abstractions.Services;
using BusinessTrackerApp.Application.DTOs.DailyPlan;
using BusinessTrackerApp.Application.Exceptions;
using BusinessTrackerApp.Application.Repositories.DailyPlan;
using BusinessTrackerApp.Application.RequestParameters;
using BusinessTrackerApp.Application.ViewModels.DailyPlan;
using BusinessTrackerApp.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace BusinessTrackerApp.Persistence.Services
{
	public class DailyPlanService : IDailyPlanService
	{
        private readonly IHttpContextAccessor _http;
		readonly IDailyPlanReadRepository _dailyPlanReadRepository;
        readonly IDailyPlanWriteRepository _dailyPlanWriteRepository;
        readonly UserManager<Employee> _userManager;

        readonly IMapper _mapper;

        public DailyPlanService(IDailyPlanWriteRepository dailyPlanWriteRepository, IDailyPlanReadRepository dailyPlanReadRepository, IMapper mapper, UserManager<Employee> userManager, IHttpContextAccessor http)
        {
            _dailyPlanWriteRepository = dailyPlanWriteRepository;
            _dailyPlanReadRepository = dailyPlanReadRepository;
            _mapper = mapper;
            _userManager = userManager;
            _http = http;
        }

        public IEnumerable<DailyPlanDto> FindAll(DailyPlanParameters parameters)
        {
            var response = _dailyPlanReadRepository.FindAll(parameters, false);

            return _mapper.Map<IEnumerable<DailyPlanDto>>(response);
            
        }

        public async Task<DailyPlanDto> FindByIdAsync(string id)
        {
            var dailyPlan = await GetByIdAndCheckExistAsync(id);
            return _mapper.Map<DailyPlanDto>(dailyPlan);
        }

        private async Task<DailyPlan> GetByIdAndCheckExistAsync(string id)
        {
            DailyPlan? dailyPlan = await _dailyPlanReadRepository.FindByIdAsync(id);

            return dailyPlan ?? throw new DailyPlanNotFoundException(id);    
        }

        public async Task  CreateDaiyPlanAsync(CreateDailyPlanRequestVM createDailyPlanRequest)
        {
            string? userName = _http.HttpContext?.User.Identity?.Name;

            Employee? employee = await _userManager.FindByNameAsync(userName!);
            if (employee is null)
                throw new EmployeeNotFoundException(userName!);

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

