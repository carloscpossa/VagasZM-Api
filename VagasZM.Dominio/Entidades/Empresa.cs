using FluentValidator;
using VagasZM.Compartilhado.Entidades;
using VagasZM.Dominio.ObjetosDeValor;

namespace VagasZM.Dominio.Entidades
{
    public class Empresa : Entidade
    {
        private Nome nome;

        protected Empresa() : base()
        {

        }

        public Empresa(Nome nomeEmpresa, Texto descricao, Nome cidade, string logo, Site site) : this()
        {
            NomeEmpresa = nomeEmpresa;
            DescricaoEmpresa = descricao;
            Cidade = cidade;
            Logo = logo;
            Site = site;

            new ValidationContract<Empresa>(this)
                .IsNotNull(NomeEmpresa, "O nome da empresa é obrigatório")
                .IsNotNull(Cidade, "A cidade da empresa é obrigatória");

            if (NomeEmpresa != null)
            {
                AddNotifications(NomeEmpresa.Notifications);
            }

            if (DescricaoEmpresa != null)
            {
                AddNotifications(DescricaoEmpresa.Notifications);
            }

            if (Cidade != null)
            {
                AddNotifications(Cidade.Notifications);
            }            
        }        

        public Nome NomeEmpresa { get; private set; }
        public Texto DescricaoEmpresa { get; private set; }
        public Nome Cidade { get; private set; }        
        public string Logo { get; private set; }
        public Site Site { get; private set; }
        
    }
}
