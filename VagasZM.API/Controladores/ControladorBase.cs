using Elmah.Io.AspNetCore;
using FluentValidator;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VagasZM.Infra.Dados.Transacoes;

namespace VagasZM.API.Controladores
{
    public class ControladorBase : Controller
    {
        private readonly IUnitOfWork _UnitOfWork;

        public ControladorBase(IUnitOfWork UnitOfWork)
        {
            _UnitOfWork = UnitOfWork;
        }

        public async Task<IActionResult> Resposta(object resultado, IEnumerable<Notification> notificacoes)
        {
            if (notificacoes.Count() == 0)
            {
                try
                {
                    _UnitOfWork.Commit();
                    return Ok(new
                    {
                        sucesso = true,
                        dados = resultado
                    });
                }
                catch (Exception ex)
                {
                    //Realizar Log

                    ex.Ship(HttpContext);

                    return StatusCode(500);
                }
            }
            else
            {                
                return BadRequest(new
                {
                    sucesso = false,
                    erros = notificacoes
                });
            }
        }
    }
}
