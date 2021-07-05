namespace SGM.Dominio.Entidades.Builders
{
    public class ItrBuilder : ImpostoComImovelBuilder
    {
        public static ItrBuilder Novo() => new();

        public Itr Construir() => new(_contribuinte,
            _anoDeReferencia,
            _imovel as ImovelRural);
    }
}