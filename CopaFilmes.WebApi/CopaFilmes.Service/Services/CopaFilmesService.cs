using CopaFilmes.Domain.Entities;
using CopaFilmes.Service.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace CopaFilmes.Service.Services
{
    public class CopaFilmesService : ICopaFilmesService
    {
        /// <summary>
        /// Realizar a copa e retornar a lista com campeão e vice campeão em ordem
        /// </summary>
        /// <returns></returns>
        public List<Filme> Copa(List<Filme> listfilmes)
        {
            List<Filme> Resultado = new List<Filme>();

            var FilmesQuartasDeFinais = Rodada(listfilmes);

            var FilmesSemiFinai = Rodada(FilmesQuartasDeFinais);

            var FilmeFinal = Rodada(FilmesSemiFinai);

            Resultado.Add(FilmeFinal.First());

            foreach (var filme in FilmesSemiFinai)
            {
                if(!FilmeFinal.Contains(filme))
                    Resultado.Add(filme);
            }            

            return Resultado;
        }

        /// <summary>
        /// Realizar Rodada da Copa
        /// </summary>
        /// <param name="filmes"></param>
        /// <returns></returns>
        public List<Filme> Rodada(List<Filme> filmes)
        {
            int Participantes = filmes.Count();
            List<Filme> FilmesRodada = new List<Filme>();
            int Cont = 0;
            for (int i = 0; i < Participantes; i +=2)
            {
                FilmesRodada.Add(Partida(filmes[Cont], filmes[(Participantes - 1) - Cont]));
                Cont++;
            }

            return FilmesRodada;
        }

        /// <summary>
        /// Realizar partida
        /// </summary>
        /// <param name="filmeA"></param>
        /// <param name="filmeB"></param>
        /// <returns></returns>
        private Filme Partida(Filme filmeA, Filme filmeB)
        {
            if (filmeA.Nota > filmeB.Nota)
                return filmeA;
            else if (filmeA.Nota < filmeB.Nota)
                return filmeB;
            else
            {
                if (filmeA.Titulo.CompareTo(filmeB.Titulo) > 0)
                    return filmeB;
                else
                    return filmeA;
            }
        }        
    }   
}

