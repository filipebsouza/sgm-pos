using System.Collections.Generic;
using SGM.Dominio.Entidades;
using SGM.Dominio.Entidades.Builders;

namespace SGM.Infra.Repositorios.Mocks
{
    public static class IptusMock
    {
        static IptusMock()
        {
            Mock = new List<Iptu> {
                IptuBuilder
                    .Novo()
                    .ComAnoDeReferencia<IptuBuilder>(2021)
                    .ComContribuinte<IptuBuilder>(PessoasMock.ObterJoaoErnesto)
                    .ComImovel<IptuBuilder>(ImovelUrbanoBuilder
                        .Novo()
                        .ComLogradouro<ImovelUrbanoBuilder>("Rua Principal")
                        .ComNumero<ImovelUrbanoBuilder>(123)
                        .ComBairro<ImovelUrbanoBuilder>("Vila dos Sonhos")
                        .ComAreaTotal<ImovelUrbanoBuilder>(234)
                        .ComValorVenal<ImovelUrbanoBuilder>(2580.55)
                        .ComAreaConstruida(78)
                        .Construir())
                    .Construir()
            };
        }

        public static List<Iptu> Mock { get; }
    }
}