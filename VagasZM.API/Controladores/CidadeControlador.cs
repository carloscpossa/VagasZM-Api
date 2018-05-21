using FluentValidator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using VagasZM.Dominio.Repositorios;
using VagasZM.Infra.Dados.Transacoes;

namespace VagasZM.API.Controladores
{
    public class CidadeControlador : ControladorBase
    {
        private readonly ICidadeRepositorio _cidadeRepositorio;
        public CidadeControlador(IUnitOfWork UnitOfWork, ICidadeRepositorio cidadeRepositorio) : base(UnitOfWork)
        {
            _cidadeRepositorio = cidadeRepositorio;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("v1/cidades/{uf}")]
        [ResponseCache(Duration = 86400)]
        public async Task<IActionResult> CidadesPorUf(string uf)
        {
            return await Resposta(_cidadeRepositorio.RetornaCidadePorEstado(uf), new List<Notification>());
        }
    }
}
