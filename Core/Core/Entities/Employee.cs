using System;
using BusinessTrackerApp.Domain.Entities.Common;

namespace BusinessTrackerApp.Domain.Entities
{
	public class Employee : BaseEntity
	{
		public string Name { get; set; }
		public string Mail { get; set; }
		public string Phone { get; set; }

		public Guid DepartmentId { get; set; }
		public Department Department { get; set; }

		public Guid? TeamId { get; set; }
		public Team? Team { get; set; }

		public ICollection<DailyPlan> DailyPlans { get; set;}


	}
}

