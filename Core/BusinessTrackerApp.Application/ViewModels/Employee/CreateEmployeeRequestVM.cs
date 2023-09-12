using System;
namespace BusinessTrackerApp.Application.ViewModels.Employee
{
	public record CreateEmployeeRequestVM
	{
        public required string Name { get; init; }
        public required string Mail { get; init; }
        public required string Phone { get; init; }
        public required string DepartmentId { get; set; }
        public string? TeamId{ get; set; }

    }
}

