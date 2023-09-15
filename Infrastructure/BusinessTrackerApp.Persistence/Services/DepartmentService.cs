using System;
using AutoMapper;
using BusinessTrackerApp.Application.Abstractions.Services;
using BusinessTrackerApp.Application.DTOs.Employee;
using BusinessTrackerApp.Application.Exceptions;
using BusinessTrackerApp.Application.Repositories.Department;
using BusinessTrackerApp.Application.ViewModels.Department;
using BusinessTrackerApp.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BusinessTrackerApp.Persistence.Services
{
	public class DepartmentService : IDepartmentService
	{
		private readonly IDepartmentWriteRepository _departmentWriteRepository;
        private readonly IDepartmentReadRepository _departmentReadRepository;
        private readonly IEmployeeService _employeeService;

        private readonly IMapper _mapper;

        public DepartmentService(IDepartmentWriteRepository departmentWriteRepository, IDepartmentReadRepository departmentReadRepository,  IMapper mapper, IEmployeeService employeeService)
        {
            _departmentWriteRepository = departmentWriteRepository;
            _departmentReadRepository = departmentReadRepository;
            _mapper = mapper;
            _employeeService = employeeService;
        }


        public IEnumerable<DepartmentResponseVM> FindAll()
        {
            var departmens = _departmentReadRepository.FindAll();
            return _mapper.Map<IEnumerable<DepartmentResponseVM>>(departmens);
        }

        private async Task<Department> GetDepartmentByNameAndCheckExist(string name)
        {
            Department? department = await _departmentReadRepository.Table
                .Include(d => d.Manager)
                .Where(d => d.Name == name)
                .FirstOrDefaultAsync();

            return department ?? throw new DepartmentNotFoundException(name);

        }

        public async Task<DepartmentResponseVM> FindByNameAsync(string name)
        { 
            Department department = await GetDepartmentByNameAndCheckExist(name);

            DepartmentResponseVM response = new DepartmentResponseVM
            {
                Id = department.Id.ToString(),
                Name = department.Name    
            };

            if (department.Manager is not null)
               response.Manager = _mapper.Map<EmployeeDto>(department.Manager);


            return response;

        }

        public async Task CreateDepartmentAsync(CreateDepartmentRequestVM createDepartmentRequest)
        {
            Department? department = await _departmentReadRepository.FindSingleByConditionAsync(d => d.Name == createDepartmentRequest.Name);

            if (department is not null)
                throw new DepartmentNameAlreadyExistException(createDepartmentRequest.Name);

            department = new Department()
            {
                Name = createDepartmentRequest.Name
            };

            if (!string.IsNullOrWhiteSpace(createDepartmentRequest.ManagerUserName))
            {
                EmployeeDto employeeDto = await _employeeService.GetEmployeeByUsernameAsync(createDepartmentRequest.ManagerUserName);
                department.ManagerId = employeeDto.Id;
            }

            await _departmentWriteRepository.AddAsync(department);
            await _departmentWriteRepository.SaveAsync();
        }

        public async Task UpdateDepartmentAsync(UpdateDepartmentRequestVM updateDepartmentRequest)
        {
            Department department = await GetDepartmentByNameAndCheckExist(updateDepartmentRequest.Name);

            department.Name = updateDepartmentRequest.Name;

            if (!string.IsNullOrWhiteSpace(updateDepartmentRequest.ManagerUserName))
            {
                var employeeDto = await _employeeService.GetEmployeeByUsernameAsync(updateDepartmentRequest.ManagerUserName);

                department.ManagerId = employeeDto.Id;
            }
            else
            {
                department.Manager = null;
            }

            _departmentWriteRepository.Update(department);
            await _departmentWriteRepository.SaveAsync();
        }

        public async Task DeleteDepartmentAsync(string idOrName)
        {
            Department? department = await _departmentReadRepository.FindSingleByConditionAsync(d => d.Name == idOrName || d.Id.ToString() == idOrName);

            if(department is not null)
            {
                _departmentWriteRepository.Remove(department);
                await _departmentWriteRepository.SaveAsync();
            }

        }







    }
}

