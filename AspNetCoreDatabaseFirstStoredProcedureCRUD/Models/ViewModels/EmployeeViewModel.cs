using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace AspNetCoreDatabaseFirstStoredProcedureCRUD.Models.ViewModels
{
    public class EmployeeViewModel
    {
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Employee name is required.")]
        [Display(Name = "Employee Name")]
        public string EmployeeName { get; set; } = null!;

        [Display(Name = "Join Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime JoinDate { get; set; } = DateTime.Now;

        [Display(Name = "Mobile No:")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Mobile number must be 11 digits.")]
        public string MobileNo { get; set; } = null!;

        [ValidateNever]
        public string ImageUrl { get; set; } = null!;
        public bool IsActive { get; set; }

        [Display(Name = "Skill List")]
        [Required(ErrorMessage = "Please select a skill")]
        public int SkillId { get; set; }

        [Display(Name = "Skill Budget")]
        public decimal SkillBudget { get; set; }

        [ValidateNever]
        public virtual Skill Skill { get; set; } = null!;

        [ValidateNever]
        public List<Skill>? Skills { get; set; }

        [ValidateNever]
        public IFormFile? ProfileFile { get; set; }

        [ValidateNever]
        public IList<SkillModule> SkillModules { get; set; } = new List<SkillModule>();
    }
}
