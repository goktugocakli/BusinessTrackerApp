using System;
using AutoMapper;
using BusinessTrackerApp.Application.Abstractions.Services;
using BusinessTrackerApp.Application.Exceptions;
using BusinessTrackerApp.Application.Repositories.Department;
using BusinessTrackerApp.Application.ViewModels.Department;
using BusinessTrackerApp.Domain.Entities;

namespace BusinessTrackerApp.Persistence.Services
{
	public class DepartmentService : IDepartmentService
	{
		private readonly IDepartmentWriteRepository _departmentWriteRepository;
        private readonly IDepartmentReadRepository _departmentReadRepository;

        private readonly IMapper _mapper;

        public DepartmentService(IDepartmentWriteRepository departmentWriteRepository, IDepartmentReadRepository departmentReadRepository, IMapper mapper)
        {
            _departmentWriteRepository = departmentWriteRepository;
            _departmentReadRepository = departmentReadRepository;
            _mapper = mapper;
        }


        public IEnumerable<Department> FindAll()
        {
            return _departmentReadRepository.FindAll();
        }

        private async Task<Department> GetDepartmentByIdAndCheckExist(string id)
        {
            Department? department = await _departmentReadRepository.FindByIdAsync(id);

            return department ?? throw new DepartmentNotFoundException(id);
        }

        public async Task<Department> FindByIdAsync(string id)
        {
            return await GetDepartmentByIdAndCheckExist(id);
        }

        public async Task CreateDepartmentAsync(CreateDepartmentRequestVM createDepartmentRequest)
        {
            Department? department = await _departmentReadRepository.FindSingleByConditionAsync(d => d.Name == createDepartmentRequest.Name);

            if (department is not null)
                throw new DepartmentNameAlreadyExistException(createDepartmentRequest.Name);

            department = _mapper.Map<Department>(createDepartmentRequest);
            await _departmentWriteRepository.AddAsync(department);
            await _departmentWriteRepository.SaveAsync();
        }

        public async Task UpdateDepartmentAsync(UpdateDepartmentRequestVM updateDepartmentRequest)
        {
            Department department = await GetDepartmentByIdAndCheckExist(updateDepartmentRequest.Id);

            department.Name = updateDepartmentRequest.Name;

            if (updateDepartmentRequest.ManagerId is not null)
                department.ManagerId = Guid.Parse(updateDepartmentRequest.ManagerId);

            _departmentWriteRepository.Update(department);
            await _departmentWriteRepository.SaveAsync();
        }

        public async Task DeleteDepartmentAsync(string idOrName)
        {
            Department? department = await _departmentReadRepository.FindSingleByConditionAsync(d => d.Name == idOrName || d.Id.ToString() == idOrName);

            if(department is not null)
            {
                _departmentWriteRepository.Remove(department);
                await _departmentWriteRepository.SaveAsync();
            }

        }







    }
}

