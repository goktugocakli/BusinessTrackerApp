using Microsoft.AspNetCore.Mvc;
using BusinessTrackerApp.Domain.Entities;
using BusinessTrackerApp.Application.ViewModels.Employee;
using BusinessTrackerApp.Application.RequestParameters;
using System.Text.Json;
using System.Web;
using BusinessTrackerApp.Application.Abstractions.Services;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using System.Data;


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
        [Authorize(Roles = "Admin, Employee")]
        public IActionResult GetAll([FromQuery] EmployeeParameters parameters)
        {

            string? userDepartment = User?.Claims?
        .FirstOrDefault(c => c.Type == "DepartmentName")?.Value;

            string[] roles = User?.Claims?
                .Where(c => c.Type == ClaimTypes.Role)
                .Select(c => c.Value)
                .ToArray()!;

            if(roles!.Any(role => role == "Employee") && userDepartment != parameters.DepartmentName)
            {
                throw new Exception("Yalnızca kendi departmanınızdaki kullanıcıları aratabilirsiniz.");
            }

            var pagedResult = _employeeService.GetAllEmployees(parameters);

            Response.Headers.Add("X_Pagination", JsonSerializer.Serialize(pagedResult.metaData));

            //var result = _mapper.Map<IEnumerable<EmployeeResponseVM>>(employees);
            return Ok(pagedResult.employeeDtos);
        }

        

        [HttpGet("{id}")]
        [Authorize(Roles ="Admin, Employee")]
        public async Task<IActionResult> GetById([FromRoute]string id)
        {
            return Ok(await _employeeService.GetEmployeeByIdAsync(id));

        }

        

        [HttpPost]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> CreateEmployee([FromBody]CreateEmployeeRequestVM model)
        {
            var response = await _employeeService.CreateEmployeeAsync(model);
            return StatusCode(201,response);
        }


        [HttpPut]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> UpdateEmployee([FromBody]UpdateEmployeeRequestVM request)
        {
            await _employeeService.UpdateEmployeeAsync(request);

            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> DeleteEmployee([FromRoute]string id)
        {
            await _employeeService.DeleteEmployeeAsync(id);
            return Ok();
        }

        [HttpPost("assing-role-to-user")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AssignRoleToEmployee([FromBody]AssignRoleToEmployeeRequestVM request)
        {
            await _employeeService.AssingRole(request.UserName, request.Role);
            return Ok();
        }

    }
}

