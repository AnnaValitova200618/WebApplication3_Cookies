using System;
using System.Collections.Generic;

namespace WebApplication3_Cookies.Models;

public partial class CrossUserRequest
{
    public int IdUser { get; set; }

    public int IdRequest { get; set; }

    public virtual User IdRequest1 { get; set; } = null!;

    public virtual Request IdRequestNavigation { get; set; } = null!;
}
