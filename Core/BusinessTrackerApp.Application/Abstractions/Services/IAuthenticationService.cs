using System;
namespace BusinessTrackerApp.Application.Abstractions.Services
{
	public interface IAuthenticationService
	{
			Task<string> LoginAsync(string usernameOrEmail, string password);
		
	}
}

