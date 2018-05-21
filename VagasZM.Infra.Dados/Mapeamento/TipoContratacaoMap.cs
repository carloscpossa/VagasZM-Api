using System.Data.Entity.ModelConfiguration;
using VagasZM.Dominio.Entidades;

namespace VagasZM.Infra.Dados.Mapeamento
{
    public class TipoContratacaoMap : EntityTypeConfiguration<TipoContratacao>
    {
        public TipoContratacaoMap()
        {
            ToTable("TipoContratacao");

            HasKey(x => x.Id);

            Property(x => x.NomeTipoContratacao.nome)
                .HasColumnName("Nome")
                .HasMaxLength(60)
                .IsRequired();
        }
    }
}
