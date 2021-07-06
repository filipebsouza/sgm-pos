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
                                    .Construir(),
                 PessoaFisicaBuilder.Novo()
                                    .ComId(2)
                                    .ComNome<PessoaFisicaBuilder>("Augusta Guilhermina Judite")
                                    .ComCpf("31571995013")
                                    .Construir()
            };
        }

        public static Pessoa ObterJoaoErnesto
            => Mock.FirstOrDefault(pessoa =>
                pessoa is PessoaFisica pessoaFisica &&
                pessoaFisica.Cpf.Valor == "27509579074"
            );

        public static Pessoa ObterAugustaGuilhermina
            => Mock.FirstOrDefault(pessoa =>
                pessoa is PessoaFisica pessoaFisica &&
                pessoaFisica.Cpf.Valor == "31571995013"
            );

        public static IReadOnlyList<Pessoa> Mock { get; }
    }
}