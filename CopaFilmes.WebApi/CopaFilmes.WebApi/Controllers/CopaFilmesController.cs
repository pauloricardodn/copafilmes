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
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<IEnumerable<Filme>>> PostCopa([FromBody] List<Filme> filmes)
        {
            
            return Ok();
        }
    }
}