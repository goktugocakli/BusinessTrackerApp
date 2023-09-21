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
using Microsoft.EntityFrameworkCore;

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

        public (IEnumerable<DailyPlanDto>, MetaData) FindAll(DailyPlanParameters parameters)
        {

            var dailyPlansWithMetaData = _dailyPlanReadRepository.FindAll(parameters, false);

            var dailyPlansDto = _mapper.Map<IEnumerable<DailyPlanDto>>(dailyPlansWithMetaData);

            return (dailyPlansDto, dailyPlansWithMetaData.MetaData);
        }

        public async Task<DailyPlanDto> FindByIdAsync(int id)
        {
            var user = _http.HttpContext?.User;

            var dailyPlan = await GetByIdAndCheckExistAsync(id);

            /*
            if (user.Identity.Name != dailyPlan.Employee.UserName)
                throw new UnauthorizedAccessException("günlük plan size ait değil");

            */
            return _mapper.Map<DailyPlanDto>(dailyPlan);
        }

        private async Task<DailyPlan> GetByIdAndCheckExistAsync(int id)
        {
            DailyPlan? dailyPlan = await _dailyPlanReadRepository.Table
                .Include(d => d.Employee)
                .ThenInclude(e => e.Department)
                .FirstOrDefaultAsync(d => d.Id == id);

            return dailyPlan ?? throw new DailyPlanNotFoundException(id.ToString());    
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

            string? username = _http.HttpContext?.User.Identity?.Name;

            if (dailyPlan.Employee.UserName != username)
                throw new UnauthorizedAccessException("Başka bir kullanıcının günlüğünü değiştirmeye yetkiniz yok.");

            dailyPlan.Header = updateDailyPlanRequest.Header;
            dailyPlan.Description = updateDailyPlanRequest.Description;
            dailyPlan.Date = updateDailyPlanRequest.Date;
            dailyPlan.Status = updateDailyPlanRequest.Status;
            dailyPlan.ResultDescription = updateDailyPlanRequest.ResultDescription;

            _dailyPlanWriteRepository.Update(dailyPlan);
            await _dailyPlanWriteRepository.SaveAsync();
        }

        public async Task DeleteByIdAsync(int id)
        { 
            DailyPlan dailyPlan = await GetByIdAndCheckExistAsync(id);

            string? username = _http.HttpContext?.User.Identity?.Name;

            if (dailyPlan.Employee.UserName != username)
                throw new UnauthorizedAccessException("Başka bir kullanıcının günlüğünü değiştirmeye yetkiniz yok.");

            _dailyPlanWriteRepository.Remove(dailyPlan);
            await _dailyPlanWriteRepository.SaveAsync();
        }


        private async Task<bool> IsDepartmentManager(string department, string username)
        {
            Employee? departmentManager = await _userManager.Users
               .Include(u => u.Department)
               .ThenInclude(d => d.Manager)
               .Where(u => u.Department.Manager.UserName == username && u.Department.Name == department)
               .FirstOrDefaultAsync();

            if (departmentManager is null)
                return false;

            return true;
        }
    }
}

