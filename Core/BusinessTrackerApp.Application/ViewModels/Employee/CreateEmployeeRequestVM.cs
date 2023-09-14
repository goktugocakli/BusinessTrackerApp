using System;
namespace BusinessTrackerApp.Application.ViewModels.Employee
{
	public record CreateEmployeeRequestVM
	{
        public required string NameSurname { get; init; }
        public string Username { get; init; }
        public string Password { get; init; }
        public required string Mail { get; init; }
        public required string Phone { get; init; }
        public required string DepartmentId { get; init; }
        public ICollection<string> Roles { get; init; }
        public string? TeamId{ get; set; }

    }
}

