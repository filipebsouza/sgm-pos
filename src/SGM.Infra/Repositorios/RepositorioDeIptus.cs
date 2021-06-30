using System.Collections.Generic;
using SGM.Dominio.Entidades;
using SGM.Dominio.Repositorios;

namespace SGM.Infra.Repositorios
{
    public class RepositorioDeIptus : IRepositorioDeIptus
    {
        // private readonly IReadOnlyList<Iptu> _mockDeIptus = new List<Iptu>
        // {
        //     new Usuario("Usuário de teste", "teste@teste.com.br", "senha123", PapelDoUsuario.Gestor),
        //     new Usuario("Maria Servidora", "maria@maria.com.br", "senha123", PapelDoUsuario.Servidor),
        //     new Usuario("João Contribuinte", "joao@joao.com.br", "senha123", new []{
        //         PapelDoUsuario.Contribuinte
        //     })
        // };
        
        public Iptu ObterPor(int anoReferencia)
        {
            throw new System.NotImplementedException();
        }
    }
}