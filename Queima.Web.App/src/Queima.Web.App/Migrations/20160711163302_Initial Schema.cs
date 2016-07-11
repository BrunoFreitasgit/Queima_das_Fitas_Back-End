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
                    ImagemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(nullable: true),
                    ImagemData = table.Column<byte[]>(nullable: true),
                    URL = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Imagens", x => x.ImagemId);
                });

            migrationBuilder.CreateTable(
                name: "Locais",
                columns: table => new
                {
                    LocalId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Latitude = table.Column<double>(nullable: false),
                    Longitude = table.Column<double>(nullable: false),
                    Nome = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locais", x => x.LocalId);
                });

            migrationBuilder.CreateTable(
                name: "Artistas",
                columns: table => new
                {
                    ArtistaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Biografia = table.Column<string>(nullable: true),
                    DataAtuacao = table.Column<DateTime>(nullable: false),
                    FacebookUrl = table.Column<string>(nullable: true),
                    FotoImagemId = table.Column<int>(nullable: false),
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
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transportes",
                columns: table => new
                {
                    TransporteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(nullable: true),
                    ImagemId = table.Column<int>(nullable: true),
                    Nome = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transportes", x => x.TransporteId);
                    table.ForeignKey(
                        name: "FK_Transportes_Imagens_ImagemId",
                        column: x => x.ImagemId,
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
                    Descricao = table.Column<string>(nullable: false),
                    ImagemId = table.Column<int>(nullable: true),
                    LocalId = table.Column<int>(nullable: true),
                    Nome = table.Column<string>(nullable: false),
                    Preco = table.Column<decimal>(nullable: false)
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
                name: "Links",
                columns: table => new
                {
                    LinkId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Categoria = table.Column<int>(nullable: false),
                    Descricao = table.Column<string>(nullable: false),
                    TransporteId = table.Column<int>(nullable: true),
                    Url = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Links", x => x.LinkId);
                    table.ForeignKey(
                        name: "FK_Links_Transportes_TransporteId",
                        column: x => x.TransporteId,
                        principalTable: "Transportes",
                        principalColumn: "TransporteId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PontosVenda",
                columns: table => new
                {
                    PontoVendaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AtividadeAcademicaId = table.Column<int>(nullable: true),
                    Descricao = table.Column<string>(nullable: true),
                    LocalId = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PontosVenda", x => x.PontoVendaId);
                    table.ForeignKey(
                        name: "FK_PontosVenda_Atividades_AtividadeAcademicaId",
                        column: x => x.AtividadeAcademicaId,
                        principalTable: "Atividades",
                        principalColumn: "AtividadeAcademicaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PontosVenda_Locais_LocalId",
                        column: x => x.LocalId,
                        principalTable: "Locais",
                        principalColumn: "LocalId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bilhetes",
                columns: table => new
                {
                    BilheteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Condicoes = table.Column<string>(nullable: true),
                    Data = table.Column<DateTime>(nullable: false),
                    LinkBilheteiraLinkId = table.Column<int>(nullable: true),
                    PrecoDiaAnterior = table.Column<decimal>(nullable: false),
                    PrecoNoDia = table.Column<decimal>(nullable: false),
                    PrecoNoDiaForaHoras = table.Column<decimal>(nullable: false),
                    PrecoNormal = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bilhetes", x => x.BilheteId);
                    table.ForeignKey(
                        name: "FK_Bilhetes_Links_LinkBilheteiraLinkId",
                        column: x => x.LinkBilheteiraLinkId,
                        principalTable: "Links",
                        principalColumn: "LinkId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Concursos",
                columns: table => new
                {
                    ConcursoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataFim = table.Column<DateTime>(nullable: false),
                    DataInicio = table.Column<DateTime>(nullable: false),
                    Descricao = table.Column<string>(nullable: false),
                    ImagemId = table.Column<int>(nullable: true),
                    TipoConcurso = table.Column<int>(nullable: false),
                    WebLinkLinkId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Concursos", x => x.ConcursoId);
                    table.ForeignKey(
                        name: "FK_Concursos_Imagens_ImagemId",
                        column: x => x.ImagemId,
                        principalTable: "Imagens",
                        principalColumn: "ImagemId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Concursos_Links_WebLinkLinkId",
                        column: x => x.WebLinkLinkId,
                        principalTable: "Links",
                        principalColumn: "LinkId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MediaEdicoes",
                columns: table => new
                {
                    MediaEdicaoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ano = table.Column<int>(nullable: false),
                    TipoMedia = table.Column<int>(nullable: false),
                    Titulo = table.Column<string>(nullable: true),
                    UrlLinkLinkId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaEdicoes", x => x.MediaEdicaoId);
                    table.ForeignKey(
                        name: "FK_MediaEdicoes_Links_UrlLinkLinkId",
                        column: x => x.UrlLinkLinkId,
                        principalTable: "Links",
                        principalColumn: "LinkId",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "IX_Bilhetes_LinkBilheteiraLinkId",
                table: "Bilhetes",
                column: "LinkBilheteiraLinkId");

            migrationBuilder.CreateIndex(
                name: "IX_Concursos_ImagemId",
                table: "Concursos",
                column: "ImagemId");

            migrationBuilder.CreateIndex(
                name: "IX_Concursos_WebLinkLinkId",
                table: "Concursos",
                column: "WebLinkLinkId");

            migrationBuilder.CreateIndex(
                name: "IX_Links_TransporteId",
                table: "Links",
                column: "TransporteId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaEdicoes_UrlLinkLinkId",
                table: "MediaEdicoes",
                column: "UrlLinkLinkId");

            migrationBuilder.CreateIndex(
                name: "IX_PontosVenda_AtividadeAcademicaId",
                table: "PontosVenda",
                column: "AtividadeAcademicaId");

            migrationBuilder.CreateIndex(
                name: "IX_PontosVenda_LocalId",
                table: "PontosVenda",
                column: "LocalId");

            migrationBuilder.CreateIndex(
                name: "IX_Transportes_ImagemId",
                table: "Transportes",
                column: "ImagemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "PontosVenda");

            migrationBuilder.DropTable(
                name: "Links");

            migrationBuilder.DropTable(
                name: "Atividades");

            migrationBuilder.DropTable(
                name: "Transportes");

            migrationBuilder.DropTable(
                name: "Locais");

            migrationBuilder.DropTable(
                name: "Imagens");
        }
    }
}
