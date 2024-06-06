using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace malak.Migrations
{
    public partial class myfirst : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "centres",
                columns: table => new
                {
                    idCentre = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NomCentre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    adresse = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tel = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_centres", x => x.idCentre);
                });

            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    idAdmin = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nomAdmin = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    prenom = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    adresse = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    idCentre = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.idAdmin);
                    table.ForeignKey(
                        name: "FK_Admins_centres_idCentre",
                        column: x => x.idCentre,
                        principalTable: "centres",
                        principalColumn: "idCentre",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "profs",
                columns: table => new
                {
                    idProf = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NomProf = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    prenom = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    adresse = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    idCentre = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_profs", x => x.idProf);
                    table.ForeignKey(
                        name: "FK_profs_centres_idCentre",
                        column: x => x.idCentre,
                        principalTable: "centres",
                        principalColumn: "idCentre",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cours",
                columns: table => new
                {
                    idCour = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NomCour = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StarTime = table.Column<DateTime>(type: "datetime2", maxLength: 100, nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: true),
                    IsOffred = table.Column<bool>(type: "bit", nullable: false),
                    idProf = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cours", x => x.idCour);
                    table.ForeignKey(
                        name: "FK_cours_profs_idProf",
                        column: x => x.idProf,
                        principalTable: "profs",
                        principalColumn: "idProf",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "students",
                columns: table => new
                {
                    idStudent = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NomStudent = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    prenom = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    adresse = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    idCour = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_students", x => x.idStudent);
                    table.ForeignKey(
                        name: "FK_students_cours_idCour",
                        column: x => x.idCour,
                        principalTable: "cours",
                        principalColumn: "idCour",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Admins_idCentre",
                table: "Admins",
                column: "idCentre");

            migrationBuilder.CreateIndex(
                name: "IX_cours_idProf",
                table: "cours",
                column: "idProf");

            migrationBuilder.CreateIndex(
                name: "IX_profs_idCentre",
                table: "profs",
                column: "idCentre");

            migrationBuilder.CreateIndex(
                name: "IX_students_idCour",
                table: "students",
                column: "idCour");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "students");

            migrationBuilder.DropTable(
                name: "cours");

            migrationBuilder.DropTable(
                name: "profs");

            migrationBuilder.DropTable(
                name: "centres");
        }
    }
}
