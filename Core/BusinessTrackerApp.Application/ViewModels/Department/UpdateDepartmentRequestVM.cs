using System;
namespace BusinessTrackerApp.Application.ViewModels.Department
{
	public record UpdateDepartmentRequestVM
	{
		public required string Name { get; init; }
		public string? ManagerUserName { get; init; }
	}
}

