using SGM.Dominio.Entidades;

namespace SGM.Dominio.Repositorios
{
    public interface IRepositorioDeIptus
    {
        Iptu ObterPor(Pessoa contriuinte, int anoReferencia);
    }
}