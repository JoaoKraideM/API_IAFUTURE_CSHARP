using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.IAFUTURE.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_csharp_iafuture_clientes",
                columns: table => new
                {
                    IdCliente = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DataNascimento = table.Column<string>(type: "NVARCHAR2(10)", nullable: false),
                    Cpf = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Telefone = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_csharp_iafuture_clientes", x => x.IdCliente);
                });

            migrationBuilder.CreateTable(
                name: "tb_csharp_iafuture_contas",
                columns: table => new
                {
                    IdConta = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Telefone = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Cnpj = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Cep = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Logradouro = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Complemento = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Bairro = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Cidade = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Estado = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Numero = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Username = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Senha = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_csharp_iafuture_contas", x => x.IdConta);
                });

            migrationBuilder.CreateTable(
                name: "tb_csharp_iafuture_feedbacks",
                columns: table => new
                {
                    IdFeedback = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    DataFeedback = table.Column<string>(type: "NVARCHAR2(10)", nullable: false),
                    Comentario = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Avaliacao = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_csharp_iafuture_feedbacks", x => x.IdFeedback);
                });

            migrationBuilder.CreateTable(
                name: "tb_csharp_iafuture_interacoes",
                columns: table => new
                {
                    IdInteracao = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    DataInteracao = table.Column<string>(type: "NVARCHAR2(10)", nullable: false),
                    Tipo = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Canal = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_csharp_iafuture_interacoes", x => x.IdInteracao);
                });

            migrationBuilder.CreateTable(
                name: "tb_csharp_iafuture_resultados",
                columns: table => new
                {
                    IdResultadoIA = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    TipoAnalise = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Detalhes = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_csharp_iafuture_resultados", x => x.IdResultadoIA);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_csharp_iafuture_clientes");

            migrationBuilder.DropTable(
                name: "tb_csharp_iafuture_contas");

            migrationBuilder.DropTable(
                name: "tb_csharp_iafuture_feedbacks");

            migrationBuilder.DropTable(
                name: "tb_csharp_iafuture_interacoes");

            migrationBuilder.DropTable(
                name: "tb_csharp_iafuture_resultados");
        }
    }
}
