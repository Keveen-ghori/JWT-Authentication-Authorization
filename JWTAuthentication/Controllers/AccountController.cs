using AutoMapper;
using JWTAuthentication.API.Handlers;
using JWTAuthentication.Application.Contract;
using JWTAuthentication.Application.Contract.Services;
using JWTAuthentication.Application.Dtos;
using JWTAuthentication.Data.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JWTAuthentication.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        public AccountService accountService;
        private readonly IMapper mapper;

        public AccountController(AccountService accountService, IMapper mapper)
        {
            this.accountService = accountService;
            this.mapper = mapper;
        }

        [HttpPost]
        [Route("Login")]
        public ApiResponse<string> Login(string userName, string password)
        {
            var apiResponse = new ApiResponse<string>();

            try
            {
                if (userName == null && password == null)
                {
                    throw new ArgumentException("Please Enter Username and Password");
                }
                else if (password == null)
                {
                    throw new ArgumentException("Please enter Password");
                }
                else if (userName == null)
                {
                    throw new ArgumentException("Please enter Username");
                }
                else
                {
                    string message = this.accountService.Login(userName, password);

                    return apiResponse.HandleResponse(message);
                }
            }
            catch (Exception ex)
            {
                return apiResponse.HandleException(ex.Message);
            }
        }

        [HttpPost]
        [Route("Register")]
        public ApiResponse<string> Register(CreateUser model)
        {
            var apiResponse = new ApiResponse<string>();

            try
            {
                bool success = false;
                if (ModelState.IsValid)
                {
                    UserDetails userDetails = mapper.Map<UserDetails>(model);
                    success = this.accountService.Register(userDetails);

                    return apiResponse.HandleResponse(success ? "Register successfully." : "There are some isuue in creating your account.");
                }
                throw new ArgumentException(ModelState.ErrorCount.ToString());
            }
            catch (Exception ex)
            {
                return apiResponse.HandleException(ex.Message);
            }

        }

        [HttpGet]
        [Route("Token")]
        public async Task<IEnumerable<string>> Get()
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");

            return new string[] { accessToken! };
        }
    }
}
