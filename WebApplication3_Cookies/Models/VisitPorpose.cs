﻿using System;
using System.Collections.Generic;

namespace WebApplication3_Cookies.Models;

public partial class VisitPorpose
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public virtual ICollection<Request> Requests { get; } = new List<Request>();
}
