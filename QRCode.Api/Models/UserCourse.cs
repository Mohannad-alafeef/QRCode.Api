using System;
using System.Collections.Generic;

namespace QRCode.Api.Models;

public partial class UserCourse
{
    public decimal Id { get; set; }

    public decimal? CourseId { get; set; }

    public decimal? UserAccountId { get; set; }

    public string? Status { get; set; }

    public decimal? Mark { get; set; }

    public virtual ICollection<Certificaton> Certificatons { get; set; } = new List<Certificaton>();

    public virtual Course? Course { get; set; }

    public virtual UserAccount? UserAccount { get; set; }
}
