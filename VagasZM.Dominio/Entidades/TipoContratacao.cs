using FluentValidator;
using VagasZM.Compartilhado.Entidades;
using VagasZM.Dominio.ObjetosDeValor;

namespace VagasZM.Dominio.Entidades
{
    public class TipoContratacao : Entidade
    {
        protected TipoContratacao() : base()
        {

        }

        public TipoContratacao(Nome nomeTipoContratacao) : this()
        {
            NomeTipoContratacao = nomeTipoContratacao;

            new ValidationContract<TipoContratacao>(this)
                .IsNotNull(NomeTipoContratacao, "O nome do tipo de contratação não pode ser nulo");

            if (NomeTipoContratacao != null)
            {
                AddNotifications(nomeTipoContratacao.Notifications);
            }
        }

        public Nome NomeTipoContratacao { get; private set; }
    }
}
