using JWTAuthentication.Application.Common;
using JWTAuthentication.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JWTAuthentication.Application.Contract
{
    public interface IEmployees : IGenericRepositoryBase<Employee>
    {
        public bool CheckEmployee(int id);
    }
}
