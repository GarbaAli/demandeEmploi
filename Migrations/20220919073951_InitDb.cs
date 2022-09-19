using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace demandeEmploi.Migrations
{
    public partial class InitDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Candidats",
                columns: table => new
                {
                    candidatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    profession = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sexe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DteNaissance = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    statutFamilial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    statut = table.Column<bool>(type: "bit", nullable: false),
                    Experience = table.Column<int>(type: "int", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    service = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidats", x => x.candidatId);
                });

            migrationBuilder.CreateTable(
                name: "Competences",
                columns: table => new
                {
                    comptetenceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    libelle = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competences", x => x.comptetenceId);
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    DocumentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fichier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    candidatLinkcandidatId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.DocumentId);
                    table.ForeignKey(
                        name: "FK_Documents_Candidats_candidatLinkcandidatId",
                        column: x => x.candidatLinkcandidatId,
                        principalTable: "Candidats",
                        principalColumn: "candidatId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CandidatCompetence",
                columns: table => new
                {
                    candidatscandidatId = table.Column<int>(type: "int", nullable: false),
                    competencescomptetenceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidatCompetence", x => new { x.candidatscandidatId, x.competencescomptetenceId });
                    table.ForeignKey(
                        name: "FK_CandidatCompetence_Candidats_candidatscandidatId",
                        column: x => x.candidatscandidatId,
                        principalTable: "Candidats",
                        principalColumn: "candidatId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CandidatCompetence_Competences_competencescomptetenceId",
                        column: x => x.competencescomptetenceId,
                        principalTable: "Competences",
                        principalColumn: "comptetenceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CandidatCompetence_competencescomptetenceId",
                table: "CandidatCompetence",
                column: "competencescomptetenceId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_candidatLinkcandidatId",
                table: "Documents",
                column: "candidatLinkcandidatId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CandidatCompetence");

            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "Competences");

            migrationBuilder.DropTable(
                name: "Candidats");
        }
    }
}
