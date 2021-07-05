namespace SGM.Dominio.Entidades.Builders
{
    public class ImpostoComImovelBuilder : ImpostoBuilder
    {
        protected Imovel _imovel;

        public T ComImovel<T>(Imovel imovel) where T : ImpostoComImovelBuilder
        {
            _imovel = imovel;
            return this as T;
        }
    }
}