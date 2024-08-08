using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TourismApp.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateOrderTour : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "OrderTours");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "OrderTours");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "OrderTours");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "OrderTourProducts");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "OrderTourProducts");

            migrationBuilder.AddColumn<int>(
                name: "DayNum",
                table: "OrderTours",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NightNum",
                table: "OrderTours",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DayNum",
                table: "OrderTours");

            migrationBuilder.DropColumn(
                name: "NightNum",
                table: "OrderTours");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "OrderTours",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "OrderTours",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "OrderTours",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "OrderTourProducts",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "OrderTourProducts",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
