using System.Collections.Generic;
using System.Linq;
using SGM.Dominio.Entidades;

namespace SGM.Infra
{
    public class RepositorioDeUsuarios
    {
        private readonly IReadOnlyList<Usuario> _mockDeUsuarios = new List<Usuario>
        {
            new Usuario("teste@teste.com.br", "senha123", PapelDoUsuario.Gestor),
            new Usuario("maria@maria.com.br", "senha123", PapelDoUsuario.Servidor),
            new Usuario("joao@joao.com.br", "senha123", new []{
                PapelDoUsuario.Contribuinte,
                PapelDoUsuario.Servidor
            })
        };

        public Usuario ObterPor(string email, string senha)
        {
            return _mockDeUsuarios.FirstOrDefault(usuario => 
                usuario.Email == email && usuario.SenhaEhValida(senha)
            );
        }
    }
}