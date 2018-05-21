using FluentValidator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using VagasZM.Dominio.Repositorios;
using VagasZM.Infra.Dados.Transacoes;

namespace VagasZM.API.Controladores
{
    public class AreaProfissionalControlador : ControladorBase
    {
        private readonly IAreaProfissionalRepositorio _areaProfissionalRepositorio;        

        public AreaProfissionalControlador(IUnitOfWork UnitOfWork, IAreaProfissionalRepositorio areaProfissionalRepositorio) : base(UnitOfWork)
        {
            _areaProfissionalRepositorio = areaProfissionalRepositorio;
        }

        [HttpGet]
        [Route("v1/areaprofissional")]    
        [AllowAnonymous]
        [ResponseCache(Duration = 86400)]
        public async Task<IActionResult> ListarAreas()
        {
            return await Resposta(_areaProfissionalRepositorio.PesquisaAreaProfissional(), new List<Notification>());
        }
    }
}
