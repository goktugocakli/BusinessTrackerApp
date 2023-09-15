using AutoMapper;
using BusinessTrackerApp.Application.Abstractions.Services;

using BusinessTrackerApp.Application.ViewModels.Team;
using BusinessTrackerApp.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BusinessTrackerApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : Controller
    {
        readonly ITeamService _teamService;

        public TeamsController(ITeamService teamService)
        {
            _teamService = teamService;
        }  


        [HttpGet]
        //[Authorize]
        public IActionResult GetAllTeams()
        {
            return Ok(_teamService.FindAll());
        }

        
        [HttpGet("{id}")]
        //[Authorize]
        public async Task<IActionResult> GetTeamById([FromRoute]string id)
        {
            return Ok(await _teamService.GetByIdAsync(id));
        }

        
        [HttpPost]
        //[Authorize(Roles ="Admin")]
        public async Task<IActionResult> CreateTeam([FromBody] CreateTeamRequestVM teamRequestVM)
        {
            await _teamService.CreateTeamAsync(teamRequestVM);

            return Ok();
        }

        
        [HttpPut]
        //[Authorize(Roles ="Admin")]
        public async Task<IActionResult> UpdateTeam([FromBody] UpdateTeamRequestVM teamRequestVM)
        {
            await _teamService.UpdateTeamAsync(teamRequestVM);

            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        //[Authorize(Roles ="Admin")]
        public async Task<IActionResult> DeleteTeamById([FromRoute]string id)
        {
            await _teamService.DeleteTeamAsync(id);
            return Ok();
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> ManipulateEmployeesInTeam([FromBody] ManipulateEmployeesIntoTeamRequest request)
        {
            await _teamService.ManipulateEmployeesAsync(request);
            return Ok();
        }  

        
    }
}

