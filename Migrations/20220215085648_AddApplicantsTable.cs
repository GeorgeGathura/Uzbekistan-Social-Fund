using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Uzbekistan_Social_Fund.Migrations
{
    public partial class AddApplicantsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Applicants",
                columns: table => new
                {
                    EmailAddress = table.Column<string>(nullable: false),
                    Id = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 100, nullable: false),
                    LastName = table.Column<string>(maxLength: 100, nullable: false),
                    Surname = table.Column<string>(maxLength: 100, nullable: false),
                    Gender = table.Column<string>(nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    IsMarried = table.Column<bool>(nullable: false),
                    PINFLNumber = table.Column<string>(nullable: false),
                    WardId = table.Column<int>(nullable: false),
                    PostalAddress = table.Column<string>(nullable: true),
                    PhysicalAddress = table.Column<string>(nullable: true),
                    TelephoneContacts = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applicants", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Applicants");
        }
    }
}
