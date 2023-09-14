using System;
using AutoMapper;
using BusinessTrackerApp.Application.DTOs.DailyPlan;
using BusinessTrackerApp.Application.DTOs.Employee;
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
			CreateMap<EmployeeResponseVM, Employee>().ReverseMap();

			CreateMap<CreateDepartmentRequestVM, Department>();
			CreateMap<UpdateDepartmentRequestVM, Department>();
			CreateMap<Department, DepartmentResponseVM>();

			CreateMap<DailyPlan, DailyPlanDto>()
				.ForMember(dest => dest.Status, opt => opt.MapFrom(src => $"{(int)src.Status} : {src.Status}"))
				;



		}
	}
}

