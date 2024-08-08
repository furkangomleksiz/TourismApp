using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TourismApp.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class TourProductPriceAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "Paxes",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "OrderTourProducts",
                columns: table => new
                {
                    OrderId = table.Column<Guid>(type: "uuid", nullable: false),
                    TourProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    BasePrice = table.Column<decimal>(type: "numeric", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    OrderId1 = table.Column<Guid>(type: "uuid", nullable: true),
                    TourProductId1 = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderTourProducts", x => new { x.OrderId, x.TourProductId });
                    table.ForeignKey(
                        name: "FK_OrderTourProducts_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderTourProducts_Orders_OrderId1",
                        column: x => x.OrderId1,
                        principalTable: "Orders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderTourProducts_TourProducts_TourProductId",
                        column: x => x.TourProductId,
                        principalTable: "TourProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderTourProducts_TourProducts_TourProductId1",
                        column: x => x.TourProductId1,
                        principalTable: "TourProducts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OrderTours",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OrderId = table.Column<Guid>(type: "uuid", nullable: false),
                    TourId = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Location = table.Column<string>(type: "text", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    OrderId1 = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderTours", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderTours_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderTours_Orders_OrderId1",
                        column: x => x.OrderId1,
                        principalTable: "Orders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderTours_Tours_TourId",
                        column: x => x.TourId,
                        principalTable: "Tours",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TourProductPrices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TourProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    PriceType = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TourProductPrices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TourProductPrices_TourProducts_TourProductId",
                        column: x => x.TourProductId,
                        principalTable: "TourProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderTourProductPrices",
                columns: table => new
                {
                    OrderId = table.Column<Guid>(type: "uuid", nullable: false),
                    TourProductPriceId = table.Column<Guid>(type: "uuid", nullable: false),
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PriceType = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    OrderId1 = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderTourProductPrices", x => new { x.OrderId, x.TourProductPriceId });
                    table.ForeignKey(
                        name: "FK_OrderTourProductPrices_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderTourProductPrices_Orders_OrderId1",
                        column: x => x.OrderId1,
                        principalTable: "Orders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderTourProductPrices_TourProductPrices_TourProductPriceId",
                        column: x => x.TourProductPriceId,
                        principalTable: "TourProductPrices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderTourProductPrices_OrderId1",
                table: "OrderTourProductPrices",
                column: "OrderId1");

            migrationBuilder.CreateIndex(
                name: "IX_OrderTourProductPrices_TourProductPriceId",
                table: "OrderTourProductPrices",
                column: "TourProductPriceId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderTourProducts_OrderId1",
                table: "OrderTourProducts",
                column: "OrderId1");

            migrationBuilder.CreateIndex(
                name: "IX_OrderTourProducts_TourProductId",
                table: "OrderTourProducts",
                column: "TourProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderTourProducts_TourProductId1",
                table: "OrderTourProducts",
                column: "TourProductId1");

            migrationBuilder.CreateIndex(
                name: "IX_OrderTours_OrderId",
                table: "OrderTours",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderTours_OrderId1",
                table: "OrderTours",
                column: "OrderId1");

            migrationBuilder.CreateIndex(
                name: "IX_OrderTours_TourId",
                table: "OrderTours",
                column: "TourId");

            migrationBuilder.CreateIndex(
                name: "IX_TourProductPrices_TourProductId",
                table: "TourProductPrices",
                column: "TourProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderTourProductPrices");

            migrationBuilder.DropTable(
                name: "OrderTourProducts");

            migrationBuilder.DropTable(
                name: "OrderTours");

            migrationBuilder.DropTable(
                name: "TourProductPrices");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "Paxes");
        }
    }
}
