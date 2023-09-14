using BusinessTrackerApp.Application.RequestParameters;

namespace BusinessTrackerApp.Application.Repositories.DailyPlan
{
	public interface IDailyPlanReadRepository : IReadRepository<Domain.Entities.DailyPlan>
	{
		PagedList<Domain.Entities.DailyPlan> FindAll(DailyPlanParameters parameters, bool tracking);
	}
}

