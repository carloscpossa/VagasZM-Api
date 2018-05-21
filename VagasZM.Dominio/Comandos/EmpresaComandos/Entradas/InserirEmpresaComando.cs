using VagasZM.Compartilhado.Comandos;

namespace VagasZM.Dominio.Comandos.EmpresaComandos.Entradas
{
    public class InserirEmpresaComando : IComando
    {
        public string NomeEmpresa { get; set; }
        public string Descricao { get; set; }
        public string Cidade { get; set; }
        public string site { get; set; }
        public string nomeUsuario { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
        public string confirmacaoSenha { get; set; }        
    }
}
