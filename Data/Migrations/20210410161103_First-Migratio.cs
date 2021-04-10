using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class FirstMigratio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationFrom = table.Column<string>(nullable: false),
                    LocationTo = table.Column<string>(nullable: false),
                    TakeOffTime = table.Column<DateTime>(nullable: false),
                    LandingTime = table.Column<DateTime>(nullable: false),
                    TypeOfPlane = table.Column<string>(nullable: false),
                    NameOfAviator = table.Column<string>(nullable: false),
                    CapacityOfStandartClass = table.Column<int>(nullable: false),
                    CapacityOfBusinessClass = table.Column<int>(nullable: false),
                    CountOfStandartClass = table.Column<int>(nullable: false),
                    CountOfBusinessClass = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: false),
                    SecondName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    EGN = table.Column<string>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: false),
                    Nationality = table.Column<string>(nullable: false),
                    TypeOfTicket = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    PlaneId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Flights");

            migrationBuilder.DropTable(
                name: "Reservations");
        }
    }
}
