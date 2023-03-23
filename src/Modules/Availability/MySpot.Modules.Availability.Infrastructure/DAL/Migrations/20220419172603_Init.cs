using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MySpot.Modules.Availability.Infrastructure.DAL.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "availability");

            migrationBuilder.CreateTable(
                name: "Resources",
                schema: "availability",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Capacity = table.Column<int>(type: "integer", nullable: true),
                    Tags = table.Column<string>(type: "text", nullable: true),
                    Version = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resources", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                schema: "availability",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Capacity = table.Column<int>(type: "integer", nullable: true),
                    Date = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    ResourceId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservations_Resources_ResourceId",
                        column: x => x.ResourceId,
                        principalSchema: "availability",
                        principalTable: "Resources",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ResourceId",
                schema: "availability",
                table: "Reservations",
                column: "ResourceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservations",
                schema: "availability");

            migrationBuilder.DropTable(
                name: "Resources",
                schema: "availability");
        }
    }
}
