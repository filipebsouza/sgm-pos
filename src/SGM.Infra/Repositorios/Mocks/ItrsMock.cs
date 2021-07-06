using System.Collections.Generic;
using SGM.Dominio.Entidades;
using SGM.Dominio.Entidades.Builders;

namespace SGM.Infra.Repositorios.Mocks
{
    public static class ItrsMock
    {
        static ItrsMock()
        {
            Mock = new List<Itr> {
                ItrBuilder
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
                    .Construir()
            };
        }

        public static List<Itr> Mock { get; }
    }
}