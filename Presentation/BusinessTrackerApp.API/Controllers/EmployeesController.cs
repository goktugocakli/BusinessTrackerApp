using Microsoft.AspNetCore.Mvc;
using BusinessTrackerApp.Domain.Entities;
using BusinessTrackerApp.Application.ViewModels.Employee;
using BusinessTrackerApp.Application.RequestParameters;
using System.Text.Json;
using System.Web;
using BusinessTrackerApp.Application.Abstractions.Services;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BusinessTrackerApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : Controller
    {
        readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public IActionResult GetAll([FromQuery] EmployeeParameters parameters)
        {
            var pagedResult = _employeeService.GetAllEmployees(parameters);

            Response.Headers.Add("X_Pagination", JsonSerializer.Serialize(pagedResult.metaData));

            //var result = _mapper.Map<IEnumerable<EmployeeResponseVM>>(employees);
            return Ok(pagedResult.employeeDtos);
        }

        

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute]string id)
        {
            return Ok(await _employeeService.GetEmployeeByIdAsync(id));

        }

        

        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody]CreateEmployeeRequestVM model)
        {
            var response = await _employeeService.CreateEmployeeAsync(model);
            return StatusCode(201,response);
        }


        [HttpPut]
        public async Task<IActionResult> UpdateEmployee([FromBody]UpdateEmployeeRequestVM request)
        {
            await _employeeService.UpdateEmployeeAsync(request);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee([FromRoute]string id)
        {
            await _employeeService.DeleteEmployeeAsync(id);
            return Ok();
        }

       
    }
}

