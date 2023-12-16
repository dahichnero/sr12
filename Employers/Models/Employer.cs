using System;
using System.Collections.Generic;

namespace Employers.Models;

public partial class Employer
{
    public int EmployeeId { get; set; }

    public string FirstName { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? LastName { get; set; }

    public DateTime Birth { get; set; }

    public string Address { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Passport { get; set; } = null!;

    public string Photo { get; set; } = null!;

    public int Job { get; set; }

    public virtual Job JobNavigation { get; set; } = null!;
}
