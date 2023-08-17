using JWTAuthentication.Application.Contract;
using JWTAuthentication.Data.Models;
using JWTAuthentication.Data.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace JWTAuthenticationInfrastructure.AccountRepository
{
    public class AccountsRepository : IAccountsRepository
    {
        private readonly EmsContext emscontext;

        public AccountsRepository(EmsContext emscontext)
        {
            this.emscontext = emscontext;
        }

        public bool Add(UserDetails entity)
        {
            entity.DisplayName = entity.UserName;
            entity.CreatedDate = DateTime.Now;
            entity.Password = Crypto.HashPassword(entity.Password);
            this.emscontext.Add(entity);
            this.emscontext.SaveChanges();
            return true;
        }

        public UserDetails UserDetails(string username)
        {

            var user = this.emscontext.Users.FirstOrDefault(user => user.Email == username);

            return user!;
        }

    }
}
