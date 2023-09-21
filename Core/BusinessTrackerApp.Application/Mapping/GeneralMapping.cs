using System;
using AutoMapper;
using BusinessTrackerApp.Application.DTOs.DailyPlan;
using BusinessTrackerApp.Application.DTOs.Department;
using BusinessTrackerApp.Application.DTOs.Employee;
using BusinessTrackerApp.Application.DTOs.Team;
using BusinessTrackerApp.Application.ViewModels.Department;
using BusinessTrackerApp.Application.ViewModels.Employee;
using BusinessTrackerApp.Domain.Entities;

namespace BusinessTrackerApp.Application.Mapping
{
	public class GeneralMapping : Profile
	{
		public GeneralMapping()
		{
			CreateMap<Employee, EmployeeDto>().ReverseMap();

			CreateMap<Employee, EmployeeDetailsDto>().ReverseMap();
			CreateMap<CreateEmployeeRequestVM, Employee>().ReverseMap();
			CreateMap<UpdateEmployeeRequestVM, Employee>().ReverseMap();

			CreateMap<CreateDepartmentRequestVM, Department>();
			CreateMap<UpdateDepartmentRequestVM, Department>();

			CreateMap<Department, DepartmentDto>()
				.ForMember(dest => dest.Manager, act => act.MapFrom(src => src.Manager));

			CreateMap<Team, TeamDto>()
				.ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department.Name));

			CreateMap<DailyPlan, DailyPlanDto>()
				.ForMember(dest => dest.Status, opt => opt.MapFrom(src => $"{(int)src.Status} : {src.Status}"))
				.ForMember(dest => dest.EmployeeUsername, opt => opt.MapFrom( src => src.Employee.UserName))
				;

		}
	}
}

