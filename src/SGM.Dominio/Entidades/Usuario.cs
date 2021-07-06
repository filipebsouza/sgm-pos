using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using SGM.Utils.IntExtensions;

namespace SGM.Dominio.Entidades
{
    public class Usuario
    {
        public const string MensagemNomeInvalido = "Nome inválido";
        public const string MensagemEmailInvalido = "Email inválido";
        public const string MensagemSenhaInvalida = "Senha inválida";
        public const string MensagemSenhaDeveTerEntre6E8Caracteres = "Senha deve ter entre 6 e 8 caracteres";
        public const string MensagemPapelInvalido = "Papel de permissão inválido";
        public const string MensagemPessoaInvalida = "Pessoa inválida";

        public int Id { get; private set; }
        public string Nome { get; }
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
        public Pessoa Pessoa { get; }

        public Usuario(string nome, string email, string senha, params PapelDoUsuario[] papeis)
        {
            ValidarParametros(nome, email, senha, papeis);
            Nome = nome;
            Email = email;
            Senha = senha;
            Papeis = papeis;
        }

        public Usuario(string nome, string email, string senha, Pessoa pessoa, params PapelDoUsuario[] papeis) : this(nome, email, senha, papeis)
        {
            ValidarPessoa(pessoa);
            Pessoa = pessoa;
        }

        public bool SenhaEhValida(string senha)
        {
            ReadOnlySpan<byte> buffer4;
            byte[] src = Convert.FromBase64String(hashDaSenha);
            if ((src.Length != 0x31) || (src[0] != 0))
            {
                return false;
            }
            byte[] dst = new byte[0x10];
            Buffer.BlockCopy(src, 1, dst, 0, 0x10);
            byte[] buffer3 = new byte[0x20];
            Buffer.BlockCopy(src, 0x11, buffer3, 0, 0x20);
            using (Rfc2898DeriveBytes bytes = new(senha, dst, 0x3e8))
            {
                buffer4 = bytes.GetBytes(0x20).AsSpan();
            }
            return buffer3.AsSpan().SequenceEqual(buffer4);
        }

        private static void ValidarParametros(string nome, string email, string senha, PapelDoUsuario[] papeis)
        {
            if (string.IsNullOrWhiteSpace(nome)) throw new ArgumentException(MensagemNomeInvalido);

            if (string.IsNullOrWhiteSpace(email)) throw new ArgumentException(MensagemEmailInvalido);

            if (string.IsNullOrWhiteSpace(senha)) throw new ArgumentException(MensagemSenhaInvalida);

            if (senha?.Length.Between(6, 8) is not true) throw new ArgumentException(MensagemSenhaDeveTerEntre6E8Caracteres);

            if (papeis is { Length: <= 0 }) throw new ArgumentException(MensagemPapelInvalido);
        }

        private static void ValidarPessoa(Pessoa pessoa)
        {
            if (pessoa is null) throw new ArgumentException(MensagemPessoaInvalida);
        }

        private static string GerarHashDaSenha(string senha)
        {
            byte[] salt;
            byte[] buffer2;
            using (Rfc2898DeriveBytes bytes = new(senha, 0x10, 0x3e8))
            {
                salt = bytes.Salt;
                buffer2 = bytes.GetBytes(0x20);
            }
            byte[] dst = new byte[0x31];
            Buffer.BlockCopy(salt, 0, dst, 1, 0x10);
            Buffer.BlockCopy(buffer2, 0, dst, 0x11, 0x20);
            return Convert.ToBase64String(dst);
        }
    }
}