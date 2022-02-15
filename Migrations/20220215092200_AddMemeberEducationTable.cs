using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Uzbekistan_Social_Fund.Migrations
{
    public partial class AddMemeberEducationTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MemberEducations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LangugeProfiency = table.Column<bool>(nullable: false),
                    WriteProfiency = table.Column<bool>(nullable: false),
                    SchoolAttendance = table.Column<bool>(nullable: false),
                    SchoolLevel = table.Column<string>(nullable: true),
                    HasAttendedSchool = table.Column<bool>(nullable: false),
                    HighestSchoolLevel = table.Column<string>(nullable: true),
                    HouseMemberId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberEducations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MemberEducations_HouseMembers_HouseMemberId",
                        column: x => x.HouseMemberId,
                        principalTable: "HouseMembers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MemberEducations_HouseMemberId",
                table: "MemberEducations",
                column: "HouseMemberId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MemberEducations");
        }
    }
}
