using System;
using BusinessTrackerApp.Application.DTOs.Employee;
using BusinessTrackerApp.Domain.Entities;

namespace BusinessTrackerApp.Application.Abstractions.Services
{
	public interface ITokenService
	{
		Task<string> CreateTokenAsync(Employee user, EmployeeDetailsDto EmployeeDetails);
	}
}

