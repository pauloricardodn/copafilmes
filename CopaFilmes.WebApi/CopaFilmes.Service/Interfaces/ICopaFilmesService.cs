using CopaFilmes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CopaFilmes.Service.Interfaces
{
    public interface ICopaFilmesService
    {
        List<Filme> Copa(List<Filme> listfilmes);
    }
}
