using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MottuDesafio.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locacaos_Entregador_Entregadorid",
                table: "Locacaos");

            migrationBuilder.DropForeignKey(
                name: "FK_Locacaos_Motos_Motoid",
                table: "Locacaos");

            migrationBuilder.DropIndex(
                name: "IX_Locacaos_Entregadorid",
                table: "Locacaos");

            migrationBuilder.DropIndex(
                name: "IX_Locacaos_Motoid",
                table: "Locacaos");

            migrationBuilder.DropColumn(
                name: "entregador_id",
                table: "Locacaos");

            migrationBuilder.DropColumn(
                name: "moto_id",
                table: "Locacaos");

            migrationBuilder.DropColumn(
                name: "img_cnh",
                table: "Entregador");

            migrationBuilder.DropColumn(
                name: "numero_cnh",
                table: "Entregador");

            migrationBuilder.DropColumn(
                name: "tipo_cnh",
                table: "Entregador");

            migrationBuilder.RenameColumn(
                name: "placa",
                table: "Motos",
                newName: "Placa");

            migrationBuilder.RenameColumn(
                name: "modelo",
                table: "Motos",
                newName: "Modelo");

            migrationBuilder.RenameColumn(
                name: "ano",
                table: "Motos",
                newName: "Ano");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Motos",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "plano",
                table: "Locacaos",
                newName: "Plano");

            migrationBuilder.RenameColumn(
                name: "Motoid",
                table: "Locacaos",
                newName: "MotoId");

            migrationBuilder.RenameColumn(
                name: "Entregadorid",
                table: "Locacaos",
                newName: "EntregadorId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Locacaos",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "valor_diaria",
                table: "Locacaos",
                newName: "ValorDiaria");

            migrationBuilder.RenameColumn(
                name: "data_termino",
                table: "Locacaos",
                newName: "DataTermino");

            migrationBuilder.RenameColumn(
                name: "data_previsao_termino",
                table: "Locacaos",
                newName: "DataPrevisaoTermino");

            migrationBuilder.RenameColumn(
                name: "data_inicio",
                table: "Locacaos",
                newName: "DataInicio");

            migrationBuilder.RenameColumn(
                name: "data_devolucao",
                table: "Locacaos",
                newName: "DataDevolucao");

            migrationBuilder.RenameColumn(
                name: "nome",
                table: "Entregador",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "cnpj",
                table: "Entregador",
                newName: "Cnpj");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Entregador",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "data_nasc",
                table: "Entregador",
                newName: "DataNasc");

            migrationBuilder.AlterColumn<int>(
                name: "MotoId",
                table: "Locacaos",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "EntregadorId",
                table: "Locacaos",
                type: "integer",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "EntregadorId1",
                table: "Locacaos",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "MotoId1",
                table: "Locacaos",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "FotoCnh",
                table: "Entregador",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NumeroCnh",
                table: "Entregador",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TipoCnh",
                table: "Entregador",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Locacaos_EntregadorId1",
                table: "Locacaos",
                column: "EntregadorId1");

            migrationBuilder.CreateIndex(
                name: "IX_Locacaos_MotoId1",
                table: "Locacaos",
                column: "MotoId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Locacaos_Entregador_EntregadorId1",
                table: "Locacaos",
                column: "EntregadorId1",
                principalTable: "Entregador",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Locacaos_Motos_MotoId1",
                table: "Locacaos",
                column: "MotoId1",
                principalTable: "Motos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locacaos_Entregador_EntregadorId1",
                table: "Locacaos");

            migrationBuilder.DropForeignKey(
                name: "FK_Locacaos_Motos_MotoId1",
                table: "Locacaos");

            migrationBuilder.DropIndex(
                name: "IX_Locacaos_EntregadorId1",
                table: "Locacaos");

            migrationBuilder.DropIndex(
                name: "IX_Locacaos_MotoId1",
                table: "Locacaos");

            migrationBuilder.DropColumn(
                name: "EntregadorId1",
                table: "Locacaos");

            migrationBuilder.DropColumn(
                name: "MotoId1",
                table: "Locacaos");

            migrationBuilder.DropColumn(
                name: "FotoCnh",
                table: "Entregador");

            migrationBuilder.DropColumn(
                name: "NumeroCnh",
                table: "Entregador");

            migrationBuilder.DropColumn(
                name: "TipoCnh",
                table: "Entregador");

            migrationBuilder.RenameColumn(
                name: "Placa",
                table: "Motos",
                newName: "placa");

            migrationBuilder.RenameColumn(
                name: "Modelo",
                table: "Motos",
                newName: "modelo");

            migrationBuilder.RenameColumn(
                name: "Ano",
                table: "Motos",
                newName: "ano");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Motos",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Plano",
                table: "Locacaos",
                newName: "plano");

            migrationBuilder.RenameColumn(
                name: "MotoId",
                table: "Locacaos",
                newName: "Motoid");

            migrationBuilder.RenameColumn(
                name: "EntregadorId",
                table: "Locacaos",
                newName: "Entregadorid");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Locacaos",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "ValorDiaria",
                table: "Locacaos",
                newName: "valor_diaria");

            migrationBuilder.RenameColumn(
                name: "DataTermino",
                table: "Locacaos",
                newName: "data_termino");

            migrationBuilder.RenameColumn(
                name: "DataPrevisaoTermino",
                table: "Locacaos",
                newName: "data_previsao_termino");

            migrationBuilder.RenameColumn(
                name: "DataInicio",
                table: "Locacaos",
                newName: "data_inicio");

            migrationBuilder.RenameColumn(
                name: "DataDevolucao",
                table: "Locacaos",
                newName: "data_devolucao");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Entregador",
                newName: "nome");

            migrationBuilder.RenameColumn(
                name: "Cnpj",
                table: "Entregador",
                newName: "cnpj");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Entregador",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "DataNasc",
                table: "Entregador",
                newName: "data_nasc");

            migrationBuilder.AlterColumn<long>(
                name: "Motoid",
                table: "Locacaos",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<long>(
                name: "Entregadorid",
                table: "Locacaos",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "entregador_id",
                table: "Locacaos",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "moto_id",
                table: "Locacaos",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<byte[]>(
                name: "img_cnh",
                table: "Entregador",
                type: "bytea",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "numero_cnh",
                table: "Entregador",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "tipo_cnh",
                table: "Entregador",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Locacaos_Entregadorid",
                table: "Locacaos",
                column: "Entregadorid");

            migrationBuilder.CreateIndex(
                name: "IX_Locacaos_Motoid",
                table: "Locacaos",
                column: "Motoid");

            migrationBuilder.AddForeignKey(
                name: "FK_Locacaos_Entregador_Entregadorid",
                table: "Locacaos",
                column: "Entregadorid",
                principalTable: "Entregador",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Locacaos_Motos_Motoid",
                table: "Locacaos",
                column: "Motoid",
                principalTable: "Motos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
