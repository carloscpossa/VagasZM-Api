using System.Data.Entity.ModelConfiguration;
using VagasZM.Dominio.Entidades;

namespace VagasZM.Infra.Dados.Mapeamento
{
    public class FormacaoEscolarMap : EntityTypeConfiguration<FormacaoEscolar>
    {
        public FormacaoEscolarMap()
        {
            ToTable("FormacaoEscolar");

            HasKey(x => x.Id);

            Property(x => x.DataInicio)
                .HasColumnName("DataInicio")
                .IsRequired();

            Property(x => x.DataTermino)
                .HasColumnName("DataTermino");

            Property(x => x.Instituicao.nome)
                .HasColumnName("Instituicao")
                .HasMaxLength(60)
                .IsRequired();

            Property(x => x.Curso.nome)
                .HasColumnName("Curso")
                .HasMaxLength(60)
                .IsRequired();

            Property(x => x.NivelFormacao)
                .HasColumnName("NivelFormacao");                
        }
    }
}
