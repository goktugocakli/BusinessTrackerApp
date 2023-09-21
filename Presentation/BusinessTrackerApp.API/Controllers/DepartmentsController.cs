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

       
        [HttpGet("{nameOrId}")]
        [Authorize]
        public async Task<IActionResult> GetDepartmentByNameOrId([FromRoute] string nameOrId)
        {
            return Ok(await _departmentService.FindByNameOrIdAsync(nameOrId));
        }

        [HttpPost]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> CreateDepartment([FromBody] CreateDepartmentRequestVM createDepartmentRequest)
        {
             var response = await _departmentService.CreateDepartmentAsync(createDepartmentRequest);
            return StatusCode(201, response);
        }


        [HttpPut]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> UpdateDepartment([FromBody] UpdateDepartmentRequestVM updateDepartmentRequest)
        {
            await _departmentService.UpdateDepartmentAsync(updateDepartmentRequest);
            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete("{idOrName}")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> DeleteDepartmentByIdOrName([FromRoute] string idOrName)
        {
            await _departmentService.DeleteDepartmentAsync(idOrName);
            return Ok();
        }


    }
}

