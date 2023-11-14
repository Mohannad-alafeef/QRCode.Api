using System;
using System.Collections.Generic;

namespace QRCode.Api.Models;

public partial class Usercousre
{
    public decimal Id { get; set; }

    public decimal? CousreId { get; set; }

    public decimal? UseraccountId { get; set; }

    public string? Stuts { get; set; }

    public decimal? Mark { get; set; }

    public virtual ICollection<Certificaton> Certificatons { get; set; } = new List<Certificaton>();

    public virtual Cousre? Cousre { get; set; }

    public virtual UserAccount? Useraccount { get; set; }
}
