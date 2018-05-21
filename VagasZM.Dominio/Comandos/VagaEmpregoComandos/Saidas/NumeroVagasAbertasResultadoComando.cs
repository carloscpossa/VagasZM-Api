using VagasZM.Compartilhado.Comandos;

namespace VagasZM.Dominio.Comandos.VagaEmpregoComandos.Saidas
{
    public class NumeroVagasAbertasResultadoComando : IResultadoComando
    {
        public int QuantidadeVagasAbertas { get; set; }
    }
}
