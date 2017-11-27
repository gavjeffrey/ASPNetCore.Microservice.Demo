using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CustomerInformation.Migrations
{
    public partial class ProfileStatus_Column : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KYCStatus",
                table: "Profiles");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Profiles",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Profiles");

            migrationBuilder.AddColumn<string>(
                name: "KYCStatus",
                table: "Profiles",
                nullable: true);
        }
    }
}
