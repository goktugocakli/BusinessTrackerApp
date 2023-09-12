using System;
using BusinessTrackerApp.Application.Repositories.Team;
using BusinessTrackerApp.Domain.Entities;
using BusinessTrackerApp.Persistence.Context;

namespace BusinessTrackerApp.Persistence.Repositories
{
    public class TeamReadRepository : ReadRepository<Team>, ITeamReadRepository
    {
        public TeamReadRepository(BusinessTrackerDbContext context) : base(context)
        {
        }
    }
}

