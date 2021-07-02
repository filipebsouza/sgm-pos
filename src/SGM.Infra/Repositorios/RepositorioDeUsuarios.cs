using System.Collections.Generic;
using System.Linq;
using SGM.Dominio.Entidades;
using SGM.Dominio.Entidades.Builders;
using SGM.Dominio.Repositorios;

namespace SGM.Infra.Repositorios
{
    public class RepositorioDeUsuarios : IRepositorioDeUsuarios
    {
        private readonly IReadOnlyList<Usuario> _mockDeUsuarios = new List<Usuario>
        {
            UsuarioBuilder.Novo()
                          .ComNome("Usuário de teste")
                          .ComEmail("teste@teste.com.br")
                          .ComSenha("senha123")
                          .ComPapeis(PapelDoUsuario.Gestor)
                          .Construir(),
            UsuarioBuilder.Novo()
                          .ComNome("Maria Servidora")
                          .ComEmail("maria@maria.com.br")
                          .ComSenha("senha123")
                          .ComPapeis(PapelDoUsuario.Servidor)
                          .Construir(),
            UsuarioBuilder.Novo()
                          .ComNome("João Contribuinte")
                          .ComEmail("joao@joao.com.br")
                          .ComSenha("senha123")
                          .ComPapeis(PapelDoUsuario.Contribuinte)
                          .ComPessoa(
                              PessoaFisicaBuilder.Novo()
                                                 .ComId(1)
                                                 .ComNome<PessoaFisicaBuilder>("João Contribuinte")
                                                 .ComCpf("03227637111")
                                                 .Construir()
                          )
                          .Construir()
        };

        public Usuario ObterPor(string email, string senha)
        {
            return _mockDeUsuarios.FirstOrDefault(usuario =>
                usuario.Email == email && usuario.SenhaEhValida(senha)
            );
        }

        public Usuario ObterPor(string email) =>
            _mockDeUsuarios.FirstOrDefault(usuario => usuario.Email == email);
    }
}