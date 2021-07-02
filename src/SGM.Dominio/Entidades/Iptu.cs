using System;

namespace SGM.Dominio.Entidades
{
    public class Iptu : Imposto
    {
        public const string MensagemImovelInvalido = "Imóvel inválido";
        public const string MensagemImovelNaoAvaliado = "Imóvel ainda não foi avaliado";
        public const string NOME = "Imposto Territorial Urbano";
        public const string SIGLA = "IPTU";
        public const double ALIQUOTA_BASE = 0.02;

        public ImovelUrbano Imovel { get; }
        public override double BaseDeCalculo => Imovel.ValorVenal;
        public override double Aliquota
        {
            get
            {
                var aliquota = ALIQUOTA_BASE;

                if (Imovel.PossuiAsfalto) aliquota += 0.01;
                if (Imovel.PossuiEsgoto) aliquota += 0.02;

                return aliquota;
            }
        }

        public Iptu(Pessoa contribuinte, int anoReferencia, ImovelUrbano imovel) : base(NOME, SIGLA, contribuinte, anoReferencia)
        {
            ValidarParametros(imovel);
            
            Imovel = imovel;
        }

        private static void ValidarParametros(ImovelUrbano imovel)
        {
            if (imovel is null) throw new ArgumentException(MensagemImovelInvalido);

            if (!imovel.PossuiAvaliacao) throw new ArgumentException(MensagemImovelNaoAvaliado);
        }
    }
}