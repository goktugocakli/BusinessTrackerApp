using System;
namespace BusinessTrackerApp.Application.Exceptions
{
	public class NotFoundException : Exception
	{

        public NotFoundException(string message) : base(message)
        {
        }
    }
}

