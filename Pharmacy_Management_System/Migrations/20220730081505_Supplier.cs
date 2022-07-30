using Microsoft.EntityFrameworkCore.Migrations;

namespace Pharmacy_Management_System.Migrations
{
    public partial class Supplier : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EmailId",
                table: "SupplierDetails",
                newName: "EmailID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EmailID",
                table: "SupplierDetails",
                newName: "EmailId");
        }
    }
}
