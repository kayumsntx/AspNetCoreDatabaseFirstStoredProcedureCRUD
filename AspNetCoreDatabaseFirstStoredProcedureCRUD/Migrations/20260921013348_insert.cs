using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspNetCoreDatabaseFirstStoredProcedureCRUD.Migrations
{
    /// <inheritdoc />
    public partial class insert : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.Sql(@"
                IF NOT EXISTS (SELECT * FROM sys.types WHERE name = 'ParamModuleType')
                BEGIN
                    CREATE TYPE dbo.ParamModuleType AS TABLE
                    (
                        ModuleName VARCHAR(50),
                        Duration   INT
                    );
                END
            ");

            migrationBuilder.Sql(@"
                CREATE OR ALTER PROC dbo.InsertEmployeeSP
                    @EmployeeName VARCHAR(50),
                    @JoinDate     DATETIME,
                    @MobileNo     VARCHAR(11),
                    @IsActive     BIT,
                    @SkillId      INT,
                    @ImageUrl     VARCHAR(100),
                    @SkillBudget  DECIMAL(18,2),
                    @SkillModules dbo.ParamModuleType READONLY
                AS
                BEGIN
                    SET NOCOUNT ON;
                    BEGIN TRY
                        DECLARE @EmployeeId INT;

                        INSERT INTO dbo.Employee (EmployeeName, JoinDate, MobileNo, IsActive, SkillId, ImageUrl, SkillBudget)
                        VALUES (@EmployeeName, @JoinDate, @MobileNo, @IsActive, @SkillId, @ImageUrl, @SkillBudget);

                        SET @EmployeeId = SCOPE_IDENTITY();

                        INSERT INTO dbo.SkillModule (ModuleName, Duration, EmployeeId)
                        SELECT ModuleName, Duration, @EmployeeId
                        FROM @SkillModules;
                    END TRY
                    BEGIN CATCH
                        THROW;
                    END CATCH
                END
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP PROC IF EXISTS dbo.InsertEmployeeSP;");
            migrationBuilder.Sql(@"DROP TYPE IF EXISTS dbo.ParamModuleType;");
        }
    }
}
