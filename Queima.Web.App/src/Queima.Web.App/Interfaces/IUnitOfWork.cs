using Queima.Web.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Queima.Web.App.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        // Todos os repositórios
        IRepository<Artista> ArtistasRepository { get; }
        IRepository<AtividadeAcademica> AtividadesAcademicasRepository { get; }
        IRepository<Barraca> BarracasRepository { get; }
        IRepository<Imagem> ImagensRepository { get; }
        IRepository<Local> LocaisRepository { get; }
        IRepository<PontoVenda> PontosVendaRepository { get; }
        IRepository<Concurso> ConcursosRepository { get; }
        IRepository<MediaEdicao> MediaEdicoesRepository { get; }
        IRepository<Transporte> TransportesRepository { get; }
        void SalvarAlteracoes();
    }
}
