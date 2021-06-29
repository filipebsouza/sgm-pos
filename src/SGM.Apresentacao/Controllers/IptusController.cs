using Microsoft.AspNetCore.Mvc;
using SGM.Apresentacao.Helpers;
using SGM.Dominio.Entidades;

namespace SGM.Apresentacao.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IptusController : ControllerBase
    {
        public IptusController()
        {
            
        }

        [HttpGet]
        [Route("")]
        [AuthorizeRoles(PapelDoUsuario.Contribuinte, PapelDoUsuario.Servidor)]
        public ActionResult Get()
        {
            
            return null;
        }
    }
}
