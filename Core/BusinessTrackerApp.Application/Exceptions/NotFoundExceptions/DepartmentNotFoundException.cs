using System;
namespace BusinessTrackerApp.Application.Exceptions
{
	public class DepartmentNotFoundException : NotFoundException
	{
		

        public DepartmentNotFoundException(string name) : base($"the department with name: {name} could not found.")
        {
        }
    }
}

