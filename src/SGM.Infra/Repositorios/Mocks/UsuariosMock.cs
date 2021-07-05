using System.Collections.Generic;
using SGM.Dominio.Entidades;
using SGM.Dominio.Entidades.Builders;

namespace SGM.Infra.Repositorios.Mocks
{
    public static class UsuariosMock
    {
        static UsuariosMock()
        {
            Mock = new List<Usuario>
            {
                UsuarioBuilder.Novo()
                                .ComId(1)
                                .ComNome("Claudionor dos Santos Barbosa")
                                .ComEmail("claudionor@bomdestino.governo.br")
                                .ComSenha("senha123")
                                .ComPapeis(PapelDoUsuario.Gestor)
                                .Construir(),
                UsuarioBuilder.Novo()
                                .ComId(2)
                                .ComNome("Maria da Silva")
                                .ComEmail("maria@bomdestino.governo.br")
                                .ComSenha("senha123")
                                .ComPapeis(PapelDoUsuario.Servidor)
                                .Construir(),
                UsuarioBuilder.Novo()
                                .ComId(3)
                                .ComNome("João Ernesto Villalba")
                                .ComEmail("joao@joao.com.br")
                                .ComSenha("senha123")
                                .ComPapeis(PapelDoUsuario.Contribuinte)
                                .ComPessoa(
                                    PessoasMock.ObterJoaoErnesto
                                )
                                .Construir()
            };
        }

        public static IReadOnlyList<Usuario> Mock { get; }
    }
}