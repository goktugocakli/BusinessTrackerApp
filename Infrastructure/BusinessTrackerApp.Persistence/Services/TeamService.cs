using System;
using AutoMapper;
using BusinessTrackerApp.Application.Abstractions.Services;
using BusinessTrackerApp.Application.DTOs.Employee;
using BusinessTrackerApp.Application.DTOs.Team;
using BusinessTrackerApp.Application.Exceptions;
using BusinessTrackerApp.Application.Repositories.Team;
using BusinessTrackerApp.Application.ViewModels.Team;
using BusinessTrackerApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BusinessTrackerApp.Persistence.Services
{
    public class TeamService : ITeamService
    {
        readonly ITeamReadRepository _teamReadRepository;
        readonly ITeamWriteRepository _teamWriteRepository;
        readonly IDepartmentService _departmentService;
        readonly IMapper _mapper;
        readonly IEmployeeService _employeeService;

        public TeamService(ITeamWriteRepository teamWriteRepository, ITeamReadRepository teamReadRepository, IDepartmentService departmentService, IMapper mapper, IEmployeeService employeeService)
        {
            _teamWriteRepository = teamWriteRepository;
            _teamReadRepository = teamReadRepository;
            _departmentService = departmentService;
            _mapper = mapper;
            _employeeService = employeeService;
        }

        public async Task CreateTeamAsync(CreateTeamRequestVM teamRequestVM)
        {
            string? leaderId = null;

            var departmentDto = await _departmentService.FindByNameOrIdAsync(teamRequestVM.DepartmentName);

            if (!string.IsNullOrWhiteSpace(teamRequestVM.LeaderUsername))
            {
                var _ = await _employeeService.GetEmployeeByUsernameAsync(teamRequestVM.LeaderUsername);
                leaderId = _.Id;
            }

            Team team = new()
            {
                Name = teamRequestVM.Name,
                DepartmentId = departmentDto.Id,
                LeaderId = leaderId
            };

            await AddEmployeeIntoTeam(teamRequestVM.EmployeeUsernames, team);

            await _teamWriteRepository.AddAsync(team);
            await _teamWriteRepository.SaveAsync();
        }

        private async Task AddEmployeeIntoTeam(ICollection<string> employeeUsernames, Team team)
        {
            foreach (var username in employeeUsernames)
            {
                Employee employee = await _employeeService.GetEmployeeByUsernameAndCheckExist(username);

                team.Employees.Add(employee);
            }
        }

        public IEnumerable<TeamDto> FindAll()
        {
            var teams = _teamReadRepository.Table
                .Include(team => team.Leader)
                .Include(team => team.Department);
            return _mapper.Map<IEnumerable<TeamDto>>(teams);
        }

        private async Task<Team> GetTeamByIdAndCheckExist(int id)
        {
            Team? team = await _teamReadRepository.Table
                .Include(t => t.Department)
                .Include(t => t.Leader)
                .FirstOrDefaultAsync(e => e.Id == id);


            return team ?? throw new TeamNotFoundException(id.ToString());
        }

        public async Task<TeamDto> GetByIdAsync(int id)
        {
            Team team = await GetTeamByIdAndCheckExist(id);

            return _mapper.Map<TeamDto>(team);

        }

        public async Task UpdateTeamAsync(UpdateTeamRequestVM teamRequestVM)
        {
            Team team = await GetTeamByIdAndCheckExist(teamRequestVM.Id);

            var departmentDto = await _departmentService.FindByNameOrIdAsync(teamRequestVM.DepartmentName);

            if (teamRequestVM.LeaderUsername is not null)
            {
                var _ = await _employeeService.GetEmployeeByUsernameAsync(teamRequestVM.LeaderUsername);
                team.LeaderId = _.Id;
            }
            else
            {
                team.LeaderId = null;
            }

            team.Name = teamRequestVM.Name;
            team.DepartmentId = departmentDto.Id;

            _teamWriteRepository.Update(team);
            await _teamWriteRepository.SaveAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            Team team = await GetTeamByIdAndCheckExist(id);

            _teamWriteRepository.Remove(team);
            await _teamWriteRepository.SaveAsync();
        }


        public async Task ManipulateEmployeesAsync(ManipulateEmployeesIntoTeamRequest request)
        {
            Team team = await GetTeamByIdAndCheckExist(request.TeamId);


            foreach (var employeeItem in request.employeeUsernames)
            {
                Employee employee = await _employeeService.GetEmployeeByUsernameAndCheckExist(employeeItem.Username);

                switch (employeeItem.Code)
                {
                    case Code.Delete:
                        team.Employees.Remove(employee);
                        break;

                    case Code.Add:
                        team.Employees.Add(employee);
                        break;

                    default:
                        break;
                }
            }

            _teamWriteRepository.Update(team);
            await _teamWriteRepository.SaveAsync();

        }

    }
}

