using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using SGM.Dominio.Entidades;

namespace SGM.WebApi.Helpers
{
    public class AuthorizeRolesAttribute : AuthorizeAttribute
    {
        public AuthorizeRolesAttribute(params PapelDoUsuario[] papeis)
        {
            var papeisComoStrings = papeis.Select(papel => Enum.GetName(typeof(PapelDoUsuario), papel));
            Roles = string.Join(",", papeisComoStrings);
        }
    }
}