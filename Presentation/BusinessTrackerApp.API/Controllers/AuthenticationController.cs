using System;
using BusinessTrackerApp.Application.Abstractions.Services;
using BusinessTrackerApp.Application.ViewModels.Employee;
using Microsoft.AspNetCore.Mvc;

namespace BusinessTrackerApp.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthenticationController : Controller
	{
		readonly IAuthenticationService _authService;

        public AuthenticationController(IAuthenticationService authService)
        {
            _authService = authService;
        }

		[HttpPost("[action]")]
		public async Task<IActionResult> Login([FromBody]LoginEmployeeRequestVM request)
		{
			string response = await _authService.LoginAsync(request.UsernameOrEmail, request.Password);
			return Ok(response);
		}
	}
}

