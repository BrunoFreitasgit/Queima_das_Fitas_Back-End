using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Queima.Web.App.Migrations
{
    public partial class SchemaIncialv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artistas",
                columns: table => new
                {
                    ArtistaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Biografia = table.Column<string>(nullable: true),
                    DataAtuacao = table.Column<DateTime>(nullable: false),
                    FacebookUrl = table.Column<string>(nullable: true),
                    FotoImagemId = table.Column<int>(nullable: true),
                    Nome = table.Column<string>(nullable: false),
                    Palco = table.Column<int>(nullable: false),
                    SpotifyUrl = table.Column<string>(nullable: true),
                    TwitterUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artistas", x => x.ArtistaId);
                    table.ForeignKey(
                        name: "FK_Artistas_Imagens_FotoImagemId",
                        column: x => x.FotoImagemId,
                        principalTable: "Imagens",
                        principalColumn: "ImagemId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Atividades",
                columns: table => new
                {
                    AtividadeAcademicaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Data = table.Column<DateTime>(nullable: false),
                    Descricao = table.Column<string>(nullable: true),
                    ImagemId = table.Column<int>(nullable: true),
                    LocalId = table.Column<int>(nullable: true),
                    Nome = table.Column<string>(nullable: false),
                    Preco = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atividades", x => x.AtividadeAcademicaId);
                    table.ForeignKey(
                        name: "FK_Atividades_Imagens_ImagemId",
                        column: x => x.ImagemId,
                        principalTable: "Imagens",
                        principalColumn: "ImagemId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Atividades_Locais_LocalId",
                        column: x => x.LocalId,
                        principalTable: "Locais",
                        principalColumn: "LocalId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Barracas",
                columns: table => new
                {
                    BarracaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FacebookEventUrl = table.Column<string>(nullable: true),
                    FotoImagemId = table.Column<int>(nullable: true),
                    Nome = table.Column<string>(nullable: false),
                    PosicaoLocalId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Barracas", x => x.BarracaId);
                    table.ForeignKey(
                        name: "FK_Barracas_Imagens_FotoImagemId",
                        column: x => x.FotoImagemId,
                        principalTable: "Imagens",
                        principalColumn: "ImagemId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Barracas_Locais_PosicaoLocalId",
                        column: x => x.PosicaoLocalId,
                        principalTable: "Locais",
                        principalColumn: "LocalId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PontosVenda",
                columns: table => new
                {
                    PontoVendaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(nullable: true),
                    LocalId = table.Column<int>(nullable: true),
                    Nome = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PontosVenda", x => x.PontoVendaId);
                    table.ForeignKey(
                        name: "FK_PontosVenda_Locais_LocalId",
                        column: x => x.LocalId,
                        principalTable: "Locais",
                        principalColumn: "LocalId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Locais",
                nullable: false);

            migrationBuilder.CreateIndex(
                name: "IX_Artistas_FotoImagemId",
                table: "Artistas",
                column: "FotoImagemId");

            migrationBuilder.CreateIndex(
                name: "IX_Atividades_ImagemId",
                table: "Atividades",
                column: "ImagemId");

            migrationBuilder.CreateIndex(
                name: "IX_Atividades_LocalId",
                table: "Atividades",
                column: "LocalId");

            migrationBuilder.CreateIndex(
                name: "IX_Barracas_FotoImagemId",
                table: "Barracas",
                column: "FotoImagemId");

            migrationBuilder.CreateIndex(
                name: "IX_Barracas_PosicaoLocalId",
                table: "Barracas",
                column: "PosicaoLocalId");

            migrationBuilder.CreateIndex(
                name: "IX_PontosVenda_LocalId",
                table: "PontosVenda",
                column: "LocalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Artistas");

            migrationBuilder.DropTable(
                name: "Atividades");

            migrationBuilder.DropTable(
                name: "Barracas");

            migrationBuilder.DropTable(
                name: "PontosVenda");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Locais",
                nullable: true);
        }
    }
}
