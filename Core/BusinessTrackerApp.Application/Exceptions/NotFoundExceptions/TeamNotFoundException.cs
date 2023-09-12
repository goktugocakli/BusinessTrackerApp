using System;
namespace BusinessTrackerApp.Application.Exceptions
{
	public class TeamNotFoundException : NotFoundException
    {

        public TeamNotFoundException(string id) : base($"The team with id: {id} could not found.")
        {
        }
    }
}

