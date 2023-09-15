using System;
using AutoMapper;
using BusinessTrackerApp.Application.Abstractions.Services;
using BusinessTrackerApp.Application.DTOs.Employee;
using BusinessTrackerApp.Application.Exceptions;
using BusinessTrackerApp.Application.RequestParameters;
using BusinessTrackerApp.Application.ViewModels.Employee;
using BusinessTrackerApp.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using BusinessTrackerApp.Persistence.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BusinessTrackerApp.Persistence.Services
{
	public class EmployeeService : IEmployeeService
	{
        readonly UserManager<Employee> _userManager;
        readonly IMapper _mapper;

        public EmployeeService(IMapper mapper, UserManager<Employee> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }

        public (IEnumerable<EmployeeDto> employeeDtos, MetaData metaData) GetAllEmployees(EmployeeParameters parameters)
        {
            IQueryable<Employee> query = _userManager.Users
                .FilterEmployee(parameters.DepartmentName);

            var employeesWithMetaData = PagedList<Employee>.ToPagedList(query, parameters.PageNumber, parameters.PageSize);

            var employeesDto = _mapper.Map<IEnumerable<EmployeeDto>>(employeesWithMetaData);

            return (employeesDto, employeesWithMetaData.MetaData);
        }

        public async Task<Employee> GetEmployeeByUsernameAndCheckExist(string username)
        {
            Employee? employee = await _userManager.FindByNameAsync(username);
            return employee ?? throw new EmployeeNotFoundException(username);
        }

        public async Task<EmployeeDto> GetEmployeeByUsernameAsync(string username)
        {
            Employee employee = await GetEmployeeByUsernameAndCheckExist(username);
            
            return _mapper.Map<EmployeeDto>(employee);
        }


        public async Task<EmployeeDto> CreateEmployeeAsync(CreateEmployeeRequestVM model)
        {

            Employee employee = new()
            {
                NameSurname = model.NameSurname,
                UserName = model.Username,
                Email = model.Mail,
                PhoneNumber = model.Phone,
                DepartmentId = Guid.Parse(model.DepartmentId)
            };

            if (model.TeamId is not null)
                employee.TeamId = Guid.Parse(model.TeamId);

            IdentityResult result = await _userManager.CreateAsync(employee, model.Password);
            if (result.Succeeded)
                await _userManager.AddToRolesAsync(employee, model.Roles);
                return _mapper.Map<EmployeeDto>(employee);

            throw new Exception("Employee oluşturulurken bir hata ile karşılaşıldı.");
        }

        public async Task UpdateEmployeeAsync(UpdateEmployeeRequestVM request)
        {
            Employee? employee = await GetEmployeeByUsernameAndCheckExist(request.Username);

            employee.NameSurname = request.Name;
            employee.Email = request.Mail;
            employee.UserName = request.Username;
            employee.PhoneNumber = request.Phone;
            employee.DepartmentId = Guid.Parse(request.DepartmentId);

            if (request.TeamId is not null)
                employee.TeamId = Guid.Parse(request.TeamId);

            var result = await _userManager.UpdateAsync(employee);

            if (result.Succeeded)
                return;

            throw new Exception("kullanıcı update edilirken hata oluştu.");

        }

        public async Task DeleteEmployeeAsync(string id)
        {
            IdentityResult result = new();
            
            Employee? employee = await GetEmployeeByUsernameAndCheckExist(id);
            if (employee is not null)
            {
                result = await _userManager.DeleteAsync(employee);
            }

            if (result.Succeeded)
                return;

            throw new Exception("Kullanıcı silinirken hata oluştu.");

        }

        public async Task AssingRole(string userName, ICollection<string> roles)
        {
            Employee? employee = await _userManager.FindByNameAsync(userName);

            if (employee is null)
                throw new EmployeeNotFoundException(userName);
           
            await _userManager.AddToRolesAsync(employee, roles);

        }

        public async Task<EmployeeDetailsDto> FindEmployeeDetailsAsync(string userName)
        {
            EmployeeDetailsDto? emp = await _userManager.Users
                .Where(u => u.UserName == userName)
                .Include(u => u.Department)
                .Include(u => u.Team)
                .Select(u => new EmployeeDetailsDto
                {
                    Id = u.Id,
                    NameSurname = u.NameSurname,
                    Username = u.UserName,
                    Email = u.Email,
                    PhoneNumber = u.PhoneNumber,
                    DepartmentName = u.Department.Name
                })
                .FirstOrDefaultAsync();

            return emp ?? new();

        }
    }
}

