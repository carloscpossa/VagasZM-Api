using FluentValidator;
using System.Text;
using VagasZM.Compartilhado.Entidades;
using VagasZM.Dominio.ObjetosDeValor;

namespace VagasZM.Dominio.Entidades
{
    public class UsuarioEmpresa : Entidade
    {
        protected UsuarioEmpresa():base()
        {
                
        }

        public UsuarioEmpresa(Empresa empresa, Nome nome, Email email, string senha, string confirmacaoDeSenha) : this()
        {
            Empresa = empresa;
            Nome = nome;
            Email = email;
            Senha = EncriptarSenha(senha);

            new ValidationContract<UsuarioEmpresa>(this)
                .IsNotNull(Empresa, "O nome da empresa é obrigatório")
                .IsNotNull(Nome, "O nome completo do contato da empresa é obrigatório")
                .IsNotNull(Email, "O email é obrigatório")
                .IsRequired(x => x.Senha, "A senha é de preenchimento obrigatório")
                .AreEquals(x => x.Senha, EncriptarSenha(confirmacaoDeSenha), "As senhas não coincidem");

            if (Nome != null)
            {
                AddNotifications(Nome.Notifications);
            }

            if (Email != null)
            {
                AddNotifications(Email.Notifications);
            }

            if (string.IsNullOrWhiteSpace(senha))
            {
                AddNotification("Senha", "A senha é de preenchimento obrigatório");
            }

        }

        public Empresa Empresa { get; private set; }
        public Nome Nome { get; private set; }
        public Email Email { get; private set; }
        public string Senha { get; private set; }

        private string EncriptarSenha(string pass)
        {
            if (string.IsNullOrEmpty(pass)) return "";
            var password = (pass += "|2d381bbw-f6j0-40c7-bb43-6e58689d2881");
            var md5 = System.Security.Cryptography.MD5.Create();
            var data = md5.ComputeHash(Encoding.Default.GetBytes(password));
            var sbString = new StringBuilder();
            foreach (var t in data)
                sbString.Append(t.ToString("x2"));

            return sbString.ToString();
        }

        public bool Autenticado(string senha)
        {
            if (string.IsNullOrEmpty(senha) || string.IsNullOrEmpty(senha.Trim()) || EncriptarSenha(senha) != Senha)
            {
                AddNotification("Senha", "Senha inválida");
                return false;
            }

            return true;
        }

    }
}
