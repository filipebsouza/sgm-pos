using Microsoft.AspNetCore.Mvc;
using SGM.Dominio.Entidades;

namespace SGM.Apresentacao.Helpers
{
    public static class ControllerBaseExtensions
    {
        public static Usuario ObterUsuarioLogado(this ControllerBase controller)
        {
            return controller.HttpContext.Items["User"] as Usuario;
        }
    }
}