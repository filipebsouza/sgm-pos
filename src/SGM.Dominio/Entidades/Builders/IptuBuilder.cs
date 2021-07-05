namespace SGM.Dominio.Entidades.Builders
{
    public class IptuBuilder : ImpostoComImovelBuilder
    {
        public static IptuBuilder Novo() => new();

        public Iptu Construir()
        {
            return new(_contribuinte,
                       _anoDeReferencia,
                       _imovel as ImovelUrbano);
        }
    }
}