using System;

namespace SGM.Dominio.Entidades
{
    public class ImovelRural : Imovel
    {
        public const string MensagemAreaUtilTotalInvalida = "Área útil total inválida";
        public const string MensagemAreaDePreservacaoAmbientalInvalida = "Área de preservação ambiental inválida";

        public int AreaUtilTotal { get; }
        public int AreaDePreservacaoAmbiental { get; }
        public bool ManejoDeAgriculturaFamiliar { get; }

        public ImovelRural(string logradouro,
                           int numero,
                           string bairro,
                           int areaTotal,
                           int areaUtilTotal,
                           int areaDePreservacaoAmbiental,
                           bool manejoDeAgriculturaFamiliar)
        : base(logradouro, numero, bairro, areaTotal)
        {
            ValidarParametros(areaUtilTotal, areaDePreservacaoAmbiental);

            AreaUtilTotal = areaUtilTotal;
            AreaDePreservacaoAmbiental = areaDePreservacaoAmbiental;
            ManejoDeAgriculturaFamiliar = manejoDeAgriculturaFamiliar;
        }

        private static void ValidarParametros(int areaUtilTotal, int areaDePreservacaoAmbiental)
        {
            if (areaUtilTotal < 0) throw new ArgumentException(MensagemAreaUtilTotalInvalida);

            if (areaDePreservacaoAmbiental < 0) throw new ArgumentException(MensagemAreaDePreservacaoAmbientalInvalida);
        }
    }
}