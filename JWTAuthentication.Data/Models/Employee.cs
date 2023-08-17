using System;
using System.Collections.Generic;

namespace JWTAuthentication.Data.Models;

public partial class Employee
{
    public long EmployeeId { get; set; }

    public string FirstName { get; set; } = null!;

    public string? LastName { get; set; }

    public string Email { get; set; } = null!;

    public DateTime? Dob { get; set; }

    public byte Gender { get; set; }

    public string Password { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public int? Attemps { get; set; }

    public int TotalAttemps { get; set; }

    public bool? Status { get; set; }

    public bool? IsLocked { get; set; }

    public string UserName { get; set; } = null!;

    public int? ExpDays { get; set; }

    public DateTime? PasswordUpdatedAt { get; set; }
}
