using System;
namespace BusinessTrackerApp.Application.ViewModels.Department
{
	public record CreateDepartmentRequestVM
	{
		public required string Name { get; init; }
		public string? ManagerId { get; init; }

	}
}

