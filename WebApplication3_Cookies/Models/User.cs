using System;
using System.Collections.Generic;

namespace WebApplication3_Cookies.Models;

public partial class User
{
    public int Id { get; set; }

    public string? Fio { get; set; }

    public string? NumberPhone { get; set; }

    public string? Email { get; set; }

    public DateTime? Dob { get; set; }

    public string? PasprtSeries { get; set; }

    public string? PasportNumber { get; set; }

    public string? Login { get; set; }

    public string? Password { get; set; }

    public string? Organization { get; set; }

    public string? Note { get; set; }

    public byte[]? Filee { get; set; }

    public virtual ICollection<CrossUserRequest> CrossUserRequests { get; } = new List<CrossUserRequest>();

    public virtual ICollection<DarkList> DarkLists { get; } = new List<DarkList>();
}
