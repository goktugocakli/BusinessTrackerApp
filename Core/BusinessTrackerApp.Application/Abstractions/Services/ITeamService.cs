using System;
using BusinessTrackerApp.Application.ViewModels.Team;
using BusinessTrackerApp.Domain.Entities;

namespace BusinessTrackerApp.Application.Abstractions.Services
{
	public interface ITeamService
	{
		void AddEmployee(ICollection<string> employeeIds);
		void AddEmployee(string teamId, string employeeId);

		Task CreateTeamAsync(CreateTeamRequestVM teamRequestVM);

		Task UpdateTeamAsync(UpdateTeamRequestVM teamRequestVM);

		IEnumerable<Team> FindAll();

		//Task<Team> GetTeamByIdAndCheckExist(string id);

		Task<Team> GetByIdAsync(string id);

		Task DeleteTeamAsync(string id);
    }
}

