using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RelicarioApplication.Migrations
{
    public partial class ALUNOXPROFESSOR : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_ALUNOS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeAluno = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Idade = table.Column<int>(type: "int", nullable: false),
                    NomeResponsavel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RG = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CPF = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DtEntrada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProfessorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_ALUNOS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_ALUNOS_TB_PROFESSORES_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "TB_PROFESSORES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_ALUNOS_ProfessorId",
                table: "TB_ALUNOS",
                column: "ProfessorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_ALUNOS");
        }
    }
}
