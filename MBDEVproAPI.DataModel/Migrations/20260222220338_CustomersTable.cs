using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MBDEVproAPI.DataModel.Migrations
{
    /// <inheritdoc />
    public partial class CustomersTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusinessID = table.Column<int>(type: "int", nullable: false),
                    Company = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BPhone = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    HPhone = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    MPhone = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Fax = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    City = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    State = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false),
                    ZIPCode = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    WebPage = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", maxLength: 4010, nullable: true),
                    Photo = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: true),
                    Map = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
