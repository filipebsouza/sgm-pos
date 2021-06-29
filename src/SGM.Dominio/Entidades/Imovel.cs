using System;

namespace SGM.Dominio.Entidades
{
    public abstract class Imovel
    {
        public const string MensagemLogradouroInvalido = "Logradouro inválido";
        public const string MensagemNumeroInvalido = "Número inválido";
        public const string MensagemBairroInvalido = "Bairro inválido";

        public string Logradouro { get; }
        public int Numero { get; }
        public string Bairro { get; }

        protected Imovel(string logradouro, int numero, string bairro)
        {
            ValidarParametros(logradouro, numero, bairro);

            Logradouro = logradouro;
            Numero = numero;
            Bairro = bairro;
        }

        private static void ValidarParametros(string logradouro, int numero, string bairro)
        {
            if (string.IsNullOrWhiteSpace(logradouro)) throw new ArgumentException(MensagemLogradouroInvalido);

            if (numero <= 0) throw new ArgumentException(MensagemNumeroInvalido);

            if (string.IsNullOrWhiteSpace(bairro)) throw new ArgumentException(MensagemBairroInvalido);
        }
    }
}