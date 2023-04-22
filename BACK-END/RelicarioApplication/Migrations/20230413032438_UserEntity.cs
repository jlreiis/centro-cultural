using Microsoft.EntityFrameworkCore.Migrations;

namespace RelicarioApplication.Migrations
{
    public partial class UserEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlunoModelAtividadesModel");

            migrationBuilder.DropTable(
                name: "TB_ALUNOS");

            migrationBuilder.DropTable(
                name: "TB_ATIVIDADES");

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.CreateTable(
                name: "TB_ALUNOS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Idade = table.Column<int>(type: "int", nullable: false),
                    NomeAluno = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_ALUNOS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_ATIVIDADES",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeAtividade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfessorResponsavel = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_ATIVIDADES", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AlunoModelAtividadesModel",
                columns: table => new
                {
                    AlunosId = table.Column<int>(type: "int", nullable: false),
                    AtvPraticanteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunoModelAtividadesModel", x => new { x.AlunosId, x.AtvPraticanteId });
                    table.ForeignKey(
                        name: "FK_AlunoModelAtividadesModel_TB_ALUNOS_AlunosId",
                        column: x => x.AlunosId,
                        principalTable: "TB_ALUNOS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlunoModelAtividadesModel_TB_ATIVIDADES_AtvPraticanteId",
                        column: x => x.AtvPraticanteId,
                        principalTable: "TB_ATIVIDADES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlunoModelAtividadesModel_AtvPraticanteId",
                table: "AlunoModelAtividadesModel",
                column: "AtvPraticanteId");
        }
    }
}
