using FluentValidator;
using System;
using VagasZM.Compartilhado.Entidades;
using VagasZM.Dominio.ObjetosDeValor;

namespace VagasZM.Dominio.Entidades
{
    public class Candidatura : Entidade
    {       
        protected Candidatura():base()
        {

        }

        public Candidatura(VagaEmprego vaga, Candidato candidato, NumeroPositivo pretensaoSalarial, Texto observacao)
        {
            
            Vaga = vaga;
            Candidato = candidato;
            DataCandidatura = DateTime.Now;
            PretensaoSalarial = pretensaoSalarial;
            Observacao = observacao;

            new ValidationContract<Candidatura>(this)
                .IsNotNull(Vaga, "A vaga de emprego da candudatura não pode ser nula")
                .IsNotNull(Candidato, "O candidato à vaga de emprego não pode ser nulo");                

            if (Vaga != null)
            {
                AddNotifications(Vaga.Notifications);
            }

            if (Candidato != null)
            {
                AddNotifications(Candidato.Notifications);
            }

            if (PretensaoSalarial != null && PretensaoSalarial.Valor != 0)
            {
                AddNotifications(PretensaoSalarial.Notifications);
            }

        }

        public VagaEmprego Vaga { get; private set; }
        public Candidato Candidato { get; private set; }
        public DateTime DataCandidatura { get; private set; }
        public NumeroPositivo PretensaoSalarial { get; private set; }
        public Texto Observacao { get; private set; }
    }
}
