using System;

namespace SGM.Dominio.Entidades
{
    public abstract class Pessoa
    {
        public const string MensagemNomeInvalido = "Nome inválido";
        public const string MensagemNomeExtrapolaTamanho = "Nome deve ter no máximo 200 caracteres";

        public int Id { get; protected set; }
        public string Nome { get; }

        protected Pessoa(string nome)
        {
            ValidaParametros(nome);
            Nome = nome;
        }

        private static void ValidaParametros(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome)) throw new ArgumentException(MensagemNomeInvalido);

            if (nome.Length > 200) throw new ArgumentException(MensagemNomeExtrapolaTamanho);
        }
    }
}