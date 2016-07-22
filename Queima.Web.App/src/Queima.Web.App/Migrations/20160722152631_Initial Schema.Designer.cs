using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Queima.Web.App.DAL;

namespace Queima.Web.App.Migrations
{
    [DbContext(typeof(QueimaDbContext))]
    [Migration("20160722152631_Initial Schema")]
    partial class InitialSchema
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Queima.Web.App.Models.Artista", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Biografia");

                    b.Property<DateTime>("DataAtuacao");

                    b.Property<string>("FacebookUrl");

                    b.Property<string>("ImagemPath")
                        .IsRequired();

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.Property<int>("Palco");

                    b.Property<string>("SpotifyUrl");

                    b.Property<string>("TwitterUrl");

                    b.HasKey("Id");

                    b.ToTable("Artistas");
                });

            modelBuilder.Entity("Queima.Web.App.Models.AtividadeAcademica", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Data");

                    b.Property<string>("Descricao")
                        .IsRequired();

                    b.Property<string>("ImagemPath")
                        .IsRequired();

                    b.Property<int?>("LocalId");

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.Property<decimal>("Preco");

                    b.HasKey("Id");

                    b.HasIndex("LocalId");

                    b.ToTable("Atividades");
                });

            modelBuilder.Entity("Queima.Web.App.Models.Barraca", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FacebookEventUrl");

                    b.Property<string>("ImagemPath")
                        .IsRequired();

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.Property<int?>("PosicaoId");

                    b.HasKey("Id");

                    b.HasIndex("PosicaoId");

                    b.ToTable("Barracas");
                });

            modelBuilder.Entity("Queima.Web.App.Models.Bilhete", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Condicoes");

                    b.Property<DateTime>("Data");

                    b.Property<int?>("LinkBilheteiraId");

                    b.Property<decimal>("PrecoDiaAnterior");

                    b.Property<decimal>("PrecoNoDia");

                    b.Property<decimal>("PrecoNoDiaForaHoras");

                    b.Property<decimal>("PrecoNormal");

                    b.HasKey("Id");

                    b.HasIndex("LinkBilheteiraId");

                    b.ToTable("Bilhetes");
                });

            modelBuilder.Entity("Queima.Web.App.Models.Concurso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DataFim");

                    b.Property<DateTime>("DataInicio");

                    b.Property<string>("Descricao")
                        .IsRequired();

                    b.Property<string>("ImagemPath")
                        .IsRequired();

                    b.Property<int>("TipoConcurso");

                    b.Property<int?>("WebLinkId");

                    b.HasKey("Id");

                    b.HasIndex("WebLinkId");

                    b.ToTable("Concursos");
                });

            modelBuilder.Entity("Queima.Web.App.Models.Link", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Categoria");

                    b.Property<string>("Descricao")
                        .IsRequired();

                    b.Property<int?>("TransporteId");

                    b.Property<string>("Url")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("TransporteId");

                    b.ToTable("Links");
                });

            modelBuilder.Entity("Queima.Web.App.Models.MediaEdicao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Ano");

                    b.Property<int>("TipoMedia");

                    b.Property<string>("Titulo");

                    b.Property<int?>("UrlLinkId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UrlLinkId");

                    b.ToTable("MediaEdicoes");
                });

            modelBuilder.Entity("Queima.Web.App.Models.PontoInteresse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AtividadeAcademicaId");

                    b.Property<string>("DescricaoAdicional");

                    b.Property<double>("Latitude");

                    b.Property<double>("Longitude");

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.Property<int>("Tipo");

                    b.HasKey("Id");

                    b.HasIndex("AtividadeAcademicaId");

                    b.ToTable("PontosInteresse");
                });

            modelBuilder.Entity("Queima.Web.App.Models.Transporte", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descricao");

                    b.Property<string>("ImagemPath")
                        .IsRequired();

                    b.Property<int>("Nome");

                    b.HasKey("Id");

                    b.ToTable("Transportes");
                });

            modelBuilder.Entity("Queima.Web.App.Models.AtividadeAcademica", b =>
                {
                    b.HasOne("Queima.Web.App.Models.PontoInteresse", "Local")
                        .WithMany()
                        .HasForeignKey("LocalId");
                });

            modelBuilder.Entity("Queima.Web.App.Models.Barraca", b =>
                {
                    b.HasOne("Queima.Web.App.Models.PontoInteresse", "Posicao")
                        .WithMany()
                        .HasForeignKey("PosicaoId");
                });

            modelBuilder.Entity("Queima.Web.App.Models.Bilhete", b =>
                {
                    b.HasOne("Queima.Web.App.Models.Link", "LinkBilheteira")
                        .WithMany()
                        .HasForeignKey("LinkBilheteiraId");
                });

            modelBuilder.Entity("Queima.Web.App.Models.Concurso", b =>
                {
                    b.HasOne("Queima.Web.App.Models.Link", "WebLink")
                        .WithMany()
                        .HasForeignKey("WebLinkId");
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
                        .HasForeignKey("UrlLinkId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Queima.Web.App.Models.PontoInteresse", b =>
                {
                    b.HasOne("Queima.Web.App.Models.AtividadeAcademica")
                        .WithMany("PontosVenda")
                        .HasForeignKey("AtividadeAcademicaId");
                });
        }
    }
}
