using System;
using System.Collections.Generic;

namespace QRCode.Api.Models;

public partial class Cousre
{
    public decimal Id { get; set; }

    public string? Cousrename { get; set; }

    public DateTime? Startdate { get; set; }

    public DateTime? Enddate { get; set; }

    public DateTime? Time { get; set; }

    public string? Instructor { get; set; }

    public virtual ICollection<Usercousre> Usercousres { get; set; } = new List<Usercousre>();
}
