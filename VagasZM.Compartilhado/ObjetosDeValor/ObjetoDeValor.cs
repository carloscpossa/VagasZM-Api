using FluentValidator;
using System;

namespace VagasZM.Compartilhado.ObjetosDeValor
{
    public class ObjetoDeValor : Notifiable
    {
        protected ObjetoDeValor()
        {
            Id = Guid.NewGuid();
        }
        protected Guid Id { get; private set; }
    }
}
