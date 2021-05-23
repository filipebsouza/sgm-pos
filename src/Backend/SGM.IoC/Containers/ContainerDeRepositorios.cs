using Microsoft.Extensions.DependencyInjection;
using SGM.Infra;

namespace SGM.IoC.Containers
{
    internal static class ContainerDeRepositorios
    {
        internal static IServiceCollection RegistrarDependenciasDeRepositorios(this IServiceCollection services)
        {
            services.AddTransient<RepositorioDeUsuarios>();

            return services;
        }
    }
}