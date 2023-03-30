using System;
using System.Collections.Generic;

namespace WebApplication3_Cookies.Models;

public partial class Request
{
    public int Id { get; set; }

    public int? IdWorker { get; set; }

    public DateTime? TimeStart { get; set; }

    public DateTime? TimeEnd { get; set; }

    public int? IdReason { get; set; }

    public int? IdVisitPorose { get; set; }

    public int? IdStatus { get; set; }

    public int? GroupUsers { get; set; }

    public virtual ICollection<CrossUserRequest> CrossUserRequests { get; } = new List<CrossUserRequest>();

    public virtual Reason? IdReasonNavigation { get; set; }

    public virtual Status? IdStatusNavigation { get; set; }

    public virtual VisitPorpose? IdVisitPoroseNavigation { get; set; }

    public virtual Worker? IdWorkerNavigation { get; set; }

    public virtual ICollection<Visit> Visits { get; } = new List<Visit>();
}
