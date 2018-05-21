using System;
using VagasZM.Compartilhado.Comandos;

namespace VagasZM.Dominio.Comandos.VagaEmpregoComandos.Saidas
{
    public class InserirVagaEmpregoResultadoComando : IResultadoComando
    {
        public Guid VagaEmpregoId { get; set; }    
    }
}
