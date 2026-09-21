using System;
using System.Collections.Generic;

namespace AspNetCoreDatabaseFirstStoredProcedureCRUD.Models;

public partial class Skill
{
    public int SkillId { get; set; }

    public string SkillName { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
