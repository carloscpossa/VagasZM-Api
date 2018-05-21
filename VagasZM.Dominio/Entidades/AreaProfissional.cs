using FluentValidator;
using VagasZM.Compartilhado.Entidades;
using VagasZM.Dominio.ObjetosDeValor;

namespace VagasZM.Dominio.Entidades
{
    public class AreaProfissional : Entidade
    {

        protected AreaProfissional() : base()
        {

        }


        public AreaProfissional(Nome nome) : this()
        {
            Nome = nome;

            new ValidationContract<AreaProfissional>(this)
                .IsNotNull(Nome, "O nome da área profissional não pode ser nulo");
        }

        public Nome Nome { get; private set; }
    }
}
