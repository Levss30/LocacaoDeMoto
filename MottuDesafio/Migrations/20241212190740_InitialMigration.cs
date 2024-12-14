using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MottuDesafio.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Entregador",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    nome = table.Column<string>(type: "text", nullable: false),
                    cnpj = table.Column<string>(type: "text", nullable: false),
                    datanasc = table.Column<DateTime>(name: "data_nasc", type: "timestamp with time zone", nullable: false),
                    numerocnh = table.Column<int>(name: "numero_cnh", type: "integer", nullable: false),
                    tipocnh = table.Column<int>(name: "tipo_cnh", type: "integer", nullable: false),
                    imgcnh = table.Column<byte[]>(name: "img_cnh", type: "bytea", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entregador", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Motos",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ano = table.Column<int>(type: "integer", nullable: false),
                    modelo = table.Column<string>(type: "text", nullable: false),
                    placa = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Locacaos",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    entregadorid = table.Column<int>(name: "entregador_id", type: "integer", nullable: false),
                    motoid = table.Column<int>(name: "moto_id", type: "integer", nullable: false),
                    valordiaria = table.Column<int>(name: "valor_diaria", type: "integer", nullable: false),
                    datainicio = table.Column<DateTime>(name: "data_inicio", type: "timestamp with time zone", nullable: false),
                    dataprevisaotermino = table.Column<DateTime>(name: "data_previsao_termino", type: "timestamp with time zone", nullable: false),
                    datatermino = table.Column<DateTime>(name: "data_termino", type: "timestamp with time zone", nullable: false),
                    datadevolucao = table.Column<DateTime>(name: "data_devolucao", type: "timestamp with time zone", nullable: false),
                    plano = table.Column<int>(type: "integer", nullable: false),
                    Motoid = table.Column<long>(type: "bigint", nullable: false),
                    Entregadorid = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locacaos", x => x.id);
                    table.ForeignKey(
                        name: "FK_Locacaos_Entregador_Entregadorid",
                        column: x => x.Entregadorid,
                        principalTable: "Entregador",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Locacaos_Motos_Motoid",
                        column: x => x.Motoid,
                        principalTable: "Motos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Locacaos_Entregadorid",
                table: "Locacaos",
                column: "Entregadorid");

            migrationBuilder.CreateIndex(
                name: "IX_Locacaos_Motoid",
                table: "Locacaos",
                column: "Motoid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Locacaos");

            migrationBuilder.DropTable(
                name: "Entregador");

            migrationBuilder.DropTable(
                name: "Motos");
        }
    }
}
