using System;
using AutoMapper;
using BusinessTrackerApp.Application.Abstractions.Services;
using BusinessTrackerApp.Application.Exceptions;
using BusinessTrackerApp.Application.Repositories.Department;
using BusinessTrackerApp.Application.ViewModels.Department;
using BusinessTrackerApp.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace BusinessTrackerApp.Persistence.Services
{
	public class DepartmentService : IDepartmentService
	{
		private readonly IDepartmentWriteRepository _departmentWriteRepository;
        private readonly IDepartmentReadRepository _departmentReadRepository;
        private readonly UserManager<Employee> _userManager;

        public DepartmentService(IDepartmentWriteRepository departmentWriteRepository, IDepartmentReadRepository departmentReadRepository, UserManager<Employee> userManager)
        {
            _departmentWriteRepository = departmentWriteRepository;
            _departmentReadRepository = departmentReadRepository;
            _userManager = userManager;
        }


        public IEnumerable<Department> FindAll()
        {
            return _departmentReadRepository.FindAll();
        }

        private async Task<Department> GetDepartmentByIdAndCheckExist(string id)
        {
            Department? department = await _departmentReadRepository.FindByIdAsync(id);

            return department ?? throw new DepartmentNotFoundException(id);
        }

        public async Task<Department> FindByIdAsync(string id)
        {
            return await GetDepartmentByIdAndCheckExist(id);
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
                Employee? employee = await _userManager.FindByNameAsync(createDepartmentRequest.ManagerUserName);
                department.Manager = employee;
            }

            await _departmentWriteRepository.AddAsync(department);
            await _departmentWriteRepository.SaveAsync();
        }

        public async Task UpdateDepartmentAsync(UpdateDepartmentRequestVM updateDepartmentRequest)
        {
            Department department = await GetDepartmentByIdAndCheckExist(updateDepartmentRequest.Id);

            department.Name = updateDepartmentRequest.Name;

            if (!string.IsNullOrWhiteSpace(updateDepartmentRequest.ManagerUserName))
            {
                Employee? employee = await _userManager.FindByNameAsync(updateDepartmentRequest.ManagerUserName);

                if(employee is not null)
                    department.Manager = employee;
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

