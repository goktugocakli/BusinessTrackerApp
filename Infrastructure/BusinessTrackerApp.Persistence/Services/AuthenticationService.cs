using System;
using System.Security.Authentication;
using BusinessTrackerApp.Application.Abstractions.Services;
using BusinessTrackerApp.Application.Exceptions;
using BusinessTrackerApp.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace BusinessTrackerApp.Persistence.Services
{
	public class AuthenticationService : IAuthenticationService
	{
        readonly UserManager<Employee> _userManager;
        readonly SignInManager<Employee> _signInManager;
        readonly ITokenService _tokenService;
        readonly IEmployeeService _employeeService;

        public AuthenticationService(UserManager<Employee> userManager, SignInManager<Employee> signInManager, ITokenService tokenService, IEmployeeService employeeService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
            _employeeService = employeeService;
        }

        public async Task<string> LoginAsync(string username, string password)
        {

            Employee? user = await _userManager.FindByNameAsync(username);

            if (user is null)
                throw new EmployeeNotFoundException(username);

            var employeeDetailsDto = await _employeeService.FindEmployeeDetailsAsync(username);

            SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, password, false);

            if (result.Succeeded)
            {
                string token = await _tokenService.CreateTokenAsync(user, employeeDetailsDto);
                return token;
            }
            throw new AuthenticationException("Kimlik doğrulama hatası");
            
        }
    }
}

