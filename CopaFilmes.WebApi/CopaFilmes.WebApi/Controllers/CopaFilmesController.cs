using CopaFilmes.Service.Interfaces;
using CopaFilmes.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CopaFilmes.WebApi.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class CopaFilmesController : ControllerBase
    {
        private readonly ICopaFilmesService _copaFilmesService;

        public CopaFilmesController(ICopaFilmesService copaFilmesService) => _copaFilmesService = copaFilmesService;

        
        /// <summary>
        /// Realizar a copa e retornar a lista com campeão e vice campeão em ordem
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<IEnumerable<Filme>> Post([FromBody] List<Filme> filmes)
        {
            List<Filme> Result =  _copaFilmesService.Copa(filmes);
            
            return Ok(Result);
        }
    }
}