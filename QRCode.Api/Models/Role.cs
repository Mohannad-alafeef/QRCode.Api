using System;
using System.Collections.Generic;

namespace QRCode.Api.Models;

public partial class Role
{
    public decimal Id { get; set; }

    public string? Rolename { get; set; }

    public virtual ICollection<UserAccount> Useraccounts { get; set; } = new List<UserAccount>();
}
