using System.Data.Entity.ModelConfiguration;
using VagasZM.Dominio.Entidades;

namespace VagasZM.Infra.Dados.Mapeamento
{
    public class CandidatoMap : EntityTypeConfiguration<Candidato>
    {
        public CandidatoMap()
        {
            ToTable("Candidato");

            HasKey(x => x.Id);

            Property(x => x.Email.EnderecoEmail)
                .HasColumnName("Email")
                .HasMaxLength(50)
                .IsRequired();

            Property(x => x.Nome.nome)
                .HasColumnName("Nome")
                .HasMaxLength(60)
                .IsRequired();

            Property(x => x.Telefone.Numero)
                .HasColumnName("Telefone")
                .HasMaxLength(12);

            Property(x => x.CPF.Numero)
                .HasColumnName("CPF")
                .HasMaxLength(11)
                .IsFixedLength();

            Property(x => x.Senha)
                .HasColumnName("Senha")
                .HasMaxLength(32)
                .IsRequired()
                .IsFixedLength();

            Property(x => x.Endereco.Logradouro)
                .HasColumnName("Logradouro")
                .HasMaxLength(60)
                .IsOptional();

            Property(x => x.Endereco.Numero)
                .HasColumnName("Numero")
                .HasMaxLength(60)
                .IsOptional();

            Property(x => x.Endereco.Bairro)
                .HasColumnName("Bairro")
                .HasMaxLength(60)
                .IsOptional();

            Property(x => x.Endereco.Cidade)
                .HasColumnName("Cidade")
                .HasMaxLength(60)
                .IsOptional();

            Property(x => x.Endereco.Complemento)
                .HasColumnName("Complemento")
                .HasMaxLength(60)
                .IsOptional();

            Property(x => x.Endereco.Uf)
                .HasColumnName("Uf")
                .IsOptional();            

            HasMany(x => x.ExperienciaProfissional);
            HasMany(x => x.FormacaoEscolar);
        }
    }
}
