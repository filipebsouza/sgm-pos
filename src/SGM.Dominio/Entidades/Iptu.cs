using System;

namespace SGM.Dominio.Entidades
{
    public class Iptu : Imposto
    {
        public const string MensagemImovelInvalido = "Imóvel inválido";
        public const string NOME = "Imposto Territorial Urbano";
        public const string SIGLA = "IPTU";

        public ImovelUrbano Imovel { get; }

        public Iptu(Pessoa contribuinte, int anoReferencia, ImovelUrbano imovel) : base(NOME, SIGLA, contribuinte, anoReferencia)
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