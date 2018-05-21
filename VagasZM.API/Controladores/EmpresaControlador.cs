using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VagasZM.Dominio.Comandos.EmpresaComandos;
using VagasZM.Dominio.Comandos.EmpresaComandos.Entradas;
using VagasZM.Infra.Dados.Transacoes;

namespace VagasZM.API.Controladores
{
    public class EmpresaControlador : ControladorBase
    {
        private readonly EmpresaComandoManipulador _empresaManipulador;
        public EmpresaControlador(EmpresaComandoManipulador empresaManipulador, IUnitOfWork UnitOfWork) : base(UnitOfWork)
        {
            _empresaManipulador = empresaManipulador;
        }


        [HttpPost]
        [AllowAnonymous]
        [Route("v1/empresa")]
        public async Task<IActionResult> CriarEmpresa([FromBody]InserirEmpresaComando comando)
        {
            var resultado = _empresaManipulador.Manipular(comando);
            return await Resposta(resultado, _empresaManipulador.Notifications);
        }
    }
}
