using System;
using System.Collections.Generic;

namespace Employers.Models;

public partial class Job
{
    public int JobId { get; set; }

    public string? JobName { get; set; }

    public virtual ICollection<Employer> Employers { get; set; } = new List<Employer>();
}
