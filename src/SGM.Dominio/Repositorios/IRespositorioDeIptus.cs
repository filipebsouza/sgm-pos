using SGM.Dominio.Entidades;

namespace SGM.Dominio.Repositorios
{
    public interface IRepositorioDeIptus
    {
        Iptu ObterPor(Pessoa contribuinte, int anoDeReferencia);
        Iptu ObterPor(int idDoContribuinte, int anoDeReferencia);
    }
}