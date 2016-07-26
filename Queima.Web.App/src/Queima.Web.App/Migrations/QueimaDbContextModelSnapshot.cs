﻿using System;
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
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Biografia")
                        .IsRequired();

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

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.Property<int>("PontoInteresseId");

                    b.Property<decimal>("Preco");

                    b.HasKey("Id");

                    b.HasIndex("PontoInteresseId");

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

                    b.Property<int>("PontoInteresseId");

                    b.HasKey("Id");

                    b.HasIndex("PontoInteresseId");

                    b.ToTable("Barracas");
                });

            modelBuilder.Entity("Queima.Web.App.Models.Bilhete", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BilheteiraId");

                    b.Property<DateTime>("Data");

                    b.Property<int>("LinkId");

                    b.Property<decimal>("PrecoDiaAnterior");

                    b.Property<decimal>("PrecoNoDia");

                    b.Property<decimal>("PrecoNoDiaForaHoras");

                    b.Property<decimal>("PrecoNormal");

                    b.HasKey("Id");

                    b.HasIndex("BilheteiraId");

                    b.HasIndex("LinkId");

                    b.ToTable("Bilhetes");
                });

            modelBuilder.Entity("Queima.Web.App.Models.Bilheteira", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Condicoes");

                    b.HasKey("Id");

                    b.ToTable("Bilheteiras");
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

                    b.Property<int>("LinkId");

                    b.Property<int>("TipoConcurso");

                    b.HasKey("Id");

                    b.HasIndex("LinkId");

                    b.ToTable("Concursos");
                });

            modelBuilder.Entity("Queima.Web.App.Models.Link", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Categoria");

                    b.Property<string>("Descricao")
                        .IsRequired();

                    b.Property<string>("Url")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Links");
                });

            modelBuilder.Entity("Queima.Web.App.Models.MediaEdicao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Ano");

                    b.Property<int>("LinkId");

                    b.Property<int>("TipoMedia");

                    b.Property<string>("Titulo");

                    b.HasKey("Id");

                    b.HasIndex("LinkId");

                    b.ToTable("MediaEdicoes");
                });

            modelBuilder.Entity("Queima.Web.App.Models.PontoInteresse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Latitude");

                    b.Property<double>("Longitude");

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.Property<int>("Tipo");

                    b.HasKey("Id");

                    b.ToTable("PontosInteresse");
                });

            modelBuilder.Entity("Queima.Web.App.Models.PontoVenda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AtividadeAcademicaId");

                    b.Property<int?>("BilheteiraId");

                    b.Property<string>("DescricaoAdicional");

                    b.Property<double>("Latitude");

                    b.Property<double>("Longitude");

                    b.Property<string>("Nome");

                    b.HasKey("Id");

                    b.HasIndex("AtividadeAcademicaId");

                    b.HasIndex("BilheteiraId");

                    b.ToTable("PontosVenda");
                });

            modelBuilder.Entity("Queima.Web.App.Models.Transporte", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descricao");

                    b.Property<string>("ImagemPath")
                        .IsRequired();

                    b.Property<int>("LinkId");

                    b.Property<int>("Nome");

                    b.HasKey("Id");

                    b.HasIndex("LinkId");

                    b.ToTable("Transportes");
                });

            modelBuilder.Entity("Queima.Web.App.Models.AtividadeAcademica", b =>
                {
                    b.HasOne("Queima.Web.App.Models.PontoInteresse", "PontoInteresse")
                        .WithMany()
                        .HasForeignKey("PontoInteresseId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Queima.Web.App.Models.Barraca", b =>
                {
                    b.HasOne("Queima.Web.App.Models.PontoInteresse", "PontoInteresse")
                        .WithMany()
                        .HasForeignKey("PontoInteresseId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Queima.Web.App.Models.Bilhete", b =>
                {
                    b.HasOne("Queima.Web.App.Models.Bilheteira", "Bilheteira")
                        .WithMany("Bilhetes")
                        .HasForeignKey("BilheteiraId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Queima.Web.App.Models.Link", "Link")
                        .WithMany()
                        .HasForeignKey("LinkId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Queima.Web.App.Models.Concurso", b =>
                {
                    b.HasOne("Queima.Web.App.Models.Link", "Link")
                        .WithMany()
                        .HasForeignKey("LinkId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Queima.Web.App.Models.MediaEdicao", b =>
                {
                    b.HasOne("Queima.Web.App.Models.Link", "Link")
                        .WithMany()
                        .HasForeignKey("LinkId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Queima.Web.App.Models.PontoVenda", b =>
                {
                    b.HasOne("Queima.Web.App.Models.AtividadeAcademica")
                        .WithMany("PontosVenda")
                        .HasForeignKey("AtividadeAcademicaId");

                    b.HasOne("Queima.Web.App.Models.Bilheteira")
                        .WithMany("PontosVenda")
                        .HasForeignKey("BilheteiraId");
                });

            modelBuilder.Entity("Queima.Web.App.Models.Transporte", b =>
                {
                    b.HasOne("Queima.Web.App.Models.Link", "Link")
                        .WithMany()
                        .HasForeignKey("LinkId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
