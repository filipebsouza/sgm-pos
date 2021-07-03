using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SGM.Infra.Segurancas;
using SGM.Apresentacao.Dtos;
using SGM.Dominio.Repositorios;

namespace SGM.Apresentacao.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuariosController : ControllerBase
    {
        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Login(
            [FromServices] IRepositorioDeUsuarios repositorio,
            [FromBody] UsuarioHttpDto dto
        )
        {
            var usuario = repositorio.ObterPor(dto.Email, dto.Senha);

            if (usuario == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            var token = ServicoDeToken.GerarToken(usuario);

            return new
            {
                Usuario = new
                {
                    Id = usuario.Id,
                    Email = usuario.Email,
                    Papeis = usuario.Papeis
                },
                Token = token
            };
        }
    }
}