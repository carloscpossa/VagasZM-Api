namespace VagasZM.Infra.Dados.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VersaoInicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AreaProfissional",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Nome = c.String(nullable: false, maxLength: 60),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Candidato",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Email = c.String(nullable: false, maxLength: 50),
                        Nome = c.String(nullable: false, maxLength: 60),
                        Telefone = c.String(maxLength: 12),
                        CPF = c.String(maxLength: 11, fixedLength: true),
                        Senha = c.String(nullable: false, maxLength: 32, fixedLength: true),
                        Logradouro = c.String(maxLength: 60),
                        Numero = c.String(maxLength: 60),
                        Complemento = c.String(maxLength: 60),
                        Bairro = c.String(maxLength: 60),
                        Cidade = c.String(maxLength: 60),
                        Uf = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ExperienciaProfissional",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        DataInicio = c.DateTime(nullable: false),
                        DataTermino = c.DateTime(),
                        Empresa = c.String(nullable: false, maxLength: 60),
                        Cargo = c.String(nullable: false, maxLength: 60),
                        AtividadeExercida = c.String(nullable: false, unicode: false, storeType: "text"),
                        Area_Id = c.Guid(nullable: false),
                        Candidato_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AreaProfissional", t => t.Area_Id, cascadeDelete: true)
                .ForeignKey("dbo.Candidato", t => t.Candidato_Id)
                .Index(t => t.Area_Id)
                .Index(t => t.Candidato_Id);
            
            CreateTable(
                "dbo.FormacaoEscolar",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        DataInicio = c.DateTime(nullable: false),
                        DataTermino = c.DateTime(),
                        Instituicao = c.String(nullable: false, maxLength: 60),
                        Curso = c.String(nullable: false, maxLength: 60),
                        NivelFormacao = c.Int(nullable: false),
                        Candidato_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Candidato", t => t.Candidato_Id)
                .Index(t => t.Candidato_Id);
            
            CreateTable(
                "dbo.Candidatura",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        DataCandidatura = c.DateTime(nullable: false),
                        PretensaoSalarialInicial = c.Double(nullable: false),
                        PretensaoSalarialFinal = c.Double(nullable: false),
                        Candidato_Id = c.Guid(nullable: false),
                        Vaga_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Candidato", t => t.Candidato_Id, cascadeDelete: true)
                .ForeignKey("dbo.VagaEmprego", t => t.Vaga_Id, cascadeDelete: true)
                .Index(t => t.Candidato_Id)
                .Index(t => t.Vaga_Id);
            
            CreateTable(
                "dbo.VagaEmprego",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Cargo = c.String(nullable: false, maxLength: 60),
                        Descricao = c.String(nullable: false, unicode: false, storeType: "text"),
                        Beneficios = c.String(nullable: false, unicode: false, storeType: "text"),
                        HorarioTrabalho = c.String(maxLength: 100),
                        DataCriacao = c.DateTime(nullable: false),
                        DataExpiracao = c.DateTime(nullable: false),
                        SalarioAcombinar = c.Boolean(nullable: false),
                        Salario = c.Double(nullable: false),
                        AreaProfissional_Id = c.Guid(nullable: false),
                        Empresa_Id = c.Guid(nullable: false),
                        TipoContratacao_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AreaProfissional", t => t.AreaProfissional_Id, cascadeDelete: true)
                .ForeignKey("dbo.Empresa", t => t.Empresa_Id, cascadeDelete: true)
                .ForeignKey("dbo.TipoContratacao", t => t.TipoContratacao_Id, cascadeDelete: true)
                .Index(t => t.AreaProfissional_Id)
                .Index(t => t.Empresa_Id)
                .Index(t => t.TipoContratacao_Id);
            
            CreateTable(
                "dbo.Empresa",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Nome = c.String(nullable: false, maxLength: 60),
                        Descricao = c.String(nullable: false, unicode: false, storeType: "text"),
                        Cidade = c.String(nullable: false, maxLength: 60),
                        Logo = c.String(maxLength: 200),
                        Site = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TipoContratacao",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Nome = c.String(nullable: false, maxLength: 60),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UsuarioEmpresa",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Nome = c.String(nullable: false, maxLength: 60),
                        Email = c.String(nullable: false, maxLength: 50),
                        Senha = c.String(nullable: false, maxLength: 32, fixedLength: true),
                        Empresa_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Empresa", t => t.Empresa_Id, cascadeDelete: true)
                .Index(t => t.Empresa_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UsuarioEmpresa", "Empresa_Id", "dbo.Empresa");
            DropForeignKey("dbo.Candidatura", "Vaga_Id", "dbo.VagaEmprego");
            DropForeignKey("dbo.VagaEmprego", "TipoContratacao_Id", "dbo.TipoContratacao");
            DropForeignKey("dbo.VagaEmprego", "Empresa_Id", "dbo.Empresa");
            DropForeignKey("dbo.VagaEmprego", "AreaProfissional_Id", "dbo.AreaProfissional");
            DropForeignKey("dbo.Candidatura", "Candidato_Id", "dbo.Candidato");
            DropForeignKey("dbo.FormacaoEscolar", "Candidato_Id", "dbo.Candidato");
            DropForeignKey("dbo.ExperienciaProfissional", "Candidato_Id", "dbo.Candidato");
            DropForeignKey("dbo.ExperienciaProfissional", "Area_Id", "dbo.AreaProfissional");
            DropIndex("dbo.UsuarioEmpresa", new[] { "Empresa_Id" });
            DropIndex("dbo.VagaEmprego", new[] { "TipoContratacao_Id" });
            DropIndex("dbo.VagaEmprego", new[] { "Empresa_Id" });
            DropIndex("dbo.VagaEmprego", new[] { "AreaProfissional_Id" });
            DropIndex("dbo.Candidatura", new[] { "Vaga_Id" });
            DropIndex("dbo.Candidatura", new[] { "Candidato_Id" });
            DropIndex("dbo.FormacaoEscolar", new[] { "Candidato_Id" });
            DropIndex("dbo.ExperienciaProfissional", new[] { "Candidato_Id" });
            DropIndex("dbo.ExperienciaProfissional", new[] { "Area_Id" });
            DropTable("dbo.UsuarioEmpresa");
            DropTable("dbo.TipoContratacao");
            DropTable("dbo.Empresa");
            DropTable("dbo.VagaEmprego");
            DropTable("dbo.Candidatura");
            DropTable("dbo.FormacaoEscolar");
            DropTable("dbo.ExperienciaProfissional");
            DropTable("dbo.Candidato");
            DropTable("dbo.AreaProfissional");
        }
    }
}
