using CopaFilmes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CopaFilmes.Test
{
    public class CopaFimesParticipante
    {
        public CopaFimesParticipanteFake()
        {
            new List<Filme> = new List<Filme>()
            {
                new Filme()
                {
                    Id ="tt5463162",
                    Titulo = "Deadpool 2",
                    Ano = 2018,
                    Nota = 8.1M
                },
                new Filme()
                {
                    Id ="tt4881806",
                    Titulo = "Jurassic World: Reino Ameaçado",
                    Ano = 2018,
                    Nota = 6.7M
                },
                new Filme()
                {
                    Id ="tt4881806",
                    Titulo = "Jurassic World: Reino Ameaçado",
                    Ano = 2018,
                    Nota = 6.7M
                }
            };
        }
    }
}
