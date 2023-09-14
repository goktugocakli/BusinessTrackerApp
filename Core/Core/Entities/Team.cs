using System;
using System.Collections;
using System.Collections.Generic;
using BusinessTrackerApp.Domain.Entities.Common;

namespace BusinessTrackerApp.Domain.Entities
{
	public class Team : BaseEntity
	{
		public string Name { get; set; }

		public ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();

		public Guid DepartmentId  { get; set; }
		public Department Department { get; set; }

		public String? LeaderId { get; set; }
		public Employee? Leader { get; set; }

	}
}

