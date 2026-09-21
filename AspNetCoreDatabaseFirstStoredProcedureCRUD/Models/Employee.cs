using System;
using System.Collections.Generic;

namespace AspNetCoreDatabaseFirstStoredProcedureCRUD.Models;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string EmployeeName { get; set; } = null!;

    public DateTime JoinDate { get; set; }

    public bool IsActive { get; set; }

    public string MobileNo { get; set; } = null!;

    public int SkillId { get; set; }

    public decimal SkillBudget { get; set; }

    public string? ImageUrl { get; set; }

    public virtual Skill Skill { get; set; } = null!;

    public virtual ICollection<SkillModule> SkillModules { get; set; } = new List<SkillModule>();
}
