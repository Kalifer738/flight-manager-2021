using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Data.Migrations
{
    public partial class contactsdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    LocationFrom = table.Column<string>(nullable: false),
                    LocationTo = table.Column<string>(nullable: false),
                    Going = table.Column<DateTime>(nullable: false),
                    Return = table.Column<DateTime>(nullable: false),
                    TypeOfPlane = table.Column<string>(nullable: false),
                    PlaneID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameOfAviator = table.Column<string>(nullable: false),
                    CapacityOfEconomyClass = table.Column<int>(nullable: false),
                    CapacityOfBusinessClass = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.PlaneID);
                });


            migrationBuilder.CreateTable(
               name: "Reservation",
               columns: table => new
               {
                   FirstName = table.Column<string>(nullable: false),
                   SecondName = table.Column<string>(nullable: false),
                   LastName = table.Column<string>(nullable: false),
                   EGN = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                   PhoneNumber = table.Column<int>(nullable: false),
                   Nationality = table.Column<string>(nullable: false),
                   TypeOfTicket = table.Column<string>(nullable: false),
                   Email = table.Column<string>(nullable: false)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_Reservation", x => x.EGN);
               });

            migrationBuilder.CreateTable(
               name: "Users",
               columns: table => new
               {
                   UserName = table.Column<string>(nullable: false),
                   Password = table.Column<string>(nullable: false),
                   Email = table.Column<string>(nullable: false),
                   FirstName = table.Column<string>(nullable: false),
                   LastName = table.Column<string>(nullable: false),
                   EGN = table.Column<int>(nullable: false)
                   .Annotation("SqlServer:Identity", "1, 1"),
                   Address = table.Column<string>(nullable: false),
                   PhoneNumber = table.Column<int>(nullable: false),
                   Role = table.Column<string>(nullable: false)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_Users", x => x.EGN);
               });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Flights");
            migrationBuilder.DropTable(
                name: "Reservation");
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
