using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace SGM.Dominio.Entidades
{
    public class Usuario
    {
        public static readonly string MensagemEmailInvalido = "Email inválido";  

        public int Id { get; }
        public string Email { get; }
        private string hashDaSenha = "";
        private string Senha
        {
            set
            {
                hashDaSenha = GerarHashDaSenha(value);
            }
        }
        public IReadOnlyList<PapelDoUsuario> Papeis { get; }

        public Usuario(string email, string senha, params PapelDoUsuario[] papeis)
        {
            ValidaParametros(email, senha, papeis);
            Email = email;
            Senha = senha;
            Papeis = papeis;
        }

        public bool SenhaEhValida(string senha)
        {
            var hashInformado = GerarHashDaSenha(senha);
            return hashDaSenha == hashInformado;
        }

        private void ValidaParametros(string email, string senha, PapelDoUsuario[] papeis)
        {
            throw new NotImplementedException();
        }

        private static string GerarHashDaSenha(string senha)
        {
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            return Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: senha,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8)
            );
        }
    }
}