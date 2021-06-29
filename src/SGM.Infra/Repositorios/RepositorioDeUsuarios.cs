using System.Collections.Generic;
using System.Linq;
using SGM.Dominio.Entidades;
using SGM.Dominio.Repositorios;

namespace SGM.Infra
{
    public class RepositorioDeUsuarios : IRepositorioDeUsuarios
    {
        private readonly IReadOnlyList<Usuario> _mockDeUsuarios = new List<Usuario>
        {
            new Usuario("Usuário de teste", "teste@teste.com.br", "senha123", PapelDoUsuario.Gestor),
            new Usuario("Maria Servidora", "maria@maria.com.br", "senha123", PapelDoUsuario.Servidor),
            new Usuario("João Contribuinte", "joao@joao.com.br", "senha123", new []{
                PapelDoUsuario.Contribuinte
            })
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