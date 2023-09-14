using System;
namespace BusinessTrackerApp.Application.ViewModels.Employee
{
	public record UpdateEmployeeRequestVM
	{
        public required string Id { get; init; }
        public required string Name { get; init; }
        public string Username { get; init; }
        public required string Mail { get; init; }
        public required string Phone { get; init; }
        public required string DepartmentId { get; init; }
        public string? TeamId { get; init; }

    }
}

