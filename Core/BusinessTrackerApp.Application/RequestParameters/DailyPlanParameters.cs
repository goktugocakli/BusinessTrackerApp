using System;
namespace BusinessTrackerApp.Application.RequestParameters
{
	public class DailyPlanParameters : RequestParameters
	{
		public DateOnly StartTime { get; set; } = DateOnly.FromDateTime(DateTime.MinValue);
		public DateOnly EndTime { get; set; } = DateOnly.FromDateTime(DateTime.MaxValue);

		public bool ValidTimeRange => EndTime > StartTime;

		public string? EmployeeUserName { get; set; }

		public string? DepartmentName { get; set; }

		private string? _teamName;

		public string? TeamName
		{
			get { return _teamName; }

			set { _teamName = string.IsNullOrEmpty(DepartmentName) ? null : value; }
		}
	}
}

