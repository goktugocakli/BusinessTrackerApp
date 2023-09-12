using System;
using AutoMapper;
using BusinessTrackerApp.Application.Abstractions.Services;
using BusinessTrackerApp.Application.DTOs.Employee;
using BusinessTrackerApp.Application.Exceptions;
using BusinessTrackerApp.Application.Repositories.Employee;
using BusinessTrackerApp.Application.RequestParameters;
using BusinessTrackerApp.Application.ViewModels.Employee;
using BusinessTrackerApp.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BusinessTrackerApp.Persistence.Services
{
	public class EmployeeService : IEmployeeService
	{
		readonly IEmployeeReadRepository _employeeReadRepository;
		readonly IEmployeeWriteRepository _employeeWriteRepository;
        readonly IMapper _mapper;

        public EmployeeService(IEmployeeReadRepository employeeReadRepository, IEmployeeWriteRepository employeeWriteRepository, IMapper mapper)
        {
            _employeeReadRepository = employeeReadRepository;
            _employeeWriteRepository = employeeWriteRepository;
            _mapper = mapper;
        }

        public (IEnumerable<EmployeeDto> employeeDtos, MetaData metaData) GetAllEmployees(EmployeeParameters parameters)
        {
            var employeesWithMetaData = _employeeReadRepository.FindAll(parameters);

            var employeesDto = _mapper.Map<IEnumerable<EmployeeDto>>(employeesWithMetaData);

            return (employeesDto, employeesWithMetaData.MetaData);
        }

        private async Task<Employee> GetEmployeeByIdAndCheckExist(string id)
        {
            Employee? employee = await _employeeReadRepository.FindByIdAsync(id);
            return employee ?? throw new EmployeeNotFoundException(id);
        }

        public async Task<EmployeeDto> GetEmployeeByIdAsync(string id)
        {
            Employee employee = await GetEmployeeByIdAndCheckExist(id);

            return _mapper.Map<EmployeeDto>(employee);
        }


        public async Task<EmployeeDto> CreateEmployeeAsync(CreateEmployeeRequestVM model)
        {

            Employee employee = new()
            {
                Name = model.Name,
                Mail = model.Mail,
                Phone = model.Phone,
                DepartmentId = Guid.Parse(model.DepartmentId)
            };

            if (model.TeamId is not null)
                employee.TeamId = Guid.Parse(model.TeamId);

            await _employeeWriteRepository.AddAsync(employee);
            await _employeeWriteRepository.SaveAsync();

            return _mapper.Map<EmployeeDto>(employee);
        }

        public async Task UpdateEmployeeAsync(UpdateEmployeeRequestVM request)
        {
            Employee? employee = await _employeeReadRepository.FindByIdAsync(request.Id) ?? throw new EmployeeNotFoundException(request.Id);


            employee.Name = request.Name;
            employee.Mail = request.Mail;
            employee.Phone = request.Phone;
            employee.DepartmentId = Guid.Parse(request.DepartmentId);

            if (request.TeamId is not null)
                employee.TeamId = Guid.Parse(request.TeamId);

            _employeeWriteRepository.Update(employee);
            await _employeeWriteRepository.SaveAsync();

        }

        public async Task DeleteEmployeeAsync(string id)
        {
            Employee? employee = await _employeeReadRepository.FindByIdAsync(id);
            if (employee is not null)
            {
                _employeeWriteRepository.Remove(employee);
                await _employeeWriteRepository.SaveAsync();
            }
        }

        
    }
}

