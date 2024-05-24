using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIweb.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "produto",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    ativo = table.Column<bool>(type: "boolean", nullable: false),
                    nomeProduto = table.Column<string>(type: "text", nullable: false),
                    paisDeOrigem = table.Column<string>(type: "text", nullable: false),
                    paisDeDestino = table.Column<string>(type: "text", nullable: false),
                    quantidade = table.Column<int>(type: "integer", nullable: false),
                    valorUnitario = table.Column<int>(type: "integer", nullable: false),
                    importador = table.Column<string>(type: "text", nullable: false),
                    exportador = table.Column<string>(type: "text", nullable: false),
                    dataEmbarque = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    dataChegada = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    freteModo = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_produto", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "produto");
        }
    }
}
