using System;
using System.Collections.Generic;

namespace WebApplication3_Cookies.Models;

public partial class DarkList
{
    public int Id { get; set; }

    public int IdUser { get; set; }

    public virtual User IdUserNavigation { get; set; } = null!;
}
