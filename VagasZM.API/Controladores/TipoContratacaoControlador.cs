using FluentValidator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using VagasZM.Dominio.Repositorios;
using VagasZM.Infra.Dados.Transacoes;

namespace VagasZM.API.Controladores
{
    public class TipoContratacaoControlador : ControladorBase
    {
        private readonly ITipoContratacaoRepositorio _tipoContratacaoRepositorio;
        public TipoContratacaoControlador(IUnitOfWork UnitOfWork, ITipoContratacaoRepositorio tipoContratacaoRepositorio) : base(UnitOfWork)
        {
            _tipoContratacaoRepositorio = tipoContratacaoRepositorio;        
        }

        [HttpGet]
        [Route("v1/tipocontratacao")]
        [AllowAnonymous]
        [ResponseCache(Duration = 86400)]
        public async Task<IActionResult> ListaTipoContratacao()
        {
            return await Resposta(_tipoContratacaoRepositorio.PesquisaTipoContratacao(), new List<Notification>());
        }
    }
}
