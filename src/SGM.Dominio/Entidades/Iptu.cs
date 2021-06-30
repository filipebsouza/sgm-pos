using System;

namespace SGM.Dominio.Entidades
{
    public class Iptu : Imposto
    {
        public const string MensagemImovelInvalido = "Imóvel inválido";

        public ImovelUrbano Imovel { get; }

        public Iptu(string nome, string sigla, Pessoa contribuinte, int anoReferencia, ImovelUrbano imovel) : base(nome, sigla, contribuinte, anoReferencia)
        {
            ValidarParametros(imovel);

            Imovel = imovel;
        }

        private static void ValidarParametros(Imovel imovel)
        {
            if (imovel is null) throw new ArgumentException(MensagemImovelInvalido);
        }
    }
}