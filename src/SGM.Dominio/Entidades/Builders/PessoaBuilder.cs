namespace SGM.Dominio.Entidades.Builders
{
    public class PessoaBuilder
    {
        protected string _nome;

        public static PessoaBuilder Novo() => new();

        public T ComNome<T>(string nome) where T : PessoaBuilder
        {
            _nome = nome;
            return this as T;
        }
    }
}