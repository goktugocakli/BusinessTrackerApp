using System.Text.Json;
using BusinessTrackerApp.Application.Abstractions.Services;
using BusinessTrackerApp.Application.RequestParameters;
using BusinessTrackerApp.Application.ViewModels.DailyPlan;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BusinessTrackerApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DailyPlansController : Controller
    {

        private readonly IDailyPlanService _dailyPlanService;

        public DailyPlansController(IDailyPlanService dailyPlanService)
        {
            _dailyPlanService = dailyPlanService;
        }

        [Authorize(Roles ="Admin, Employee")]
        [HttpGet]
        public IActionResult GetAll([FromQuery] DailyPlanParameters parameters)
        {
            var pagedResult = _dailyPlanService.FindAll(parameters);

            Response.Headers.Add("X_Pagination", JsonSerializer.Serialize(pagedResult.metaData));
            return Ok(pagedResult.dailyPlans);
        }
        

        
        [HttpGet("{id:int}")]
        [Authorize(Roles = "Employee, Admin")]
        public async Task<IActionResult> GetById([FromRoute]int id)
        {
            return Ok(await _dailyPlanService.FindByIdAsync(id));
        }

        
        [HttpPost]
        [Authorize(Roles = "Employee, Admin")]
        public async Task<IActionResult> CreateDailyPlan([FromBody]CreateDailyPlanRequestVM dailyPlanRequest)
        {
            await _dailyPlanService.CreateDaiyPlanAsync(dailyPlanRequest);

            return Ok();

        }

        
        [HttpPut]
        [Authorize(Roles = "Employee, Admin")]
        public async Task<IActionResult> UpdateDailyPlan([FromBody] UpdateDailyPlanRequestVM dailyPlanRequest)
        {
            await _dailyPlanService.UpdateDailyPlanAsync(dailyPlanRequest);
            return Ok();
        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Employee, Admin")]
        public async Task<IActionResult> DeleteAsync([FromRoute]int id)
        {
            await _dailyPlanService.DeleteByIdAsync(id);
            return Ok();
           
        }
    }
}

