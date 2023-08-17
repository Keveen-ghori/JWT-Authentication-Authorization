using JWTAuthentication.Application.Common;
using JWTAuthentication.Application.Contract;
using JWTAuthentication.Data.Models;
using JWTAuthentication.Data.Settings;
using JWTAuthenticationInfrastructure.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JWTAuthenticationInfrastructure.AccountRepository
{
    public class EmployeeRepository : GenericRepositoryBase<Employee>, IEmployees
    {

        private readonly EmsContext emscontext;

        public EmployeeRepository(EmsContext emscontext) : base(emscontext)
        {
            this.emscontext = emscontext;
        }

        public bool CheckEmployee(int id)
        {
            return this.emscontext.Employees.Any(e => e.EmployeeId == id);
        }

    }
}
