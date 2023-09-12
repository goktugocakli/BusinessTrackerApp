using System;
using BusinessTrackerApp.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BusinessTrackerApp.Persistence
{
	public class DesignTimeDbContext : IDesignTimeDbContextFactory<BusinessTrackerDbContext>
	{
		public DesignTimeDbContext()
		{
		}

        public BusinessTrackerDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<BusinessTrackerDbContext>();
            optionsBuilder.UseNpgsql(Configurations.ConnectionString);

            return new BusinessTrackerDbContext(optionsBuilder.Options);
        }
    }
}

