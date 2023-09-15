using System;
using BusinessTrackerApp.Application.ViewModels.Department;
using BusinessTrackerApp.Domain.Entities;

namespace BusinessTrackerApp.Application.Abstractions.Services
{
	public interface IDepartmentService
	{
        IEnumerable<DepartmentResponseVM> FindAll();

        Task<DepartmentResponseVM> FindByNameAsync(string id);

        Task CreateDepartmentAsync(CreateDepartmentRequestVM createDepartmentRequest);

        Task UpdateDepartmentAsync(UpdateDepartmentRequestVM updateDepartmentRequest);

        Task DeleteDepartmentAsync(string idOrName);



    }
}

