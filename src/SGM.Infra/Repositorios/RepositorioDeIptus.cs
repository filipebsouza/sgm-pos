using System.Collections.Generic;
using System.Linq;
using SGM.Dominio.Entidades;
using SGM.Dominio.Entidades.Builders;
using SGM.Dominio.Repositorios;

namespace SGM.Infra.Repositorios
{
    public class RepositorioDeIptus : IRepositorioDeIptus
    {
        private readonly IReadOnlyList<Iptu> _mockDeIptus = new List<Iptu>
        {
            IptuBuilder
                .Novo()
                .ComAnoDeReferencia<IptuBuilder>(2021)
                .ComContribuinte<IptuBuilder>(
                    PessoaFisicaBuilder.Novo()
                                       .ComId(1)
                                       .ComNome<PessoaFisicaBuilder>("Teste e tals")
                                       .ComCpf("03227637111")
                                       .Construir()
                )
                .ComImovel<IptuBuilder>(
                    ImovelUrbanoBuilder.Novo()
                        .ComLogradouro<ImovelUrbanoBuilder>("Rua Principal")
                        .ComNumero<ImovelUrbanoBuilder>(123)
                        .ComBairro<ImovelUrbanoBuilder>("Vila Qualquer")
                        .ComAreaTotal<ImovelUrbanoBuilder>(234)
                        .ComValorVenal(2580.55)
                        .ComAreaConstruida(78)
                        .Construir()
                )
                .Construir()
        };

        public Iptu ObterPor(Pessoa contribuinte, int anoDeReferencia)
            => _mockDeIptus.FirstOrDefault(iptu =>
                iptu.Contribuinte.Id == contribuinte.Id &&
                iptu.AnoDeReferencia == anoDeReferencia);

        public Iptu ObterPor(string cpfDoContribuinte, int anoDeReferencia)
            => _mockDeIptus.FirstOrDefault(iptu =>
                (iptu.Contribuinte as PessoaFisica)?.Cpf.Valor == cpfDoContribuinte &&
                iptu.AnoDeReferencia == anoDeReferencia);

    }
}