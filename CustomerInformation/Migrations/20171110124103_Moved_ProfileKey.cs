using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CustomerInformation.Migrations
{
    public partial class Moved_ProfileKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "ProfileID",
                table: "ProfileKeys",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.CreateIndex(
                name: "IX_ProfileKeys_ProfileID",
                table: "ProfileKeys",
                column: "ProfileID");

            migrationBuilder.AddForeignKey(
                name: "FK_ProfileKeys_Profiles_ProfileID",
                table: "ProfileKeys",
                column: "ProfileID",
                principalTable: "Profiles",
                principalColumn: "ProfileID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProfileKeys_Profiles_ProfileID",
                table: "ProfileKeys");

            migrationBuilder.DropIndex(
                name: "IX_ProfileKeys_ProfileID",
                table: "ProfileKeys");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProfileID",
                table: "ProfileKeys",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);
        }
    }
}
