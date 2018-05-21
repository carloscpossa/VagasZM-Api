using FluentValidator;
using VagasZM.Compartilhado.ObjetosDeValor;

namespace VagasZM.Dominio.ObjetosDeValor
{
    public class Nome : ObjetoDeValor
    {
        protected Nome():base()
        {

        }

        public Nome(string nome) : this()
        {
            this.nome = nome;

            new ValidationContract<Nome>(this)
                .IsRequired(x => x.nome, "O nome é obrigatório")
                .HasMinLenght(x => x.nome, 2, "O nome deve ter no mínimo dois caracteres")
                .HasMaxLenght(x => x.nome, 60, "O nome dete ter no máximo sessenta caracteres");
        }

        public string nome { get; private set; }
    }
}
