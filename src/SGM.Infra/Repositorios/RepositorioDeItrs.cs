// using System.Collections.Generic;
// using SGM.Dominio.Entidades;
// using SGM.Dominio.Repositorios;

// namespace SGM.Infra.Repositorios
// {
//     public class RepositorioDeItrs : IRepositorioDeItrs
//     {

//         public class RepositorioDeIptus : IRepositorioDeIptus
//         {
//             private readonly IReadOnlyList<Iptu> _mockDeIptus = new List<Iptu>
//         {
//             IptuBuilder
//                 .Novo()
//                 .ComAnoDeReferencia<IptuBuilder>(2021)
//                 .ComContribuinte<IptuBuilder>(
//                     PessoaFisicaBuilder.Novo()
//                                        .ComId(1)
//                                        .ComNome<PessoaFisicaBuilder>("Teste e tals")
//                                        .ComCpf("03227637111")
//                                        .Construir()
//                 )
//                 .ComImovel<IptuBuilder>(
//                     ImovelUrbanoBuilder.Novo()
//                         .ComLogradouro<ImovelUrbanoBuilder>("Rua Principal")
//                         .ComNumero<ImovelUrbanoBuilder>(123)
//                         .ComBairro<ImovelUrbanoBuilder>("Vila Qualquer")
//                         .ComAreaTotal<ImovelUrbanoBuilder>(234)
//                         .ComValorVenal(2580.55)
//                         .ComAreaConstruida(78)
//                         .Construir()
//                 )
//                 .Construir()

//         public Itr ObterPor(Pessoa contribuinte, int anoDeReferencia)
//             {
//                 throw new System.NotImplementedException();
//             }

//             public Itr ObterPor(string cpfDoContribuinte, int anoDeReferencia)
//             {
//                 throw new System.NotImplementedException();
//             }
//         }
//     }