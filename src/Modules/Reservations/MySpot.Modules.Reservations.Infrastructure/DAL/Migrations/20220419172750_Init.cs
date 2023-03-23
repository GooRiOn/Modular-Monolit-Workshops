using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MySpot.Modules.Reservations.Infrastructure.DAL.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "reservations");

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "reservations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    JobTitle = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WeeklyReservations",
                schema: "reservations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: true),
                    Week = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    JobTitle = table.Column<string>(type: "text", nullable: true),
                    Version = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeeklyReservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeeklyReservations_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "reservations",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                schema: "reservations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ParkingSpotId = table.Column<Guid>(type: "uuid", nullable: true),
                    Capacity = table.Column<int>(type: "integer", nullable: true),
                    LicensePlate = table.Column<string>(type: "text", nullable: true),
                    Date = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    Note = table.Column<string>(type: "text", nullable: true),
                    State = table.Column<string>(type: "text", nullable: true),
                    WeeklyReservationsId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservations_WeeklyReservations_WeeklyReservationsId",
                        column: x => x.WeeklyReservationsId,
                        principalSchema: "reservations",
                        principalTable: "WeeklyReservations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_WeeklyReservationsId",
                schema: "reservations",
                table: "Reservations",
                column: "WeeklyReservationsId");

            migrationBuilder.CreateIndex(
                name: "IX_WeeklyReservations_UserId_Week",
                schema: "reservations",
                table: "WeeklyReservations",
                columns: new[] { "UserId", "Week" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservations",
                schema: "reservations");

            migrationBuilder.DropTable(
                name: "WeeklyReservations",
                schema: "reservations");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "reservations");
        }
    }
}
