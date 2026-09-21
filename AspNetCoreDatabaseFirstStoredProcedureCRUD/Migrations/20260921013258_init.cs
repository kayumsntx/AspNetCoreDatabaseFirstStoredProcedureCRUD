using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspNetCoreDatabaseFirstStoredProcedureCRUD.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "Skill",
            //    columns: table => new
            //    {
            //        SkillId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        SkillName = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__Skill__DFA09187D820A0F8", x => x.SkillId);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Employee",
            //    columns: table => new
            //    {
            //        EmployeeId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        EmployeeName = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
            //        JoinDate = table.Column<DateTime>(type: "datetime", nullable: false),
            //        IsActive = table.Column<bool>(type: "bit", nullable: false),
            //        MobileNo = table.Column<string>(type: "char(11)", unicode: false, fixedLength: true, maxLength: 11, nullable: false),
            //        SkillId = table.Column<int>(type: "int", nullable: false),
            //        SkillBudget = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
            //        ImageUrl = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__Employee__7AD04F11662A70DD", x => x.EmployeeId);
            //        table.ForeignKey(
            //            name: "FK__Employee__SkillI__38996AB5",
            //            column: x => x.SkillId,
            //            principalTable: "Skill",
            //            principalColumn: "SkillId",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "SkillModule",
            //    columns: table => new
            //    {
            //        SkillModuleId = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        ModuleName = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
            //        Duration = table.Column<int>(type: "int", nullable: false),
            //        EmployeeId = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK__SkillMod__CDCC035FB5613FF0", x => x.SkillModuleId);
            //        table.ForeignKey(
            //            name: "FK__SkillModu__Emplo__3B75D760",
            //            column: x => x.EmployeeId,
            //            principalTable: "Employee",
            //            principalColumn: "EmployeeId",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_Employee_SkillId",
            //    table: "Employee",
            //    column: "SkillId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_SkillModule_EmployeeId",
            //    table: "SkillModule",
            //    column: "EmployeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "SkillModule");

            //migrationBuilder.DropTable(
            //    name: "Employee");

            //migrationBuilder.DropTable(
            //    name: "Skill");
        }
    }
}
