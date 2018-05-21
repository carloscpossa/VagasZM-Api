using VagasZM.Compartilhado.Comandos;

namespace VagasZM.Dominio.Comandos.VagaEmpregoComandos.Saidas
{
    public class UltimasVagasEmpregoAbertasResultadoComando : IResultadoComando
    {
        public string Cargo { get; set; }
        public string NomeEmpresa { get; set; }
        public string Cidade { get; set; }
        public string Descricao { get; set; }
        public string Beneficios { get; set; }
        public string HorarioTrabalho { get; set; }
        public string DataCriacao { get; set; }
        public string Salario { get; set; }
    }
}
