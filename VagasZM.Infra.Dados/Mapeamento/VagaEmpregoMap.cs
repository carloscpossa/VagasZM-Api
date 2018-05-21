using System.Data.Entity.ModelConfiguration;
using VagasZM.Dominio.Entidades;

namespace VagasZM.Infra.Dados.Mapeamento
{
    public class VagaEmpregoMap : EntityTypeConfiguration<VagaEmprego>
    {
        public VagaEmpregoMap()
        {
            ToTable("VagaEmprego");

            HasKey(x => x.Id);

            HasRequired(x => x.Empresa);
            HasRequired(x => x.AreaProfissional);
            HasRequired(x => x.TipoContratacao);

            Property(x => x.Cargo.nome)
                .HasColumnName("Cargo")
                .HasMaxLength(60)
                .IsRequired();

            Property(x => x.Descricao.Conteudo)
                .HasColumnName("Descricao")
                .HasColumnType("text")
                .IsRequired();

            Property(x => x.Beneficios.Conteudo)
                .HasColumnName("Beneficios")
                .HasColumnType("text");

            Property(x => x.HorarioTrabalho.descricao)
                .HasColumnName("HorarioTrabalho")
                .HasMaxLength(100);

            Property(x => x.DataCriacao)
                .HasColumnName("DataCriacao")
                .IsRequired();

            Property(x => x.DataExpiracao)
                .HasColumnName("DataExpiracao")
                .IsRequired();

            Property(x => x.SalarioAcombinar)
                .HasColumnName("SalarioAcombinar")
                .IsRequired();

            Property(x => x.Salario.Valor)
                .HasColumnName("Salario");                

            Property(x => x.Status)
                .HasColumnName("Status")
                .IsRequired();

        }
    }
}
