using CopaFilmes.Domain.Entities;
using CopaFilmes.Service.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            // Arrange
            List<Filme> Filmes = FilmesFake.FilmesQuartasFinais();
            List<Filme> FilmesEsperados = FilmesFake.ResultFilmesQuartasFinais();

            // Act
            var RodadaResult = _copaFilmesService.Rodada(Filmes);

            Assert.IsType<List<Filme>>(RodadaResult);

            Assert.True(FilmesEsperados.Count == RodadaResult.Count);
            // Assert.InRange(items.All(shouldItem => FilmesEsperados.FindAll(isItem => isItem == shouldItem)));
        }

        [Fact]
        public void SemiFinail()
        {
            // Arrange
            List<Filme> Filmes = FilmesFake.FilmesSemiFinal();
            List<Filme> FilmesEsperados = FilmesFake.ResultFilmesSemiFinal();

            // Act
            var RodadaResult = _copaFilmesService.Rodada(Filmes);

            Assert.IsType<List<Filme>>(RodadaResult);

            Assert.True(FilmesEsperados.Count == RodadaResult.Count);
            // Assert.InRange(items.All(shouldItem => FilmesEsperados.FindAll(isItem => isItem == shouldItem)));
        }

        [Fact]
        public void Final()
        {
            // Arrange
            List<Filme> Filmes = FilmesFake.FilmesFinal();
            List<Filme> FilmesEsperados = FilmesFake.ResultFilmesFinal();

            // Act
            var RodadaResult = _copaFilmesService.Rodada(Filmes);

            Assert.IsType<List<Filme>>(RodadaResult);

            Assert.True(FilmesEsperados.Count == RodadaResult.Count);
            // Assert.InRange(items.All(shouldItem => FilmesEsperados.FindAll(isItem => isItem == shouldItem)));
        }

    }
}
