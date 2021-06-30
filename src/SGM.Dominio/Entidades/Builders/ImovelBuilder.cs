namespace SGM.Dominio.Entidades.Builders
{
    public class ImovelBuilder
    {
        protected string _logradouro;
        protected int _numero;
        protected string _bairro;
        protected int _areaTotal;

        public static ImovelBuilder Novo() => new();

        public ImovelBuilder ComLogradouro(string logradouro)
        {
            _logradouro = logradouro;
            return this;
        }

        public ImovelBuilder ComNumero(int numero)
        {
            _numero = numero;
            return this;
        }

        public ImovelBuilder ComBairro(string bairro)
        {
            _bairro = bairro;
            return this;
        }

        public ImovelBuilder ComAreaTotal(int areaTotal)
        {
            _areaTotal = areaTotal;
            return this;
        }
    }
}