using AutoMapper;
using JWTAuthentication.Application.Common;
using JWTAuthentication.Application.Dtos;
using JWTAuthentication.Data.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace JWTAuthentication.Application.Contract.Services
{
    public class AccountService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public IConfiguration configuration;

        public AccountService(IConfiguration configuration, IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.configuration = configuration;
        }

        public string Login(string username, string password)
        {
            UserDetails user = this.unitOfWork.User.UserDetails(username);

            if (user == null)
            {
                return "User Not Found";
            }
            else
            {
                if (!Crypto.VerifyHashedPassword(user.Password, password))
                {
                    return "Username and Password did not match.";
                }
                var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, this.configuration["JWT:Subject"]!),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("UserId", user.UserId.ToString()),
                        new Claim("DisplayName", user.DisplayName),
                        new Claim("UserName", user.UserName),
                        new Claim("Email", user.Email)
                    };


                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.configuration["JWT:Secret"]!));
                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                        this.configuration["JWT:ValidIssuer"]!,
                        this.configuration["JWT:ValidAudience"]!,
                        claims,
                        expires: DateTime.UtcNow.AddMinutes(10),
                        signingCredentials: signIn);


                UserInfo userInfo = new();
                userInfo.Token = new JwtSecurityTokenHandler().WriteToken(token);
                return new JwtSecurityTokenHandler().WriteToken(token);
            }
        }

        public bool Register(UserDetails model)
        {
            var employees = this.unitOfWork.User.Add(model);
            if (employees)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
