using Microsoft.Extensions.DependencyInjection;
using SGM.Dominio.Repositorios;
using SGM.Infra.Repositorios;

namespace SGM.IoC.Containers
{
    internal static class ContainerDeRepositorios
    {
        internal static IServiceCollection RegistrarDependenciasDeRepositorios(this IServiceCollection services)
        {
            services.AddTransient<IRepositorioDeUsuarios, RepositorioDeUsuarios>();
            services.AddTransient<IRepositorioDeIptus, RepositorioDeIptus>();

            return services;
        }
    }
}