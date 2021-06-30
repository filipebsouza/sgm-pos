using SGM.Dominio.ObjetosDeValor;

namespace SGM.Dominio.Entidades.Builders
{
    public class PessoaFisicaBuilder : PessoaBuilder
    {
        private Cpf _cpf;

        new public static PessoaFisicaBuilder Novo() => new();

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