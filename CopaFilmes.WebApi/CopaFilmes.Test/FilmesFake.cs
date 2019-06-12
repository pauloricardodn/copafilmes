using CopaFilmes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CopaFilmes.Test
{
    public class FilmesFake
    {
        public List<Filme> FilmesQuartasFinais()
        {
            List<Filme> Filmes = new List<Filme>() {
                new Filme { Id = "tt5463162", Titulo = "Deadpool 2", Ano = 2018, Nota = 8.1M },
                new Filme { Id = "tt3778644", Titulo = "Han Solo: Uma História Star Wars", Ano = 2018, Nota = 7.2M },
                new Filme { Id = "tt7784604", Titulo = "Hereditário", Ano = 2018, Nota = 7.8M },
                new Filme { Id = "tt4881806", Titulo = "Jurassic World: Reino Ameaçado", Ano = 2018, Nota = 6.7M },
                new Filme { Id = "tt5164214", Titulo = "Oito Mulheres e um Segredo", Ano = 2018, Nota = 6.3M },
                new Filme { Id = "tt3606756", Titulo = "Os Incríveis 2", Ano = 2018, Nota = 8.5M },
                new Filme { Id = "tt3501632", Titulo = "Thor: Ragnarok", Ano = 2017, Nota = 7.9M },
                new Filme { Id = "tt4154756", Titulo = "Vingadores: Guerra Infinita", Ano = 2018, Nota = 8.8M }
            };

            return Filmes;
        }

        public List<Filme> ResultFilmesQuartasFinais()
        {
            List<Filme> Filmes = new List<Filme>() {
                new Filme { Id = "tt4154756", Titulo = "Vingadores: Guerra Infinita", Ano = 2018, Nota = 8.8M },
                new Filme { Id = "tt3501632", Titulo = "Thor: Ragnarok", Ano = 2017, Nota = 7.9M },
                new Filme { Id = "tt3606756", Titulo = "Os Incríveis 2", Ano = 2018, Nota = 8.5M },
                new Filme { Id = "tt4881806", Titulo = "Jurassic World: Reino Ameaçado", Ano = 2018, Nota = 6.7M }
            };

            return Filmes;
        }

        public List<Filme> FilmesSemiFinal()
        {
            List<Filme> Filmes = new List<Filme>() {
                new Filme { Id = "tt4154756", Titulo = "Vingadores: Guerra Infinita", Ano = 2018, Nota = 8.8M },
                new Filme { Id = "tt3501632", Titulo = "Thor: Ragnarok", Ano = 2017, Nota = 7.9M },
                new Filme { Id = "tt3606756", Titulo = "Os Incríveis 2", Ano = 2018, Nota = 8.5M },
                new Filme { Id = "tt4881806", Titulo = "Jurassic World: Reino Ameaçado", Ano = 2018, Nota = 6.7M }
            };

            return Filmes;
        }

        public List<Filme> ResultFilmesSemiFinal()
        {
            List<Filme> Filmes = new List<Filme>() {
                new Filme { Id = "tt4154756", Titulo = "Vingadores: Guerra Infinita", Ano = 2018, Nota = 8.8M },
                new Filme { Id = "tt3606756", Titulo = "Os Incríveis 2", Ano = 2018, Nota = 8.5M }
            };

            return Filmes;
        }

        public List<Filme> FilmesFinal()
        {
            List<Filme> Filmes = new List<Filme>() {
                new Filme { Id = "tt4154756", Titulo = "Vingadores: Guerra Infinita", Ano = 2018, Nota = 8.8M },
                new Filme { Id = "tt3606756", Titulo = "Os Incríveis 2", Ano = 2018, Nota = 8.5M }
            };

            return Filmes;
        }

        public List<Filme> ResultFilmesFinal()
        {
            List<Filme> Filmes = new List<Filme>() {
                new Filme { Id = "tt4154756", Titulo = "Vingadores: Guerra Infinita", Ano = 2018, Nota = 8.8M }
            };

            return Filmes;
        }
    }
}
