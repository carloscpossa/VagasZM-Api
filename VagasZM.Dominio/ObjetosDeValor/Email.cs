using FluentValidator;
using VagasZM.Compartilhado.ObjetosDeValor;

namespace VagasZM.Dominio.ObjetosDeValor
{
    public class Email : ObjetoDeValor
    {
        protected Email():base()
        {

        }

        public Email(string enderecoEmail):this()
        {
            EnderecoEmail = enderecoEmail;

            new ValidationContract<Email>(this)
                .IsRequired(x=>x.EnderecoEmail, "O endereço de e-mail é obrigatório")
                .HasMaxLenght(x=>x.EnderecoEmail, 50, "O endereço deve ter no máximo 50 caracteres")
                .IsEmail(x => x.EnderecoEmail, "E-mail inválido");            
        }

        public string EnderecoEmail { get; private set; }
    }
}
