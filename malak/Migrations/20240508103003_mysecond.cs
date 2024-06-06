using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace malak.Migrations
{
    public partial class mysecond : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admins_centres_idCentre",
                table: "Admins");

            migrationBuilder.DropIndex(
                name: "IX_Admins_idCentre",
                table: "Admins");

            migrationBuilder.DropColumn(
                name: "idCentre",
                table: "Admins");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "idCentre",
                table: "Admins",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Admins_idCentre",
                table: "Admins",
                column: "idCentre");

            migrationBuilder.AddForeignKey(
                name: "FK_Admins_centres_idCentre",
                table: "Admins",
                column: "idCentre",
                principalTable: "centres",
                principalColumn: "idCentre",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
