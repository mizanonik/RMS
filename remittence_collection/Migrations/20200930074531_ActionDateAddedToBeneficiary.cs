using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace remittence_collection.Migrations
{
    public partial class ActionDateAddedToBeneficiary : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ActionDate",
                table: "Beneficiaries",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActionDate",
                table: "Beneficiaries");
        }
    }
}
