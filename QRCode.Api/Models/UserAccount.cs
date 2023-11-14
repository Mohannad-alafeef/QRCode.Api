using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace QRCode.Api.Models;

public partial class UserAccount
{
    public decimal? Id { get; set; }

    public decimal? RoleId { get; set; }

    public string? Firstname { get; set; }

    public string? Lastname { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? Password { get; set; }

    public string? ImagUrl { get; set; }

    public string? Address { get; set; }

    public string? Gender { get; set; }

    [NotMapped]
    public IFormFile? Image { get; set; }
    [NotMapped]
    public IFormFile? CV { get; set; }


    public DateTime? Dateofbirth { get; set; }

    public string? CvUrl { get; set; }

    public virtual Role? Role { get; set; }

    public virtual ICollection<Usercousre> Usercousres { get; set; } = new List<Usercousre>();
}
