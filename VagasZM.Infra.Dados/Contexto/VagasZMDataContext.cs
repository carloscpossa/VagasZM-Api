using System.Data.Entity;
using VagasZM.Compartilhado;
using VagasZM.Dominio.Entidades;
using VagasZM.Infra.Dados.Mapeamento;

namespace VagasZM.Infra.Dados.Contexto
{
    public class VagasZMDataContext : DbContext
    {
        public VagasZMDataContext() : base(Runtime.StringDeConexao)
        {
            var ensureDLLIsCopied = System.Data.Entity.SqlServer.SqlProviderServices.Instance;

            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AreaProfissionalMap());
            modelBuilder.Configurations.Add(new EmpresaMap());
            modelBuilder.Configurations.Add(new ExperienciaProfissionalMap());
            modelBuilder.Configurations.Add(new FormacaoEscolarMap());
            modelBuilder.Configurations.Add(new TipoContratacaoMap());
            modelBuilder.Configurations.Add(new UsuarioEmpresaMap());
            modelBuilder.Configurations.Add(new CandidatoMap());
            modelBuilder.Configurations.Add(new CandidaturaMap());
            modelBuilder.Configurations.Add(new VagaEmpregoMap());
        }

        public DbSet<AreaProfissional> AreaProfissional { get; set; }
        public DbSet<Empresa> Empresa { get; set; }
        public DbSet<ExperienciaProfissional> ExperienciaProfissional { get; set; }
        public DbSet<FormacaoEscolar> FormacaoEscolar { get; set; }
        public DbSet<TipoContratacao> TipoContratacao { get; set; }
        public DbSet<UsuarioEmpresa> UsuarioEmpresa { get; set; }
        public DbSet<Candidato> Candidato { get; set; }
        public DbSet<Candidatura> Candidatura { get; set; }
        public DbSet<VagaEmprego> VagaEmprego { get; set; }
    }
}
