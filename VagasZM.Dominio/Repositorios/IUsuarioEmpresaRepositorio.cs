using VagasZM.Dominio.Entidades;

namespace VagasZM.Dominio.Repositorios
{
    public interface IUsuarioEmpresaRepositorio
    {
        void Adicionar(UsuarioEmpresa usuario);
        UsuarioEmpresa BuscarUsuarioPorEmail(string email);
        bool VerificarSeUsuarioExistePorEmail(string email);
    }
}
