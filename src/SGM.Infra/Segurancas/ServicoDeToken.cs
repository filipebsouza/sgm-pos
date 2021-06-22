using SGM.Dominio.Entidades;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;

namespace SGM.Infra.Segurancas
{
    public static class ServicoDeToken
    {
        public const string Segredo = "fedaf7d8863b48e197b9287d492b708e";
        public const string EmissorDoToken = "ServicoDeToken.SGM";
        public const string AudienciaDoToken = "EveryApplication";
        public static string GerarToken(Usuario usuario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var chave = Encoding.ASCII.GetBytes(Segredo);
            List<Claim> claims = ObterClaims(usuario);

            var descricaoDoToken = new SecurityTokenDescriptor
            {
                Issuer = EmissorDoToken,
                Audience = AudienciaDoToken,
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(chave), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(descricaoDoToken);
            return tokenHandler.WriteToken(token);
        }

        private static List<Claim> ObterClaims(Usuario usuario)
        {
            var claims = new List<Claim> { new Claim(ClaimTypes.Name, usuario.Email.ToString()) };
            foreach (var papel in usuario.Papeis)
            {
                claims.Add(new Claim(ClaimTypes.Role, papel.ToString().ToLower()));
            }

            return claims;
        }
    }
}