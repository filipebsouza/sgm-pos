using Microsoft.AspNetCore.Mvc;
using SGM.Apresentacao.Helpers;
using SGM.Dominio.Entidades;
using SGM.Dominio.Repositorios;

namespace SGM.Apresentacao.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IptusController : ControllerBase
    {
        private readonly IRepositorioDeIptus _repositorioDeIptus;

        public IptusController(IRepositorioDeIptus repositorioDeIptus)
        {
            _repositorioDeIptus = repositorioDeIptus;
        }

        [HttpGet]
        [Route("")]
        [AuthorizeRoles(PapelDoUsuario.Contribuinte, PapelDoUsuario.Servidor)]
        public ActionResult Get()
        {

            //_repositorioDeIptus.ObterPor()
            return null;
        }
    }
}
