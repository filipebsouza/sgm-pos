using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using SGM.Utils.IntExtensions;

namespace SGM.Dominio.Entidades
{
    public class Usuario
    {
        public static readonly string MensagemEmailInvalido = "Email inválido";
        public static readonly string MensagemSenhaInvalida = "Senha inválida";
        public static readonly string MensagemSenhaDeveTerEntre6E8Caracteres = "Senha deve ter entre 6 e 8 caracteres";
        public static readonly string MensagemPapelInvalido = "Papel de permissão inválido";

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

        private static void ValidaParametros(string email, string senha, PapelDoUsuario[] papeis)
        {
            if (string.IsNullOrWhiteSpace(email)) throw new ArgumentException(MensagemEmailInvalido);

            if (string.IsNullOrWhiteSpace(senha)) throw new ArgumentException(MensagemSenhaInvalida);

            if (senha?.Length.Between(6, 8) is not true) throw new ArgumentException(MensagemSenhaDeveTerEntre6E8Caracteres);

            if (papeis?.Length <= 0) throw new ArgumentException(MensagemPapelInvalido);
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