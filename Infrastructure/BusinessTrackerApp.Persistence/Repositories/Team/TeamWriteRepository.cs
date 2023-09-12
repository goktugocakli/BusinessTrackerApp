using System;
using BusinessTrackerApp.Application.Repositories.Team;
using BusinessTrackerApp.Domain.Entities;
using BusinessTrackerApp.Persistence.Context;

namespace BusinessTrackerApp.Persistence.Repositories
{
    public class TeamWriteRepository : WriteRepository<Team>, ITeamWriteRepository
    {
        public TeamWriteRepository(BusinessTrackerDbContext context) : base(context)
        {
        }
    }
}

