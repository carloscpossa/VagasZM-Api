using System;
using System.Collections.Generic;
using VagasZM.Dominio.Comandos.VagaEmpregoComandos.Saidas;
using VagasZM.Dominio.Entidades;

namespace VagasZM.Dominio.Repositorios
{
    public interface IVagaEmpregoRepositorio
    {
        void Adicionar(VagaEmprego vaga);

        NumeroVagasAbertasResultadoComando RetornaQuantidadeVagasAbertas();

        IEnumerable<UltimasVagasEmpregoAbertasResultadoComando> RetornaUltimasVagasAbertas();

        IEnumerable<VagaEmpregoEmpresaResultadoComando> RetornaVagasEmpresa(Guid empresaId, string cargo, string descricao, int? status, double? salarioInicial, double? salarioFinal, Guid? areaProfissionalId, Guid? tipoContratacaoId);

    }
}
