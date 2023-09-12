using System;
namespace BusinessTrackerApp.Application.ViewModels.Team
{
	public record UpdateTeamRequestVM : AbstractManipulateTeam
	{
		public string Id { get; init; }

	}
}

