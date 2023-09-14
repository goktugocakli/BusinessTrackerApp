using System;
using BusinessTrackerApp.Domain.Entities.Common;

namespace BusinessTrackerApp.Domain.Entities
{
	public class Department : BaseEntity
	{
		
		public required string Name { get; set; }

		public ICollection<Team> Teams { get; set; } = new HashSet<Team>();
		public ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();

		public String? ManagerId { get; set; }
		public Employee? Manager { get; set; }


		
	}
}

