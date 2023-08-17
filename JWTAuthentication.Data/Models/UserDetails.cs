using System;
using System.Collections.Generic;

namespace JWTAuthentication.Data.Models;

public partial class UserDetails
{
    public int UserId { get; set; }

    public string DisplayName { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public DateTime CreatedDate { get; set; }
}
