using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using VagasZM.Dominio.Entidades;
using VagasZM.Dominio.Enumeracoes;
using VagasZM.Dominio.ObjetosDeValor;

namespace VagasZM.Dominio.Testes.EntidadesTestes
{
    [TestClass]
    public class FormacaoEscolarTestes
    {
        [TestCategory("FormacaoEscolar - Nova Formacao do Candidadto")]
        [TestMethod]
        public void DadoUmNomeDeInstituicaoNuloOConstrutorDeveCriarUmaFormacaoDoCandidatoInvalida()
        {
            FormacaoEscolar formacao = new FormacaoEscolar(new DateTime(2001, 02, 01), new DateTime(2004, 11, 30), null, new Nome("Administração de Empresas"), NivelFormacao.GraduacaoCompleta);
            Assert.IsFalse(formacao.IsValid());
        }

        [TestCategory("FormacaoEscolar - Nova Formacao do Candidadto")]
        [TestMethod]
        public void DadoUmNomeDeCursoNuloOConstrutorDeveCriarUmaFormacaoDoCandidatoInvalida()
        {
            FormacaoEscolar formacao = new FormacaoEscolar(new DateTime(2001, 02, 01), new DateTime(2004, 11, 30), new Nome("PUC Minas"), null, NivelFormacao.GraduacaoIncompleta);
            Assert.IsFalse(formacao.IsValid());
        }

        [TestCategory("FormacaoEscolar - Nova Formacao do Candidadto")]
        [TestMethod]
        public void DadaUmaDataDeTerminoMenorOuIgualADataDeInicioDaFormacaoOConstrutorDeveCriarUmaFormacaoInvalida()
        {
            FormacaoEscolar formacao = new FormacaoEscolar(new DateTime(2001, 02, 01), new DateTime(2001, 1, 25), new Nome("PUC Minas"), new Nome("Administração de Empresas"), NivelFormacao.GraduacaoIncompleta);
            Assert.IsFalse(formacao.IsValid());
        }

        [TestCategory("FormacaoEscolar - Nova Formacao do Candidadto")]
        [TestMethod]
        public void DadasTodasAsInformacoesValidasDaFormacaoOConstrutorDeveCriarUmaFormacaoDoCandidatoValida()
        {
            DateTime dataInicio = new DateTime(2001, 02, 01);
            DateTime dataTermino = new DateTime(2004, 12, 01);
            Nome instituicao = new Nome("PUC Minas");
            Nome curso = new Nome("Desenvolvimento de Aplicações Web");

            FormacaoEscolar formacao = new FormacaoEscolar(dataInicio, dataTermino, instituicao, curso, NivelFormacao.Especializacao);
            Assert.IsTrue(formacao.IsValid());

            Assert.AreEqual(dataInicio, formacao.DataInicio);
            Assert.AreEqual(dataTermino, formacao.DataTermino);
            Assert.AreEqual(instituicao, formacao.Instituicao);
            Assert.AreEqual(curso, formacao.Curso);
            Assert.AreEqual(NivelFormacao.Especializacao, formacao.NivelFormacao);
        }
    }
}
