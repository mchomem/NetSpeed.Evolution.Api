using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NetSpeed.Evolution.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddTables_Swot_Strength_Opportunity_Threat_Weakness : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            #region Necessário para desfazer o IDENTITY na coluna Id da tabela Employee

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Employee_ManagerId",
                table: "Employee"
            );

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeHardSkills_Employee_EmployeeId",
                table: "EmployeeHardSkills"
            );

            migrationBuilder.DropPrimaryKey(name: "PK_Employee", table: "Employee");

            migrationBuilder.Sql(@"
                -- Criar uma nova coluna temporária sem IDENTITY
                alter table Employee add IdTemp bigint not null;

                -- Remover a restrição de chave primária
                alter table Employee drop column Id;

                -- Renomear a nova coluna para substituir a antiga
                exec sp_rename 'Employee.IdTemp', 'Id', 'column';

                -- Restaurar a chave primária
                alter table Employee add constraint PK_Employee primary key (Id);
            ");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Employee_ManagerId",
                table: "Employee",
                column: "ManagerId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeHardSkills_Employee_EmployeeId",
                table: "EmployeeHardSkills",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            #endregion

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "varchar(30)", nullable: false),
                    Password = table.Column<string>(type: "varchar(100)", nullable: false),
                    Blocked = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "0")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Swot",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedById = table.Column<long>(type: "bigint", nullable: false),
                    UpdatedById = table.Column<long>(type: "bigint", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<string>(type: "varchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Swot", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Swot_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Swot_User_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Swot_User_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Opportunity",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SwotId = table.Column<long>(type: "bigint", nullable: false),
                    Description = table.Column<string>(type: "varchar(100)", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Opportunity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Opportunity_Swot_SwotId",
                        column: x => x.SwotId,
                        principalTable: "Swot",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Strength",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SwotId = table.Column<long>(type: "bigint", nullable: false),
                    Description = table.Column<string>(type: "varchar(100)", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Strength", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Strength_Swot_SwotId",
                        column: x => x.SwotId,
                        principalTable: "Swot",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Threat",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SwotId = table.Column<long>(type: "bigint", nullable: false),
                    Description = table.Column<string>(type: "varchar(100)", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Threat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Threat_Swot_SwotId",
                        column: x => x.SwotId,
                        principalTable: "Swot",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Weakness",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SwotId = table.Column<long>(type: "bigint", nullable: false),
                    Description = table.Column<string>(type: "varchar(100)", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weakness", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Weakness_Swot_SwotId",
                        column: x => x.SwotId,
                        principalTable: "Swot",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Opportunity_SwotId",
                table: "Opportunity",
                column: "SwotId");

            migrationBuilder.CreateIndex(
                name: "IX_Strength_SwotId",
                table: "Strength",
                column: "SwotId");

            migrationBuilder.CreateIndex(
                name: "IX_Swot_CreatedById",
                table: "Swot",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Swot_EmployeeId",
                table: "Swot",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Swot_UpdatedById",
                table: "Swot",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Threat_SwotId",
                table: "Threat",
                column: "SwotId");

            migrationBuilder.CreateIndex(
                name: "IX_Weakness_SwotId",
                table: "Weakness",
                column: "SwotId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Employee_Id",
                table: "Employee",
                column: "Id",
                principalTable: "User",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Employee_Id",
                table: "Employee");

            migrationBuilder.DropTable(
                name: "Opportunity");

            migrationBuilder.DropTable(
                name: "Strength");

            migrationBuilder.DropTable(
                name: "Threat");

            migrationBuilder.DropTable(
                name: "Weakness");

            migrationBuilder.DropTable(
                name: "Swot");

            migrationBuilder.DropTable(
                name: "User");

            #region Necessário para refazer o IDENTITY na coluna Id da tabela Employee

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Employee_ManagerId",
                table: "Employee"
            );

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeHardSkills_Employee_EmployeeId",
                table: "EmployeeHardSkills"
            );

            migrationBuilder.DropPrimaryKey(name: "PK_Employee", table: "Employee");

            migrationBuilder.Sql(@"
                -- Criar uma nova coluna temporária IDENTITY
                alter table Employee add IdTemp bigint IDENTITY(1,1)  not null;

                -- Remover a chave primária
                alter table Employee drop column Id;

                -- Renomear de volta para 'Id'
                exec sp_rename 'Employee.IdTemp', 'Id', 'column';

                -- Restaurar a chave primária
                alter table Employee add constraint PK_Employee primary key (Id);
            ");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Employee_ManagerId",
                table: "Employee",
                column: "ManagerId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeHardSkills_Employee_EmployeeId",
                table: "EmployeeHardSkills",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            #endregion
        }
    }
}
