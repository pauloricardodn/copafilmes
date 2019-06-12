using CopaFilmes.Domain.Entities;
using CopaFilmes.Service.Services;
using System.Collections.Generic;
using System.ComponentModel;
using Xunit;

namespace CopaFilmes.Test
{
    public class CopaTest
    {
        private CopaFilmesService _copaFilmesService = new CopaFilmesService();
        private FilmesFake FilmesFake = new FilmesFake();

        [Fact]
        public void QuartasFinais()
        {
            List<Filme> Filmes = FilmesFake.FilmesQuartasFinais();

            var RodadaResult = _copaFilmesService.Rodada(Filmes);

            Assert.IsType<List<Filme>>(RodadaResult);

            Assert.True(4 == RodadaResult.Count);
            Assert.True(RodadaResult.Exists(x => x.Titulo == "Vingadores: Guerra Infinita"));
            Assert.True(RodadaResult.Exists(x => x.Titulo == "Thor: Ragnarok"));
            Assert.True(RodadaResult.Exists(x => x.Titulo == "Os Incríveis 2"));
            Assert.True(RodadaResult.Exists(x => x.Titulo == "Jurassic World: Reino Ameaçado"));
        }

        [Fact]
        public void SemiFinail()
        {
            List<Filme> Filmes = FilmesFake.FilmesSemiFinal();

            var RodadaResult = _copaFilmesService.Rodada(Filmes);

            Assert.IsType<List<Filme>>(RodadaResult);
            Assert.True(2 == RodadaResult.Count);
            Assert.True(RodadaResult.Exists(x => x.Titulo == "Vingadores: Guerra Infinita"));
            Assert.True(RodadaResult.Exists(x => x.Titulo == "Os Incríveis 2"));
        }

        [Fact]        
        public void Final()
        {
            List<Filme> Filmes = FilmesFake.FilmesFinal();

            var RodadaResult = _copaFilmesService.Rodada(Filmes);

            Assert.IsType<List<Filme>>(RodadaResult);
            Assert.True(1 == RodadaResult.Count);
            Assert.True(RodadaResult.Exists(x => x.Titulo == "Vingadores: Guerra Infinita"));
        }

        [Fact]
        public void Copa()
        {
            List<Filme> Filmes = FilmesFake.FilmesQuartasFinais();

            var RodadaResult = _copaFilmesService.Copa(Filmes);

            Assert.IsType<List<Filme>>(RodadaResult);

            Assert.True(2 == RodadaResult.Count);
            Assert.True(RodadaResult[0].Titulo == "Vingadores: Guerra Infinita");
            Assert.True(RodadaResult[1].Titulo == "Os Incríveis 2");
        }
    }
}
