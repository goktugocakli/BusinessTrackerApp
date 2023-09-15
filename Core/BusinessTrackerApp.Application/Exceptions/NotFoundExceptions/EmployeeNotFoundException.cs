using System;
namespace BusinessTrackerApp.Application.Exceptions
{
	public class EmployeeNotFoundException : NotFoundException
	{

        public EmployeeNotFoundException(string username) : base($"The employee with username: {username} could not found.")
        {
        }
    }
}

