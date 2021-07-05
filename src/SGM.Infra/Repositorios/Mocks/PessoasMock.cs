using System.Collections.Generic;
using System.Linq;
using SGM.Dominio.Entidades;
using SGM.Dominio.Entidades.Builders;

namespace SGM.Infra.Repositorios.Mocks
{
    public static class PessoasMock
    {
        static PessoasMock()
        {
            Mock = new List<Pessoa>
            {
                PessoaFisicaBuilder.Novo()
                                    .ComId(1)
                                    .ComNome<PessoaFisicaBuilder>("João Ernesto Villalba")
                                    .ComCpf("27509579074")
                                    .Construir()
            };
        }

        public static Pessoa ObterJoaoErnesto
            => Mock.FirstOrDefault(pessoa =>
                pessoa is PessoaFisica pessoaFisica &&
                pessoaFisica.Cpf.Valor == "27509579074"
            );

        public static IReadOnlyList<Pessoa> Mock { get; }
    }
}