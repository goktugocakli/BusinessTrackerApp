using System;
using BusinessTrackerApp.Domain.Entities.Common;

namespace BusinessTrackerApp.Domain.Entities
{
	public class DailyPlan : BaseEntity
	{

		public string Header { get; set; }
		public string Description { get; set; }
		public DateTime Date { get; set; } = DateTime.Today;
		public Status Status { get; set; } = Status.NotStarted;

		public string? ResultDescription { get; set; }

		public Guid EmployeeId { get; set; }
		public Employee Employee { get; set; }


	}

	public enum Status
	{
		NotStarted,
		InProgress,
		Completed,
		PartiallyCompleted
	}
}

