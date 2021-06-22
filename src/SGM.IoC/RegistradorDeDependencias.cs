using Microsoft.Extensions.DependencyInjection;
using SGM.IoC.Containers;

namespace SGM.IoC
{
    public static class RegistradorDeDependencias
    {
        public static IServiceCollection RegistrarDependencias(this IServiceCollection services)
        {
            services.RegistrarDependenciasDeRepositorios();
            services.RegistrarDependenciasDaWeb();

            return services;
        }
    }
}