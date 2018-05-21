using System.Data.Entity.ModelConfiguration;
using VagasZM.Dominio.Entidades;

namespace VagasZM.Infra.Dados.Mapeamento
{
    public class EmpresaMap : EntityTypeConfiguration<Empresa>
    {
        public EmpresaMap()
        {
            ToTable("Empresa");

            HasKey(x => x.Id);

            Property(x => x.NomeEmpresa.nome)
                .HasColumnName("Nome")
                .HasMaxLength(60)
                .IsRequired();

            Property(x => x.DescricaoEmpresa.Conteudo)
                .HasColumnName("Descricao")
                .HasColumnType("text");

            Property(x => x.Cidade.nome)
                .HasColumnName("Cidade")
                .HasMaxLength(60)
                .IsRequired();

            Property(x => x.Logo)
                .HasColumnName("Logo")
                .HasMaxLength(200);

            Property(x => x.Site.URL)
                .HasColumnName("Site")
                .HasMaxLength(50);
        }
    }
}
