using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NetSpeed.Evolution.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Add_ActionPlain5W2HFollowUp_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActionPlain5W2HFollowUp",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActionPlain5W2HId = table.Column<long>(type: "bigint", nullable: false),
                    Annotation = table.Column<string>(type: "varchar(1000)", nullable: false),
                    CreatedById = table.Column<long>(type: "bigint", nullable: false),
                    UpdatedById = table.Column<long>(type: "bigint", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionPlain5W2HFollowUp", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActionPlain5W2HFollowUp_ActionPlain5W2H_ActionPlain5W2HId",
                        column: x => x.ActionPlain5W2HId,
                        principalTable: "ActionPlain5W2H",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ActionPlain5W2HFollowUp_User_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ActionPlain5W2HFollowUp_User_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActionPlain5W2HFollowUp_ActionPlain5W2HId",
                table: "ActionPlain5W2HFollowUp",
                column: "ActionPlain5W2HId");

            migrationBuilder.CreateIndex(
                name: "IX_ActionPlain5W2HFollowUp_CreatedById",
                table: "ActionPlain5W2HFollowUp",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ActionPlain5W2HFollowUp_UpdatedById",
                table: "ActionPlain5W2HFollowUp",
                column: "UpdatedById");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActionPlain5W2HFollowUp");
        }
    }
}
