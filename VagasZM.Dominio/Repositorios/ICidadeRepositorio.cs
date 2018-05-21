using System.Collections.Generic;
using VagasZM.Dominio.Comandos.CidadeComandos.Saidas;

namespace VagasZM.Dominio.Repositorios
{
    public interface ICidadeRepositorio
    {
        IEnumerable<CidadesPorEstadoResultadoComando> RetornaCidadePorEstado(string siglaUf);
    }
}
