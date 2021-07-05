using System;

namespace SGM.Dominio.Entidades
{
    public class Iptu : ImpostoSobreImovel
    {
        public const string NOME = "Imposto Territorial Urbano";
        public const string SIGLA = "IPTU";
        public const double ALIQUOTA_BASE = 0.02;

        public override double Aliquota
        {
            get
            {
                var aliquota = ALIQUOTA_BASE;
                var imovelUrbano = Imovel as ImovelUrbano;

                if (imovelUrbano.PossuiAsfalto) aliquota += 0.01;
                if (imovelUrbano.PossuiEsgoto) aliquota += 0.02;

                return aliquota;
            }
        }

        public Iptu(Pessoa contribuinte, int anoDeReferencia, ImovelUrbano imovel)
            : base(NOME, SIGLA, contribuinte, anoDeReferencia, imovel)
        { }
    }
}