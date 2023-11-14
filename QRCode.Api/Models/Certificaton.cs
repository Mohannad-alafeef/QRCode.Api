using System;
using System.Collections.Generic;

namespace QRCode.Api.Models;

public partial class Certificaton
{
    public decimal Id { get; set; }

    public decimal? UsercousreId { get; set; }

    public string? CertificatonUrl { get; set; }

    public DateTime? DateofIssuance { get; set; }

    public virtual Usercousre? Usercousre { get; set; }
}
