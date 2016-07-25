using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Queima.Web.App.Migrations
{
    public partial class InitialSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artistas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Biografia = table.Column<string>(nullable: true),
                    DataAtuacao = table.Column<DateTime>(nullable: false),
                    FacebookUrl = table.Column<string>(nullable: true),
                    ImagemPath = table.Column<string>(nullable: false),
                    Nome = table.Column<string>(nullable: false),
                    Palco = table.Column<int>(nullable: false),
                    SpotifyUrl = table.Column<string>(nullable: true),
                    TwitterUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artistas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transportes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(nullable: true),
                    ImagemPath = table.Column<string>(nullable: false),
                    Nome = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transportes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Links",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Categoria = table.Column<int>(nullable: false),
                    Descricao = table.Column<string>(nullable: false),
                    TransporteId = table.Column<int>(nullable: true),
                    Url = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Links", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Links_Transportes_TransporteId",
                        column: x => x.TransporteId,
                        principalTable: "Transportes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Bilhetes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Condicoes = table.Column<string>(nullable: true),
                    Data = table.Column<DateTime>(nullable: false),
                    LinkBilheteiraId = table.Column<int>(nullable: true),
                    PrecoDiaAnterior = table.Column<decimal>(nullable: false),
                    PrecoNoDia = table.Column<decimal>(nullable: false),
                    PrecoNoDiaForaHoras = table.Column<decimal>(nullable: false),
                    PrecoNormal = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bilhetes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bilhetes_Links_LinkBilheteiraId",
                        column: x => x.LinkBilheteiraId,
                        principalTable: "Links",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Concursos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataFim = table.Column<DateTime>(nullable: false),
                    DataInicio = table.Column<DateTime>(nullable: false),
                    Descricao = table.Column<string>(nullable: false),
                    ImagemPath = table.Column<string>(nullable: false),
                    TipoConcurso = table.Column<int>(nullable: false),
                    WebLinkId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Concursos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Concursos_Links_WebLinkId",
                        column: x => x.WebLinkId,
                        principalTable: "Links",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MediaEdicoes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ano = table.Column<int>(nullable: false),
                    LinkId = table.Column<int>(nullable: false),
                    TipoMedia = table.Column<int>(nullable: false),
                    Titulo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaEdicoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MediaEdicoes_Links_LinkId",
                        column: x => x.LinkId,
                        principalTable: "Links",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PontosInteresse",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AtividadeAcademicaId = table.Column<int>(nullable: true),
                    DescricaoAdicional = table.Column<string>(nullable: true),
                    Latitude = table.Column<double>(nullable: false),
                    Longitude = table.Column<double>(nullable: false),
                    Nome = table.Column<string>(nullable: false),
                    Tipo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PontosInteresse", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Atividades",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Data = table.Column<DateTime>(nullable: false),
                    Descricao = table.Column<string>(nullable: false),
                    ImagemPath = table.Column<string>(nullable: false),
                    Nome = table.Column<string>(nullable: false),
                    PontoInteresseId = table.Column<int>(nullable: false),
                    Preco = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atividades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Atividades_PontosInteresse_PontoInteresseId",
                        column: x => x.PontoInteresseId,
                        principalTable: "PontosInteresse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Barracas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FacebookEventUrl = table.Column<string>(nullable: true),
                    ImagemPath = table.Column<string>(nullable: false),
                    Nome = table.Column<string>(nullable: false),
                    PosicaoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Barracas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Barracas_PontosInteresse_PosicaoId",
                        column: x => x.PosicaoId,
                        principalTable: "PontosInteresse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Atividades_PontoInteresseId",
                table: "Atividades",
                column: "PontoInteresseId");

            migrationBuilder.CreateIndex(
                name: "IX_Barracas_PosicaoId",
                table: "Barracas",
                column: "PosicaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Bilhetes_LinkBilheteiraId",
                table: "Bilhetes",
                column: "LinkBilheteiraId");

            migrationBuilder.CreateIndex(
                name: "IX_Concursos_WebLinkId",
                table: "Concursos",
                column: "WebLinkId");

            migrationBuilder.CreateIndex(
                name: "IX_Links_TransporteId",
                table: "Links",
                column: "TransporteId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaEdicoes_LinkId",
                table: "MediaEdicoes",
                column: "LinkId");

            migrationBuilder.CreateIndex(
                name: "IX_PontosInteresse_AtividadeAcademicaId",
                table: "PontosInteresse",
                column: "AtividadeAcademicaId");

            migrationBuilder.AddForeignKey(
                name: "FK_PontosInteresse_Atividades_AtividadeAcademicaId",
                table: "PontosInteresse",
                column: "AtividadeAcademicaId",
                principalTable: "Atividades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Atividades_PontosInteresse_PontoInteresseId",
                table: "Atividades");

            migrationBuilder.DropTable(
                name: "Artistas");

            migrationBuilder.DropTable(
                name: "Barracas");

            migrationBuilder.DropTable(
                name: "Bilhetes");

            migrationBuilder.DropTable(
                name: "Concursos");

            migrationBuilder.DropTable(
                name: "MediaEdicoes");

            migrationBuilder.DropTable(
                name: "Links");

            migrationBuilder.DropTable(
                name: "Transportes");

            migrationBuilder.DropTable(
                name: "PontosInteresse");

            migrationBuilder.DropTable(
                name: "Atividades");
        }
    }
}
