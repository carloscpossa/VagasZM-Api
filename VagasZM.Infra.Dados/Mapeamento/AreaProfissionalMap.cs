using System.Data.Entity.ModelConfiguration;
using VagasZM.Dominio.Entidades;

namespace VagasZM.Infra.Dados.Mapeamento
{
    public class AreaProfissionalMap : EntityTypeConfiguration<AreaProfissional>
    {
        public AreaProfissionalMap()
        {
            ToTable("AreaProfissional");

            HasKey(x => x.Id);

            Property(x => x.Nome.nome)
                .HasColumnName("Nome")
                .HasMaxLength(60)
                .IsRequired();
        }
    }
}
