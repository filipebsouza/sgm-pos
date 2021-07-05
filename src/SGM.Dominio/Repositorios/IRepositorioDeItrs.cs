using SGM.Dominio.Entidades;

namespace SGM.Dominio.Repositorios
{
    public interface IRepositorioDeItrs
    {
        Itr ObterPor(Pessoa contribuinte, int anoDeReferencia);
        Itr ObterPor(string cpfDoContribuinte, int anoDeReferencia);
    }
}