using FluentValidator;
using VagasZM.Compartilhado.ObjetosDeValor;

namespace VagasZM.Dominio.ObjetosDeValor
{
    public class Site : ObjetoDeValor
    {
        protected Site():base()
        {

        }

        public Site(string URL):this()
        {
            this.URL = URL;

            new ValidationContract<Site>(this)                
                .HasMaxLenght(x => x.URL, 50, "A URL tem no máximo 50 caracteres")
                .IsRequired(x => x.URL, "A URL é de preenchimento obrigatório");

            if (string.IsNullOrWhiteSpace(this.URL))
            {
                AddNotification("URL", "A URL não pode ter espaços em branco");
            }
        }

        public string URL { get; private set; }
    }
}
