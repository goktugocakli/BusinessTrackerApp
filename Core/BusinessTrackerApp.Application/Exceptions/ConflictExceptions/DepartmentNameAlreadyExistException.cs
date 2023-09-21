using System;
namespace BusinessTrackerApp.Application.Exceptions.ConflictExceptions
{
	public class DepartmentNameAlreadyExistException : ConflictException
	{

            public DepartmentNameAlreadyExistException(string name) : base($"Department with name: {name} is already exist in database")
            {
            }
        
    }
}

