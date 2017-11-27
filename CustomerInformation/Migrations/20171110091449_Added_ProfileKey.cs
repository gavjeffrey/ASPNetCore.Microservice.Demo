using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CustomerInformation.Migrations
{
    public partial class Added_ProfileKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProfileKeys",
                columns: table => new
                {
                    ProfileKeyID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProfileID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProfileKeyValue = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfileKeys", x => x.ProfileKeyID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProfileKeys");
        }
    }
}
