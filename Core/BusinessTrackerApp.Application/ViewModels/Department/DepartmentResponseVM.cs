using System;
using BusinessTrackerApp.Application.DTOs.Employee;

namespace BusinessTrackerApp.Application.ViewModels.Department
{
	public class DepartmentResponseVM
	{
		public string Id { get; set; }
		public string Name { get; init; }
		public EmployeeDto Manager { get; set; }
		

		// public IList<EmployeeDto> Employees { get; set; }
	}
}

