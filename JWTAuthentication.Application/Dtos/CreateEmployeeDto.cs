using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace JWTAuthentication.Application.Dtos
{
    [DataContract]
    public class CreateEmployeeDto
    {
        [DataMember]
        public string FirstName { get; set; } = string.Empty;
        [DataMember]
        public string? LastName { get; set; } = string.Empty;
        [DataMember]
        public string Email { get; set; } = string.Empty;
        [DataMember]
        public string Password { get; set; } = String.Empty;
        [DataMember]
        public DateTime? DOB { get; set; }
        [DataMember]
        [Range(1, 3, ErrorMessage = "Invalid value for Gender.")]
        public byte Gender { get; set; }    
    }
}
