using System;
namespace BusinessTrackerApp.Application.ViewModels.Team
{
	public record ManipulateEmployeesIntoTeamRequest
	{
		public string TeamId { get; init; }
		public required ICollection<ManipulateStruct> employeeUsernames { get; init; } = new HashSet<ManipulateStruct>();

	}


	/**
	 * Eğer code 1 ise kullanıcı ekleme, 
	 * eğer code 0 ise kullanıcı silme işlemi yapılır.
	 */
    public record struct ManipulateStruct
    {
		public Code Code { get; set; }
		public string Username { get; set; }

       
    }

	public enum Code
	{
		Delete,
		Add
	}
}

