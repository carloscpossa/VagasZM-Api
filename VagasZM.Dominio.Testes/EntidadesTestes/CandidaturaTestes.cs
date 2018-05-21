using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using VagasZM.Dominio.Entidades;
using VagasZM.Dominio.ObjetosDeValor;

namespace VagasZM.Dominio.Testes.EntidadesTestes
{
    [TestClass]
    public class CandidaturaTestes
    {
        private VagaEmprego vagaEmprego;
        private Candidato candidato;
        private NumeroPositivo pretensaoSalarial;
        private Texto observacoes;

        [TestInitialize]
        public void Inicializar()
        {
            var empresa = new Empresa(new Nome("Empresa LTDA"), new Texto("Empresa"), new Nome("Belo Horizonte"), "", new Site("www.empresa.io"));
            var areaProfissional = new AreaProfissional(new Nome("Informática"));
            vagaEmprego = new VagaEmprego(empresa, new Nome("Programador"), new Texto("Programar em .NET com C#"), new Texto("Vale Refeição"), areaProfissional, new Descricao("De 08 às 17:40 todos os dias de semana"), new DateTime(2118, 01, 20), false, new NumeroPositivo(4000), new TipoContratacao(new Nome("CLT")));
            candidato = new Candidato(new Email("jose_silva@outlook.com"), new Nome("José Silva"), new Telefone("3134231829"), new CPF("16654614038"), "!1234", "!1234");
            pretensaoSalarial = new NumeroPositivo(8000);
            observacoes = new Texto("Disponibilidade imediata");
        }


        [TestMethod]
        [TestCategory("Candidatura - Nova Candidatura")]
        public void DadaUmaVagaDeEmpregoNulaOConstrutorDeveCriarUmaCandidaturaInvalida()
        {
            Candidatura candidatura = new Candidatura(null, candidato, pretensaoSalarial, observacoes);
            Assert.IsFalse(candidatura.IsValid());
        }

        [TestMethod]
        [TestCategory("Candidatura - Nova Candidatura")]
        public void DadoUmCandidatoNuloOConstrutorDeveCriarUmaCandidaturaInvalida()
        {
            Candidatura candidatura = new Candidatura(vagaEmprego, null, pretensaoSalarial, observacoes);
            Assert.IsFalse(candidatura.IsValid());
        }

        [TestMethod]
        [TestCategory("Candidatura - Nova Candidatura")]
        public void DadaUmaPretensaoSalarialNegativaOConstrutorDeveCriarUmaCandidaturaInvalida()
        {
            Candidatura candidatura = new Candidatura(vagaEmprego, candidato, new NumeroPositivo(-1000), observacoes);
            Assert.IsFalse(candidatura.IsValid());
        }

        [TestMethod]
        [TestCategory("Candidatura - Nova Candidatura")]
        public void DadasTodasInformacoesCorretasConstrutorDeveCriarUmaCandidaturaValida()
        {
            Candidatura candidatura = new Candidatura(vagaEmprego, candidato, pretensaoSalarial, observacoes);
            Assert.IsTrue(candidatura.IsValid());

            Assert.AreEqual(vagaEmprego, candidatura.Vaga);
            Assert.AreEqual(candidato, candidatura.Candidato);
            Assert.AreEqual(DateTime.Today, candidatura.DataCandidatura.Date);
            Assert.AreEqual(pretensaoSalarial, candidatura.PretensaoSalarial);
            Assert.AreEqual(observacoes, candidatura.Observacao);
        }
    }
}
