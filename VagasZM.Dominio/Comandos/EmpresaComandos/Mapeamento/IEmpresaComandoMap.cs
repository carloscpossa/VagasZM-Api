using VagasZM.Dominio.Comandos.EmpresaComandos.Entradas;
using VagasZM.Dominio.Entidades;

namespace VagasZM.Dominio.Comandos.EmpresaComandos.Mapeamento
{
    public interface IEmpresaComandoMap
    {
        Empresa CriarEmpresa(InserirEmpresaComando comando);

        UsuarioEmpresa CriarUsuario(InserirEmpresaComando comando, Empresa empresa);
    }
}
