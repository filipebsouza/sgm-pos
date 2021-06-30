namespace SGM.Dominio.Entidades.Builders
{
    public class IptuBuilder : ImpostoBuilder
    {
        private ImovelUrbano _imovelUrbano;

        new public static IptuBuilder Novo() => new();

        public IptuBuilder ComImovelUrbano(ImovelUrbano imovelUrbano)
        {
            _imovelUrbano = imovelUrbano;
            return this;
        }

        public Iptu Construir()
        {
            return new(_contribuinte,
                       _anoDeReferencia,
                       _imovelUrbano);
        }
    }
}