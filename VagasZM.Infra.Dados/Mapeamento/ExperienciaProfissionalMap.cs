using System.Data.Entity.ModelConfiguration;
using VagasZM.Dominio.Entidades;

namespace VagasZM.Infra.Dados.Mapeamento
{
    public class ExperienciaProfissionalMap : EntityTypeConfiguration<ExperienciaProfissional>
    {
        public ExperienciaProfissionalMap()
        {
            ToTable("ExperienciaProfissional");

            HasKey(x => x.Id);

            Property(x => x.DataInicio)
                .HasColumnName("DataInicio")
                .IsRequired();

            Property(x => x.DataTermino)
                .HasColumnName("DataTermino");

            Property(x => x.Empresa.nome)
                .HasColumnName("Empresa")
                .HasMaxLength(60)
                .IsRequired();

            Property(x => x.Cargo.nome)
                .HasColumnName("Cargo")
                .HasMaxLength(60)
                .IsRequired();            

            Property(x => x.AtividadeExercida.Conteudo)
                .HasColumnName("AtividadeExercida")
                .HasColumnType("text");

            HasRequired(x => x.Area);
        }
    }
}
