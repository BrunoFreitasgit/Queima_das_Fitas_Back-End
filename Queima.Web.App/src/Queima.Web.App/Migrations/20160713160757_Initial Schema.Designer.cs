using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Queima.Web.App.DAL;

namespace Queima.Web.App.Migrations
{
    [DbContext(typeof(QueimaDbContext))]
    [Migration("20160713160757_Initial Schema")]
    partial class InitialSchema
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Queima.Web.App.Models.Artista", b =>
                {
                    b.Property<int>("ArtistaId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Biografia");

                    b.Property<DateTime>("DataAtuacao");

                    b.Property<string>("FacebookUrl");

                    b.Property<int?>("FotoImagemId")
                        .IsRequired();

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.Property<int>("Palco");

                    b.Property<string>("SpotifyUrl");

                    b.Property<string>("TwitterUrl");

                    b.HasKey("ArtistaId");

                    b.HasIndex("FotoImagemId");

                    b.ToTable("Artistas");
                });

            modelBuilder.Entity("Queima.Web.App.Models.AtividadeAcademica", b =>
                {
                    b.Property<int>("AtividadeAcademicaId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Data");

                    b.Property<string>("Descricao")
                        .IsRequired();

                    b.Property<int?>("ImagemId");

                    b.Property<int?>("LocalPontoInteresseID");

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.Property<decimal>("Preco");

                    b.HasKey("AtividadeAcademicaId");

                    b.HasIndex("ImagemId");

                    b.HasIndex("LocalPontoInteresseID");

                    b.ToTable("Atividades");
                });

            modelBuilder.Entity("Queima.Web.App.Models.Barraca", b =>
                {
                    b.Property<int>("BarracaId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FacebookEventUrl");

                    b.Property<int?>("FotoImagemId");

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.Property<int?>("PosicaoPontoInteresseID");

                    b.HasKey("BarracaId");

                    b.HasIndex("FotoImagemId");

                    b.HasIndex("PosicaoPontoInteresseID");

                    b.ToTable("Barracas");
                });

            modelBuilder.Entity("Queima.Web.App.Models.Bilhete", b =>
                {
                    b.Property<int>("BilheteId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Condicoes");

                    b.Property<DateTime>("Data");

                    b.Property<int?>("LinkBilheteiraLinkId");

                    b.Property<decimal>("PrecoDiaAnterior");

                    b.Property<decimal>("PrecoNoDia");

                    b.Property<decimal>("PrecoNoDiaForaHoras");

                    b.Property<decimal>("PrecoNormal");

                    b.HasKey("BilheteId");

                    b.HasIndex("LinkBilheteiraLinkId");

                    b.ToTable("Bilhetes");
                });

            modelBuilder.Entity("Queima.Web.App.Models.Concurso", b =>
                {
                    b.Property<int>("ConcursoId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DataFim");

                    b.Property<DateTime>("DataInicio");

                    b.Property<string>("Descricao")
                        .IsRequired();

                    b.Property<int?>("ImagemId");

                    b.Property<int>("TipoConcurso");

                    b.Property<int?>("WebLinkLinkId");

                    b.HasKey("ConcursoId");

                    b.HasIndex("ImagemId");

                    b.HasIndex("WebLinkLinkId");

                    b.ToTable("Concursos");
                });

            modelBuilder.Entity("Queima.Web.App.Models.Imagem", b =>
                {
                    b.Property<int>("ImagemId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descricao");

                    b.Property<byte[]>("ImagemData");

                    b.Property<string>("URL");

                    b.HasKey("ImagemId");

                    b.ToTable("Imagens");
                });

            modelBuilder.Entity("Queima.Web.App.Models.Link", b =>
                {
                    b.Property<int>("LinkId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Categoria");

                    b.Property<string>("Descricao")
                        .IsRequired();

                    b.Property<int?>("TransporteId");

                    b.Property<string>("Url")
                        .IsRequired();

                    b.HasKey("LinkId");

                    b.HasIndex("TransporteId");

                    b.ToTable("Links");
                });

            modelBuilder.Entity("Queima.Web.App.Models.MediaEdicao", b =>
                {
                    b.Property<int>("MediaEdicaoId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Ano");

                    b.Property<int>("TipoMedia");

                    b.Property<string>("Titulo");

                    b.Property<int?>("UrlLinkLinkId")
                        .IsRequired();

                    b.HasKey("MediaEdicaoId");

                    b.HasIndex("UrlLinkLinkId");

                    b.ToTable("MediaEdicoes");
                });

            modelBuilder.Entity("Queima.Web.App.Models.PontoInteresse", b =>
                {
                    b.Property<int>("PontoInteresseID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AtividadeAcademicaId");

                    b.Property<string>("DescricaoAdicional");

                    b.Property<double>("Latitude");

                    b.Property<double>("Longitude");

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.Property<int>("Tipo");

                    b.HasKey("PontoInteresseID");

                    b.HasIndex("AtividadeAcademicaId");

                    b.ToTable("PontosInteresse");
                });

            modelBuilder.Entity("Queima.Web.App.Models.Transporte", b =>
                {
                    b.Property<int>("TransporteId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descricao");

                    b.Property<int?>("ImagemId");

                    b.Property<int>("Nome");

                    b.HasKey("TransporteId");

                    b.HasIndex("ImagemId");

                    b.ToTable("Transportes");
                });

            modelBuilder.Entity("Queima.Web.App.Models.Artista", b =>
                {
                    b.HasOne("Queima.Web.App.Models.Imagem", "Foto")
                        .WithMany()
                        .HasForeignKey("FotoImagemId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Queima.Web.App.Models.AtividadeAcademica", b =>
                {
                    b.HasOne("Queima.Web.App.Models.Imagem", "Imagem")
                        .WithMany()
                        .HasForeignKey("ImagemId");

                    b.HasOne("Queima.Web.App.Models.PontoInteresse", "Local")
                        .WithMany()
                        .HasForeignKey("LocalPontoInteresseID");
                });

            modelBuilder.Entity("Queima.Web.App.Models.Barraca", b =>
                {
                    b.HasOne("Queima.Web.App.Models.Imagem", "Foto")
                        .WithMany()
                        .HasForeignKey("FotoImagemId");

                    b.HasOne("Queima.Web.App.Models.PontoInteresse", "Posicao")
                        .WithMany()
                        .HasForeignKey("PosicaoPontoInteresseID");
                });

            modelBuilder.Entity("Queima.Web.App.Models.Bilhete", b =>
                {
                    b.HasOne("Queima.Web.App.Models.Link", "LinkBilheteira")
                        .WithMany()
                        .HasForeignKey("LinkBilheteiraLinkId");
                });

            modelBuilder.Entity("Queima.Web.App.Models.Concurso", b =>
                {
                    b.HasOne("Queima.Web.App.Models.Imagem", "Imagem")
                        .WithMany()
                        .HasForeignKey("ImagemId");

                    b.HasOne("Queima.Web.App.Models.Link", "WebLink")
                        .WithMany()
                        .HasForeignKey("WebLinkLinkId");
                });

            modelBuilder.Entity("Queima.Web.App.Models.Link", b =>
                {
                    b.HasOne("Queima.Web.App.Models.Transporte")
                        .WithMany("Links")
                        .HasForeignKey("TransporteId");
                });

            modelBuilder.Entity("Queima.Web.App.Models.MediaEdicao", b =>
                {
                    b.HasOne("Queima.Web.App.Models.Link", "UrlLink")
                        .WithMany()
                        .HasForeignKey("UrlLinkLinkId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Queima.Web.App.Models.PontoInteresse", b =>
                {
                    b.HasOne("Queima.Web.App.Models.AtividadeAcademica")
                        .WithMany("PontosVenda")
                        .HasForeignKey("AtividadeAcademicaId");
                });

            modelBuilder.Entity("Queima.Web.App.Models.Transporte", b =>
                {
                    b.HasOne("Queima.Web.App.Models.Imagem", "Imagem")
                        .WithMany()
                        .HasForeignKey("ImagemId");
                });
        }
    }
}
