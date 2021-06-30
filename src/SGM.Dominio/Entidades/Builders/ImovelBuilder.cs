namespace SGM.Dominio.Entidades.Builders
{
    public class ImovelBuilder
    {
        protected string _logradouro;
        protected int _numero;
        protected string _bairro;
        protected int _areaTotal;

        public static ImovelBuilder Novo() => new();

        public T ComLogradouro<T>(string logradouro) where T : ImovelBuilder
        {
            _logradouro = logradouro;
            return this as T;
        }

        public T ComNumero<T>(int numero) where T : ImovelBuilder
        {
            _numero = numero;
            return this as T;
        }

        public T ComBairro<T>(string bairro) where T : ImovelBuilder
        {
            _bairro = bairro;
            return this as T;
        }

        public T ComAreaTotal<T>(int areaTotal) where T : ImovelBuilder
        {
            _areaTotal = areaTotal;
            return this as T;
        }
    }
}