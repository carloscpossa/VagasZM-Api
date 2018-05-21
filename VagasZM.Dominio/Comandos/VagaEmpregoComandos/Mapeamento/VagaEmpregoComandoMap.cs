using System;
using VagasZM.Dominio.Comandos.VagaEmpregoComandos.Entradas;
using VagasZM.Dominio.Entidades;
using VagasZM.Dominio.ObjetosDeValor;

namespace VagasZM.Dominio.Comandos.VagaEmpregoComandos.Mapeamento
{
    public class VagaEmpregoComandoMap : IVagaEmpregoComandoMap
    {
        public VagaEmprego CriarVagaEmprego(InserirVagaEmpregoComando comando, Empresa empresa, AreaProfissional areaProfissional, TipoContratacao tipoContratacao)
        {
            if (comando == null)
                return null;

            return new VagaEmprego(empresa,
                                   new Nome(comando.Cargo),
                                   new Texto(comando.Descricao),
                                   new Texto(comando.Beneficios),
                                   areaProfissional,
                                   new Descricao(comando.HorarioTrabalho),
                                   DateTime.Today.AddDays(30),
                                   comando.SalarioAcombinar,
                                   new NumeroPositivo(comando.Salario),
                                   tipoContratacao);
        }
    }
}
