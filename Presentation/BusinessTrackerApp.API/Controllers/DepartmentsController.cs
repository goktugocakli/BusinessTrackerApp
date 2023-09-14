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

        

        // GET: api/values
        [HttpGet]
        [Authorize]
        public IActionResult GetAll()
        {
            IEnumerable<Department> departments = _departmentService.FindAll();
            return Ok(departments);
        }

       

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            return Ok(await _departmentService.FindByIdAsync(id));
        }

        // POST api/values
        [HttpPost]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> Post([FromBody] CreateDepartmentRequestVM createDepartmentRequest)
        {
             await _departmentService.CreateDepartmentAsync(createDepartmentRequest);
            return Ok();
        }

        // PUT api/values/5
        [HttpPut]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> Put([FromBody] UpdateDepartmentRequestVM updateDepartmentRequest)
        {
            await _departmentService.UpdateDepartmentAsync(updateDepartmentRequest);
            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            await _departmentService.DeleteDepartmentAsync(id);
            return Ok();
        }

    }
}

