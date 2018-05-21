using FluentValidator;
using VagasZM.Compartilhado.ObjetosDeValor;

namespace VagasZM.Dominio.ObjetosDeValor
{
    public class Texto : ObjetoDeValor
    {
        protected Texto():base()
        {

        }

        public Texto(string conteudo)
        {
            this.Conteudo = conteudo;

            if (conteudo == null)
                AddNotification("conteudo", "O conteúdo não pode ser nulo.");
        }

        public string Conteudo { get; private set; }
    }
}
