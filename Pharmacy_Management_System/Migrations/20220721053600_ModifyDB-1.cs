using Microsoft.EntityFrameworkCore.Migrations;

namespace Pharmacy_Management_System.Migrations
{
    public partial class ModifyDB1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DrugsName",
                table: "OrdersDetails",
                type: "varchar(25)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(25)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DrugsName",
                table: "OrdersDetails",
                type: "varchar(25)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(25)");
        }
    }
}
