using VagasZM.Dominio.Comandos.VagaEmpregoComandos.Entradas;
using VagasZM.Dominio.Entidades;

namespace VagasZM.Dominio.Comandos.VagaEmpregoComandos.Mapeamento
{
    public interface IVagaEmpregoComandoMap
    {
        VagaEmprego CriarVagaEmprego(InserirVagaEmpregoComando comando, Empresa empresa, AreaProfissional areaProfissional, TipoContratacao tipoContratacao);
    }
}
