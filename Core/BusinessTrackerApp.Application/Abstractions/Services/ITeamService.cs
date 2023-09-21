using System;
using BusinessTrackerApp.Application.DTOs.Team;
using BusinessTrackerApp.Application.ViewModels.Team;
using BusinessTrackerApp.Domain.Entities;

namespace BusinessTrackerApp.Application.Abstractions.Services
{
	public interface ITeamService
	{
		Task ManipulateEmployeesAsync(ManipulateEmployeesIntoTeamRequest request);

		Task CreateTeamAsync(CreateTeamRequestVM teamRequestVM);

		Task UpdateTeamAsync(UpdateTeamRequestVM teamRequestVM);

		IEnumerable<TeamDto> FindAll();

		//Task<Team> GetTeamByIdAndCheckExist(string id);

		Task<TeamDto> GetByIdAsync(int id);

		Task DeleteByIdAsync(int id);
    }
}

