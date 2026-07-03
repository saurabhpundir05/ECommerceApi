using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ECommerce.DataAccess.Data.Migrations
{
    /// <inheritdoc />
    public partial class Add_Users : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Role = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DeletedBy = table.Column<int>(type: "int", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "DeletedBy", "Email", "Name", "Password", "Role", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 7, 3, 18, 55, 45, 625, DateTimeKind.Utc).AddTicks(8284), null, null, "doraemon@doraemon.com", "Doraemon", "$2a$10$OJ4AKll05OWIL2gMODgBp.zS38Ub8alGF50CSN9AGJxE/lSSD03zO", 0, 0, null },
                    { 2, new DateTime(2026, 7, 3, 18, 55, 45, 693, DateTimeKind.Utc).AddTicks(7676), null, null, "nobita@doraemon.com", "Nobita", "$2a$10$Uqing7CoQ9zUrAZH1Z/ce.tssHOKaMokIcuL55sOHz6L/AgL4ZPi6", 1, 0, null },
                    { 3, new DateTime(2026, 7, 3, 18, 55, 45, 748, DateTimeKind.Utc).AddTicks(9062), null, null, "shizuka@doraemon.com", "Shizuka", "$2a$10$Ul/xdmQTXWl2da1A22bmRuP5DD0UE6qqgu8v0oeNY.CDE2rbrfSSa", 2, 0, null },
                    { 4, new DateTime(2026, 7, 3, 18, 55, 45, 804, DateTimeKind.Utc).AddTicks(3544), null, null, "naruto@naruto.com", "Naruto", "$2a$10$1/70ojPOPGD8vAtEFKwEG.T9E3jbkFCpzJHjX0Pla48OyP.Sh3xZO", 1, 0, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
