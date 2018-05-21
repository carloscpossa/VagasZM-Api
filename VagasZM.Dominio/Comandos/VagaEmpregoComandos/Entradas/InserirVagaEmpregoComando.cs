using System;
using VagasZM.Compartilhado.Comandos;

namespace VagasZM.Dominio.Comandos.VagaEmpregoComandos.Entradas
{
    public class InserirVagaEmpregoComando : IComando
    {
        public Guid EmpresaId { get; set; }
        public string Cargo { get; set; }
        public string Descricao { get; set; }
        public string Beneficios { get; set; }
        public Guid AreaProfissionalId { get; set; }
        public string HorarioTrabalho { get; set; }
        public bool SalarioAcombinar { get; set; }
        public double Salario { get; set; }
        public Guid TipoContratacaoId { get; set; }
    }
}
