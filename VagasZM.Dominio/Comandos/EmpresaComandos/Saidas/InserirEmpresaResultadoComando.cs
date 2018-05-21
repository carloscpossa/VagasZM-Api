using System;
using VagasZM.Compartilhado.Comandos;

namespace VagasZM.Dominio.Comandos.EmpresaComandos.Saidas
{
    public class InserirEmpresaResultadoComando : IResultadoComando
    {
        public Guid EmpresaId { get; set; }
    }
}
