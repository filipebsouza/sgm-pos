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
    public class ItrsController : ControllerBase
    {
        private const string MensagemContribuinteNaoEncontrado = "Contribuinte não encontrado";

        private readonly IRepositorioDeItrs _repositorioDeItrs;

        public ItrsController(IRepositorioDeItrs repositorioDeItrs)
        {
            _repositorioDeItrs = repositorioDeItrs;
        }

        [HttpGet]
        [AuthorizeRoles(PapelDoUsuario.Contribuinte)]
        public ActionResult Get()
        {
            var usuario = this.ObterUsuarioLogado();

            if (usuario.Pessoa is null) return this.NotFound(MensagemContribuinteNaoEncontrado);

            var itrAnoAtual = _repositorioDeItrs.ObterPor(this.ObterUsuarioLogado().Pessoa, DateTime.Now.Year);

            if (itrAnoAtual is null) return Ok(null);

            return Ok(new ImpostoSobreImovelHttpDto
            {
                Logradouro = itrAnoAtual.Imovel.Logradouro,
                Numero = itrAnoAtual.Imovel.Numero,
                Bairro = itrAnoAtual.Imovel.Bairro,
                PossuiDebitos = itrAnoAtual.PossuiDebitos,
                SaldoDevedor = itrAnoAtual.SaldoDevedor,
                AnoDeReferencia = itrAnoAtual.AnoDeReferencia
            });
        }

        [HttpGet("{cpfDoContribuinte}/{anoDeReferencia}")]
        [AuthorizeRoles(PapelDoUsuario.Servidor)]
        public ActionResult GetPorContribuinteEAnoDeReferencia(string cpfDoContribuinte, int anoDeReferencia)
        {
            var itrAnoAtual = _repositorioDeItrs.ObterPor(cpfDoContribuinte, anoDeReferencia);

            if (itrAnoAtual is null) return Ok(null);

            return Ok(new ImpostoSobreImovelHttpDto
            {
                Logradouro = itrAnoAtual.Imovel.Logradouro,
                Numero = itrAnoAtual.Imovel.Numero,
                Bairro = itrAnoAtual.Imovel.Bairro,
                PossuiDebitos = itrAnoAtual.PossuiDebitos,
                SaldoDevedor = itrAnoAtual.SaldoDevedor,
                AnoDeReferencia = itrAnoAtual.AnoDeReferencia
            });
        }
    }
}