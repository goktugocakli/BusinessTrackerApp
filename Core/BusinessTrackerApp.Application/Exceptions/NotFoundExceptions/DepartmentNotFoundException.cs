using System;
namespace BusinessTrackerApp.Application.Exceptions
{
	public class DepartmentNotFoundException : NotFoundException
	{
		

        public DepartmentNotFoundException(string id) : base($"the department with id: {id} could not found.")
        {
        }
    }
}

