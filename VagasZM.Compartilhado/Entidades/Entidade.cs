using FluentValidator;
using System;

namespace VagasZM.Compartilhado.Entidades
{
    public class Entidade : Notifiable
    {
        protected Entidade()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; private set; }
    }
}
