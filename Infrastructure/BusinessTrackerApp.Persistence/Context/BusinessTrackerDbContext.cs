using System.Reflection;
using BusinessTrackerApp.Domain.Entities;
using BusinessTrackerApp.Domain.Entities.Common;
using BusinessTrackerApp.Persistence.Config;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BusinessTrackerApp.Persistence.Context
{
	public class BusinessTrackerDbContext : IdentityDbContext<Employee>
	{
		
        public BusinessTrackerDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<DailyPlan> DailyPlans { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            

            modelBuilder.Entity<Department>()
                .HasIndex(d => d.Name)
                .IsUnique();

            modelBuilder.Entity<Employee>()
                .HasOne<Department>(e => e.Department)
                .WithMany(d => d.Employees)
                .HasForeignKey(e => e.DepartmentId);

            modelBuilder.Entity<Employee>()
                .HasOne<Team>(e => e.Team)
                .WithMany(t => t.Employees)
                .HasForeignKey(e => e.TeamId);

            modelBuilder.Entity<Employee>()
                .HasMany<DailyPlan>(e => e.DailyPlans)
                .WithOne(d => d.Employee)
                .HasForeignKey(d => d.EmployeeId)
                .IsRequired(true);

            modelBuilder.Entity<Department>()
                .HasOne<Employee>(d => d.Manager)
                .WithOne()
                .HasForeignKey<Department>(d => d.ManagerId)
                .IsRequired(false);

            modelBuilder.Entity<Team>()
                .HasOne<Employee>(t => t.Leader)
                .WithOne()
                .HasForeignKey<Team>(t => t.LeaderId)
                .IsRequired(false);

            modelBuilder.Entity<Team>()
                .HasOne<Department>(t => t.Department)
                .WithMany(d => d.Teams)
                .HasForeignKey(t => t.DepartmentId)
                .IsRequired(true);

            modelBuilder
                .Entity<DailyPlan>()
                .Property(d => d.Status)
                .HasConversion(
                    v => v.ToString(),
                    v => (Status)Enum.Parse(typeof(Status), v));
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            
            var datas = ChangeTracker.Entries<BaseEntity>();
            foreach (var data in datas)
            {
                switch (data.State)
                {
                    case EntityState.Added:
                        data.Entity.CreatedDate = DateTime.UtcNow;
                        break;

                    case EntityState.Modified:
                        data.Entity.UpdatedDate = DateTime.UtcNow;
                        break;

                    default:
                        _ = DateTime.UtcNow;
                        break;
                }
            }
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}

