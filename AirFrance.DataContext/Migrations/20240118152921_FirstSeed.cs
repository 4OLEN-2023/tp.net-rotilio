using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AirFrance.DataContext.Migrations
{
    /// <inheritdoc />
    public partial class FirstSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Vols",
                columns: new[] { "Id", "Destination", "IsDelayed", "NetSales", "OnBoardingMessage", "SeatCount", "TakeOffDate" },
                values: new object[] { 1, "USA", true, 50000f, "welcome to the flight to the USA", 80, new DateTime(2024, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Passagers",
                columns: new[] { "Id", "Birthdate", "FirstName", "IsCheckedId", "LastName", "TicketPrice", "VolId" },
                values: new object[,]
                {
                    { 1, new DateTime(2002, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jules", true, "ROTILIO", 50f, 1 },
                    { 2, new DateTime(1999, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Enzo", true, "ROTILIO", 50f, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Passagers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Passagers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Vols",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
