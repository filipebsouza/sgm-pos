namespace SGM.Dominio.Entidades.Builders
{
    public class ImpostoBuilder
    {
        protected string _nome;
        protected string _sigla;
        protected Pessoa _contribuinte;
        protected int _anoDeReferencia;

        public static ImpostoBuilder Novo() => new();

        public T ComNome<T>(string nome) where T : ImpostoBuilder
        {
            _nome = nome;
            return this as T;
        }

        public T ComSigla<T>(string sigla) where T : ImpostoBuilder
        {
            _sigla = sigla;
            return this as T;
        }

        public T ComContribuinte<T>(Pessoa contribuinte) where T : ImpostoBuilder
        {
            _contribuinte = contribuinte;
            return this as T;
        }

        public T ComAnoDeReferencia<T>(int anoDeReferencia) where T : ImpostoBuilder
        {
            _anoDeReferencia = anoDeReferencia;
            return this as T;
        }
    }
}