using Microsoft.EntityFrameworkCore.Migrations;

namespace remittence_collection.Migrations
{
    public partial class AddedBeneficiaries : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Beneficiaries",
                columns: table => new
                {
                    BeneficiaryId = table.Column<string>(nullable: false),
                    RemitterId = table.Column<string>(nullable: true),
                    NationalityId = table.Column<int>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    StateId = table.Column<int>(nullable: false),
                    MobileNo = table.Column<string>(nullable: true),
                    RelationWithRemitter = table.Column<string>(nullable: true),
                    Remarks = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beneficiaries", x => x.BeneficiaryId);
                    table.ForeignKey(
                        name: "FK_Beneficiaries_Countries_NationalityId",
                        column: x => x.NationalityId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Beneficiaries_Remitters_RemitterId",
                        column: x => x.RemitterId,
                        principalTable: "Remitters",
                        principalColumn: "RemitterId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Beneficiaries_States_StateId",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Beneficiaries_NationalityId",
                table: "Beneficiaries",
                column: "NationalityId");

            migrationBuilder.CreateIndex(
                name: "IX_Beneficiaries_RemitterId",
                table: "Beneficiaries",
                column: "RemitterId");

            migrationBuilder.CreateIndex(
                name: "IX_Beneficiaries_StateId",
                table: "Beneficiaries",
                column: "StateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Beneficiaries");
        }
    }
}
