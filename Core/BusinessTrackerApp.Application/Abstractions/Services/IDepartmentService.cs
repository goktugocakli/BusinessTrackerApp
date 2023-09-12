using System;
using BusinessTrackerApp.Application.ViewModels.Department;
using BusinessTrackerApp.Domain.Entities;

namespace BusinessTrackerApp.Application.Abstractions.Services
{
	public interface IDepartmentService
	{
        IEnumerable<Department> FindAll();

        Task<Department> FindByIdAsync(string id);

        Task CreateDepartmentAsync(CreateDepartmentRequestVM createDepartmentRequest);

        Task UpdateDepartmentAsync(UpdateDepartmentRequestVM updateDepartmentRequest);

        Task DeleteDepartmentAsync(string idOrName);



    }
}

