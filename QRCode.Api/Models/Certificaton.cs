using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace QRCode.Api.Models;

public partial class Certificaton
{
    public decimal Id { get; set; }

    public decimal? UserCourseId { get; set; }

    public string? CertificatonUrl { get; set; }

    public DateTime? DateOfIssuance { get; set; }

    public string? Token { get; set; }

    public DateTime? ExpDate { get; set; }

    public string? Status { get; set; }
    [NotMapped]
    public IFormFile? Image { get; set; }

    public virtual UserCourse? UserCourse { get; set; }
}
