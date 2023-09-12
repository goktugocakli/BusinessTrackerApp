using System;
using BusinessTrackerApp.Domain.Entities;

namespace BusinessTrackerApp.Application.DTOs.Team
{
	public record TeamDto
	{
        public string Name { get; init; }

        //public ICollection<Employee> Employees { get; init; }

        public Guid DepartmentId { get; init; }
       

        public Guid? LeaderId { get; init; }
       
    }
}

