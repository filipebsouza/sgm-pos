using SGM.Dominio.ObjetosDeValor;
using SGM.Utils.ObjectExtensions;

namespace SGM.Dominio.Entidades.Builders
{
    public class PessoaFisicaBuilder : PessoaBuilder
    {
        private int _id;
        private Cpf _cpf;

        new public static PessoaFisicaBuilder Novo() => new();

        public PessoaFisicaBuilder ComId(int id)
        {
            _id = id;
            return this;
        }

        public PessoaFisicaBuilder ComCpf(string valor)
        {
            _cpf = new Cpf(valor);
            return this;
        }

        public PessoaFisica Construir()
        {
            PessoaFisica pessoaFisica = new(_nome, _cpf);

            if (_id > 0)
                pessoaFisica.Set(() => pessoaFisica.Id, _id);

            return pessoaFisica;
        }
    }
}