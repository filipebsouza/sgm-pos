using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.IdentityModel.Tokens;
using SGM.Dominio.Repositorios;
using SGM.Infra.Segurancas;

namespace SGM.Apresentacao.Middlewares
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IRepositorioDeUsuarios _repositorioDeUsuarios;

        public JwtMiddleware(RequestDelegate next, IRepositorioDeUsuarios repositorioDeUsuarios)
        {
            _next = next;
            _repositorioDeUsuarios = repositorioDeUsuarios;
        }

        public async Task Invoke(HttpContext context)
        {
            var endpoint = context.Features.Get<IEndpointFeature>()?.Endpoint;
            if (endpoint == null)
            {
                await _next(context);
                return;
            }

            var ehAnonimo = endpoint?.Metadata.GetMetadata<AllowAnonymousAttribute>();
            if (ehAnonimo != null)
            {
                await _next(context);
                return;
            }

            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            if (token == null)
            {
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                await context.Response.WriteAsync("Acesso não autorizado");
                return;
            }

            AdicionarUsuarioAoContexto(context, token);
            await _next(context);
        }

        private void AdicionarUsuarioAoContexto(HttpContext context, string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(ServicoDeToken.Segredo);
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = System.TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var email = jwtToken.Claims.FirstOrDefault(x => x.Type == "unique_name").Value;

                context.Items["User"] = _repositorioDeUsuarios.ObterPor(email);
            }
            catch
            {
                // do nothing if jwt validation fails
                // user is not attached to context so request won't have access to secure routes
            }
        }
    }
}