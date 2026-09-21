using AspNetCoreDatabaseFirstStoredProcedureCRUD.Models;
using AspNetCoreDatabaseFirstStoredProcedureCRUD.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace AspNetCoreDatabaseFirstStoredProcedureCRUD.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly SpcoreDbContext _db;
        private readonly IWebHostEnvironment _env;

        public EmployeesController(SpcoreDbContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var employees = await _db.Employees
                                     .Include(s => s.Skill)
                                     .Include(m => m.SkillModules)
                                     .ToListAsync();
            return View(employees);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var viewModel = new EmployeeViewModel
            {
                Skills = await _db.Skills.ToListAsync()
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EmployeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                string imageName = await GetImageName(model.ProfileFile);

                var skillModuleTable = new DataTable();
                skillModuleTable.Columns.Add("ModuleName", typeof(string));
                skillModuleTable.Columns.Add("Duration", typeof(int));

                if (model.SkillModules != null && model.SkillModules.Any())
                {
                    foreach (var mod in model.SkillModules)
                    {
                        skillModuleTable.Rows.Add(mod.ModuleName, mod.Duration);
                    }
                }

                var parameters = new[]
                {
                    new SqlParameter("@EmployeeName", SqlDbType.NVarChar) { Value = (object)model.EmployeeName ?? DBNull.Value },
                    new SqlParameter("@JoinDate", SqlDbType.DateTime) { Value = model.JoinDate },
                    new SqlParameter("@MobileNo", SqlDbType.VarChar) { Value = (object)model.MobileNo ?? DBNull.Value },
                    new SqlParameter("@IsActive", SqlDbType.Bit) { Value = model.IsActive },
                    new SqlParameter("@SkillId", SqlDbType.Int) { Value = model.SkillId },
                    new SqlParameter("@ImageUrl", SqlDbType.NVarChar) { Value = (object)imageName ?? DBNull.Value },
                    new SqlParameter("@SkillBudget", SqlDbType.Decimal) { Value = model.SkillBudget },
                    new SqlParameter("@SkillModules", SqlDbType.Structured) { Value = skillModuleTable, TypeName = "dbo.ParamModuleType" }
                };

                await _db.Database.ExecuteSqlRawAsync(
                    "EXEC dbo.InsertEmployeeSP @EmployeeName, @JoinDate, @MobileNo, @IsActive, @SkillId, @ImageUrl, @SkillBudget, @SkillModules",
                    parameters
                );

                return RedirectToAction(nameof(Index));
            }

            model.Skills = await _db.Skills.ToListAsync();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var employee = await _db.Employees
                                    .Include(e => e.SkillModules)
                                    .FirstOrDefaultAsync(e => e.EmployeeId == id);

            if (employee == null) return NotFound();

            var viewModel = new EmployeeViewModel
            {
                EmployeeId = employee.EmployeeId,
                EmployeeName = employee.EmployeeName,
                JoinDate = employee.JoinDate,
                ImageUrl = employee.ImageUrl,
                SkillId = employee.SkillId,
                MobileNo = employee.MobileNo,
                IsActive = employee.IsActive,
                SkillBudget = employee.SkillBudget,
                SkillModules = employee.SkillModules?.ToList() ?? new List<SkillModule>(),
                Skills = await _db.Skills.ToListAsync()
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EmployeeViewModel model, string? OldImageUrl)
        {
            if (!ModelState.IsValid)
            {
                model.Skills = await _db.Skills.ToListAsync();
                return View(model);
            }

            var existingEmployee = await _db.Employees
                                            .Include(e => e.SkillModules)
                                            .FirstOrDefaultAsync(e => e.EmployeeId == model.EmployeeId);

            if (existingEmployee == null) return NotFound();

            if (model.ProfileFile != null && model.ProfileFile.Length > 0)
            {
                string imageName = await GetImageName(model.ProfileFile);

                if (!string.IsNullOrEmpty(OldImageUrl))
                {
                    string oldPath = Path.Combine(_env.WebRootPath, "images", Path.GetFileName(OldImageUrl));
                    if (System.IO.File.Exists(oldPath))
                    {
                        System.IO.File.Delete(oldPath);
                    }
                }
                existingEmployee.ImageUrl = imageName;
            }
            else
            {
                existingEmployee.ImageUrl = OldImageUrl ?? existingEmployee.ImageUrl;
            }

            existingEmployee.EmployeeName = model.EmployeeName;
            existingEmployee.JoinDate = model.JoinDate;
            existingEmployee.MobileNo = model.MobileNo;
            existingEmployee.IsActive = model.IsActive;
            existingEmployee.SkillId = model.SkillId;
            existingEmployee.SkillBudget = model.SkillBudget;

            _db.SkillModules.RemoveRange(existingEmployee.SkillModules);

            if (model.SkillModules != null && model.SkillModules.Any())
            {
                foreach (var mod in model.SkillModules)
                {
                    existingEmployee.SkillModules.Add(new SkillModule
                    {
                        ModuleName = mod.ModuleName,
                        Duration = mod.Duration,
                        EmployeeId = existingEmployee.EmployeeId
                    });
                }
            }

            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var emp = await _db.Employees
                               .Include(e => e.SkillModules)
                               .FirstOrDefaultAsync(e => e.EmployeeId == id);

            if (emp == null) return NotFound();

            if (!string.IsNullOrEmpty(emp.ImageUrl))
            {
                string imagePath = Path.Combine(_env.WebRootPath, "images", emp.ImageUrl);
                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }
            }

            _db.Employees.Remove(emp);
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private async Task<string> GetImageName(IFormFile? profileFile)
        {
            if (profileFile == null || profileFile.Length == 0) return string.Empty;

            string uploadFolder = Path.Combine(_env.WebRootPath, "images");

            if (!Directory.Exists(uploadFolder))
            {
                Directory.CreateDirectory(uploadFolder);
            }

            string imageName = Guid.NewGuid().ToString() + Path.GetExtension(profileFile.FileName);
            string filePath = Path.Combine(uploadFolder, imageName);

            await using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await profileFile.CopyToAsync(fileStream);
            }

            return imageName;
        }
    }
}
