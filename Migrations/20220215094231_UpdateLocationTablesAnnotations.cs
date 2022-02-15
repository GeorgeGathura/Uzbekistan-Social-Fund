using Microsoft.EntityFrameworkCore.Migrations;

namespace Uzbekistan_Social_Fund.Migrations
{
    public partial class UpdateLocationTablesAnnotations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Wards",
                maxLength: 70,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "SubCounties",
                maxLength: 70,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Counties",
                maxLength: 70,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Wards",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 70);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "SubCounties",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 70);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Counties",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 70);
        }
    }
}
