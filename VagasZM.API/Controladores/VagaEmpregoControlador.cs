using FluentValidator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VagasZM.Dominio.Comandos.VagaEmpregoComandos;
using VagasZM.Dominio.Comandos.VagaEmpregoComandos.Entradas;
using VagasZM.Dominio.Repositorios;
using VagasZM.Infra.Dados.Transacoes;

namespace VagasZM.API.Controladores
{
    public class VagaEmpregoControlador : ControladorBase
    {
        private readonly IVagaEmpregoRepositorio _vagaEmpregoRepositorio;
        private readonly VagaEmpregoComandoManipulador _vagaEmpregoComandoManipulador;
        public VagaEmpregoControlador(IUnitOfWork UnitOfWork, 
                                      VagaEmpregoComandoManipulador vagaEmpregoComandoManipulador, 
                                      IVagaEmpregoRepositorio vagaEmpregoRepositorio) : base(UnitOfWork)
        {
            _vagaEmpregoRepositorio = vagaEmpregoRepositorio;
            _vagaEmpregoComandoManipulador = vagaEmpregoComandoManipulador;
        }

        [HttpPost]
        [Route("v1/vagaemprego")]
        [Authorize(Policy = "UsuarioEmpresa")]
        public async Task<IActionResult> CriarVagaEmprego([FromBody]InserirVagaEmpregoComando comando)
        {
            comando.EmpresaId = Guid.Parse(User.Claims.FirstOrDefault(x => x.Type == "EmpresaId").Value);            
            
            var resultado = _vagaEmpregoComandoManipulador.Manipular(comando);
            return await Resposta(resultado, _vagaEmpregoComandoManipulador.Notifications);
        }    
        
        [HttpGet]
        [Route("v1/vagaemprego/quantidadevagasabertas")]
        [AllowAnonymous]
        [ResponseCache(Duration = 900)]
        public async Task<IActionResult> QuantidadeVagasAbertas()
        {
            return await Resposta(_vagaEmpregoRepositorio.RetornaQuantidadeVagasAbertas(), new List<Notification>());
        }

        [HttpGet]
        [Route("v1/vagaemprego/ultimasvagasabertas")]
        [AllowAnonymous]
        [ResponseCache(Duration = 900)]
        public async Task<IActionResult> UltimasVagasAbertas()
        {
            return await Resposta(_vagaEmpregoRepositorio.RetornaUltimasVagasAbertas(), new List<Notification>());
        }

        [HttpGet]
        [Route("v1/vagaemprego/empresa")]
        [Authorize(Policy = "UsuarioEmpresa")]
        public async Task<IActionResult> VagaEmpregoEmpresa([FromQuery] string cargo, [FromQuery] string descricao, [FromQuery] int? status, [FromQuery] double? salarioInicial, [FromQuery] double? salarioFinal, [FromQuery] Guid? areaProfissionalId, [FromQuery] Guid? tipoContratacaoId)
        {
            var EmpresaId = Guid.Parse(User.Claims.FirstOrDefault(x => x.Type == "EmpresaId").Value);
            return await Resposta(_vagaEmpregoRepositorio.RetornaVagasEmpresa(EmpresaId, cargo, descricao, status, salarioInicial, salarioFinal, areaProfissionalId, tipoContratacaoId), new List<Notification>());
        }

    }
}
