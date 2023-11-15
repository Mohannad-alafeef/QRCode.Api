using System;
using System.Collections.Generic;

namespace QRCode.Api.Models;

public partial class Role
{
    public decimal Id { get; set; }

    public string? RoleName { get; set; }

    public virtual ICollection<UserAccount> UserAccounts { get; set; } = new List<UserAccount>();
}
