using SGM.Dominio.ObjetosDeValor;

namespace SGM.Dominio.Entidades.Builders
{
    public class PessoaFisicaBuilder
    {
        private string _nome;
        private Cpf _cpf;

        public static PessoaFisicaBuilder Novo() => new();

        public PessoaFisicaBuilder ComNome(string nome)
        {
            _nome = nome;
            return this;
        }

        public PessoaFisicaBuilder ComCpf(string valor)
        {
            _cpf = new Cpf(valor);
            return this;
        }

        public PessoaFisica Construir()
        {
            return new(_nome, _cpf);
        }
    }
}