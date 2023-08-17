using AutoMapper;
using Azure.Core;
using JWTAuthentication.Application.Common;
using JWTAuthentication.Application.Dtos;
using JWTAuthentication.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JWTAuthentication.Application.Contract.Services
{
    public class IEmployeeServices
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public IEmployeeServices(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }


        public async Task<List<EmployeeDto>> GetAllEmployeesAsync()
        {
            var employees = await this.unitOfWork.GenericRepositoryBase<Employee>()
                                                 .GetAllAsync(x => x.DeletedAt == null);


            return mapper.Map<List<EmployeeDto>>(employees);
        }

        public async Task<EmployeeDto> GetEmployeeDetailsAsync(long EmployeeId)
        {
            var employees = await this.unitOfWork.GenericRepositoryBase<Employee>()
                                                 .GetByIdAsync(x => x.DeletedAt == null && x.EmployeeId== EmployeeId);


            return mapper.Map<EmployeeDto>(employees);
        }

        public async Task<EmployeeDto> CreateEmpAsync(CreateEmployeeDto model)
        {
            var employees = await this.unitOfWork.GenericRepositoryBase<CreateEmployeeDto>()
                                                 .AddAsync(model);


            return mapper.Map<EmployeeDto>(employees);
        }

    }
}
