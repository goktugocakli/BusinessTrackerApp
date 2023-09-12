using System;
namespace BusinessTrackerApp.Application.Exceptions
{
	public class EmployeeNotFoundException : NotFoundException
	{

        public EmployeeNotFoundException(string id) : base($"The employee with id: {id} could not found.")
        {
        }
    }
}

