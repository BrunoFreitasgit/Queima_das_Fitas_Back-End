using Queima.Web.App.Interfaces;
using Queima.Web.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Queima.Web.App.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private bool _disposed;

        // Db Context
        private readonly QueimaDbContext _db;
        private IRepository<Artista> _artistasRepository;
        private IRepository<AtividadeAcademica> _atividadesRepository;
        private IRepository<Barraca> _barracasRepository;
        private IRepository<Imagem> _imagensRepository;
        private IRepository<Local> _locaisRepository;
        private IRepository<PontoVenda> _pontosVendaRepository;
        private IRepository<Concurso> _concursosRepository;
        private IRepository<MediaEdicao> _mediaedicoesRepository;
        private IRepository<Transporte> _transportesRepository;

        public UnitOfWork()
        {
            _db = new QueimaDbContext();
        }
        public UnitOfWork(QueimaDbContext db)
        {
            _db = db;
        }

        public IRepository<Artista> ArtistasRepository
        {
            get
            {
                if (_artistasRepository == null)
                {
                    _artistasRepository = new Repository<Artista>(_db);
                }
                return _artistasRepository;
            }
        }

        public IRepository<AtividadeAcademica> AtividadesAcademicasRepository
        {
            get
            {
                if (_atividadesRepository == null)
                {
                    _atividadesRepository = new Repository<AtividadeAcademica>(_db);
                }
                return _atividadesRepository;
            }
        }

        public IRepository<Barraca> BarracasRepository
        {
            get
            {
                if (_barracasRepository == null)
                {
                    _barracasRepository = new Repository<Barraca>(_db);
                }
                return _barracasRepository;
            }
        }

        public IRepository<Imagem> ImagensRepository
        {
            get
            {
                if (_imagensRepository == null)
                {
                    _imagensRepository = new Repository<Imagem>(_db);
                }
                return _imagensRepository;
            }
        }

        public IRepository<Local> LocaisRepository
        {
            get
            {
                if (_locaisRepository == null)
                {
                    _locaisRepository = new Repository<Local>(_db);
                }
                return _locaisRepository;
            }
        }

        public IRepository<PontoVenda> PontosVendaRepository
        {
            get
            {
                if (_pontosVendaRepository == null)
                {
                    _pontosVendaRepository = new Repository<PontoVenda>(_db);
                }
                return _pontosVendaRepository;
            }
        }
        public IRepository<MediaEdicao> MediaEdicoesRepository
        {
            get
            {
                if (_mediaedicoesRepository == null)
                {
                    _mediaedicoesRepository = new Repository<MediaEdicao>(_db);
                }
                return _mediaedicoesRepository;
            }
        }
        public IRepository<Transporte> TransportesRepository
        {
            get
            {
                if (_transportesRepository == null)
                {
                    _transportesRepository = new Repository<Transporte>(_db);
                }
                return _transportesRepository;
            }
        }
        public IRepository<Concurso> ConcursosRepository
        {
            get
            {
                if (_concursosRepository == null)
                {
                    _concursosRepository = new Repository<Concurso>(_db);
                }
                return _concursosRepository;
            }
        }

        public void SalvarAlteracoes()
        {
            _db.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
