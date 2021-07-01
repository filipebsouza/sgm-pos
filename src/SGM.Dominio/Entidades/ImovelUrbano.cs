using System;

namespace SGM.Dominio.Entidades
{
    public class ImovelUrbano : Imovel
    {
        public const string MensagemAreaConstruidaInvalida = "Área construída inválida";
        public const string MensagemValorVenalInvalido = "Valor venal inválido";

        public int AreaConstruida { get; }
        public bool PossuiAsfalto { get; }
        public bool PossuiEsgoto { get; }
        public double ValorVenal { get; private set; }
        public bool PossuiAvaliacao => ValorVenal > 0;

        public ImovelUrbano(string logradouro,
                            int numero,
                            string bairro,
                            int areaTotal,
                            int areaContruida,
                            bool possuiAsfalto,
                            bool possuiEsgoto)
            : base(logradouro, numero, bairro, areaTotal)
        {
            ValidarParametros(areaContruida);

            AreaConstruida = areaContruida;
            PossuiAsfalto = possuiAsfalto;
            PossuiEsgoto = possuiEsgoto;
        }

        private static void ValidarParametros(int areaContruida)
        {
            if (areaContruida <= 0) throw new ArgumentException(MensagemAreaConstruidaInvalida);
        }

        public void AdicionarValorVenal(double valorVenal)
        {
            if (valorVenal <= 0) throw new ArgumentException(MensagemValorVenalInvalido);

            ValorVenal = valorVenal;
        }        
    }
}