using System;
using VagasZM.Compartilhado.Comandos;

namespace VagasZM.Dominio.Comandos.AreaProfissionalComandos.Saidas
{
    public class BuscaListaAreaProfisionalResultadoComando : IResultadoComando
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
    }
}
