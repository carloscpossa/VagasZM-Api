using VagasZM.Compartilhado.Comandos;

namespace VagasZM.Dominio.Comandos.UsuarioEmpresaComandos.Entradas
{
    public class AutenticarUsuarioEmpresaComando : IComando
    {
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
