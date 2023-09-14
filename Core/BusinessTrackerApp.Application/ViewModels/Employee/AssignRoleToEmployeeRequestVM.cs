using System;
namespace BusinessTrackerApp.Application.ViewModels.Employee
{
    public record AssignRoleToEmployeeRequestVM
    {
        public string UserName { get; init; }
        public string Role { get; init; }
    }
}

