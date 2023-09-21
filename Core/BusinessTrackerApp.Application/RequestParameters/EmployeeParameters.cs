namespace BusinessTrackerApp.Application.RequestParameters
{
    public class EmployeeParameters : RequestParameters
	{
        public String? DepartmentName { get; set; }

        public string? TeamName { get; set; }

        public int? TeamId { get; set; }

        public EmployeeParameters()
        {
            OrderBy = "Name";
        }
    }
}

