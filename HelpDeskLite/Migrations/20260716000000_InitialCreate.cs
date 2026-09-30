using HelpDeskLite.Data;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HelpDeskLite.Migrations;

[DbContext(typeof(ApplicationDbContext))]
[Migration("20260716000000_InitialCreate")]
public partial class InitialCreate : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Tickets",
            columns: table => new
            {
                Id = table.Column<int>(type: "int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Title = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                RequesterName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                RequesterEmail = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                Category = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                Priority = table.Column<int>(type: "int", nullable: false),
                Status = table.Column<int>(type: "int", nullable: false),
                CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                ResolvedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Tickets", x => x.Id);
            });

        migrationBuilder.CreateIndex(
            name: "IX_Tickets_CreatedAt",
            table: "Tickets",
            column: "CreatedAt");

        migrationBuilder.CreateIndex(
            name: "IX_Tickets_Priority",
            table: "Tickets",
            column: "Priority");

        migrationBuilder.CreateIndex(
            name: "IX_Tickets_Status",
            table: "Tickets",
            column: "Status");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(name: "Tickets");
    }
}
