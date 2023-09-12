using AutoMapper;
using BusinessTrackerApp.Application.Abstractions.Services;

using BusinessTrackerApp.Application.ViewModels.Team;
using BusinessTrackerApp.Domain.Entities;
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

        // GET: api/values
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_teamService.FindAll());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute]string id)
        {
            Team team = await _teamService.GetByIdAsync(id);
            return Ok(team);
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateTeamRequestVM teamRequestVM)
        {
            await _teamService.CreateTeamAsync(teamRequestVM);

            return Ok();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] UpdateTeamRequestVM teamRequestVM)
        {
            await _teamService.UpdateTeamAsync(teamRequestVM);

            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute]string id)
        {
            await _teamService.DeleteTeamAsync(id);
            return Ok();
        }

        
    }
}

