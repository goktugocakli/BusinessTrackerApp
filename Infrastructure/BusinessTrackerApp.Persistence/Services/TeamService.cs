using System;
using BusinessTrackerApp.Application.Abstractions.Services;
using BusinessTrackerApp.Application.Exceptions;
using BusinessTrackerApp.Application.Repositories.Employee;
using BusinessTrackerApp.Application.Repositories.Team;
using BusinessTrackerApp.Application.ViewModels.Team;
using BusinessTrackerApp.Domain.Entities;

namespace BusinessTrackerApp.Persistence.Services
{
	public class TeamService : ITeamService
	{
        readonly ITeamReadRepository _teamReadRepository;
        readonly ITeamWriteRepository _teamWriteRepository;
        readonly IEmployeeReadRepository _employeeReadRepository;

        public TeamService(ITeamWriteRepository teamWriteRepository, ITeamReadRepository teamReadRepository, IEmployeeReadRepository employeeReadRepository)
        {
            _teamWriteRepository = teamWriteRepository;
            _teamReadRepository = teamReadRepository;
            _employeeReadRepository = employeeReadRepository;
        }

        public async void AddEmployee(ICollection<string> employeeIds)
        {
            foreach (var employeeId in employeeIds)
            {
                Employee? employee = await _employeeReadRepository.FindByIdAsync(employeeId);
                

            }
        }

        public async void AddEmployee(string teamId, string employeeId)
        {
            Employee? employee = await _employeeReadRepository.FindByIdAsync(employeeId);
            Team? team = await _teamReadRepository.FindByIdAsync(teamId);
            if (employee is not null && team is not null)
            {
                team.Employees.Add(employee);
                _teamWriteRepository.Update(team);
                await _teamWriteRepository.SaveAsync();
            }
            
        }

        public async Task CreateTeamAsync(CreateTeamRequestVM teamRequestVM)
        {
            await _teamWriteRepository.AddAsync(new()
            {
                Name = teamRequestVM.Name,
                DepartmentId = Guid.Parse(teamRequestVM.DepartmentId),
            });

            await _teamWriteRepository.SaveAsync();
        }

        public  IEnumerable<Team> FindAll()
        {
            var teams = _teamReadRepository.FindAll();
            return teams;
        }

        private async Task<Team> GetTeamByIdAndCheckExist(string id)
        {
            Team? team = await _teamReadRepository.FindByIdAsync(id);

            return team is null ? throw new TeamNotFoundException(id) : team;
        }

        public async Task<Team> GetByIdAsync(string id)
        {

            /*
             * 
             * Map fonksiyonu yazılacak
             */

            return await GetTeamByIdAndCheckExist(id);
        }

        public async Task UpdateTeamAsync(UpdateTeamRequestVM teamRequestVM)
        {
            Team entity = await GetTeamByIdAndCheckExist(teamRequestVM.Id);

            entity.DepartmentId = Guid.Parse(teamRequestVM.DepartmentId);

            if (teamRequestVM.LeaderId is not null)
                entity.LeaderId = Guid.Parse(teamRequestVM.LeaderId);

            _teamWriteRepository.Update(entity);
            await _teamWriteRepository.SaveAsync();
        }

        public async Task DeleteTeamAsync(string id)
        {
            Team team = await GetTeamByIdAndCheckExist(id);

            _teamWriteRepository.Remove(team);
            await _teamWriteRepository.SaveAsync();
        }



    }
}

