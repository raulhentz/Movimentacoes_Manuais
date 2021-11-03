using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MovimentosManuais.Infra.Repository.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    Cod_Produto = table.Column<string>(type: "char(4)", nullable: false),
                    Des_Produto = table.Column<string>(type: "varchar(30)", nullable: true),
                    Sta_Status = table.Column<string>(type: "char(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.Cod_Produto);
                });

            migrationBuilder.CreateTable(
                name: "Produto_Cosif",
                columns: table => new
                {
                    Cod_Produto = table.Column<string>(type: "char(4)", nullable: false),
                    Cod_Cosif = table.Column<string>(type: "char(11)", nullable: false),
                    Cod_Classifcacao = table.Column<string>(type: "char(6)", nullable: true),
                    Sta_Status = table.Column<string>(type: "char(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto_Cosif", x => new { x.Cod_Produto, x.Cod_Cosif });
                    table.ForeignKey(
                        name: "FK_Produto_Cosif_Produto_Cod_Produto",
                        column: x => x.Cod_Produto,
                        principalTable: "Produto",
                        principalColumn: "Cod_Produto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Movimento_Manual",
                columns: table => new
                {
                    Num_Lancamento = table.Column<int>(type: "INTEGER", nullable: false),
                    Dat_Mes = table.Column<int>(type: "INTEGER", nullable: false),
                    Dat_Ano = table.Column<int>(type: "INTEGER", nullable: false),
                    Cod_Produto = table.Column<string>(type: "char(4)", nullable: false),
                    Cod_Cosif = table.Column<string>(type: "char(11)", nullable: false),
                    Des_Descricao = table.Column<string>(type: "varchar(50)", nullable: false),
                    Dat_Movimento = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Cod_Usuario = table.Column<string>(type: "varchar(15)", nullable: false),
                    Val_Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movimento_Manual", x => new { x.Num_Lancamento, x.Dat_Mes, x.Dat_Ano, x.Cod_Produto, x.Cod_Cosif });
                    table.ForeignKey(
                        name: "FK_Movimento_Manual_Produto_Cosif_Cod_Produto_Cod_Cosif",
                        columns: x => new { x.Cod_Produto, x.Cod_Cosif },
                        principalTable: "Produto_Cosif",
                        principalColumns: new[] { "Cod_Produto", "Cod_Cosif" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movimento_Manual_Cod_Produto_Cod_Cosif",
                table: "Movimento_Manual",
                columns: new[] { "Cod_Produto", "Cod_Cosif" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movimento_Manual");

            migrationBuilder.DropTable(
                name: "Produto_Cosif");

            migrationBuilder.DropTable(
                name: "Produto");
        }
    }
}
