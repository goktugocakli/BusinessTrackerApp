using System;
namespace BusinessTrackerApp.Application.ViewModels.Employee
{
    public record AssignRolesToEmployeeRequestVM
    {
        public string UserName { get; init; }
        public ICollection<string> Roles { get; init; } = new HashSet<string>();
    }
}

