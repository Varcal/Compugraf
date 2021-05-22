using Microsoft.EntityFrameworkCore.Migrations;

namespace Compugraf.Dados.Migrations
{
    public partial class createDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pessoa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    Sobrenome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    Cpf = table.Column<string>(type: "char(11)", maxLength: 11, nullable: true),
                    Nacionalidade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    Telefone = table.Column<string>(type: "char(11)", maxLength: 11, nullable: true),
                    Cep = table.Column<string>(type: "char(8)", maxLength: 8, nullable: true),
                    Estado = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    Cidade = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    Logradouro = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoa", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pessoa_Cpf",
                table: "Pessoa",
                column: "Cpf",
                unique: true,
                filter: "[Cpf] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pessoa");
        }
    }
}
