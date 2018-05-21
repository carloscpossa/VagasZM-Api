using FluentValidator;
using VagasZM.Compartilhado.ObjetosDeValor;

namespace VagasZM.Dominio.ObjetosDeValor
{
    public class Descricao : ObjetoDeValor
    {
        protected Descricao() : base()
        { }

        public Descricao(string descricao) : this()
        {
            this.descricao = descricao;

            new ValidationContract<Descricao>(this)
                .IsRequired(x => x.descricao, "A descrição é obrigatória")
                .HasMinLenght(x => x.descricao, 2, "A descrição deve ter no mínimo dois caracteres")
                .HasMaxLenght(x => x.descricao, 100, "A descrição dete ter no máximo cem caracteres");
        }

        public string descricao { get; private set; }
    }
}
