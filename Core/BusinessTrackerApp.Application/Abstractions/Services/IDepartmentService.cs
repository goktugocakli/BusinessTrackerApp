using System;
using BusinessTrackerApp.Application.DTOs.Department;
using BusinessTrackerApp.Application.ViewModels.Department;
using BusinessTrackerApp.Domain.Entities;

namespace BusinessTrackerApp.Application.Abstractions.Services
{
	public interface IDepartmentService
	{
        IEnumerable<DepartmentDto> FindAll();

        Task<DepartmentDto> FindByNameOrIdAsync(string name);

        //Task<Department> FindByIdAsync(int id);

        Task<DepartmentDto> CreateDepartmentAsync(CreateDepartmentRequestVM createDepartmentRequest);

        Task UpdateDepartmentAsync(UpdateDepartmentRequestVM updateDepartmentRequest);

        Task DeleteDepartmentAsync(string idOrName);



    }
}

