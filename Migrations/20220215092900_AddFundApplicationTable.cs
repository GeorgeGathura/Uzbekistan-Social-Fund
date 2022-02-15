using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Uzbekistan_Social_Fund.Migrations
{
    public partial class AddFundApplicationTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    AppliantId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FundApplication", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FundApplication_Applicants_AppliantId",
                        column: x => x.AppliantId,
                        principalTable: "Applicants",
                        principalColumn: "EmailAddress",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FundApplication_AppliantId",
                table: "FundApplication",
                column: "AppliantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FundApplication");
        }
    }
}
