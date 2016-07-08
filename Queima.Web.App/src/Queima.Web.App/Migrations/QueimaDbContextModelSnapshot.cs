using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Queima.Web.App.DAL;

namespace Queima.Web.App.Migrations
{
    [DbContext(typeof(QueimaDbContext))]
    partial class QueimaDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<int?>("FotoImagemId");

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

                    b.Property<string>("Descricao");

                    b.Property<int?>("ImagemId");

                    b.Property<int?>("LocalId");

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.Property<decimal>("Preco");

                    b.HasKey("AtividadeAcademicaId");

                    b.HasIndex("ImagemId");

                    b.HasIndex("LocalId");

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

                    b.Property<int?>("PosicaoLocalId");

                    b.HasKey("BarracaId");

                    b.HasIndex("FotoImagemId");

                    b.HasIndex("PosicaoLocalId");

                    b.ToTable("Barracas");
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

            modelBuilder.Entity("Queima.Web.App.Models.Local", b =>
                {
                    b.Property<int>("LocalId")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Latitude");

                    b.Property<double>("Longitude");

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.HasKey("LocalId");

                    b.ToTable("Locais");
                });

            modelBuilder.Entity("Queima.Web.App.Models.PontoVenda", b =>
                {
                    b.Property<int>("PontoVendaId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descricao");

                    b.Property<int?>("LocalId");

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.HasKey("PontoVendaId");

                    b.HasIndex("LocalId");

                    b.ToTable("PontosVenda");
                });

            modelBuilder.Entity("Queima.Web.App.Models.Artista", b =>
                {
                    b.HasOne("Queima.Web.App.Models.Imagem", "Foto")
                        .WithMany()
                        .HasForeignKey("FotoImagemId");
                });

            modelBuilder.Entity("Queima.Web.App.Models.AtividadeAcademica", b =>
                {
                    b.HasOne("Queima.Web.App.Models.Imagem", "Imagem")
                        .WithMany()
                        .HasForeignKey("ImagemId");

                    b.HasOne("Queima.Web.App.Models.Local", "Local")
                        .WithMany()
                        .HasForeignKey("LocalId");
                });

            modelBuilder.Entity("Queima.Web.App.Models.Barraca", b =>
                {
                    b.HasOne("Queima.Web.App.Models.Imagem", "Foto")
                        .WithMany()
                        .HasForeignKey("FotoImagemId");

                    b.HasOne("Queima.Web.App.Models.Local", "Posicao")
                        .WithMany()
                        .HasForeignKey("PosicaoLocalId");
                });

            modelBuilder.Entity("Queima.Web.App.Models.PontoVenda", b =>
                {
                    b.HasOne("Queima.Web.App.Models.Local", "Local")
                        .WithMany()
                        .HasForeignKey("LocalId");
                });
        }
    }
}
