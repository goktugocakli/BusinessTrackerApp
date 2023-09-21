using System;
namespace BusinessTrackerApp.Application.ViewModels.Employee
{
	public record UpdateEmployeeRequestVM
	{
        public required string Id { get; init; }
        public required string NameSurname { get; init; }
        public required string Username { get; init; }
        public required string Mail { get; init; }
        public required string Phone { get; init; }
        public required int DepartmentId { get; init; }
        public int? TeamId { get; init; }

    }
}

