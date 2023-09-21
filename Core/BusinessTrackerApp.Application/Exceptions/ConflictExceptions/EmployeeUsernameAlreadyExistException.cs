using System;
namespace BusinessTrackerApp.Application.Exceptions.ConflictExceptions
{
	public class EmployeeUsernameAlreadyExistException : ConflictException
	{
		

        public EmployeeUsernameAlreadyExistException(string username) : base($"The employee with username: '{username}' already exist in database. Username must be unique.")
        {
        }
    }
}

