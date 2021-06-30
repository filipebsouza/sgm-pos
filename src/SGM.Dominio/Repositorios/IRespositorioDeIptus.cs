using SGM.Dominio.Entidades;

namespace SGM.Dominio.Repositorios
{
    public interface IRepositorioDeIptus
    {
        Iptu ObterPor(int anoReferencia);
    }
}