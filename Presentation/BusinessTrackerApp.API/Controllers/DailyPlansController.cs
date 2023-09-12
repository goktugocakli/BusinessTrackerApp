using BusinessTrackerApp.Application.Abstractions.Services;
using BusinessTrackerApp.Application.RequestParameters;
using BusinessTrackerApp.Application.ViewModels.DailyPlan;
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

        
        [HttpGet]
        public IActionResult GetAll([FromQuery] DailyPlanParameters parameters)
        {
            var response = _dailyPlanService.FindAll(parameters);
            return Ok(response);
        }
        

        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute]string id)
        {
            return Ok(await _dailyPlanService.FindByIdAsync(id));
        }

        
        [HttpPost]
        public async Task<IActionResult> CreateDailyPlan([FromBody]CreateDailyPlanRequestVM dailyPlanRequest)
        {
            await _dailyPlanService.CreateDaiyPlanAsync(dailyPlanRequest);

            return Ok();

        }

        
        [HttpPut]
        public async Task<IActionResult> UpdateDailyPlan([FromBody] UpdateDailyPlanRequestVM dailyPlanRequest)
        {
            await _dailyPlanService.UpdateDailyPlanAsync(dailyPlanRequest);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute]string id)
        {
            await _dailyPlanService.DeleteByIdAsync(id);
            return Ok();
           
        }
    }
}

