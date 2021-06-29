using SGM.Dominio.Entidades;

namespace SGM.Dominio.Repositorios
{
    public interface IRepositorioDeUsuarios
    {
        public Usuario ObterPor(string email);
        public Usuario ObterPor(string email, string senha);
    }
}