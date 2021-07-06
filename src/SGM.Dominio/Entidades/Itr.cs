namespace SGM.Dominio.Entidades
{
    public class Itr : ImpostoSobreImovel
    {
        public const string NOME = "Imposto Territorial Rural";
        public const string SIGLA = "ITR";
        public const double ALIQUOTA_BASE = 0.015;
        public bool AreaDePreservacaoEhMaisDeCinquentaPorcentoDaPropriedade
        {
            get
            {
                if (Imovel is ImovelRural imovelRural)
                    return imovelRural.AreaDePreservacaoAmbiental >= (imovelRural.AreaTotal / 2);

                return false;
            }
        }
        public override double Aliquota
        {
            get
            {
                var aliquota = ALIQUOTA_BASE;
                var imovelRural = Imovel as ImovelRural;

                if (HaIncidenciaDeAliquotaZero)
                {
                    aliquota = 0;
                }
                else
                {
                    if (imovelRural.AreaUtilTotal > 20) aliquota += 0.001;
                    if (imovelRural.AreaUtilTotal > 40) aliquota += 0.003;
                    if (imovelRural.AreaUtilTotal > 60) aliquota += 0.01;
                }

                return aliquota;
            }
        }

        public bool HaIncidenciaDeAliquotaZero =>
            AreaDePreservacaoEhMaisDeCinquentaPorcentoDaPropriedade || (Imovel as ImovelRural)?.ManejoDeAgriculturaFamiliar == true;

        public Itr(Pessoa contribuinte, int anoDeReferencia, ImovelRural imovel)
            : base(NOME, SIGLA, contribuinte, anoDeReferencia, imovel)
        { }
    }
}