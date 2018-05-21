using System.Data.Entity.ModelConfiguration;
using VagasZM.Dominio.Entidades;

namespace VagasZM.Infra.Dados.Mapeamento
{
    public class CandidaturaMap : EntityTypeConfiguration<Candidatura>
    {
        public CandidaturaMap()
        {
            ToTable("Candidatura");

            HasKey(x => x.Id);

            HasRequired(x => x.Vaga);
            HasRequired(x => x.Candidato);

            Property(x => x.DataCandidatura)
                .HasColumnName("DataCandidatura")
                .IsRequired();

            Property(x => x.PretensaoSalarial.Valor)
                .HasColumnName("PretensaoSalarial");

            Property(x => x.Observacao.Conteudo)
                .HasColumnName("Observacao")
                .HasColumnType("text");
            
        }
    }
}
