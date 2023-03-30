using System;
using System.Collections.Generic;

namespace WebApplication3_Cookies.Models;

public partial class Visit
{
    public int Id { get; set; }

    public DateTime? TimeStart { get; set; }

    public DateTime? TimeEnd { get; set; }

    public int? IdAccess { get; set; }

    public int? IdRequest { get; set; }

    public DateTime? TimeSubdivisionStart { get; set; }

    public DateTime? TimeSubdivsionEnd { get; set; }

    public virtual Access? IdAccessNavigation { get; set; }

    public virtual Request? IdRequestNavigation { get; set; }
}
