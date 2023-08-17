using JWTAuthentication.Application.Common;
using JWTAuthentication.Application.Contract;
using JWTAuthentication.Application.Contract.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JWTAuthenticationInfrastructure.AccountServices
{
    public class EmployeeServices 
    {
        public IUnitOfWork UnitOfWork => throw new NotImplementedException();

        public IEmployees Employees => throw new NotImplementedException();
    }
}
