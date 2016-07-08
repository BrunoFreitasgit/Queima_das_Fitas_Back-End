using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Queima.Web.App.DAL;

namespace Queima.Web.App.Migrations
{
    [DbContext(typeof(QueimaDbContext))]
    [Migration("20160708165546_Schema Inicial")]
    partial class SchemaInicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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

                    b.Property<string>("Nome");

                    b.HasKey("LocalId");

                    b.ToTable("Locais");
                });
        }
    }
}
