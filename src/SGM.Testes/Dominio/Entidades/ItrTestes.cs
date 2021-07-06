using SGM.Dominio.Entidades.Builders;
using SGM.Infra.Repositorios.Mocks;
using Xunit;

namespace SGM.Testes.Dominio.Entidades
{
    public class ItrTestes
    {
        [Fact]
        public void DeveCriarItrValido()
        {
            var itr = ItrBuilder
                .Novo()
                .ComAnoDeReferencia<ItrBuilder>(2021)
                .ComContribuinte<ItrBuilder>(PessoasMock.ObterAugustaGuilhermina)
                .ComImovel<ItrBuilder>(ImovelRuralBuilder
                    .Novo()
                    .ComLogradouro<ImovelRuralBuilder>("Linha Centro-Sul")
                    .ComNumero<ImovelRuralBuilder>(45)
                    .ComBairro<ImovelRuralBuilder>("Sertãozinho")
                    .ComAreaTotal<ImovelRuralBuilder>(2800)
                    .ComValorVenal<ImovelRuralBuilder>(1_900_080.78)
                    .ComAreaUtilTotal(2000)
                    .ComAreaDePreservacaoAmbiental(1700)
                    .PossuiManejoDeAgriculturaFamiliar(false)
                    .Construir())
                .Construir();

            Assert.NotNull(itr);
        }
    }
}