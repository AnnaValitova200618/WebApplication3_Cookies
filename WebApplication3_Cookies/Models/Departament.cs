using System;
using System.Collections.Generic;

namespace WebApplication3_Cookies.Models;

public partial class Departament
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public virtual ICollection<Worker> Workers { get; } = new List<Worker>();
}
