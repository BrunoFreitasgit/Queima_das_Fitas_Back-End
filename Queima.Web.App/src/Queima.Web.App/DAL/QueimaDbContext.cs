using Microsoft.EntityFrameworkCore;
using Queima.Web.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Queima.Web.App.DAL
{
    public class QueimaDbContext : DbContext
    {

        public QueimaDbContext(DbContextOptions<QueimaDbContext> options)
            : base(options)
        { }
        public QueimaDbContext()
        {

        }
        public DbSet<Local> Locais { get; set; }
        public DbSet<Imagem> Imagens { get; set; }
        public DbSet<AtividadeAcademica> Atividades { get; set; }
        public DbSet<Barraca> Barracas { get; set; }
        public DbSet<PontoVenda> PontosVenda { get; set; }
        public DbSet<Artista> Artistas { get; set; }
        public DbSet<Concurso> Concursos { get; set; }
        public DbSet<MediaEdicao> MediaEdicoes { get; set; }
        public DbSet<Transporte> Transportes { get; set; }
    }
}
