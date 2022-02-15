using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Uzbekistan_Social_Fund.Migrations
{
    public partial class FixedApplicantKeyIssue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Applicants",
                table: "Applicants");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                maxLength: 70,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                maxLength: 70,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Applicants",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Applicants",
                table: "Applicants",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Counties",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(maxLength: 70, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Counties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FundApplication",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BenefitTwoYearOld = table.Column<bool>(nullable: false),
                    BenefitFamilyWithTeens = table.Column<bool>(nullable: false),
                    BenefitLowIncomeFamily = table.Column<bool>(nullable: false),
                    ApplicantId = table.Column<int>(nullable: false),
                    AppliantId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FundApplication", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FundApplication_Applicants_AppliantId",
                        column: x => x.AppliantId,
                        principalTable: "Applicants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HouseMembers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FullName = table.Column<string>(nullable: false),
                    IDNumber = table.Column<string>(maxLength: 30, nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Relationship = table.Column<string>(nullable: false),
                    ApplicantId = table.Column<int>(nullable: false),
                    AppliantId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HouseMembers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HouseMembers_Applicants_AppliantId",
                        column: x => x.AppliantId,
                        principalTable: "Applicants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SubCounties",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(maxLength: 70, nullable: false),
                    CountyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCounties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubCounties_Counties_CountyId",
                        column: x => x.CountyId,
                        principalTable: "Counties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateTable(
                name: "Wards",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(maxLength: 70, nullable: false),
                    SubCountyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Wards_SubCounties_SubCountyId",
                        column: x => x.SubCountyId,
                        principalTable: "SubCounties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FundApplication_AppliantId",
                table: "FundApplication",
                column: "AppliantId");

            migrationBuilder.CreateIndex(
                name: "IX_HouseMembers_AppliantId",
                table: "HouseMembers",
                column: "AppliantId");

            migrationBuilder.CreateIndex(
                name: "IX_MemberEducations_HouseMemberId",
                table: "MemberEducations",
                column: "HouseMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_SubCounties_CountyId",
                table: "SubCounties",
                column: "CountyId");

            migrationBuilder.CreateIndex(
                name: "IX_Wards_SubCountyId",
                table: "Wards",
                column: "SubCountyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FundApplication");

            migrationBuilder.DropTable(
                name: "MemberEducations");

            migrationBuilder.DropTable(
                name: "Wards");

            migrationBuilder.DropTable(
                name: "HouseMembers");

            migrationBuilder.DropTable(
                name: "SubCounties");

            migrationBuilder.DropTable(
                name: "Counties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Applicants",
                table: "Applicants");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Applicants",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Applicants",
                table: "Applicants",
                column: "EmailAddress");
        }
    }
}
