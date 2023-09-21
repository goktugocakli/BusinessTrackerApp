using System;
namespace BusinessTrackerApp.Application.ViewModels.Department
{
	public record UpdateDepartmentRequestVM
	{
		public int Id { get; init; }
		public required string Name { get; init; }
		public string? ManagerUserName { get; init; }
	}
}

