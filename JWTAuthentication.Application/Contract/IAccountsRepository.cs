using JWTAuthentication.Application.Dtos;
using JWTAuthentication.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JWTAuthentication.Application.Contract
{
    public interface IAccountsRepository
    {
        UserDetails UserDetails(string username);
        bool Add(UserDetails entity);
    }
}
