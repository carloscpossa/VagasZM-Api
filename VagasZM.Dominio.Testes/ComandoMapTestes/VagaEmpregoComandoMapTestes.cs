using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using VagasZM.Dominio.Comandos.VagaEmpregoComandos.Entradas;
using VagasZM.Dominio.Comandos.VagaEmpregoComandos.Mapeamento;
using VagasZM.Dominio.Entidades;
using VagasZM.Dominio.ObjetosDeValor;

namespace VagasZM.Dominio.Testes.ComandoMapTestes
{
    [TestClass]
    public class VagaEmpregoComandoMapTestes
    {
        private Empresa empresaValida;
        private AreaProfissional areaProfissionalValida;
        private TipoContratacao tipoContratacaoValida;
        private InserirVagaEmpregoComando comandoValido;

        public VagaEmpregoComandoMapTestes()
        {
            empresaValida = new Empresa(new Nome("Empresa Teste LTDA"), new Texto("Empresa de teste"), new Nome("Ressaquinha"), "", new Site("www.empresateste.com.br"));
            areaProfissionalValida = new AreaProfissional(new Nome("Informática"));
            tipoContratacaoValida = new TipoContratacao(new Nome("CLT"));

            comandoValido = new InserirVagaEmpregoComando
            {
                AreaProfissionalId = Guid.Parse("6360523F-F3F8-4384-A51F-0280E98E9D08"),
                Cargo = "Analista de Sistemas",
                Beneficios = "Vale transporte, plano de saúde, vale refeição",
                Descricao = "Obrigatório conhecimento de Programação Orientada a Objetos, .NET Framework, .NET Core, EF, Dapper, SQL Server, NoSql (MongoDb ou RavenDb)",
                EmpresaId = Guid.Parse("640dbf6f-bfcb-4290-a059-c71152d479f3"),
                HorarioTrabalho = "Horário flexível",
                Salario = 6000,
                SalarioAcombinar = false,
                TipoContratacaoId = Guid.Parse("8D6B1678-5059-42EB-A8C5-F071E88A70C9")
            };
        }

        [TestMethod]
        [TestCategory("VagaEmpregoComandoMapTestes - CriarVagaEmprego")]
        public void SeInserirVagaEmpregoComandoForNuloCriarVagaEmpregoDeveRetornarNulo()
        {
            Assert.IsNull(new VagaEmpregoComandoMap().CriarVagaEmprego(null, empresaValida, areaProfissionalValida, tipoContratacaoValida));
        }

        [TestMethod]
        [TestCategory("VagaEmpregoComandoMapTestes - CriarVagaEmprego")]
        public void DadoUmInserirVagaEmpregoComandoCriarVagaEmpregoDeveRetornarVagaEmpregoComOsMesmosDadosDoComando()
        {

            var vagaEmprego = new VagaEmpregoComandoMap().CriarVagaEmprego(comandoValido, empresaValida, areaProfissionalValida, tipoContratacaoValida);            

            Assert.AreEqual(empresaValida, vagaEmprego.Empresa);
            Assert.AreEqual(areaProfissionalValida, vagaEmprego.AreaProfissional);
            Assert.AreEqual(tipoContratacaoValida, vagaEmprego.TipoContratacao);
            Assert.AreEqual(comandoValido.Cargo, vagaEmprego.Cargo.nome);
            Assert.AreEqual(comandoValido.Descricao, vagaEmprego.Descricao.Conteudo);
            Assert.AreEqual(comandoValido.Beneficios, vagaEmprego.Beneficios.Conteudo);
            Assert.AreEqual(comandoValido.HorarioTrabalho, vagaEmprego.HorarioTrabalho.descricao);
            Assert.AreEqual(comandoValido.SalarioAcombinar, vagaEmprego.SalarioAcombinar);
            Assert.AreEqual(comandoValido.Salario, vagaEmprego.Salario.Valor);
        }
    }
}
