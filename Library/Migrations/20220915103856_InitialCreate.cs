using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookTitle = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true),
                    Author = table.Column<string>(nullable: true),
                    NumberAvailable = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookId);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerFirstName = table.Column<string>(maxLength: 50, nullable: false),
                    CustomerLastName = table.Column<string>(maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Loans",
                columns: table => new
                {
                    LoanId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateForLoan = table.Column<DateTime>(nullable: false),
                    DateForReturn = table.Column<DateTime>(nullable: true),
                    CustomerId = table.Column<int>(nullable: false),
                    BookId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loans", x => x.LoanId);
                    table.ForeignKey(
                        name: "FK_Loans_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Loans_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "Author", "BookTitle", "ImageUrl", "NumberAvailable" },
                values: new object[,]
                {
                    { 1, "Liza Marklund", "Kallmyren", "\\Images\\Kallmyren.jpg", 2 },
                    { 2, "Jussi Adler Olsen", "Natriumklorid", "\\Images\\Natriumklorid.jpg", 1 },
                    { 3, "Christina Larsson", "Agenturen", "\\Images\\Agenturen.jpg", 2 },
                    { 4, "Frida Skybäck", "Svartfågel", "\\Images\\Svartfagel.jpg", 3 },
                    { 5, "Lars Keppler", "Spegelmannen", "\\Images\\Spegelmannen.jpg", 2 }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "CustomerFirstName", "CustomerLastName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "Anna", "Andersson", "0723456789" },
                    { 2, "Björn", "Andersson", "0723456790" },
                    { 3, "Albin", "Karlsson", "0729876543" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Loans_BookId",
                table: "Loans",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Loans_CustomerId",
                table: "Loans",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Loans");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
