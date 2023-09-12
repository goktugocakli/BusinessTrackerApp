using System;
namespace BusinessTrackerApp.Application.Exceptions
{
	public class DailyPlanNotFoundException : NotFoundException
	{

        public DailyPlanNotFoundException(string id) : base($"The daily plan with id: {id} could not found.")
        {
        }
    }
}

