using System.Collections.Generic;
using System.Linq;
using SGM.Dominio.Entidades;
using SGM.Dominio.Entidades.Builders;
using SGM.Dominio.ObjetosDeValor;
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
                                       .ComNome<PessoaFisicaBuilder>("Teste e tals")
                                       .ComCpf("03227637111")
                                       .Construir()
                )
                .ComImovelUrbano(
                    ImovelUrbanoBuilder.Novo()
                        .ComLogradouro<ImovelUrbanoBuilder>("Rua Principal")
                        .ComNumero<ImovelUrbanoBuilder>(123)
                        .ComBairro<ImovelUrbanoBuilder>("Vila Qualquer")
                        .ComAreaTotal<ImovelUrbanoBuilder>(234)
                        .ComAreaConstruida(78)
                        .Construir()
                )
                .Construir()
        };

        public Iptu ObterPor(int anoReferencia)
            => _mockDeIptus.FirstOrDefault(iptu => iptu.AnoDeReferencia == anoReferencia);

    }
}