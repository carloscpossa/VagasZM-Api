using FluentValidator;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VagasZM.Compartilhado.Entidades;
using VagasZM.Dominio.Enumeracoes;
using VagasZM.Dominio.ObjetosDeValor;

namespace VagasZM.Dominio.Entidades
{
    public class Candidato : Entidade
    {
        private List<FormacaoEscolar> _formacao;
        private List<ExperienciaProfissional> _experiencia;

        protected Candidato():base()
        {
            _formacao = new List<FormacaoEscolar>();
            _experiencia = new List<ExperienciaProfissional>();

            Endereco = new Endereco("", "", "", "", "", Estados.MG);
        }

        public Candidato(Email email, Nome nome, Telefone telefone, CPF cPF, string senha, string confirmacaoDeSenha) :this()
        {
            Email = email;
            Nome = nome;
            Telefone = telefone;
            CPF = cPF;
            Senha = EncriptarSenha(senha);

            new ValidationContract<Candidato>(this)
                .IsNotNull(Email, "O e-mail do candidato deve ser preenchido")
                .IsNotNull(Nome, "O nome do candidato deve ser preenchido")
                .IsRequired(x => x.Senha, "A senha deve ser preenchida")
                .AreEquals(x => x.Senha, EncriptarSenha(confirmacaoDeSenha), "As senhas não coincidem");

            if (string.IsNullOrWhiteSpace(senha))
            {
                AddNotification("Senha", "A senha deve ser preenchida");
            }

            if (Email != null)
            {
                AddNotifications(Email.Notifications);
            }

            if (Nome != null)
            {
                AddNotifications(Nome.Notifications);
            }

            if (Telefone != null)
            {
                AddNotifications(Telefone.Notifications);
            }

            if (CPF != null)
            {
                AddNotifications(CPF.Notifications);
            }

        }

        public Email Email { get; private set; }
        public Nome Nome { get; private set; }
        public Telefone Telefone { get; private set; }
        public CPF CPF { get; private set; }
        public string Senha { get; private set; }
        public Endereco Endereco { get; private set; }

        public virtual ICollection<FormacaoEscolar> FormacaoEscolar
        {            
            get => _formacao;
            private set
            {
                _formacao = value.ToList();
            }
        }        
        public virtual ICollection<ExperienciaProfissional> ExperienciaProfissional
        {
            get => _experiencia;
            private set
            {
                _experiencia = value.ToList();
            }
        }

        public void AdicionarFormacao(FormacaoEscolar formacao)
        {
            if (formacao != null && formacao.IsValid())
                _formacao.Add(formacao);
        }

        public void RemoverFormacao(FormacaoEscolar formacao)
        {
            _formacao.Remove(formacao);
        }

        public void AdicionarExperiencia(ExperienciaProfissional experiencia)
        {
            if (experiencia!=null && experiencia.IsValid())
                _experiencia.Add(experiencia);
        }

        public void RemoverExperiencia(ExperienciaProfissional experiencia)
        {
            _experiencia.Remove(experiencia);
        }

        public void InformarEndereco(Endereco endereco)
        {
            if (endereco!=null && endereco.IsValid()) 
                Endereco = endereco;
        }

        private string EncriptarSenha(string pass)
        {
            if (string.IsNullOrEmpty(pass)) return "";
            var password = (pass += "|3c138bbw-f6j0-40c7-bb43-6e58689d3781");
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
