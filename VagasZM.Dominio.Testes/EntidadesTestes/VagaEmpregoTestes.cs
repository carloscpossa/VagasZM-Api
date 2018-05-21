using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using VagasZM.Dominio.Entidades;
using VagasZM.Dominio.Enumeracoes;
using VagasZM.Dominio.ObjetosDeValor;

namespace VagasZM.Dominio.Testes.EntidadesTestes
{
    [TestClass]
    public class VagaEmpregoTestes
    {
        
        private Empresa empresa;
        private Nome cargo;
        private Texto descricaoVaga;
        private Texto beneficios;        
        private AreaProfissional areaProfissional;
        private Descricao horarioTrabalho;
        private DateTime dataExpiracao;
        private NumeroPositivo salario;
        private TipoContratacao tipoContratacao;

        [TestInitialize]
        public void Inicializar()
        {            
            empresa = new Empresa(new Nome("KURINGAS BAR"), new Texto("Bar localizado no centro cidade com serviço de delivery"), new Nome("Ressaquinha"), null, null);
            cargo = new Nome("Gerente Administrativo");
            descricaoVaga = new Texto("Vaga de gerente administrativo. Deve ter conhecimento em rotinas financeiras.");
            beneficios = new Texto("Vale refeição, vale transporte e PL");            
            areaProfissional = new AreaProfissional(new Nome("Administrativo/Financeiro"));
            horarioTrabalho = new Descricao("De segunda à sexta, das 8:00 às 17:50 hs com uma hora de almoço");
            dataExpiracao = DateTime.Today.AddDays(30);
            salario = new NumeroPositivo(989.77);
            tipoContratacao = new TipoContratacao(new Nome("CLT"));
        }
        

        [TestMethod]
        [TestCategory("VagaEmprego - Nova Vaga")]
        public void DadoUmaEmpresaNulaConstrutorDeveRetornarUmaVagaDeEmpregoInvalida()
        {
            VagaEmprego vaga = new VagaEmprego(null, cargo, descricaoVaga, beneficios, areaProfissional, horarioTrabalho, dataExpiracao, false, salario, tipoContratacao);
            Assert.IsFalse(vaga.IsValid());
        }

        [TestMethod]
        [TestCategory("VagaEmprego - Nova Vaga")]
        public void DadoUmCargoNuloConstrutorDeveRetornarUmaVagaDeEmpregoInvalida()
        {
            VagaEmprego vaga = new VagaEmprego(empresa, null, descricaoVaga, beneficios, areaProfissional, horarioTrabalho, dataExpiracao, false, salario, tipoContratacao);
            Assert.IsFalse(vaga.IsValid());
        }

        [TestMethod]
        [TestCategory("VagaEmprego - Nova Vaga")]
        public void DadaUmaDescricaoDaVagaNulaConstrutorDeveRetornarUmaVagaDeEmpregoInvalida()
        {
            VagaEmprego vaga = new VagaEmprego(empresa, cargo, null, beneficios, areaProfissional, horarioTrabalho, dataExpiracao, false, salario, tipoContratacao);
            Assert.IsFalse(vaga.IsValid());
        }

        [TestMethod]
        [TestCategory("VagaEmprego - Nova Vaga")]
        public void DadaUmaAreaProfissionalNulaConstrutorDeveRetornarUmaVagaDeEmpregoInvalida()
        {
            VagaEmprego vaga = new VagaEmprego(empresa, cargo, descricaoVaga, null, null, horarioTrabalho, dataExpiracao, false, salario, tipoContratacao);
            Assert.IsFalse(vaga.IsValid());
        }

        [TestMethod]
        [TestCategory("VagaEmprego - Nova Vaga")]
        public void DadoUmTipoDeContratacaoNuloConstrutorDeveRetornarUmaVagaDeEmpregoInvalida()
        {
            VagaEmprego vaga = new VagaEmprego(empresa, cargo, descricaoVaga, null, areaProfissional, horarioTrabalho, dataExpiracao, false, salario, null);
            Assert.IsFalse(vaga.IsValid());
        }

        [TestMethod]
        [TestCategory("VagaEmprego - Nova Vaga")]
        public void DadaUmaDataDeExpiracaoMenorQueADataDeCriacaoDaVagaConstrutorDeveRetornarUmaVagaDeEmpregoInvalida()
        {
            dataExpiracao = DateTime.Today.AddDays(-30);
            VagaEmprego vaga = new VagaEmprego(empresa, cargo, descricaoVaga, beneficios, areaProfissional, horarioTrabalho, dataExpiracao, false, salario, tipoContratacao);
            Assert.IsFalse(vaga.IsValid());
        }

        [TestMethod]
        [TestCategory("VagaEmprego - Nova Vaga")]
        public void SeOSalarioACombinarForFalsoEOValorDoSalarioForNuloOConstrutorDeveraCriarUmaVagaDeEmpregoInvalida()
        {
            VagaEmprego vaga = new VagaEmprego(empresa, cargo, descricaoVaga, beneficios, areaProfissional, horarioTrabalho, dataExpiracao, false, null, tipoContratacao);
            Assert.IsFalse(vaga.IsValid());
        }

        [TestMethod]
        [TestCategory("VagaEmprego - Nova Vaga")]
        public void SeOSalarioACombinarForVerdadeiroConstrutorDeveCriarUmaVagaDeEmpregoComOSalarioIgualAZero()
        {
            VagaEmprego vaga = new VagaEmprego(empresa, cargo, descricaoVaga, beneficios, areaProfissional, horarioTrabalho, dataExpiracao, true, salario, tipoContratacao);
            Assert.AreEqual(0, vaga.Salario.Valor);
        }

        [TestMethod]
        [TestCategory("VagaEmprego - Nova Vaga")]
        public void DadasTodasAsInformacoesValidasDaVagaDeEmpregoOConstrutorDeveCriarUmaVagaDeEmpregoAbertaValida()
        {
            VagaEmprego vaga = new VagaEmprego(empresa, cargo, descricaoVaga, beneficios, areaProfissional, horarioTrabalho, dataExpiracao, false, salario, tipoContratacao);
            Assert.IsTrue(vaga.IsValid());

            Assert.AreEqual(DateTime.Today, vaga.DataCriacao.Date);
            Assert.AreEqual(empresa, vaga.Empresa);
            Assert.AreEqual(cargo, vaga.Cargo);
            Assert.AreEqual(descricaoVaga, vaga.Descricao);
            Assert.AreEqual(beneficios, vaga.Beneficios);
            Assert.AreEqual(areaProfissional, vaga.AreaProfissional);
            Assert.AreEqual(horarioTrabalho, vaga.HorarioTrabalho);
            Assert.AreEqual(dataExpiracao, vaga.DataExpiracao);
            Assert.IsFalse(vaga.SalarioAcombinar);
            Assert.AreEqual(salario, vaga.Salario);
            Assert.AreEqual(tipoContratacao, vaga.TipoContratacao);
            Assert.AreEqual(StatusVaga.Aberta, vaga.Status);
        }

        [TestMethod]
        [TestCategory("VagaEmprego - Encerrar Vaga")]
        public void QuandoUmaVagaForEncerradaSeuStatusDeveraSerTrocadoEncerrada()
        {
            VagaEmprego vaga = new VagaEmprego(empresa, cargo, descricaoVaga, beneficios, areaProfissional, horarioTrabalho, dataExpiracao, false, salario, tipoContratacao);
            vaga.Encerrar();
            Assert.AreEqual(StatusVaga.Encerrada, vaga.Status);
        }
    }
}
