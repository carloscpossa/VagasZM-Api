using System;
using System.Collections.Generic;
using VagasZM.Dominio.Comandos.TipoContratacaoComandos.Saidas;
using VagasZM.Dominio.Entidades;

namespace VagasZM.Dominio.Repositorios
{
    public interface ITipoContratacaoRepositorio
    {
        IEnumerable<BuscaListaTipoContratacaoResultadoComando> PesquisaTipoContratacao();
        TipoContratacao BuscaTipoContratacaoPorId(Guid Id);
    }
}
