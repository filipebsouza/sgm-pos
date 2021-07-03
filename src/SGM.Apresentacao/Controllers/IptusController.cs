using System;
using Microsoft.AspNetCore.Mvc;
using SGM.Apresentacao.Dtos;
using SGM.Apresentacao.Helpers;
using SGM.Dominio.Entidades;
using SGM.Dominio.Repositorios;

namespace SGM.Apresentacao.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IptusController : ControllerBase
    {
        private const string MensagemContribuinteNaoEncontrado = "Contribuinte não encontrado";
        private readonly IRepositorioDeIptus _repositorioDeIptus;

        public IptusController(IRepositorioDeIptus repositorioDeIptus)
        {
            _repositorioDeIptus = repositorioDeIptus;
        }

        [HttpGet]
        [AuthorizeRoles(PapelDoUsuario.Contribuinte)]
        public ActionResult Get()
        {
            var usuario = this.ObterUsuarioLogado();

            if (usuario.Pessoa is null) return this.NotFound(MensagemContribuinteNaoEncontrado);

            var iptuAnoAtual = _repositorioDeIptus.ObterPor(this.ObterUsuarioLogado().Pessoa, DateTime.Now.Year);

            if (iptuAnoAtual is null) return Ok(null);

            return Ok(new IptuHttpDto
            {
                Logradouro = iptuAnoAtual.Imovel.Logradouro,
                Numero = iptuAnoAtual.Imovel.Numero,
                Bairro = iptuAnoAtual.Imovel.Bairro,
                PossuiDebitos = iptuAnoAtual.PossuiDebitos,
                SaldoDevedor = iptuAnoAtual.SaldoDevedor,
                AnoDeReferencia = iptuAnoAtual.AnoDeReferencia
            });
        }

        [HttpGet("{cpfDoContribuinte}/{anoDeReferencia}")]
        [AuthorizeRoles(PapelDoUsuario.Servidor)]
        public ActionResult GetPorContribuinteEAnoDeReferencia(string cpfDoContribuinte, int anoDeReferencia)
        {
            var iptuAnoAtual = _repositorioDeIptus.ObterPor(cpfDoContribuinte, anoDeReferencia);

            if (iptuAnoAtual is null) return Ok(null);

            return Ok(new IptuHttpDto
            {
                Logradouro = iptuAnoAtual.Imovel.Logradouro,
                Numero = iptuAnoAtual.Imovel.Numero,
                Bairro = iptuAnoAtual.Imovel.Bairro,
                PossuiDebitos = iptuAnoAtual.PossuiDebitos,
                SaldoDevedor = iptuAnoAtual.SaldoDevedor,
                AnoDeReferencia = iptuAnoAtual.AnoDeReferencia
            });
        }
    }
}
