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
        private readonly IRepositorioDeIptus _repositorioDeIptus;

        public IptusController(IRepositorioDeIptus repositorioDeIptus)
        {
            _repositorioDeIptus = repositorioDeIptus;
        }

        [HttpGet]
        [Route("")]
        [AuthorizeRoles(PapelDoUsuario.Contribuinte, PapelDoUsuario.Servidor)]
        public ActionResult Get()
        {
            var iptuAnoAtual = _repositorioDeIptus.ObterPor(this.ObterUsuarioLogado().Pessoa, DateTime.Now.Year);

            return Ok(new IptuHttpDto
            {
                Logradouro = iptuAnoAtual.Imovel.Logradouro,
                Numero = iptuAnoAtual.Imovel.Numero,
                Bairro = iptuAnoAtual.Imovel.Bairro
            });
        }
    }
}
