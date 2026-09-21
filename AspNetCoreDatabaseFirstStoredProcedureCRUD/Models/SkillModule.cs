using System;
using System.Collections.Generic;

namespace AspNetCoreDatabaseFirstStoredProcedureCRUD.Models;

public partial class SkillModule
{
    public int SkillModuleId { get; set; }

    public string ModuleName { get; set; } = null!;

    public int Duration { get; set; }

    public int EmployeeId { get; set; }

    public virtual Employee Employee { get; set; } = null!;
}
