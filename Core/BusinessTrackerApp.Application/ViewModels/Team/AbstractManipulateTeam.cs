using System;
namespace BusinessTrackerApp.Application.ViewModels.Team
{
	public abstract record AbstractManipulateTeam
	{
        public required string Name { get; init; }
        public required string DepartmentId { get; init; }
        public string? LeaderId { get; init; }
        public ICollection<string>? EmployeesId { get; init; }
    }
}

