using System;
using System.Collections.Generic;

namespace WebApplication3_Cookies.Models;

public partial class Worker
{
    public int Id { get; set; }

    public string Fio { get; set; } = null!;

    public int? IdSubdivision { get; set; }

    public int? IdDepartamint { get; set; }

    public string? Code { get; set; }

    public virtual Departament? IdDepartamintNavigation { get; set; }

    public virtual Subdivision? IdSubdivisionNavigation { get; set; }

    public virtual ICollection<Request> Requests { get; } = new List<Request>();
}
