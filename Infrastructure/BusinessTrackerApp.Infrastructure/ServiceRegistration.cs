using System;
using BusinessTrackerApp.Application.Abstractions.Services;
using BusinessTrackerApp.Infrastructure.Services.Token;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessTrackerApp.Infrastructure
{
	public static class ServiceRegistration
	{
		public static void AddInfrastructureServices(this IServiceCollection services)
		{
			services.AddScoped<ITokenService, TokenService>();
		}
	}
}

