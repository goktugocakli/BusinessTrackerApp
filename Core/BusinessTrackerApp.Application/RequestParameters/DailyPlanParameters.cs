using System;
namespace BusinessTrackerApp.Application.RequestParameters
{
	public class DailyPlanParameters : RequestParameters
	{
		public DateTime StartTime { get; set; } = DateTime.MinValue;
		public DateTime EndTime { get; set; } = DateTime.MaxValue;

		public bool ValidTimeRange => EndTime > StartTime;

		public string? EmployeeId { get; set; }

		public string? DepartmentName { get; set; }

		private string? _teamName;

		public string? TeamName
		{
			get { return _teamName; }

			set { _teamName = string.IsNullOrEmpty(DepartmentName) ? null : value; }
		}
	}
}

