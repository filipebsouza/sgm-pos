using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using SGM.Infra.Segurancas;

namespace SGM.IoC.Containers
{
    internal static class ContainerDeDependenciasDaWeb
    {
        internal static IServiceCollection RegistrarDependenciasDaWeb(this IServiceCollection services)
        {
            services.AddCors();
            services.AddControllers();
            services.AddAuthentication(configuration =>
            {
                configuration.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                configuration.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(configuration =>
            {
                configuration.RequireHttpsMetadata = false;
                configuration.SaveToken = true;
                configuration.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.ASCII.GetBytes(ServicoDeToken.Segredo)
                    ),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            return services;
        }
    }
}