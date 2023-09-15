using System;
using BusinessTrackerApp.Application.DTOs.Employee;
using BusinessTrackerApp.Application.RequestParameters;
using BusinessTrackerApp.Application.ViewModels.Employee;
using BusinessTrackerApp.Domain.Entities;

namespace BusinessTrackerApp.Application.Abstractions.Services
{
	public interface IEmployeeService 
	{
        (IEnumerable<EmployeeDto> employeeDtos, MetaData metaData) GetAllEmployees(EmployeeParameters parameters);

		Task<EmployeeDto> GetEmployeeByUsernameAsync(string username);

		Task<EmployeeDto> CreateEmployeeAsync(CreateEmployeeRequestVM model);

		Task UpdateEmployeeAsync(UpdateEmployeeRequestVM request);
        Task DeleteEmployeeAsync(string id);
        Task AssingRole(string userName, ICollection<string> roles);

		Task<EmployeeDetailsDto> FindEmployeeDetailsAsync(string userName);

		Task<Employee> GetEmployeeByUsernameAndCheckExist(string username);

    }
}

