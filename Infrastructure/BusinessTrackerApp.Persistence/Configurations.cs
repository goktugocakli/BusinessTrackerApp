using System;
using Microsoft.Extensions.Configuration;

namespace BusinessTrackerApp.Persistence
{
	static class Configurations
	{
		public static string ConnectionString
		{
			get
			{
				ConfigurationManager configurationManager = new();
				configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/BusinessTrackerApp.API"));
				configurationManager.AddJsonFile("appsettings.json");
                return configurationManager.GetConnectionString("postgreSQL");
			}
		}
	}
}

