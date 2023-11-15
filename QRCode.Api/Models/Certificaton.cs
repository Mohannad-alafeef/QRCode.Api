using System;
using System.Collections.Generic;

namespace QRCode.Api.Models;

public partial class Certificaton
{
    public decimal Id { get; set; }

    public decimal? UserCourseId { get; set; }

    public string? CertificatonUrl { get; set; }

    public DateTime? DateOfIssuance { get; set; }

    public string? Token { get; set; }

    public virtual UserCourse? UserCourse { get; set; }
}
