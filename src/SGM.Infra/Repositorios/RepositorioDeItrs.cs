using SGM.Dominio.Entidades;
using SGM.Dominio.Repositorios;
using SGM.Infra.Repositorios.Mocks;

namespace SGM.Infra.Repositorios
{
    public class RepositorioDeItrs : IRepositorioDeItrs
    {
        public Itr ObterPor(Pessoa contribuinte, int anoDeReferencia)
            => ItrsMock.Mock.Find(itr =>
                itr.Contribuinte.Id == contribuinte.Id &&
                itr.AnoDeReferencia == anoDeReferencia);

        public Itr ObterPor(string cpfDoContribuinte, int anoDeReferencia)
            => ItrsMock.Mock.Find(itr =>
                (itr.Contribuinte as PessoaFisica)?.Cpf.Valor == cpfDoContribuinte &&
                itr.AnoDeReferencia == anoDeReferencia);
    }
}