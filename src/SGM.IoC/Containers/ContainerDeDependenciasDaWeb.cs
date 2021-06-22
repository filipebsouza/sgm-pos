using System;
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
            services.AddAuthorization();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(configuration =>
            {
                // configuration.RequireHttpsMetadata = false;
                // configuration.SaveToken = true;
                configuration.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = ServicoDeToken.EmissorDoToken,
                    ValidateAudience = true,
                    ValidAudience = ServicoDeToken.AudienciaDoToken,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.ASCII.GetBytes(ServicoDeToken.Segredo)
                    ),
                    RequireExpirationTime = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });

            return services;
        }
    }
}