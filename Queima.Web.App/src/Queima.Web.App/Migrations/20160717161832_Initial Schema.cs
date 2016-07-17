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
                name: "Imagens",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(nullable: true),
                    ImagemData = table.Column<byte[]>(nullable: true),
                    URL = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Imagens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Artistas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Biografia = table.Column<string>(nullable: true),
                    DataAtuacao = table.Column<DateTime>(nullable: false),
                    FacebookUrl = table.Column<string>(nullable: true),
                    FotoId = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(nullable: false),
                    Palco = table.Column<int>(nullable: false),
                    SpotifyUrl = table.Column<string>(nullable: true),
                    TwitterUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artistas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Artistas_Imagens_FotoId",
                        column: x => x.FotoId,
                        principalTable: "Imagens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transportes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(nullable: true),
                    ImagemId = table.Column<int>(nullable: true),
                    Nome = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transportes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transportes_Imagens_ImagemId",
                        column: x => x.ImagemId,
                        principalTable: "Imagens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    ImagemId = table.Column<int>(nullable: true),
                    TipoConcurso = table.Column<int>(nullable: false),
                    WebLinkId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Concursos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Concursos_Imagens_ImagemId",
                        column: x => x.ImagemId,
                        principalTable: "Imagens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    TipoMedia = table.Column<int>(nullable: false),
                    Titulo = table.Column<string>(nullable: true),
                    UrlLinkId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaEdicoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MediaEdicoes_Links_UrlLinkId",
                        column: x => x.UrlLinkId,
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
                    ImagemId = table.Column<int>(nullable: true),
                    LocalId = table.Column<int>(nullable: true),
                    Nome = table.Column<string>(nullable: false),
                    Preco = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atividades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Atividades_Imagens_ImagemId",
                        column: x => x.ImagemId,
                        principalTable: "Imagens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Atividades_PontosInteresse_LocalId",
                        column: x => x.LocalId,
                        principalTable: "PontosInteresse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Barracas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FacebookEventUrl = table.Column<string>(nullable: true),
                    FotoId = table.Column<int>(nullable: true),
                    Nome = table.Column<string>(nullable: false),
                    PosicaoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Barracas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Barracas_Imagens_FotoId",
                        column: x => x.FotoId,
                        principalTable: "Imagens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Barracas_PontosInteresse_PosicaoId",
                        column: x => x.PosicaoId,
                        principalTable: "PontosInteresse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Artistas_FotoId",
                table: "Artistas",
                column: "FotoId");

            migrationBuilder.CreateIndex(
                name: "IX_Atividades_ImagemId",
                table: "Atividades",
                column: "ImagemId");

            migrationBuilder.CreateIndex(
                name: "IX_Atividades_LocalId",
                table: "Atividades",
                column: "LocalId");

            migrationBuilder.CreateIndex(
                name: "IX_Barracas_FotoId",
                table: "Barracas",
                column: "FotoId");

            migrationBuilder.CreateIndex(
                name: "IX_Barracas_PosicaoId",
                table: "Barracas",
                column: "PosicaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Bilhetes_LinkBilheteiraId",
                table: "Bilhetes",
                column: "LinkBilheteiraId");

            migrationBuilder.CreateIndex(
                name: "IX_Concursos_ImagemId",
                table: "Concursos",
                column: "ImagemId");

            migrationBuilder.CreateIndex(
                name: "IX_Concursos_WebLinkId",
                table: "Concursos",
                column: "WebLinkId");

            migrationBuilder.CreateIndex(
                name: "IX_Links_TransporteId",
                table: "Links",
                column: "TransporteId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaEdicoes_UrlLinkId",
                table: "MediaEdicoes",
                column: "UrlLinkId");

            migrationBuilder.CreateIndex(
                name: "IX_PontosInteresse_AtividadeAcademicaId",
                table: "PontosInteresse",
                column: "AtividadeAcademicaId");

            migrationBuilder.CreateIndex(
                name: "IX_Transportes_ImagemId",
                table: "Transportes",
                column: "ImagemId");

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
                name: "FK_Atividades_Imagens_ImagemId",
                table: "Atividades");

            migrationBuilder.DropForeignKey(
                name: "FK_Atividades_PontosInteresse_LocalId",
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
                name: "Imagens");

            migrationBuilder.DropTable(
                name: "PontosInteresse");

            migrationBuilder.DropTable(
                name: "Atividades");
        }
    }
}
