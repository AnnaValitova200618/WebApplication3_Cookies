using System;
using System.Collections.Generic;

namespace WebApplication3_Cookies.Models;

public partial class Access
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public virtual ICollection<Visit> Visits { get; } = new List<Visit>();
}
