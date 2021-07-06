using SGM.Dominio.Entidades.Builders;
using SGM.Infra.Repositorios.Mocks;
using Xunit;

namespace SGM.Testes.Dominio.Entidades
{
    public class IptuTestes
    {
        [Fact]
        public void DeveCriarUmIptuValido()
        {
            var iptu = IptuBuilder
                    .Novo()
                    .ComAnoDeReferencia<IptuBuilder>(2021)
                    .ComContribuinte<IptuBuilder>(PessoasMock.ObterJoaoErnesto)
                    .ComImovel<IptuBuilder>(ImovelUrbanoBuilder
                        .Novo()
                        .ComLogradouro<ImovelUrbanoBuilder>("Rua Principal")
                        .ComNumero<ImovelUrbanoBuilder>(123)
                        .ComBairro<ImovelUrbanoBuilder>("Vila dos Sonhos")
                        .ComAreaTotal<ImovelUrbanoBuilder>(234)
                        .ComValorVenal(2580.55)
                        .ComAreaConstruida(78)
                        .Construir())
                    .Construir();

            Assert.NotNull(iptu);
            Assert.True(iptu.Aliquota > 0);
        }
    }
}