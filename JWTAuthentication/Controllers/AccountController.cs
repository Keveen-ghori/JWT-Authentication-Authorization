using AutoMapper;
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
        public IActionResult Login(string userName, string password)
        {
            if (userName == null && password == null)
            {
                return BadRequest("Please Enter Username and Password");
            }
            else if (password == null)
            {
                return BadRequest("Please enter Password");
            }
            else if (userName == null)
            {
                return BadRequest("Please enter Username");
            }
            else
            {
                string message = this.accountService.Login(userName, password);

                return Ok(message);
            }
        }

        [HttpPost]
        [Route("Register")]
        public IActionResult Register(CreateUser model)
        {
            bool success = false;
            if (ModelState.IsValid)
            {
                UserDetails userDetails = mapper.Map<UserDetails>(model);
                success = this.accountService.Register(userDetails);

                return Ok(success ? "Register successfully." : "There are some isuue in creating your account.");
            }
            return BadRequest(ModelState.ErrorCount);
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
