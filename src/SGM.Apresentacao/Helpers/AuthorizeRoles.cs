using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using SGM.Dominio.Entidades;

namespace SGM.Apresentacao.Helpers
{
    public class AuthorizeRolesAttribute : AuthorizeAttribute
    {
        public AuthorizeRolesAttribute(params PapelDoUsuario[] papeis) : base()
        {
            var papeisComoStrings = papeis.Select(papel => papel.ToString().ToLower());
            Roles = string.Join(",", papeisComoStrings);
        }
    }
}