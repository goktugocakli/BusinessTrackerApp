using System;
using Microsoft.EntityFrameworkCore;

namespace BusinessTrackerApp.Application.Repositories
{
    public interface IRepository<T> where T : class 
    {
        DbSet<T> Table { get; }
	}
}

