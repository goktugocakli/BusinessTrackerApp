﻿using System;
namespace BusinessTrackerApp.Application.ViewModels.Employee
{
	public record LoginEmployeeRequestVM
	{
		public string UsernameOrEmail { get; init; }
		public string Password { get; init; }
	}
}

