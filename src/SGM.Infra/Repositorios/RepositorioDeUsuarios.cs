using SGM.Dominio.Entidades;
using SGM.Dominio.Repositorios;
using SGM.Infra.Repositorios.Mocks;

namespace SGM.Infra.Repositorios
{
    public class RepositorioDeUsuarios : IRepositorioDeUsuarios
    {
        public Usuario ObterPor(string email, string senha)
        {
            return UsuariosMock.Mock.Find(usuario =>
                usuario.Email == email && usuario.SenhaEhValida(senha)
            );
        }

        public Usuario ObterPor(string email) =>
            UsuariosMock.Mock.Find(usuario => usuario.Email == email);
    }
}