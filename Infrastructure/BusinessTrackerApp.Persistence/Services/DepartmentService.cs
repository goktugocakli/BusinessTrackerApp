using System;
using AutoMapper;
using BusinessTrackerApp.Application.Abstractions.Services;
using BusinessTrackerApp.Application.DTOs.Department;
using BusinessTrackerApp.Application.Exceptions;
using BusinessTrackerApp.Application.Exceptions.ConflictExceptions;
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
        private readonly UserManager<Employee> _employeeManager;

        private readonly IMapper _mapper;

        public DepartmentService(IDepartmentWriteRepository departmentWriteRepository,
            IDepartmentReadRepository departmentReadRepository,
            IMapper mapper,
            UserManager<Employee> employeeManager)
        {
            _departmentWriteRepository = departmentWriteRepository;
            _departmentReadRepository = departmentReadRepository;
            _mapper = mapper;
            _employeeManager = employeeManager;
        }


        public IEnumerable<DepartmentDto> FindAll()
        {
            var departmens = _departmentReadRepository.Table
                .Include(dept => dept.Manager);
            return _mapper.Map<IEnumerable<DepartmentDto>>(departmens);
        }



        public async Task<DepartmentDto> FindByNameOrIdAsync(string nameOrId)
        { 
            Department department = await GetDepartmentByNameOrIdAndCheckExist(nameOrId);

            var response = _mapper.Map<DepartmentDto>(department);

            return response;
        }

        public async Task<DepartmentDto> CreateDepartmentAsync(CreateDepartmentRequestVM createDepartmentRequest)
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
                var employee = await _employeeManager.FindByNameAsync(createDepartmentRequest.ManagerUserName) ??
                    throw new EmployeeNotFoundException(createDepartmentRequest.ManagerUserName);

                department.ManagerId = employee.Id;
            }

            await _departmentWriteRepository.AddAsync(department);
            await _departmentWriteRepository.SaveAsync();

            return _mapper.Map<DepartmentDto>(department); 
        }

        public async Task UpdateDepartmentAsync(UpdateDepartmentRequestVM updateDepartmentRequest)
        {
            Department department = await FindByIdAsync(updateDepartmentRequest.Id);

            department.Name = updateDepartmentRequest.Name;

            if (!string.IsNullOrWhiteSpace(updateDepartmentRequest.ManagerUserName))
            {
                var employee = await _employeeManager.FindByNameAsync(updateDepartmentRequest.ManagerUserName) ??
                    throw new EmployeeNotFoundException(updateDepartmentRequest.ManagerUserName);

                department.ManagerId = employee.Id;
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


        private async Task<Department> FindByIdAsync(int id)
        {
            Department? department = await _departmentReadRepository.FindByIdAsync(id);
            return department ?? throw new DepartmentNotFoundException(id.ToString());
        }


        private async Task<Department> GetDepartmentByNameOrIdAndCheckExist(string nameOrId)
        {
            Department? department = await _departmentReadRepository.Table
                .Include(d => d.Manager)
                .Where(d => d.Name == nameOrId || d.Id.ToString() == nameOrId )
                .FirstOrDefaultAsync();

            return department ?? throw new DepartmentNotFoundException(nameOrId);
        }

    }

}

