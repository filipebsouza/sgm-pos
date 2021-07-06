namespace SGM.Dominio.Entidades.Builders
{
    public class ImovelRuralBuilder : ImovelBuilder
    {
        private int _areaUtilTotal;
        private int _areaDePreservacaoAmbiental;
        private bool _manejoDeAgriculturaFamiliar;

        new public static ImovelRuralBuilder Novo() => new();

        public ImovelRuralBuilder ComAreaUtilTotal(int areaUtilTotal)
        {
            _areaUtilTotal = areaUtilTotal;
            return this;
        }

        public ImovelRuralBuilder ComAreaDePreservacaoAmbiental(int areaDePreservacaoAmbiental)
        {
            _areaDePreservacaoAmbiental = areaDePreservacaoAmbiental;
            return this;
        }

        public ImovelRuralBuilder PossuiManejoDeAgriculturaFamiliar(bool manejoDeAgriculturaFamiliar)
        {
            _manejoDeAgriculturaFamiliar = manejoDeAgriculturaFamiliar;
            return this;
        }

        public ImovelRural Construir()
        {
            ImovelRural imovelRural = new(_logradouro,
                       _numero,
                       _bairro,
                       _areaTotal,
                       _areaUtilTotal,
                       _areaDePreservacaoAmbiental,
                       _manejoDeAgriculturaFamiliar);

            if (_valorVenal > 0)
                imovelRural.AdicionarValorVenal(_valorVenal);

            return imovelRural;
        }
    }
}