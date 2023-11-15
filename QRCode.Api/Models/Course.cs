using System;
using System.Collections.Generic;

namespace QRCode.Api.Models;

public partial class Course
{
    public decimal Id { get; set; }

    public string? CourseName { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public string? Time { get; set; }

    public string? ImagUrl { get; set; }

    public string? Instructor { get; set; }

    public virtual ICollection<UserCourse> UserCourses { get; set; } = new List<UserCourse>();
}
