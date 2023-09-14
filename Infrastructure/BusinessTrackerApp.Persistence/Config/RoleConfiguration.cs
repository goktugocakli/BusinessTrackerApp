using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusinessTrackerApp.Persistence.Config
{
	public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
	{

        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                    new IdentityRole
                    {
                        Name = "Admin",
                        NormalizedName = "ADMIN"
                    },
                    new IdentityRole
                    {
                        Name = "Department Manager",
                        NormalizedName = "DEPARTMENT MANAGER"
                    },
                    new IdentityRole
                    {
                        Name = "Team Leader",
                        NormalizedName = "TEAM LEADER"
                    },
                    new IdentityRole
                    {
                        Name = "Employee",
                        NormalizedName = "EMPLOYEE"
                    }
                );
        }
    }
}

