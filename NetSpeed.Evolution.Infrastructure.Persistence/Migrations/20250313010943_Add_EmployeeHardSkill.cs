using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NetSpeed.Evolution.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Add_EmployeeHardSkill : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeeHardSkills",
                columns: table => new
                {
                    EmployeeId = table.Column<long>(type: "bigint", nullable: false),
                    HardSkillId = table.Column<long>(type: "bigint", nullable: false),
                    Level = table.Column<string>(type: "varchar(15)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeHardSkills", x => new { x.EmployeeId, x.HardSkillId });
                    table.ForeignKey(
                        name: "FK_EmployeeHardSkills_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeHardSkills_HardSkill_HardSkillId",
                        column: x => x.HardSkillId,
                        principalTable: "HardSkill",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeHardSkills_HardSkillId",
                table: "EmployeeHardSkills",
                column: "HardSkillId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeHardSkills");
        }
    }
}
