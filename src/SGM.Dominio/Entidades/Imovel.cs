using System;

namespace SGM.Dominio.Entidades
{
    public abstract class Imovel
    {
        public const string MensagemLogradouroInvalido = "Logradouro inválido";
        public const string MensagemNumeroInvalido = "Número inválido";
        public const string MensagemBairroInvalido = "Bairro inválido";
        public const string MensagemAreaTotalInvalida = "Área total inválida";
        public const string MensagemValorVenalInvalido = "Valor venal inválido";

        public string Logradouro { get; }
        public int Numero { get; }
        public string Bairro { get; }
        public int AreaTotal { get; }
        public double ValorVenal { get; private set; }
        public bool PossuiAvaliacao => ValorVenal > 0;

        protected Imovel(string logradouro, int numero, string bairro, int areaTotal)
        {
            ValidarParametros(logradouro, numero, bairro, areaTotal);

            Logradouro = logradouro;
            Numero = numero;
            Bairro = bairro;
            AreaTotal = areaTotal;
        }

        private static void ValidarParametros(string logradouro, int numero, string bairro, int areaTotal)
        {
            if (string.IsNullOrWhiteSpace(logradouro)) throw new ArgumentException(MensagemLogradouroInvalido);

            if (numero <= 0) throw new ArgumentException(MensagemNumeroInvalido);

            if (string.IsNullOrWhiteSpace(bairro)) throw new ArgumentException(MensagemBairroInvalido);

            if (areaTotal <= 0) throw new ArgumentException(MensagemAreaTotalInvalida);
        }

        public void AdicionarValorVenal(double valorVenal)
        {
            if (valorVenal <= 0) throw new ArgumentException(MensagemValorVenalInvalido);

            ValorVenal = valorVenal;
        }
    }
}