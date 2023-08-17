using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JWTAuthentication.Application.Dtos
{
    public class EmployeeDto
    {
        public string FirstName { get; set; } = string.Empty;

        public string? LastName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public DateTime? Dob { get; set; }

        public byte Gender { get; set; }

        public string Password { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
    }
}
