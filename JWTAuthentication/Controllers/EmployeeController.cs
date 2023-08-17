using JWTAuthentication.Application.Contract.Services;
using JWTAuthentication.Application.Dtos;
using JWTAuthentication.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JWTAuthentication.API.Controllers
{
    [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeServices empService;

        public EmployeeController(IEmployeeServices empService)
        {
            this.empService = empService;
        }

        // GET: api/employee>
        [HttpGet]
        [Route("GetAllEmployees")]
        public async Task<ActionResult<List<EmployeeDto>>> Get()
        {
            var employees = await this.empService.GetAllEmployeesAsync();
            return Ok(employees);
        }

        [HttpGet]
        [Route("GetEmpById/{EmployeeId:long}")]
        public async Task<ActionResult<EmployeeDto>> GetEmpById([FromRoute] long EmployeeId)
        {
            try
            {
                var employee = await this.empService.GetEmployeeDetailsAsync(EmployeeId);
                return Ok(employee);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }

        }

        [HttpPost]
        [Route("CreateEmp")]
        public async Task<ActionResult<EmployeeDto>> CreateEmp([FromBody] CreateEmployeeDto model)
        {
            var newEmp = await this.empService.CreateEmpAsync(model);
            return Ok(newEmp);
        }

    }
}
