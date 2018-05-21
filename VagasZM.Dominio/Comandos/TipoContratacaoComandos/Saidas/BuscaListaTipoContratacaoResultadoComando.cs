using System;
using VagasZM.Compartilhado.Comandos;

namespace VagasZM.Dominio.Comandos.TipoContratacaoComandos.Saidas
{
    public class BuscaListaTipoContratacaoResultadoComando : IResultadoComando
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
    }
}
