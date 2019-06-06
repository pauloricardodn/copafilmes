using Microsoft.Extensions.DependencyInjection;
using CopaFilmes.Service.Services;
using CopaFilmes.Service.Interfaces;

namespace CopaFilmes.WebApi
{
    public static class InjectionDependency
    {
        /// <summary>
        /// Adiciona a injeção de dependência entre as Services e suas interfaces.
        /// </summary>
        /// <param name="services"></param>
        public static void InjecaoDependenciaRepositorios(ref IServiceCollection services)
        {
            services.AddScoped<ICopaFilmesService, CopaFilmesService>();
        }
    }
}
