using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pharmacy_Management_System.Migrations
{
    public partial class Database : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DoctorsDetails",
                columns: table => new
                {
                    DoctorId = table.Column<string>(type: "varchar(25)", nullable: false),
                    DoctorName = table.Column<string>(type: "varchar(25)", nullable: false),
                    Contact = table.Column<string>(type: "varchar(25)", nullable: false),
                    EmailID = table.Column<string>(type: "varchar(35)", nullable: false),
                    Password = table.Column<string>(type: "varchar(225)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorsDetails", x => x.DoctorId);
                });

            migrationBuilder.CreateTable(
                name: "DrugDetails",
                columns: table => new
                {
                    DrugId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DrugName = table.Column<string>(type: "varchar(25)", nullable: false),
                    DrugPrice = table.Column<int>(type: "int", nullable: false),
                    DrugQuantity = table.Column<int>(type: "int", nullable: false),
                    MfdDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SupplierId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrugDetails", x => x.DrugId);
                });

            migrationBuilder.CreateTable(
                name: "OrdersDetails",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DrugId = table.Column<int>(type: "int", nullable: false),
                    DrugsName = table.Column<string>(type: "varchar(25)", nullable: false),
                    DrugPrice = table.Column<int>(type: "int", nullable: false),
                    DrugQuantity = table.Column<int>(type: "int", nullable: false),
                    PickupDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalAmount = table.Column<double>(type: "float", nullable: false),
                    IsPicked = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdersDetails", x => x.OrderId);
                });

            migrationBuilder.CreateTable(
                name: "SupplierDetails",
                columns: table => new
                {
                    SupplierId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierName = table.Column<string>(type: "varchar(25)", nullable: false),
                    EmailID = table.Column<string>(type: "varchar(35)", nullable: false),
                    Contact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DrugAvailable = table.Column<string>(type: "varchar(25)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierDetails", x => x.SupplierId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DoctorsDetails");

            migrationBuilder.DropTable(
                name: "DrugDetails");

            migrationBuilder.DropTable(
                name: "OrdersDetails");

            migrationBuilder.DropTable(
                name: "SupplierDetails");
        }
    }
}
