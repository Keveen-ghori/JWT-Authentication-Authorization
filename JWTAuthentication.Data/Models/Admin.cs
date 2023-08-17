using System;
using System.Collections.Generic;

namespace JWTAuthentication.Data.Models;

public partial class Admin
{
    public long AdminId { get; set; }

    public string FirstName { get; set; } = null!;

    public string? LastName { get; set; }

    public string Email { get; set; } = null!;

    public DateTime? Dob { get; set; }

    public byte Gender { get; set; }

    public string Password { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public bool? Status { get; set; }

    public string UserName { get; set; } = null!;

    public DateTime PasswordUpdatedAt { get; set; }

    public int ExpDays { get; set; }
}
