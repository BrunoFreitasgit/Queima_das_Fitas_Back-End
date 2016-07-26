using Microsoft.EntityFrameworkCore;
using Queima.Web.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Queima.Web.App.ViewModels;
using Microsoft.AspNetCore.Hosting;

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
        public DbSet<PontoVenda> PontosVenda { get; set; }
        public DbSet<Bilheteira> Bilheteiras { get; set; }
        public DbSet<PontoInteresse> PontosInteresse { get; set; }
        public DbSet<AtividadeAcademica> Atividades { get; set; }
        public DbSet<Barraca> Barracas { get; set; }
        public DbSet<Artista> Artistas { get; set; }
        public DbSet<Concurso> Concursos { get; set; }
        public DbSet<MediaEdicao> MediaEdicoes { get; set; }
        public DbSet<Transporte> Transportes { get; set; }
        public DbSet<Link> Links { get; set; }
        public DbSet<Bilhete> Bilhetes { get; set; }
        public void EnsureSeedData(IHostingEnvironment env)
        {
            if (!PontosInteresse.Any())
            {
                PontosInteresse.AddRange(
                    new PontoInteresse { Nome = "Coliseu do Porto", Latitude = 41.1469917, Longitude = -8.605416999999989, Tipo = TipoLocal.AtividadeAcademica },
                    new PontoInteresse { Nome = "Avenida dos Aliados", Latitude = 41.1484572, Longitude = -8.610746400000039, Tipo = TipoLocal.AtividadeAcademica },
                    new PontoInteresse { Nome = "Aula Magna da Universidade Portucalense", Latitude = 41.1804589, Longitude = -8.605948000000012, Tipo = TipoLocal.AtividadeAcademica },
                    new PontoInteresse { Nome = "Cidade do Porto", Latitude = 41.1494466, Longitude = -8.607507199999986, Tipo = TipoLocal.AtividadeAcademica },
                    new PontoInteresse { Nome = "Teatro Sá da Bandeira", Latitude = 41.146793, Longitude = -8.608879099999967, Tipo = TipoLocal.AtividadeAcademica },
                    new PontoInteresse { Nome = "Casa dos Arcos", Latitude = 41.1657561, Longitude = -8.670960700000023, Tipo = TipoLocal.AtividadeAcademica }
                );
                SaveChanges();
            }
            if (!PontosVenda.Any())
            {
                PontosVenda.AddRange(
                    new PontoVenda { Nome = "FAP", Latitude = 41.1523043, Longitude = -8.636018499999977, DescricaoAdicional = "teste" },
                    new PontoVenda { Nome = "Campus S.João", Latitude = 41.18024569999999, Longitude = -8.604281899999933, DescricaoAdicional = "teste" },
                    new PontoVenda { Nome = "Queimódromo", Latitude = 41.17346102935757, Longitude = -8.68374690413475, DescricaoAdicional = "teste" },
                    new PontoVenda { Nome = "El Corte Inglés", Latitude = 41.125627, Longitude = -8.604804999999942, DescricaoAdicional = "teste" }
                    );
                SaveChanges();
            }
            if (!Atividades.Any())
            {
                List<PontoInteresse> pontos = PontosInteresse.Where(x => x.Tipo == TipoLocal.AtividadeAcademica).ToList();
                List<PontoVenda> pontos_venda = PontosVenda.ToList();
                Atividades.AddRange(
                    new AtividadeAcademica
                    {
                        Data = new DateTime(2016, 02, 01),
                        Descricao = "Descrição teste",
                        PontoInteresse = pontos.ElementAt(0),
                        Nome = "Sarau Cultural",
                        PontosVenda = pontos_venda,
                        ImagemPath = env.WebRootPath + "\\imagens\\atividades\\TOMANEPHOTOS056.jpg",
                        PontoInteresseId = pontos.ElementAt(0).Id,
                        Preco = 3.00m
                    }
                    );
                SaveChanges();
            }
        }
    }
}

