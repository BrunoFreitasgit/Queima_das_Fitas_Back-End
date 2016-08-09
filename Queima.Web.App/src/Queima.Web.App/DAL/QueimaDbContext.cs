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
        public DbSet<LocalAtividadeAcademica> LocaisAtividades { get; set; }
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
            if (!LocaisAtividades.Any())
            {
                LocaisAtividades.AddRange(
                    new LocalAtividadeAcademica { Nome = "Coliseu do Porto", Latitude = 41.1469917, Longitude = -8.605416999999989 },
                    new LocalAtividadeAcademica { Nome = "Avenida dos Aliados", Latitude = 41.1484572, Longitude = -8.610746400000039 },
                    new LocalAtividadeAcademica { Nome = "Aula Magna da Universidade Portucalense", Latitude = 41.1804589, Longitude = -8.605948000000012 },
                    new LocalAtividadeAcademica { Nome = "Cidade do Porto", Latitude = 41.1494466, Longitude = -8.607507199999986 },
                    new LocalAtividadeAcademica { Nome = "Teatro Sá da Bandeira", Latitude = 41.146793, Longitude = -8.608879099999967 },
                    new LocalAtividadeAcademica { Nome = "Casa dos Arcos", Latitude = 41.1657561, Longitude = -8.670960700000023 }
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


            if (!Bilheteiras.Any())
            {
                Bilheteira bilheteira = new Bilheteira { PrecoIngressoSemanal = 40.00m, Condicoes = "Teste Condições" };
                Bilheteiras.Add(bilheteira);
                SaveChanges();

                Link link_bilhete1 = new Link { Categoria = Categoria.Bilheteira, Descricao = "Link Bilhete dia 1", Url = "www.online.pt" };
                Link link_bilhete2 = new Link { Categoria = Categoria.Bilheteira, Descricao = "Link Bilhete dia 2", Url = "www.online.pt" };
                Link link_bilhete3 = new Link { Categoria = Categoria.Bilheteira, Descricao = "Link Bilhete dia 3", Url = "www.online.pt" };
                Link link_bilhete4 = new Link { Categoria = Categoria.Bilheteira, Descricao = "Link Bilhete dia 4", Url = "www.online.pt" };
                Link link_bilhete5 = new Link { Categoria = Categoria.Bilheteira, Descricao = "Link Bilhete dia 5", Url = "www.online.pt" };
                Link link_bilhete6 = new Link { Categoria = Categoria.Bilheteira, Descricao = "Link Bilhete dia 6", Url = "www.online.pt" };
                Link link_bilhete7 = new Link { Categoria = Categoria.Bilheteira, Descricao = "Link Bilhete dia 7", Url = "www.online.pt" };
                Link link_bilhete8 = new Link { Categoria = Categoria.Bilheteira, Descricao = "Link Bilhete dia 8", Url = "www.online.pt" };
                Link link_ingresso_semanal = new Link { Categoria = Categoria.Bilheteira, Descricao = "Link Ingresso Semanal", Url = "www.ingresso.pt" };

                Links.AddRange(link_bilhete1, link_bilhete2, link_bilhete3, link_bilhete4, link_bilhete5, link_bilhete6, link_bilhete7, link_bilhete8, link_ingresso_semanal);
                SaveChanges();
                bilheteira.Link = link_ingresso_semanal;
                bilheteira.LinkId = link_ingresso_semanal.Id;
                Bilhete bilhete_dia1 = new Bilhete
                {
                    Data = new DateTime(2016, 05, 01),
                    Link = link_bilhete1,
                    LinkId = link_bilhete1.Id,
                    PrecoNormal = 8.00m,
                    PrecoDiaAnterior = 9.00m,
                    PrecoNoDia = 10.00m,
                    PrecoNoDiaForaHoras = 12.00m,
                    Bilheteira = bilheteira,
                    BilheteiraId = bilheteira.Id
                };
                Bilhete bilhete_dia2 = new Bilhete
                {
                    Data = new DateTime(2016, 05, 02),
                    Link = link_bilhete2,
                    LinkId = link_bilhete2.Id,
                    PrecoNormal = 8.00m,
                    PrecoDiaAnterior = 9.00m,
                    PrecoNoDia = 10.00m,
                    PrecoNoDiaForaHoras = 12.00m,
                    Bilheteira = bilheteira,
                    BilheteiraId = bilheteira.Id
                };
                Bilhete bilhete_dia3 = new Bilhete
                {
                    Data = new DateTime(2016, 05, 03),
                    Link = link_bilhete3,
                    LinkId = link_bilhete3.Id,
                    PrecoNormal = 8.00m,
                    PrecoDiaAnterior = 9.00m,
                    PrecoNoDia = 10.00m,
                    PrecoNoDiaForaHoras = 12.00m,
                    Bilheteira = bilheteira,
                    BilheteiraId = bilheteira.Id
                };
                Bilhete bilhete_dia4 = new Bilhete
                {
                    Data = new DateTime(2016, 05, 04),
                    Link = link_bilhete4,
                    LinkId = link_bilhete4.Id,
                    PrecoNormal = 8.00m,
                    PrecoDiaAnterior = 9.00m,
                    PrecoNoDia = 10.00m,
                    PrecoNoDiaForaHoras = 12.00m,
                    Bilheteira = bilheteira,
                    BilheteiraId = bilheteira.Id
                };
                Bilhete bilhete_dia5 = new Bilhete
                {
                    Data = new DateTime(2016, 05, 05),
                    Link = link_bilhete5,
                    LinkId = link_bilhete5.Id,
                    PrecoNormal = 8.00m,
                    PrecoDiaAnterior = 9.00m,
                    PrecoNoDia = 10.00m,
                    PrecoNoDiaForaHoras = 12.00m,
                    Bilheteira = bilheteira,
                    BilheteiraId = bilheteira.Id
                };
                Bilhete bilhete_dia6 = new Bilhete
                {
                    Data = new DateTime(2016, 05, 06),
                    Link = link_bilhete6,
                    LinkId = link_bilhete6.Id,
                    PrecoNormal = 8.00m,
                    PrecoDiaAnterior = 9.00m,
                    PrecoNoDia = 10.00m,
                    PrecoNoDiaForaHoras = 12.00m,
                    Bilheteira = bilheteira,
                    BilheteiraId = bilheteira.Id
                };
                Bilhete bilhete_dia7 = new Bilhete
                {
                    Data = new DateTime(2016, 05, 07),
                    Link = link_bilhete7,
                    LinkId = link_bilhete7.Id,
                    PrecoNormal = 8.00m,
                    PrecoDiaAnterior = 9.00m,
                    PrecoNoDia = 10.00m,
                    PrecoNoDiaForaHoras = 12.00m,
                    Bilheteira = bilheteira,
                    BilheteiraId = bilheteira.Id
                };
                Bilhete bilhete_dia8 = new Bilhete
                {
                    Data = new DateTime(2016, 05, 08),
                    Link = link_bilhete8,
                    LinkId = link_bilhete8.Id,
                    PrecoNormal = 8.00m,
                    PrecoDiaAnterior = 9.00m,
                    PrecoNoDia = 10.00m,
                    PrecoNoDiaForaHoras = 12.00m,
                    Bilheteira = bilheteira,
                    BilheteiraId = bilheteira.Id
                };

                Bilhetes.AddRange(bilhete_dia1, bilhete_dia2, bilhete_dia3, bilhete_dia4, bilhete_dia5, bilhete_dia6, bilhete_dia7, bilhete_dia8);
                SaveChanges();
                List<Bilhete> bilhetes_list = new List<Bilhete>();
                bilhetes_list.Add(bilhete_dia1);
                bilhetes_list.Add(bilhete_dia2);
                bilhetes_list.Add(bilhete_dia3);
                bilhetes_list.Add(bilhete_dia4);
                bilhetes_list.Add(bilhete_dia5);
                bilhetes_list.Add(bilhete_dia6);
                bilhetes_list.Add(bilhete_dia7);
                bilhetes_list.Add(bilhete_dia8);
                bilheteira.Bilhetes = bilhetes_list;
                Bilheteiras.Update(bilheteira);
                SaveChanges();
            };

            if (!Atividades.Any())
            {
                List<PontoVenda> pontos_venda = PontosVenda.ToList();
                List<LocalAtividadeAcademica> locais = LocaisAtividades.ToList();
                Atividades.AddRange(
                            new AtividadeAcademica
                            {
                                Data = new DateTime(2016, 02, 01),
                                Descricao = "Descrição teste",
                                LocalAtividadeAcademica = locais.ElementAt(0),
                                Nome = "Sarau Cultural",
                                PontosVenda = "Coliseu do Porto; FAP",
                                ImagemPath = env.WebRootPath + "\\imagens\\atividades\\TOMANEPHOTOS056.jpg",
                                LocalAtividadeAcademicaId = locais.ElementAt(0).Id,
                                Preco = 3.00m
                            }
                            );
                SaveChanges();
            }
            if (!Artistas.Any())
            {
                Artistas.Add(
                    new Artista
                    {
                        Nome = "Dumitri Basiul",
                        Biografia = "Dima tinha 12 anos quando começou a estudar música clássica. Depois disso emigrou para a Gronelândia",
                        DataAtuacao = new DateTime(2016, 05, 12),
                        ImagemPath = "\\imagens\\artistas\\Borgore.jpg",
                        Palco = Palco.PalcoPrincipal,
                    }
                    );
                SaveChanges();
            }
        }
    }
}

