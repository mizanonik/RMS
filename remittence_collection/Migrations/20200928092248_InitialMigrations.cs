using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace remittence_collection.Migrations
{
    public partial class InitialMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IDTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IDTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RemitterTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RemitterTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IDs",
                columns: table => new
                {
                    IDNo = table.Column<string>(nullable: false),
                    IDTypeId = table.Column<int>(nullable: false),
                    IssueDate = table.Column<string>(nullable: true),
                    ExpiryDate = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IDs", x => x.IDNo);
                    table.ForeignKey(
                        name: "FK_IDs_IDTypes_IDTypeId",
                        column: x => x.IDTypeId,
                        principalTable: "IDTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Remitters",
                columns: table => new
                {
                    RemitterId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    FatherName = table.Column<string>(nullable: true),
                    MotherName = table.Column<string>(nullable: true),
                    ContactNo = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    PrimaryIDid = table.Column<string>(nullable: true),
                    SecondaryIDid = table.Column<string>(nullable: true),
                    PresentAddress = table.Column<string>(nullable: true),
                    NatureOfJob = table.Column<string>(nullable: true),
                    NationalityId = table.Column<int>(nullable: false),
                    DateofBirth = table.Column<string>(nullable: true),
                    IncomeRange = table.Column<double>(nullable: false),
                    YearlyExpVolOfRemittence = table.Column<double>(nullable: false),
                    RemitterTypeId = table.Column<int>(nullable: false),
                    Remarks = table.Column<string>(nullable: true),
                    ActionDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Remitters", x => x.RemitterId);
                    table.ForeignKey(
                        name: "FK_Remitters_Countries_NationalityId",
                        column: x => x.NationalityId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Remitters_IDs_PrimaryIDid",
                        column: x => x.PrimaryIDid,
                        principalTable: "IDs",
                        principalColumn: "IDNo",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Remitters_RemitterTypes_RemitterTypeId",
                        column: x => x.RemitterTypeId,
                        principalTable: "RemitterTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Remitters_IDs_SecondaryIDid",
                        column: x => x.SecondaryIDid,
                        principalTable: "IDs",
                        principalColumn: "IDNo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IDs_IDTypeId",
                table: "IDs",
                column: "IDTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Remitters_NationalityId",
                table: "Remitters",
                column: "NationalityId");

            migrationBuilder.CreateIndex(
                name: "IX_Remitters_PrimaryIDid",
                table: "Remitters",
                column: "PrimaryIDid");

            migrationBuilder.CreateIndex(
                name: "IX_Remitters_RemitterTypeId",
                table: "Remitters",
                column: "RemitterTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Remitters_SecondaryIDid",
                table: "Remitters",
                column: "SecondaryIDid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Remitters");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "IDs");

            migrationBuilder.DropTable(
                name: "RemitterTypes");

            migrationBuilder.DropTable(
                name: "IDTypes");
        }
    }
}
