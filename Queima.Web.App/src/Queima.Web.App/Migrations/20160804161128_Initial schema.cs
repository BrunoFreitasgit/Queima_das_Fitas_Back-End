using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Queima.Web.App.Migrations
{
    public partial class Initialschema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artistas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Biografia = table.Column<string>(nullable: false),
                    DataAtuacao = table.Column<DateTime>(nullable: false),
                    FacebookUrl = table.Column<string>(nullable: true),
                    ImagemPath = table.Column<string>(nullable: false),
                    ImagemUrl = table.Column<string>(nullable: true),
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
                name: "Bilheteiras",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Condicoes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bilheteiras", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Links",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Categoria = table.Column<int>(nullable: false),
                    Descricao = table.Column<string>(nullable: false),
                    Url = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Links", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LocaisAtividades",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Latitude = table.Column<double>(nullable: false),
                    Longitude = table.Column<double>(nullable: false),
                    Nome = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocaisAtividades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PontosVenda",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BilheteiraId = table.Column<int>(nullable: true),
                    DescricaoAdicional = table.Column<string>(nullable: true),
                    Horário = table.Column<string>(nullable: true),
                    Latitude = table.Column<double>(nullable: false),
                    Longitude = table.Column<double>(nullable: false),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PontosVenda", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PontosVenda_Bilheteiras_BilheteiraId",
                        column: x => x.BilheteiraId,
                        principalTable: "Bilheteiras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Bilhetes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BilheteiraId = table.Column<int>(nullable: false),
                    Data = table.Column<DateTime>(nullable: false),
                    LinkId = table.Column<int>(nullable: false),
                    PrecoDiaAnterior = table.Column<decimal>(nullable: false),
                    PrecoNoDia = table.Column<decimal>(nullable: false),
                    PrecoNoDiaForaHoras = table.Column<decimal>(nullable: false),
                    PrecoNormal = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bilhetes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bilhetes_Bilheteiras_BilheteiraId",
                        column: x => x.BilheteiraId,
                        principalTable: "Bilheteiras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bilhetes_Links_LinkId",
                        column: x => x.LinkId,
                        principalTable: "Links",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    ImagemUrl = table.Column<string>(nullable: true),
                    LinkId = table.Column<int>(nullable: false),
                    TipoConcurso = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Concursos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Concursos_Links_LinkId",
                        column: x => x.LinkId,
                        principalTable: "Links",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "Transportes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(nullable: true),
                    ImagemPath = table.Column<string>(nullable: false),
                    ImagemUrl = table.Column<string>(nullable: true),
                    LinkId = table.Column<int>(nullable: false),
                    Nome = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transportes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transportes_Links_LinkId",
                        column: x => x.LinkId,
                        principalTable: "Links",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Atividades",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Data = table.Column<DateTime>(nullable: false),
                    Descricao = table.Column<string>(nullable: true),
                    ImagemPath = table.Column<string>(nullable: true),
                    ImagemUrl = table.Column<string>(nullable: true),
                    LocalAtividadeAcademicaId = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    PontosVenda = table.Column<string>(nullable: true),
                    Preco = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atividades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Atividades_LocaisAtividades_LocalAtividadeAcademicaId",
                        column: x => x.LocalAtividadeAcademicaId,
                        principalTable: "LocaisAtividades",
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
                    ImagemUrl = table.Column<string>(nullable: true),
                    Nome = table.Column<string>(nullable: false),
                    PontoInteresseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Barracas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Barracas_LocaisAtividades_PontoInteresseId",
                        column: x => x.PontoInteresseId,
                        principalTable: "LocaisAtividades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Atividades_LocalAtividadeAcademicaId",
                table: "Atividades",
                column: "LocalAtividadeAcademicaId");

            migrationBuilder.CreateIndex(
                name: "IX_Barracas_PontoInteresseId",
                table: "Barracas",
                column: "PontoInteresseId");

            migrationBuilder.CreateIndex(
                name: "IX_Bilhetes_BilheteiraId",
                table: "Bilhetes",
                column: "BilheteiraId");

            migrationBuilder.CreateIndex(
                name: "IX_Bilhetes_LinkId",
                table: "Bilhetes",
                column: "LinkId");

            migrationBuilder.CreateIndex(
                name: "IX_Concursos_LinkId",
                table: "Concursos",
                column: "LinkId");

            migrationBuilder.CreateIndex(
                name: "IX_MediaEdicoes_LinkId",
                table: "MediaEdicoes",
                column: "LinkId");

            migrationBuilder.CreateIndex(
                name: "IX_PontosVenda_BilheteiraId",
                table: "PontosVenda",
                column: "BilheteiraId");

            migrationBuilder.CreateIndex(
                name: "IX_Transportes_LinkId",
                table: "Transportes",
                column: "LinkId");
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
                name: "Bilhetes");

            migrationBuilder.DropTable(
                name: "Concursos");

            migrationBuilder.DropTable(
                name: "MediaEdicoes");

            migrationBuilder.DropTable(
                name: "PontosVenda");

            migrationBuilder.DropTable(
                name: "Transportes");

            migrationBuilder.DropTable(
                name: "LocaisAtividades");

            migrationBuilder.DropTable(
                name: "Bilheteiras");

            migrationBuilder.DropTable(
                name: "Links");
        }
    }
}
