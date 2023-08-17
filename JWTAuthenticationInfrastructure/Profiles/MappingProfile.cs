using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using JWTAuthentication.Application.Dtos;
using JWTAuthentication.Data.Models;

namespace JWTAuthenticationInfrastructure.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, EmployeeDto>().ReverseMap();
            CreateMap<UserDetails, CreateUser>().ReverseMap();
            CreateMap<UserDetails, User>().ReverseMap();
        }
    }
}
