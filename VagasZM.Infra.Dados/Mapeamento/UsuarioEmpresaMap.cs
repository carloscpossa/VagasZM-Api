using System.Data.Entity.ModelConfiguration;
using VagasZM.Dominio.Entidades;

namespace VagasZM.Infra.Dados.Mapeamento
{
    public class UsuarioEmpresaMap : EntityTypeConfiguration<UsuarioEmpresa>
    {
        public UsuarioEmpresaMap()
        {
            ToTable("UsuarioEmpresa");

            HasKey(x => x.Id);

            Property(x => x.Nome.nome)
                .HasColumnName("Nome")
                .HasMaxLength(60)
                .IsRequired();

            Property(x => x.Email.EnderecoEmail)
                .HasColumnName("Email")
                .HasMaxLength(50)
                .IsRequired();

            Property(x => x.Senha)
                .HasColumnName("Senha")
                .HasMaxLength(32)
                .IsFixedLength()
                .IsRequired();

            HasRequired(x => x.Empresa);
        }
    }
}
