using JWTAuthentication.API.Handlers;
using JWTAuthentication.Application.Contract;
using JWTAuthentication.Application.Contract.Services;
using JWTAuthentication.Application.Dtos;
using JWTAuthentication.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace JWTAuthentication.API.Controllers
{
    [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiVersion("1.0")]
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
        [Route("{v:apiVersion}/GetAllEmployees")]
        public async Task<ApiResponse<List<EmployeeDto>>> Get([FromQuery] OwnerParameters ownerParameters)
        {
            var apiResponse = new ApiResponse<List<EmployeeDto>>();
            try
            {
                var employees = await this.empService.GetAllEmployeesAsync(ownerParameters);

                var metadata = new
                {
                    employees.TotalCount,
                    employees.PageSize,
                    employees.CurrentPage,
                    employees.TotalPages,
                    employees.HasNext,
                    employees.HasPrevious
                };
                
                Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
                return apiResponse.HandleResponse(employees);
            }
            catch (Exception ex)
            {
                return apiResponse.HandleException(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetEmpById/{EmployeeId:long}")]
        public async Task<ApiResponse<EmployeeDto>> GetEmpById([FromRoute] long EmployeeId)
        {
            var apiResponse = new ApiResponse<EmployeeDto>();
            try
            {
                var employee = await this.empService.GetEmployeeDetailsAsync(EmployeeId);
                return apiResponse.HandleResponse(employee);
            }
            catch (Exception ex)
            {
                return apiResponse.HandleException(ex.Message);
            }

        }

        [HttpPost]
        [Route("CreateEmp")]
        public async Task<ApiResponse<EmployeeDto>> CreateEmp([FromBody] CreateEmployeeDto model)
        {
            var apiResponse = new ApiResponse<EmployeeDto>();
            try
            {
                var newEmp = await this.empService.CreateEmpAsync(model);
                return apiResponse.HandleResponse(newEmp);
            }
            catch (Exception ex)
            {
                return apiResponse.HandleException(ex.Message);
            }
        }

    }
}
