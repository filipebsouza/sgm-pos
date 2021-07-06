namespace SGM.Dominio.Entidades.Builders
{
    public class ImovelUrbanoBuilder : ImovelBuilder
    {
        private int _areaConstruida;
        private bool _possuiAsfalto;
        private bool _possuiEsgoto;

        new public static ImovelUrbanoBuilder Novo() => new();

        public ImovelUrbanoBuilder ComAreaConstruida(int areaConstruida)
        {
            _areaConstruida = areaConstruida;
            return this;
        }

        public ImovelUrbanoBuilder PossuiAsfalto(bool possuiAsfalto)
        {
            _possuiAsfalto = possuiAsfalto;
            return this;
        }

        public ImovelUrbanoBuilder PossuiEsgoto(bool possuiEsgoto)
        {
            _possuiEsgoto = possuiEsgoto;
            return this;
        }

        public ImovelUrbano Construir()
        {
             ImovelUrbano imovelUrbano = new (_logradouro,
                       _numero,
                       _bairro,
                       _areaTotal,
                       _areaConstruida,
                       _possuiAsfalto,
                       _possuiEsgoto);

            if (_valorVenal > 0)
                imovelUrbano.AdicionarValorVenal(_valorVenal);

            return imovelUrbano;
        }
    }
}