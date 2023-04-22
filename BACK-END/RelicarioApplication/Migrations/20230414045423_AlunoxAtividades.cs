using Microsoft.EntityFrameworkCore.Migrations;

namespace RelicarioApplication.Migrations
{
    public partial class AlunoxAtividades : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_ALUNOS_TB_ATIVIDADES_AtividadeId",
                table: "TB_ALUNOS");

            migrationBuilder.DropIndex(
                name: "IX_TB_ALUNOS_AtividadeId",
                table: "TB_ALUNOS");

            migrationBuilder.DropColumn(
                name: "AtividadeId",
                table: "TB_ALUNOS");

            migrationBuilder.CreateTable(
                name: "AlunoModelAtividadeModel",
                columns: table => new
                {
                    AlunosId = table.Column<int>(type: "int", nullable: false),
                    AtividadesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunoModelAtividadeModel", x => new { x.AlunosId, x.AtividadesId });
                    table.ForeignKey(
                        name: "FK_AlunoModelAtividadeModel_TB_ALUNOS_AlunosId",
                        column: x => x.AlunosId,
                        principalTable: "TB_ALUNOS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlunoModelAtividadeModel_TB_ATIVIDADES_AtividadesId",
                        column: x => x.AtividadesId,
                        principalTable: "TB_ATIVIDADES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlunoModelAtividadeModel_AtividadesId",
                table: "AlunoModelAtividadeModel",
                column: "AtividadesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlunoModelAtividadeModel");

            migrationBuilder.AddColumn<int>(
                name: "AtividadeId",
                table: "TB_ALUNOS",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_ALUNOS_AtividadeId",
                table: "TB_ALUNOS",
                column: "AtividadeId");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_ALUNOS_TB_ATIVIDADES_AtividadeId",
                table: "TB_ALUNOS",
                column: "AtividadeId",
                principalTable: "TB_ATIVIDADES",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
