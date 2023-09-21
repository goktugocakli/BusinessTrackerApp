using System;
namespace BusinessTrackerApp.Application.ViewModels.Team
{
	public record UpdateTeamRequestVM 
	{
		public int Id { get; init; }
        public required string Name { get; init; }
        public required string DepartmentName { get; init; }
        public string? LeaderUsername { get; init; }
        //public ICollection<string>? EmployeeUsernames { get; init; }

    }
}

