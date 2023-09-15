using System.Security.Claims;
using BusinessTrackerApp.Application.Abstractions.Services;
using BusinessTrackerApp.Application.ViewModels.Department;
using BusinessTrackerApp.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BusinessTrackerApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : Controller
    {

        readonly IDepartmentService _departmentService;

        public DepartmentsController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        
        [HttpGet]
        [Authorize]
        public IActionResult GetAll()
        {
            return Ok(_departmentService.FindAll());
        }

       
        [HttpGet("{name}")]
        //[Authorize]
        public async Task<IActionResult> GetByName([FromRoute] string name)
        {
            return Ok(await _departmentService.FindByNameAsync(name));
        }

        // POST api/values
        [HttpPost]
        //[Authorize(Roles ="Admin")]
        public async Task<IActionResult> Post([FromBody] CreateDepartmentRequestVM createDepartmentRequest)
        {
             await _departmentService.CreateDepartmentAsync(createDepartmentRequest);
            return Ok();
        }


        [HttpPut]
        //[Authorize(Roles ="Admin")]
        public async Task<IActionResult> Put([FromBody] UpdateDepartmentRequestVM updateDepartmentRequest)
        {
            await _departmentService.UpdateDepartmentAsync(updateDepartmentRequest);
            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete("{idOrName}")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> Delete([FromRoute] string idOrName)
        {
            await _departmentService.DeleteDepartmentAsync(idOrName);
            return Ok();
        }


    }
}

