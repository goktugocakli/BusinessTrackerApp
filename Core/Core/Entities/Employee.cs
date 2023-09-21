using System;
using BusinessTrackerApp.Domain.Entities.Common;
using Microsoft.AspNetCore.Identity;

namespace BusinessTrackerApp.Domain.Entities
{
    public class Employee : IdentityUser
	{
		public string NameSurname { get; set; }

		public int DepartmentId { get; set; }
		public Department Department { get; set; }

		public int? TeamId { get; set; }
		public Team? Team { get; set; }

		public ICollection<DailyPlan> DailyPlans { get; set; } = new HashSet<DailyPlan>();


	}
}

