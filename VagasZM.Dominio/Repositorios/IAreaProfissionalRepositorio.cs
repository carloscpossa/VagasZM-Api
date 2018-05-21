using System;
using System.Collections.Generic;
using VagasZM.Dominio.Comandos.AreaProfissionalComandos.Saidas;
using VagasZM.Dominio.Entidades;

namespace VagasZM.Dominio.Repositorios
{
    public interface IAreaProfissionalRepositorio
    {
        IEnumerable<BuscaListaAreaProfisionalResultadoComando> PesquisaAreaProfissional();

        AreaProfissional BuscaAreaProfissionalPorId(Guid Id);
    }
}
