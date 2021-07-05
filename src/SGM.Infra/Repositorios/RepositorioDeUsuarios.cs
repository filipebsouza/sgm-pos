using System.Linq;
using SGM.Dominio.Entidades;
using SGM.Dominio.Repositorios;
using SGM.Infra.Repositorios.Mocks;

namespace SGM.Infra.Repositorios
{
    public class RepositorioDeUsuarios : IRepositorioDeUsuarios
    {
        public Usuario ObterPor(string email, string senha)
        {
            return UsuariosMock.Mock.FirstOrDefault(usuario =>
                usuario.Email == email && usuario.SenhaEhValida(senha)
            );
        }

        public Usuario ObterPor(string email) =>
            UsuariosMock.Mock.FirstOrDefault(usuario => usuario.Email == email);
    }
}