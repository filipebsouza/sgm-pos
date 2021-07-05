using System.Collections.Generic;
using System.Linq;
using SGM.Dominio.Entidades;
using SGM.Dominio.Entidades.Builders;
using SGM.Dominio.Repositorios;
using SGM.Infra.Repositorios.Mocks;

namespace SGM.Infra.Repositorios
{
    public class RepositorioDeIptus : IRepositorioDeIptus
    {
        public Iptu ObterPor(Pessoa contribuinte, int anoDeReferencia)
            => IptusMock.Mock.FirstOrDefault(iptu =>
                iptu.Contribuinte.Id == contribuinte.Id &&
                iptu.AnoDeReferencia == anoDeReferencia);

        public Iptu ObterPor(string cpfDoContribuinte, int anoDeReferencia)
            => IptusMock.Mock.FirstOrDefault(iptu =>
                (iptu.Contribuinte as PessoaFisica)?.Cpf.Valor == cpfDoContribuinte &&
                iptu.AnoDeReferencia == anoDeReferencia);

    }
}