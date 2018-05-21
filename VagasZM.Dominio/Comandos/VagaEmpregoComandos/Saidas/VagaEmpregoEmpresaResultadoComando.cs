using System;
using VagasZM.Compartilhado.Comandos;

namespace VagasZM.Dominio.Comandos.VagaEmpregoComandos.Saidas
{
    public class VagaEmpregoEmpresaResultadoComando : IResultadoComando
    {
        public Guid vagaEmpregoId { get; set; }
        public string Cargo { get; set; }
        public string Descricao { get; set; }
        public string Beneficios { get; set; }
        public string HorarioTrabalho { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataExpiracao { get; set; }
        public bool SalarioAcombinar { get; set; }
        public double Salario { get; set; }        
        public string DescricaoStatus { get; set; }
        public Guid AreaProfissional_Id { get; set; }
        public Guid TipoContratacao_Id { get; set; }
        public string AreaProfissional { get; set; }
        public string TipoContratacao { get; set; }  
    }
}
